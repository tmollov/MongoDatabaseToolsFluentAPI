namespace FluentApi.Interfaces
{
    using FluentApi.Interfaces.Options;

    /// <summary>
    /// Interface for mongo utility.
    /// </summary>
    public interface IMongoUtility : IVerbosityOptions, IRunnableUtility, IUriOptions
    {
        /// <summary>
        /// Number of collections to dump in parallel.
        /// </summary>
        /// <param name="count">Number of parallel collections.</param>
        /// <returns><see cref="IMongoUtility"/>.</returns>
        IMongoUtility NumberOfParallelCollections(byte count);
    }
}