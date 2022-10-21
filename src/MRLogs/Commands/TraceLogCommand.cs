using System;
using System.Collections.Generic;
using System.CommandLine;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRLogs.Commands
{
    public class TraceLogCommand : Command
    {
        public TraceLogCommand() : base("trace-log", "Access and write trace logs")
        {
        }
    }
}
