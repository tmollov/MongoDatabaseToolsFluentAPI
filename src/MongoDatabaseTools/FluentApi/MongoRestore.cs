using FluentApi.Common;
using FluentApi.Common.Enums;
using FluentApi.Interfaces.Options;

namespace FluentApi
{
    using System;
    using System.Threading.Tasks;
    using CliWrap;
    using CliWrap.EventStream;
    using FluentApi.Interfaces;
    using static ProcessConstants;

    /// <inheritdoc cref="IMongoRestore" />
    public class MongoRestore : MongoUtility, IMixedOptions, IMongoRestore
    {
        /// <inheritdoc />
        public MongoRestore WithObjectsValidation()
        {
            this.AddArgument(OptionConstants.ObjectValidation, string.Empty);
            return this;
        }

        /// <inheritdoc />
        public MongoRestore WithOplogReplay()
        {
            this.AddArgument(OptionConstants.OplogReplay, string.Empty);
            return this;
        }

        /// <inheritdoc />
        public MongoRestore WithOplogFile(string filename)
        {
            this.AddArgument(OptionConstants.OplogFile, filename);
            return this;
        }

        /// <inheritdoc />
        public MongoRestore FromDirectory(string dirName)
        {
            this.AddArgument(OptionConstants.InputDirectory, dirName);
            return this;
        }

        /// <inheritdoc />
        public MongoRestore DropEachBeforeImport()
        {
            this.AddArgument(OptionConstants.Drop, string.Empty);
            return this;
        }

        /// <inheritdoc />
        public MongoRestore RunDry()
        {
            this.AddArgument(OptionConstants.DryRun, string.Empty);
            return this;
        }


        /// <inheritdoc />
        public MongoRestore WithoutIndexes()
        {
            this.AddArgument(OptionConstants.NoIndexRestore, string.Empty);
            return this;
        }

        /// <inheritdoc />
        public MongoRestore WithoutCollectionOptions()
        {
            this.AddArgument(OptionConstants.NoOptions, string.Empty);
            return this;
        }

        /// <inheritdoc />
        public MongoRestore KeepIndexVersion()
        {
            this.AddArgument(OptionConstants.KeepIndexVersion, string.Empty);
            return this;
        }

        /// <inheritdoc />
        public MongoRestore MaintainInsertionOrder()
        {
            this.AddArgument(OptionConstants.MaintainInsertionOrder, string.Empty);
            return this;
        }

        /// <inheritdoc />
        public MongoRestore StopOnError()
        {
            this.AddArgument(OptionConstants.StopOnError, string.Empty);
            return this;
        }

        /// <inheritdoc />
        public MongoRestore BypassDocumentValidation()
        {
            this.AddArgument(OptionConstants.BypassDocumentValidation, string.Empty);
            return this;
        }

        /// <inheritdoc />
        public IMongoUtility Database(string databaseName)
        {
            this.AddArgument(OptionConstants.Database, databaseName);
            return this;
        }

        /// <inheritdoc />
        public IMongoUtility Collection(string collectionName)
        {
            this.AddArgument(OptionConstants.Collection, collectionName);
            return this;
        }

        /// <inheritdoc />
        public IMongoUtility ToGzip()
        {
            this.AddArgument(OptionConstants.Gzip, string.Empty);
            return this;
        }

        /// <inheritdoc />
        public IMongoUtility Archive(string outputPath)
        {
            this.AddArgument(OptionConstants.Archive, outputPath);
            return this;
        }

        /// <inheritdoc />
        public override async Task Run(bool informationLog = true, bool errorLog = true, bool processLog = false)
        {
            Console.WriteLine(AppConstants.StartingMongoRestore);

            var result = Cli.Wrap(MongoTools(Utility.MongoRestore))
                .WithArguments(this.GetArguments())
                .WithValidation(CommandResultValidation.None);

            await foreach (var cmdEvent in result.ListenAsync())
            {
                this.LogToConsole(cmdEvent, informationLog, errorLog, processLog);
            }
        }
    }
}