namespace FluentApi.Interfaces.Options
{
    /// <summary>
    /// Interface for kerberos options of MongoDB utilities.
    /// </summary>
    public interface IKerberosOptions
    {
        /// <summary>
        /// Specify the name of the service using GSSAPI/Kerberos.
        /// </summary>
        /// <param name="serviceName">Name of the service.</param>
        /// <returns><see cref="IMongoUtility"/>.</returns>
        IMongoUtility GssapiServiceName(string serviceName);

        /// <summary>
        /// Specify the hostname of a service using GSSAPI/Kerberos.
        /// </summary>
        /// <param name="hostName">Name of the host.</param>
        /// <returns><see cref="IMongoUtility"/>.</returns>
        IMongoUtility GssapiHostName(string hostName);
    }
}