namespace FluentApi
{
    public static class MongoUtilities
    {
        public static MongoDump MongoDump => new MongoDump();

        public static MongoRestore MongoRestore => new MongoRestore();

        public static BsonDump BsonDump => new BsonDump();
    }
}