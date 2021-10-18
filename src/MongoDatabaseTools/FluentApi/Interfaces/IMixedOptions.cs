namespace FluentApi.Interfaces
{
    /// <summary>
    /// Interface for mixed options of MongoDB utilities.
    /// </summary>
    public interface IMixedOptions
    {
        /// <summary>
        /// Compresses the output of mongodump.
        /// </summary>
        /// <returns><see cref="IMongoUtility"/>.</returns>
        IMongoUtility ToGzip();

        /// <summary>
        /// Dump backup as an archive to the specified path. If flag is specified without a value, archive is written to stdout
        /// </summary>
        /// <param name="outputPath">Specified path for archive.</param>
        /// <returns><see cref="IMongoUtility"/>.</returns>
        IMongoUtility Archive(string outputPath);
    }
}