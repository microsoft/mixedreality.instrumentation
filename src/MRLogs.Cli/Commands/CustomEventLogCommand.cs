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
    public class CustomEventLogCommand : Command
    {
        public CustomEventLogCommand() : base("custom-event", "Access and write logs for custom events")
        {
            AddOption(new Option<string>(new string[] { "--name", "-n" }, "The name of the event.")
            {
                IsRequired = true
            });
            AddOption(new Option<string>(new string[] { "--properties", "-p" }, "Named string values you can use to search and classify events. (JSON format)")
            {
                IsRequired = true
            });
            AddOption(new Option<string>("--metrics", "Measurements associated with this event. (JSON format)"));

            Handler = CommandHandler.Create<CustomEventLogCommandHandlerInput, IHost, CancellationToken>(
                async (input, host, cancellationToken) =>
                {
                    var handler = ActivatorUtilities.CreateInstance<CustomEventLogCommandHandler>(host.Services);
                    await handler.ExecuteAsync(input, cancellationToken);
                });
        }
    }
}
