namespace FluentApi.Interfaces
{
    using FluentApi.Interfaces.Options;

    /// <summary>
    /// Interface for mongorestore utility.
    /// </summary>
    public interface IMongoRestore : INamespaceOptionsBasic
    {
        /// <summary>
        /// Validates all objects before inserting.
        /// </summary>
        /// <returns><see cref="IMongoRestore"/>.</returns>
        MongoRestore WithObjectsValidation();

        /// <summary>
        /// After restoring the database dump, replays the oplog entries from a bson file.
        /// </summary>
        /// <returns><see cref="IMongoRestore"/>.</returns>
        MongoRestore WithOplogReplay();

        /// <summary>
        /// Specifies Oplog file to use for replay of oplog.
        /// </summary>
        /// <param name="filename">Filename of oplog.</param>>
        /// <returns><see cref="IMongoRestore"/>.</returns>
        MongoRestore WithOplogFile(string filename);

        /// <summary>
        /// Specifies the dump directory.
        /// </summary>
        /// <param name="dirName">Name of directory.</param>
        /// <returns><see cref="IMongoRestore"/>.</returns>
        MongoRestore FromDirectory(string dirName);

        /// <summary>
        /// Restores the collections from the dumped backup, drops the collections from the target database.
        /// </summary>
        /// <returns><see cref="IMongoRestore"/>.</returns>
        MongoRestore DropEachBeforeImport();

        /// <summary>
        /// Runs mongorestore without actually importing any data, returning the mongorestore summary information.
        /// </summary>
        /// <returns><see cref="IMongoRestore"/>.</returns>
        MongoRestore RunDry();

        /// <summary>
        /// Prevents mongorestore from restoring and building indexes as specified in the corresponding mongodump output.
        /// </summary>
        /// <returns><see cref="IMongoRestore"/>.</returns>
        MongoRestore WithoutIndexes();

        /// <summary>
        /// Prevents mongorestore from setting the collection options.
        /// </summary>
        /// <returns><see cref="IMongoRestore"/>.</returns>
        MongoRestore WithoutCollectionOptions();

        /// <summary>
        /// Prevents mongorestore from restoring and building indexes as specified in the corresponding mongodump output.
        /// </summary>
        /// <returns><see cref="IMongoRestore"/>.</returns>
        MongoRestore KeepIndexVersion();

        /// <summary>
        /// Inserts the documents in the order of their appearance in the input source.
        /// </summary>
        /// <returns><see cref="IMongoRestore"/>.</returns>
        MongoRestore MaintainInsertionOrder();

        /// <summary>
        /// Forces mongorestore to halt the restore when it encounters an error.
        /// </summary>
        /// <returns><see cref="IMongoRestore"/>.</returns>
        MongoRestore StopOnError();

        /// <summary>
        /// Enables mongorestore to bypass document validation during the operation.
        /// </summary>
        /// <returns><see cref="IMongoRestore"/>.</returns>
        MongoRestore BypassDocumentValidation();
    }
}