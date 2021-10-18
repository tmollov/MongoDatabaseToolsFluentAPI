namespace FluentApi.Interfaces
{
    /// <summary>
    /// Interface for mongodump utility.
    /// </summary>
    public interface IMongoDump
    {
        /// <summary>
        /// Specifies the directory where mongodump will write BSON files for the dumped databases.
        /// </summary>
        /// <param name="outputDirectory">Output directory name.</param>
        /// <returns><see cref="MongoDump"/>.</returns>
        MongoDump Out(string outputDirectory);

        /// <summary>
        /// Creates Point-In-Time backup.
        /// </summary>
        /// <returns><see cref="MongoDump"/>.</returns>
        MongoDump WithOplog();

        /// <summary>
        /// Excludes all collections from the dump that have the given prefix
        /// </summary>
        /// <param name="collectionName">Name of the collection.</param>
        /// <returns><see cref="MongoDump"/>.</returns>
        MongoDump ExcludeCollection(string collectionName);
    }
}