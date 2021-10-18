namespace FluentApi.Interfaces
{
    /// <summary>
    /// Interface for authentications options of MongoDB utilities.
    /// </summary>
    public interface IAuthenticationOptionsBasic
    {
        /// <summary>
        /// Specifies a username for authentication.
        /// </summary>
        /// <param name="username">A username for authentication.</param>
        /// <returns><see cref="IMongoUtility"/>.</returns>
        IMongoUtility Username(string username);

        /// <summary>
        /// Specifies a password for authentication.
        /// </summary>
        /// <param name="password">A password for authentication.</param>
        /// <returns><see cref="IMongoUtility"/>.</returns>
        IMongoUtility Password(string password);
    }
}