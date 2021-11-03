namespace FluentApi.Interfaces.Options
{
    /// <summary>
    /// Interface for authentications options of MongoDB utilities.
    /// </summary>
    public interface IAuthenticationOptions
    {
        /// <summary>
        /// Specifies a username with which to authenticate to a MongoDB database that uses authentication.
        /// </summary>
        /// <param name="username">A username for authentication.</param>
        /// <returns><see cref="IMongoUtility"/>.</returns>
        IMongoUtility Username(string username);

        /// <summary>
        /// Specifies a password with which to authenticate to a MongoDB database that uses authentication.
        /// </summary>
        /// <param name="password">A password for authentication.</param>
        /// <returns><see cref="IMongoUtility"/>.</returns>
        IMongoUtility Password(string password);

        /// <summary>
        /// Specifies the authentication database where the specified username has been created.
        /// </summary>
        /// <param name="databaseName">Name of the database.</param>
        /// <returns><see cref="IMongoUtility"/>.</returns>
        IMongoUtility AuthenticationDatabase(string databaseName);

        /// <summary>
        /// Specifies the authentication mechanism the mongo utility instance uses to authenticate to the mongod or mongos.
        /// </summary>
        /// <param name="mechanism">A mechanism.</param>
        /// <returns><see cref="IMongoUtility"/>.</returns>
        IMongoUtility AuthenticationMechanism(string mechanism);

        // TODO: Add AmazonWebServicesSessionToken method.
    }
}