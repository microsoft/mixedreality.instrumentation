using System.CommandLine;
using System.CommandLine.Completions;

namespace MRLogs.Commands
{
    public class RequestLogCommand : Command
    {
        public RequestLogCommand() : base("request-track", "Access and write logs for requests to a service")
        {
            AddOption(new Option<string>("--name", "The name of the requested service.")
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
