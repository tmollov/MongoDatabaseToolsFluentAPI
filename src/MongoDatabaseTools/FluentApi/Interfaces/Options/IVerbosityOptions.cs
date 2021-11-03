namespace FluentApi.Interfaces.Options
{
    /// <summary>
    /// Interface for verbosity options of MongoDB utilities.
    /// </summary>
    public interface IVerbosityOptions
    {
        /// <summary>
        /// Specifies level of log detail.
        /// </summary>
        /// <param name="levelOfLogDetail">Level of log detail.</param>
        /// <returns><see cref="IMongoUtility"/>.</returns>
        IMongoUtility Verbose(byte levelOfLogDetail);

        /// <summary>
        /// Turns off log of mongo utility.
        /// </summary>
        /// <returns><see cref="IMongoUtility"/>.</returns>
        IMongoUtility QuietLog();
    }
}