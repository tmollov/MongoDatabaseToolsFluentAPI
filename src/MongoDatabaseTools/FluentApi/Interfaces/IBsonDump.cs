namespace FluentApi.Interfaces
{
    using FluentApi.Common.Enums;

    /// <summary>
    /// Interface for bsondump utility.
    /// </summary>
    public interface IBsonDump
    {
        /// <summary>
        /// Determines type of output of bsondump utility.
        /// </summary>
        /// <param name="type">Type of output.</param>
        /// <returns><see cref="BsonDump"/>.</returns>
        BsonDump OfType(BsonType type);

        /// <summary>
        /// Validates BSON during processing.
        /// </summary>
        /// <returns><see cref="BsonDump"/>.</returns>
        BsonDump ValidateBSON();

        /// <summary>
        /// Outputs JSON to be human-readable.
        /// </summary>
        /// <returns><see cref="BsonDump"/>.</returns>
        BsonDump PrettierJSON();

        /// <summary>
        /// Determines path to BSON file of dump.
        /// </summary>
        /// <param name="bsonFilePath">Path to BSON file.</param>
        /// <returns><see cref="BsonDump"/>.</returns>
        BsonDump FromBsonFile(string bsonFilePath);

        /// <summary>
        /// Determines path to output file to dump BSON to.
        /// </summary>
        /// <param name="path">Path to output file.</param>
        /// <returns><see cref="BsonDump"/>.</returns>
        BsonDump ToOutputFile(string path);
    }
}