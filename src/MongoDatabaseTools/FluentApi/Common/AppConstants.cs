namespace FluentApi.Common
{
    /// <summary>
    /// Class containing common app constants.
    /// </summary>
    public class AppConstants
    {
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
        /// Method to generate string.
        /// </summary>
        /// <param name="collectionName">Target collection name.</param>
        /// <returns>String in format: "Counting elements in _{collectionName}_ collection ..."</returns>
        public static string CountElementsIn(string collectionName)
            => $"Counting elements in _{collectionName}_ collection ...";

        /// <summary>
        /// Method to generate string.
        /// </summary>
        /// <param name="count">Count of elements in collection.</param>
        /// <returns>String in format: "Elements in collection: {count}".</returns>
        public static string ElementsInCollection(long count) => $"Elements in collection: {count}";
    }
}