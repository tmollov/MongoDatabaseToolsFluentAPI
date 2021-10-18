namespace ExampleApp.Data
{
    /// <summary>
    /// Class containing constants to configure database.
    /// </summary>
    public static class DbConfigurationConstants
    {
        /// <summary>
        /// Default server IP address.
        /// </summary>
        public const string ServerIp = "127.0.0.1";

        /// <summary>
        /// Default server port.
        /// </summary>
        public const string ServerPort = "27017";
        
        /// <summary>
        /// A required prefix to identify that this is a string in the standard connection format.
        /// </summary>
        public const string ConnectionStringBase = "mongodb://";

        /// <summary>
        /// Method that returns default MongoDB standalone connection string.
        /// </summary>
        public static string GetConnectionString
            => $"{ConnectionStringBase}{ServerIp}:{ServerPort}";
    }
}