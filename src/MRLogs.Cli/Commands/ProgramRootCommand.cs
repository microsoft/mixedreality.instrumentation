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

        public Option<string> AppInsightsOption = new Option<string>(new string[] { "-c", "--app-insights-conection-string" },
                "The Connection String for logging telemetry to Application Insights");

        public ProgramRootCommand()
        {

            AddCommand(new CustomEventLogCommand());
            AddCommand(new CustomMetricLogCommand());
            AddCommand(new DependencyLogCommand());
            AddCommand(new ExceptionLogCommand());
            AddCommand(new RequestLogCommand());
            AddCommand(new TraceLogCommand());

            AddGlobalOption(AppInsightsOption);
        }
    }
}
