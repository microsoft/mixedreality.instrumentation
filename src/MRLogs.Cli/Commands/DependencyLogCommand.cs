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
    public class DependencyLogCommand : Command
    {
        public DependencyLogCommand() : base("dependency", "Access and write logs for downstream dependency services")
        {
        //string Name,
        //string Data,
        //bool Success,
        //DateTimeOffset StartTime,
        //TimeSpan Duration,
        //string DependencyType,
        //string Target,
        //string ResultCode
            AddOption(new Option<string>(new string[] { "--name", "-n" }, 
                "Name of the command initiated with this dependency call. Low cardinality value. Examples are stored procedure name and URL path template..")
            {
                IsRequired = true
            });
            AddOption(new Option<string>(new string[] { "--data", "-D" },
                "Command initiated by this dependency call. Examples are SQL statement and HTTP URL's with all query parameters.")
            {
                IsRequired = true
            });
            AddOption(new Option<DateTimeOffset>(new string[] { "--start-time", "-s"},
                "The time when the dependency was called.")
            {
                IsRequired = true
            });
            AddOption(new Option<TimeSpan>(new string[] { "--duration", "-e" },
                "The time taken by the external dependency to handle the call.")
            {
                IsRequired = true
            });;
            AddOption(new Option<bool>(new string[] { "--success", "-S" },
                "True if the dependency call was handled successfully.")
            {
                IsRequired = true
            });
            AddOption(new Option<string>(new string[] { "--dependency-type" }, 
                "External dependency type. Very low cardinality value for logical grouping and interpretation of fields. Examples are SQL, Azure table, and HTTP."));
            AddOption(new Option<string>(new string[] { "--target", "-t" },
                "External dependency target."));
            AddOption(new Option<string>(new string[] { "--result-code", "-r" },
                "Result code of dependency call execution."));
            Handler = CommandHandler.Create<DependencyLogCommandHandlerInput, IHost, CancellationToken>(
                async (input, host, cancellationToken) =>
                {
                    var handler = ActivatorUtilities.CreateInstance<DependencyLogCommandHandler>(host.Services);
                    await handler.ExecuteAsync(input, cancellationToken);
                });
        }
    }
}
