namespace FluentApi.Interfaces
{
    using FluentApi.Interfaces.Options;

    /// <summary>
    /// Interface for mongo utility.
    /// </summary>
    public interface IMongoUtility : IVerbosityOptions, IRunnableUtility
    {
        /// <summary>
        /// Specifies a mongodb uri connection string.
        /// </summary>
        /// <param name="uri">A mongodb uri connection string.</param>
        /// <returns><see cref="IMongoUtility"/>.</returns>
        IMongoUtility Uri(string uri);

        /// <summary>
        /// Number of collections to dump in parallel.
        /// </summary>
        /// <param name="count">Number of parallel collections</param>
        /// <returns><see cref="IMongoUtility"/>.</returns>
        IMongoUtility NumberOfParallelCollections(byte count);
    }
}