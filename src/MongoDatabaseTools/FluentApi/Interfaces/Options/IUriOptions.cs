namespace FluentApi.Interfaces.Options
{
    /// <summary>
    /// Interface for uri options of MongoDB utilities.
    /// </summary>
    public interface IUriOptions
    {
        /// <summary>
        /// Specifies the resolvable URI connection string of the MongoDB deployment.
        /// </summary>
        /// <param name="connectionString">A connection string to MongoDB deployment</param>
        /// <returns><see cref="IMongoUtility"/>.</returns>
        IMongoUtility Uri(string connectionString);
    }
}