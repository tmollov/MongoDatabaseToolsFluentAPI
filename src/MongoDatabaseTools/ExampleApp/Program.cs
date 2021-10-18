namespace ExampleApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CliWrap;
    using CliWrap.EventStream;
    using ExampleApp.Data;
    using ExampleApp.Data.Models;
    using FluentApi;
    using MongoDB.Bson;

    /// <summary>
    /// Class containing Main method.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Starting point of ExampleApp project.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <param name="backupAndGet">Calls BackupAndGet method.</param>
        /// <param name="backupAndPut">Calls BackupAndPut method.</param>
        /// <param name="oplogAndGet">Calls OplogAndGet method.</param>
        /// <param name="oplogAndPut">Calls OplogAndPut method.</param>
        /// <param name="oplogReplay">Calls OplogReplay method.</param>
        public static async Task Main(
            bool backupAndGet,
            bool backupAndPut,
            bool oplogAndGet,
            bool oplogAndPut,
            bool oplogReplay,
            bool advanced)
        {
            if (backupAndGet)
                await BackupAndGet();
            else if (backupAndPut)
                await BackupAndPut();
            else if (oplogAndGet)
                await OplogAndGet();
            else if (oplogAndPut)
                await OplogAndPut();
            else if (oplogReplay)
                await OplogReplay();
            else if (advanced)
                await AdvancedTestWithOplog();

            await MongoUtilities
                .BsonDump
                .OfType(FluentApi.Common.Enums.BsonType.JSON)
                .PrettierJSON()
                .ValidateBSON()
                .ToOutputFile("test.json")
                .Run();

            if (!backupAndGet &&
                !backupAndPut &&
                !oplogAndGet &&
                !oplogAndPut &&
                !oplogReplay &&
                !advanced)
            {
                Console.WriteLine("Re-run app with valid options. For more run `dotnet run -- --help`");
            }
        }

        /// <summary>
        /// Method that runs advanced test with oplog and oplogReplay options of mongodump / mongorestore
        /// </summary>
        public static async Task AdvancedTestWithOplog()
        {
            // 1) Drop database
            var db = GetDbClient();
            db.DropDatabase();
            // 2) Generate 1m. documents
            SeedData("mgodatagen", "-f database_config.json")
                .GetAwaiter().GetResult();

            // 3) Start Backup / Run Generate 10k documents in parallel
            // NOTE: Make sure dump folder is deleted!!!
            var tasks = new List<Task>();
            var mongoUtil = MongoUtilities
                .MongoDump
                .WithOplog()
                .Run();
            tasks.Add(mongoUtil);

            // Using mgodatagen for fast document generating.
            tasks.Add(PutElements(db, "test", 1000, false));

            await Task.WhenAll(tasks);

            var elementIDs = await db.GetIds("test");
            Console.WriteLine("Document count: " + elementIDs.Count);
            db.DropDatabase();

            MongoUtilities
                .MongoRestore
                .WithOplogReplay()
                .Run()
                .GetAwaiter()
                .GetResult();
            var result = db.GetIds("test").GetAwaiter().GetResult();

            Console.WriteLine("Document count after RESTORE: " + result.Count);
        }

        /// <summary>
        /// Method to see is database / collection is in read-only mode while backup process is running.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public static async Task BackupAndGet()
        {
            var dbClient = GetDbClient();
            Console.WriteLine(AppConstants.StartingCounting);
            Parallel.Invoke(
                () => dbClient.PrintCollectionLength("test"));
            await MongoUtilities
                .MongoDump
                .WithOplog()
                .Run();
        }

        /// <summary>
        /// Method to see what happens when documents are inserted into a collection after a backup is initiated.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public static async Task BackupAndPut()
        {
            var dbClient = GetDbClient();
            await dbClient.PrintCollectionLength("test");
            await MongoUtilities
                .MongoDump
                .WithOplog()
                .Run();
            await PutElements(dbClient, AppConstants.TestDatabase);
            await dbClient.PrintCollectionLength(AppConstants.TestDatabase);
        }

        /// <summary>
        /// Method to see what happens when getting data while Point-in-Time backup process is running.
        /// </summary>
        public static async Task OplogAndGet()
        {
            var dbClient = GetDbClient();
            await dbClient.PrintCollectionLength(AppConstants.TestDatabase);

            await MongoUtilities
                .MongoDump
                .WithOplog()
                .Run();

            Console.WriteLine(AppConstants.StartingCounting);
            await dbClient.PrintCollectionLength(AppConstants.TestDatabase);
        }

        /// <summary>
        /// Method to see what happens when putting data while Point-in-Time backup process is running.
        /// </summary>
        public static async Task OplogAndPut()
        {
            Console.WriteLine("Testing mongodump --oplog with parallel document importing...");

            var dbClient = GetDbClient();
            Console.WriteLine(AppConstants.StartingCounting);
            await dbClient.PrintCollectionLength("test");
            Parallel.Invoke(() => PutElements(dbClient, "test"));

            await MongoUtilities
                .MongoDump
                .WithOplog()
                .Run();

            await dbClient.PrintCollectionLength("test");
        }

        /// <summary>
        /// Method to see what happens when getting data while restore process is running.
        /// </summary>
        public static async Task OplogReplay()
        {
            // Run Backup, Put data while it is running
            await OplogAndPut();

            // Drop Database
            GetDbClient().DropDatabase();
            await GetDbClient().PrintCollectionLength("test");
            // Restore to see if it really backed up everything
            await MongoUtilities
                .MongoRestore
                .WithOplogReplay()
                .Run();

            await GetDbClient().PrintCollectionLength("test");
        }

        private static async Task SeedData(string processNameAndDirectory, string arguments, bool showLog = true)
        {
            var result = Cli.Wrap(processNameAndDirectory)
                .WithArguments(arguments)
                .WithValidation(CommandResultValidation.None);

            await foreach (var cmdEvent in result.ListenAsync())
            {
                if (showLog)
                {
                    switch (cmdEvent)
                    {
                        case StandardOutputCommandEvent stdOut:
                            Console.WriteLine(stdOut.Text);
                            break;
                        case StandardErrorCommandEvent stdErr:
                            Console.WriteLine(stdErr.Text);
                            break;
                    }
                }
            }
        }

        private static IDbClient GetDbClient(string databaseName = "test")
        {
            var dbClient = new DbClient(
                DbConfigurationConstants.GetConnectionString,
                databaseName);
            return dbClient;
        }

        private static async Task PutElements(IDbClient dbClient, string targetCollectionName, int elementCount = 1000,
            bool showIdLog = false)
        {
            Console.WriteLine(AppConstants.ImportingElements(elementCount));
            for (var i = 0; i < elementCount; i++)
            {
                var newDoc = new UniversalModel<ObjectId>();
                await dbClient.InsertDocument(newDoc, targetCollectionName);
                if (showIdLog)
                {
                    Console.WriteLine($"{i} - {newDoc.Id}");
                }
            }

            Console.WriteLine(AppConstants.DoneImportingElements);
        }
    }
}