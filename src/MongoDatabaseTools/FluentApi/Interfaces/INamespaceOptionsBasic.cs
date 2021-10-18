namespace FluentApi.Interfaces
{
    /// <summary>
    /// Interface for namespace options of MongoDB utilities.
    /// </summary>
    public interface INamespaceOptionsBasic
    {
        /// <summary>
        /// Specifies a database to backup.
        /// </summary>
        /// <param name="databaseName">Name of the database.</param>
        /// <returns><see cref="IMongoUtility"/>.</returns>
        IMongoUtility Database(string databaseName);

        /// <summary>
        /// Specifies a collection to backup.
        /// </summary>
        /// <param name="collectionName">Name of the collection.</param>
        /// <returns><see cref="IMongoUtility"/>.</returns>
        IMongoUtility Collection(string collectionName);
    }
}