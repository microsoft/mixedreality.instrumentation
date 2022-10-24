using System.CommandLine;

namespace MRLogs.Commands
{
    public class TraceLogCommand : Command
    {
        public TraceLogCommand() : base("trace-log", "Access and write trace logs")
        {
        }
    }
}
