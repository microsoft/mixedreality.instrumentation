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
    public class DependencyLogCommand : Command
    {
        public DependencyLogCommand() : base("dependency", "Access and write logs for downstream dependency services")
        {
            AddOption(new Option<string>("--name", "The name of the dependency service.")
            {
                IsRequired = true
            });
            AddOption(new Option<string>("--message", "The message to log.")
            {
                IsRequired = true
            });

            Handler = CommandHandler.Create<DependencyLogCommandHandlerInput, IHost, CancellationToken>(
                async (input, host, cancellationToken) =>
                {
                    var handler = ActivatorUtilities.CreateInstance<DependencyLogCommandHandler>(host.Services);
                    return (int)await handler.ExecuteAsync(input, cancellationToken);
                });
        }
    }
}
