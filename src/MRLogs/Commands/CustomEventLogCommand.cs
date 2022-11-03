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

namespace MRLogs.Commands
{
    public class CustomEventLogCommand : Command
    {
        public CustomEventLogCommand() : base("custom-event", "Access and write logs for custom events")
        {
            AddOption(new Option<string>("--name", "The name of the event.")
            {
                IsRequired = true
            });
            AddOption(new Option<string>("--message", "The message to log.")
            {
                IsRequired = true
            });

            Handler = CommandHandler.Create<CustomEventLogCommandHandlerInput, IHost, CancellationToken>(
                async (input, host, cancellationToken) =>
                {
                    var handler = ActivatorUtilities.CreateInstance<CustomEventLogCommandHandler>(host.Services);
                    return (int)await handler.ExecuteAsync(input, cancellationToken);
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
