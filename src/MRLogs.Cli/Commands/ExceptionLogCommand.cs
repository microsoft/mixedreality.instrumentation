// -----------------------------------------------------------------------
// <copyright company="Microsoft">
//     Copyright (c) Microsoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.CommandLine;
using System.CommandLine.NamingConventionBinder;

namespace MRLogs.Cli.Commands
{
    public class ExceptionLogCommand : Command
    {
        public ExceptionLogCommand() : base("exception", "Access and write logs for exceptions")
        {
            AddOption(new Option<string>("--exception-message", "The exception message to log")
            {
                IsRequired = true
            });
            AddOption(new Option<string>("--properties", "Named string values you can use to classify and search for this exception."));
            AddOption(new Option<string>("--metrics", "Additional values associated with this exception."));

            Handler = CommandHandler.Create<ExceptionLogCommandHandlerInput, IHost, CancellationToken>(
                async (input, host, cancellationToken) =>
                {
                    var handler = ActivatorUtilities.CreateInstance<ExceptionLogCommandHandler>(host.Services);
                    await handler.ExecuteAsync(input, cancellationToken);
                });
        }
    }
}
