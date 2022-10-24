using MRLogs.Commands;
using System.CommandLine;

namespace MRLogs
{
    public class MRLogs
    {
        public static void Main(string[] args)
        {
            var rootCommand = new RootCommand();
            rootCommand.AddCommand(new CustomEventLogCommand());
            rootCommand.AddCommand(new CustomMetricLogCommand());
            rootCommand.AddCommand(new DependencyLogCommand());
            rootCommand.AddCommand(new ExceptionLogCommand());
            rootCommand.AddCommand(new RequestLogCommand());
            rootCommand.AddCommand(new TraceLogCommand());
        }
    }
}
