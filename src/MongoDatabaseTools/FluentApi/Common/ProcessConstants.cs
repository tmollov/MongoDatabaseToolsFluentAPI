namespace FluentApi.Common
{
    using System;
    using FluentApi.Common.Enums;

    /// <summary>
    /// Class containing constants to use with CliWrap library.
    /// </summary>
    public static class ProcessConstants
    {
        private static string GetPathToTool(Utility utility)
        {
            switch (utility)
            {
                case Utility.MongoDump: return "/usr/bin/mongodump";
                case Utility.MongoRestore: return "/usr/bin/mongorestore";
                case Utility.BsonDump: return "/usr/bin/bsondump";
                default: return null;
            }
        }

        // TODO: Add paths for Windows environment

        /// <summary>
        /// Method that returns path to MongoDB database tools.
        /// </summary>
        /// <returns>Returns path to given utility.</returns>
        public static string MongoTools(Utility util)
        {
            // TODO: add logic for Windows and Mac OS
            var osInfo = Environment.OSVersion.Platform;
            if (osInfo.ToString().Contains("Unix"))
            {
                return GetPathToTool(util);
            }

            return string.Empty;
        }

        /// <summary>
        /// Method to generate arguments for terminal app on Linux.
        /// </summary>
        /// <param name="args">Arguments to put in Gnome terminal.</param>
        /// <returns>String in format: -e {args}.</returns>
        public static string LinuxTerminalArgs(string args) => $"-e {args}";

        /// <summary>
        /// Method to generate arguments for terminal app on Windows.
        /// </summary>
        /// <param name="args">Arguments to put in Command Prompt.</param>
        /// <returns>String in format: /c {args}.</returns>
        public static string WindowsTerminalArgs(string args) => $"/c {args}";
    }
}