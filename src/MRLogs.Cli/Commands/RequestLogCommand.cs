// -----------------------------------------------------------------------
// <copyright company="Microsoft">
//     Copyright (c) Microsoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.CommandLine;
using System.CommandLine.Completions;
using System.CommandLine.NamingConventionBinder;

namespace MRLogs.Cli.Commands
{
    public class RequestLogCommand : Command
    {
        public RequestLogCommand() : base("request", "Send information about a request handled by the application.")
        {
            /**
             * string Name,
        DateTimeOffset StartTime,
        TimeSpan Duration,
        string ResponseCode,
        bool Success
             * */
            AddOption(new Option<string>("--name", "The request name.")
            {
                IsRequired = true
            });
            AddOption(new Option<DateTimeOffset>("--start-time", "The time when the page was requested.")
            {
                IsRequired = true
            });
            AddOption(new Option<TimeSpan>("--duration", "The time taken by the application to handle the request.")
            {
                IsRequired = true
            });
            AddOption(new Option<string>("--response-code", "The response status code.")
            {
                IsRequired = true
            });
            AddOption(new Option<bool>("--success", "True if the request was handled successfully by the application.")
            {
                IsRequired = true
            });

            Handler = CommandHandler.Create<RequestLogCommandHandlerInput, IHost, CancellationToken>(
                async (input, host, cancellationToken) =>
                {
                    var handler = ActivatorUtilities.CreateInstance<RequestLogCommandHandler>(host.Services);
                    await handler.ExecuteAsync(input, cancellationToken);
                });
        }

        public override string? Description { get => base.Description; set => base.Description = value; }
        public override string Name { get => base.Name; set => base.Name = value; }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override IEnumerable<CompletionItem> GetCompletions(CompletionContext context)
        {
            return base.GetCompletions(context);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
