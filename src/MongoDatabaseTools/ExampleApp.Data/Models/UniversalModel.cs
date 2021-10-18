namespace ExampleApp.Data.Models
{
    using MongoDB.Bson.Serialization.Attributes;

    /// <summary>
    /// Class to represent element from MongoDb database.
    /// </summary>
    /// <typeparam name="TKey">Type of Id.</typeparam>
    [BsonIgnoreExtraElements]
    public class UniversalModel<TKey>
    {
        /// <inheritdoc cref="BsonIdAttribute"/>>
        [BsonId]
        public TKey Id { get; set; }
    }
}