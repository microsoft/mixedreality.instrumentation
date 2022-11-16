using System;
using System.Collections.Generic;
using System.CommandLine;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRLogs.Cli.Commands
{
    public sealed class ProgramRootCommand : RootCommand
    {
        public readonly string[] APP_INSIGHTS_OPTIONS = new string[] { "-c", "--app-insights-conection-string" };
        public ProgramRootCommand()
        {

            AddCommand(new CustomEventLogCommand());
            AddCommand(new CustomMetricLogCommand());
            AddCommand(new DependencyLogCommand());
            AddCommand(new ExceptionLogCommand());
            AddCommand(new RequestLogCommand());
            AddCommand(new TraceLogCommand());

            // Global options
            //var appInsightsOption = new Option<string>(APP_INSIGHTS_OPTIONS,
            //    "The Connection String for logging telemetry to Application Insights");

            //AddGlobalOption(appInsightsOption);
        }
    }
}
