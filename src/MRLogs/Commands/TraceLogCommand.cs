// -----------------------------------------------------------------------
// <copyright company="Microsoft">
//     Copyright (c) Microsoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.CommandLine;
using System.CommandLine.NamingConventionBinder;

namespace MRLogs.Commands
{
    public class TraceLogCommand : Command
    {
        public TraceLogCommand() : base("trace", "Access and write trace logs")
        {
            AddOption(new Option<string>("--message", "The message to log.")
            {
                IsRequired = true
            });

            Handler = CommandHandler.Create<TraceLogCommandHandlerInput, IHost, CancellationToken>(
                async (input, host, cancellationToken) =>
                {
                    var handler = ActivatorUtilities.CreateInstance<TraceLogCommandHandler>(host.Services);
                    return (int)await handler.ExecuteAsync(input, cancellationToken);
                });
        }
    }
}
