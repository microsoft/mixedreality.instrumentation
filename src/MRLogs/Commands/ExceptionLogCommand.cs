using System;
using System.Collections.Generic;
using System.CommandLine;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRLogs.Commands
{
    public class ExceptionLogCommand : Command
    {
        public ExceptionLogCommand() : base("exception-track", "Access and write logs for exceptions")
        {
            AddOption(new Option<string>("--name", "The name of the exception.")
            {
                IsRequired = true
            });
        }
    }
}
