namespace FluentApi.Common
{
    /// <summary>
    /// Class containing constants of mongo utility options.
    /// </summary>
    public static class OptionConstants
    {
        // Verbosity options
        public const string Verbose = "--verbose";
        public const string Quiet = "--quiet";

        // Connection options
        public const string Host = "--host";
        public const string Port = "--port";

        // Authentication options
        public const string Username = "--username";
        public const string Password = "--password";

        // Namespace options
        public const string Database = "--db";
        public const string Collection = "--collection";

        // Uri options
        public const string Uri = "--uri";

        // Query options
        public const string Query = "--query";
        public const string QueryFile = "--queryFile";

        // Output options
        public const string Out = "--out";
        public const string Oplog = "--oplog";
        public const string ExcludeCollection = "--excludeCollection";

        // Input options
        public const string ObjectValidation = "--objcheck";
        public const string OplogReplay = "--oplogReplay";
        public const string OplogFile = "--oplogFile";
        public const string InputDirectory = "--dir";

        // Restore options
        public const string Drop = "--drop";
        public const string DryRun = "--dryRun";
        public const string NoIndexRestore = "--noIndexRestore";
        public const string KeepIndexVersion = "--keepIndexVersion";
        public const string MaintainInsertionOrder = "--maintainInsertionOrder";
        public const string StopOnError = "--stopOnError";
        public const string BypassDocumentValidation = "--bypassDocumentValidation";
        public const string NoOptions = "--noOptionsRestore";

        // Mixed options
        public const string Gzip = "--gzip";
        public const string Archive = "--archive";
        public const string NumberOfParallelCollections = "--numParallelCollections";
        public const string WithType = "--type";

        // BsonDump options 
        public const string PrettierJSON = "--pretty";
        public const string BsonFile = "--bsonFile";
        public const string OutputFile = "--outFile";
    }
}