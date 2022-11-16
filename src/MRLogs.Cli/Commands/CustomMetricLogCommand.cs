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
    public class CustomMetricLogCommand : Command
    {
        public CustomMetricLogCommand() : base("custom-metric", "Access and write logs for custom metric") 
        {
            AddOption(new Option<string>("--name", "The name of the metric.")
            {
                IsRequired = true
            });
            AddOption(new Option<double>(new string[] { "--metric-value", "-m" }, "Metric value")
            {
                IsRequired = true
            });
            AddOption(new Option<string>(new string[] { "--properties", "-p" }, "Named string values you can use to classify and filter metrics."));

            Handler = CommandHandler.Create<CustomMetricLogCommandHandlerInput, IHost, CancellationToken>(
                async (input, host, cancellationToken) =>
                {
                    var handler = ActivatorUtilities.CreateInstance<CustomMetricLogCommandHandler>(host.Services);
                    await handler.ExecuteAsync(input, cancellationToken);
                });
        }
    }
}
