using System.CommandLine;

namespace MRLogs.Commands
{
    public class DependencyLogCommand : Command
    {
        public DependencyLogCommand() : base("dependency-track", "Access and write logs for downstream dependency services")
        {
            AddOption(new Option<string>("--name", "The name of the dependency service.")
            {
                IsRequired = true
            });
        }
    }
}
