using System.CommandLine;

namespace MRLogs.Commands
{
    public class ExceptionLogCommand : Command
    {
        public ExceptionLogCommand() : base("exception", "Access and write logs for exceptions")
        {
            AddOption(new Option<string>("--name", "The name of the exception.")
            {
                IsRequired = true
            });
        }
    }
}
