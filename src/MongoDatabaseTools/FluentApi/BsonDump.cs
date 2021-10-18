namespace FluentApi
{
    using System;
    using System.Threading.Tasks;
    using CliWrap;
    using CliWrap.EventStream;
    using FluentApi.Common;
    using FluentApi.Common.Enums;
    using FluentApi.Interfaces;

    /// <inheritdoc cref="FluentApi.Interfaces.IBsonDump" />
    public class BsonDump : MongoUtility, IBsonDump
    {
        /// <inheritdoc />
        public BsonDump OfType(BsonType type)
        {
            this.AddArgument(
                OptionConstants.WithType,
                type == BsonType.Debug ? "debug" : "json");

            return this;
        }

        /// <inheritdoc />
        public BsonDump ValidateBSON()
        {
            this.AddArgument(OptionConstants.ObjectValidation, string.Empty);
            return this;
        }

        /// <inheritdoc />
        public BsonDump PrettierJSON()
        {
            this.AddArgument(OptionConstants.PrettierJSON, string.Empty);
            return this;
        }

        /// <inheritdoc />
        public BsonDump FromBsonFile(string bsonFilePath)
        {
            this.AddArgument(OptionConstants.BsonFile, bsonFilePath);
            return this;
        }

        /// <inheritdoc />
        public BsonDump ToOutputFile(string path)
        {
            this.AddArgument(OptionConstants.OutputFile, path);
            return this;
        }

        /// <inheritdoc />
        public override async Task Run(bool informationLog = true, bool errorLog = true, bool processLog = false)
        {
            Console.WriteLine(AppConstants.StartingBsonDump);

            var result = Cli.Wrap(ProcessConstants
                    .MongoTools(Utility.MongoDump))
                .WithArguments(this.GetArguments())
                .WithValidation(CommandResultValidation.None);

            await foreach (var cmdEvent in result.ListenAsync())
            {
                this.LogToConsole(cmdEvent, informationLog, errorLog, processLog);
            }
        }
    }
}