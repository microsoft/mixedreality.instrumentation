using System.CommandLine;
using System.CommandLine.Completions;

namespace MRLogs.Commands
{
    public class CustomMetricLogCommand : Command
    {
        public CustomMetricLogCommand() : base("custom-metric-track", "Access and write logs for custom metric") 
        {
            AddOption(new Option<string>("--name", "The name of the metric.")
            {
                IsRequired = true
            });
        }

        public override string? Description { get => base.Description; set => base.Description = value; }
        public override string Name { get => base.Name; set => base.Name = value; }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override IEnumerable<CompletionItem> GetCompletions(CompletionContext context)
        {
            return base.GetCompletions(context);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
