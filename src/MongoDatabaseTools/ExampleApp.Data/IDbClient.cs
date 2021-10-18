
namespace ExampleApp.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MongoDB.Bson;
    using Models;

    /// <summary>
    /// Class for MongoDB access.
    /// </summary>
    public interface IDbClient
    {
        /// <summary>
        /// Method to read and print collection length.
        /// </summary>
        /// <param name="collectionName">Target collection name.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task PrintCollectionLength(string collectionName);

        /// <summary>
        /// Method to insert Universal model to database.
        /// </summary>
        /// <param name="document">Document of type <see cref="UniversalModel{TKey}"/>.</param>
        /// <param name="collectionName"></param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task InsertDocument(UniversalModel<ObjectId> document, string collectionName);

        /// <summary>
        /// Method to drop database.
        /// </summary>
        /// <returns><see cref="Task"/>.</returns>
        void DropDatabase();

        /// <summary>
        /// Method to get IDs of documents by from given collection.
        /// </summary>
        /// <param name="collectionName">Name of the collection.</param>
        /// <returns></returns>
        Task<IList<UniversalModel<ObjectId>>> GetIds(string collectionName);
    }
}