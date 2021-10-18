namespace FluentApi
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using CliWrap.EventStream;
    using FluentApi.Common;
    using FluentApi.Interfaces;

    /// <inheritdoc cref="FluentApi.Interfaces.IMongoUtility" />
    public abstract class MongoUtility : IMongoUtility
    {
        private readonly Dictionary<string, string> _arguments = new();

        /// <inheritdoc />
        public IMongoUtility Verbose(byte levelOfLogDetail)
        {
            this.AddArgument(OptionConstants.Verbose, levelOfLogDetail.ToString());
            return this;
        }

        /// <inheritdoc />
        public IMongoUtility QuietLog()
        {
            this.AddArgument(OptionConstants.Quiet, string.Empty);
            return this;
        }

        /// <inheritdoc />
        public IMongoUtility Uri(string uri)
        {
            this.AddArgument(OptionConstants.Uri, uri);
            return this;
        }

        /// <inheritdoc />
        public IMongoUtility NumberOfParallelCollections(byte count)
        {
            this.AddArgument(OptionConstants.ExcludeCollection, count.ToString());
            return this;
        }

        /// <inheritdoc />
        public abstract Task Run(bool informationLog = true, bool errorLog = true, bool processLog = false);

        protected void LogToConsole(CommandEvent cmdEvent, bool informationLog = false, bool errorLog = false,
            bool processLog = false)
        {
            switch (cmdEvent)
            {
                case StartedCommandEvent started:
                    if (processLog)
                        Console.WriteLine($"Process started; ID: {started.ProcessId}");
                    break;
                case StandardOutputCommandEvent stdOut:
                    if (informationLog)
                        Console.WriteLine(stdOut.Text);
                    break;
                case StandardErrorCommandEvent stdErr:
                    if (errorLog)
                        Console.WriteLine(stdErr.Text);
                    break;
                case ExitedCommandEvent exited:
                    if (processLog)
                        Console.WriteLine($"Process exited; Code: {exited.ExitCode}");
                    break;
            }
        }

        protected void AddArgument(string key, string val)
        {
            if (this._arguments.ContainsKey(key))
            {
                this._arguments[key] = val;
            }
            else
            {
                this._arguments.Add(key, val);
            }
        }

        protected void RemoveArgument(string key)
        {
            if (this._arguments.ContainsKey(key))
            {
                this._arguments.Remove(key);
            }
        }

        /// <inheritdoc />
        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var item in this._arguments)
            {
                if (string.IsNullOrWhiteSpace(item.Value))
                {
                    sb.Append(item.Key);
                    sb.Append(Environment.NewLine);
                }
                else
                {
                    sb.Append($"{item.Key}=\"{item.Value}\"");
                    sb.Append(Environment.NewLine);
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Generates argument string for mongo utilities.
        /// </summary>
        /// <returns>String of applied arguments.</returns>
        protected string GetArguments()
        {
            var sb = new StringBuilder();

            foreach (var item in this._arguments)
            {
                if (string.IsNullOrWhiteSpace(item.Value))
                {
                    sb.Append(item.Key);
                }
                else
                {
                    sb.Append($"{item.Key}=\"{item.Value}\"");
                }

                sb.Append(' ');
            }

            return sb.ToString();
        }
    }
}