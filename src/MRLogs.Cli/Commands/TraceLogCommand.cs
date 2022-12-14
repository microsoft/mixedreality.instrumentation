// -----------------------------------------------------------------------
// <copyright company="Microsoft">
//     Copyright (c) Microsoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.CommandLine;
using System.CommandLine.NamingConventionBinder;

namespace MRLogs.Cli.Commands
{
    public class TraceLogCommand : Command
    {
        public TraceLogCommand() : base("trace", "Send a trace message for display in Diagnostic Search.")
        {
            AddOption(new Option<string>("--message", "Message to display.")
            {
                IsRequired = true
            });
            AddOption(new Option<SeverityLevel>("--severity-level", "Trace severity level."));
            AddOption(new Option<string>("--properties", "Named string values you can use to search and classify events."));

            Handler = CommandHandler.Create<TraceLogCommandHandlerInput, IHost, CancellationToken>(
                async (input, host, cancellationToken) =>
                {
                    var handler = ActivatorUtilities.CreateInstance<TraceLogCommandHandler>(host.Services);
                    await handler.ExecuteAsync(input, cancellationToken);
                });
        }
    }
}
