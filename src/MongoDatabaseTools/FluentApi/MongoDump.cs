using FluentApi.Common;
using FluentApi.Common.Enums;

namespace FluentApi
{
    using System;
    using System.Threading.Tasks;
    using CliWrap;
    using CliWrap.EventStream;
    using FluentApi.Interfaces;

    /// <inheritdoc cref="IMongoDump" />
    public class MongoDump : MongoUtility, IMixedOptions, IMongoDump
    {
        /// <inheritdoc />
        public MongoDump Out(string outputDirectory)
        {
            this.AddArgument(OptionConstants.Out, outputDirectory);
            return this;
        }

        /// <inheritdoc />
        public MongoDump WithOplog()
        {
            this.AddArgument(OptionConstants.Oplog, string.Empty);
            this.RemoveArgument(OptionConstants.Database);
            this.RemoveArgument(OptionConstants.Collection);
            return this;
        }

        /// <inheritdoc />
        public MongoDump ExcludeCollection(string collectionName)
        {
            this.AddArgument(OptionConstants.ExcludeCollection, collectionName);
            return this;
        }

        /// <inheritdoc />
        public IMongoUtility ToGzip()
        {
            this.AddArgument(OptionConstants.Gzip, string.Empty);
            return this;
        }

        /// <inheritdoc />
        public IMongoUtility Archive(string outputPath)
        {
            this.AddArgument(OptionConstants.Archive, outputPath);
            return this;
        }

        /// <inheritdoc />
        public override async Task Run(
            bool informationLog = true,
            bool errorLog = true,
            bool processLog = false)
        {
            Console.WriteLine(AppConstants.StartingMongoDump);

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