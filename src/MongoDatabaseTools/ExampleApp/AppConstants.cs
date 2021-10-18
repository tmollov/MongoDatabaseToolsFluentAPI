namespace ExampleApp
{
    /// <summary>
    /// Class containing common constants.
    /// </summary>
    public static class AppConstants
    {
        /// <summary>
        /// User-friendly info.
        /// </summary>
        public const string TestDatabase = "test";
        
        /// <summary>
        /// User-friendly info.
        /// </summary>
        public const string StartingMongoDump = "Starting mongodump...";
        
        /// <summary>
        /// User-friendly info.
        /// </summary>
        public const string StartingMongoRestore = "Starting mongorestore...";
        
        /// <summary>
        /// User-friendly info.
        /// </summary>
        public const string StartingBsonDump = "Starting bsondump...";
        
        /// <summary>
        /// User-friendly info.
        /// </summary>
        public const string StartingBackupProcess = "Starting backup process...";

        /// <summary>
        /// User-friendly info.
        /// </summary>
        public const string StartingRestoreProcess = "Starting restore process...";

        /// <summary>
        /// User-friendly info.
        /// </summary>
        public static string ImportingElements(long count) => $"Importing {count} elements...";

        /// <summary>
        /// User-friendly info.
        /// </summary>
        public const string DoneImportingElements = "Done importing elements...";
        
        /// <summary>
        /// User-friendly info.
        /// </summary>
        public static string DoneImporting(long count) => $"Done importing {count} elements.";

        /// <summary>
        /// User-friendly info.
        /// </summary>
        public const string StartingCounting = "Starting counting process...";

        
    }
}