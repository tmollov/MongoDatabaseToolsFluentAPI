using FluentApi.Common;

namespace ExampleApp.Data
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MongoDB.Bson;
    using Models;
    using MongoDB.Driver;

    /// <inheritdoc />
    public class DbClient : IDbClient
    {
        private readonly MongoClient _client;
        private readonly IMongoDatabase _database;
        private readonly string _databaseName;

        /// <summary>
        /// Initializes a new instance of the <see cref="DbClient"/> class.
        /// </summary>
        /// <param name="databaseName">Name of database to get from MongoDB server.</param>
        /// <param name="connectionString">Connection string to connect with MongoDB server.</param>
        public DbClient(string connectionString, string databaseName)
        {
            this._databaseName = databaseName;
            this._client = new MongoClient(connectionString);
            this._database = this._client.GetDatabase(databaseName);
        }

        public async Task<IList<UniversalModel<ObjectId>>> GetIds(string collectionName)
        {
            Console.WriteLine("Getting Document IDs");
            var list = await this._database
                .GetCollection<UniversalModel<ObjectId>>(collectionName)
                .Find(x => x.Id != null)
                .ToListAsync();
            Console.WriteLine("IDs acquired.");
            return list;
        }

        /// <inheritdoc />
        public async Task PrintCollectionLength(string collectionName)
        {
            Console.WriteLine(AppConstants.CountElementsIn(collectionName));
            var list = await this._database
                .GetCollection<UniversalModel<ObjectId>>(collectionName)
                .Find(x => x.Id != null)
                .ToListAsync();
            Console.WriteLine(AppConstants.ElementsInCollection(list.Count));
        }

        /// <inheritdoc />
        public async Task InsertDocument(UniversalModel<ObjectId> document, string collectionName) =>
            await this._database
                .GetCollection<UniversalModel<ObjectId>>(collectionName)
                .InsertOneAsync(document);

        public void DropDatabase()
        {
            Console.WriteLine("Dropping database: " + this._databaseName);
            this._client.DropDatabase(this._databaseName);
            Console.WriteLine("Dropped database " + this._databaseName);
        }
    }
}