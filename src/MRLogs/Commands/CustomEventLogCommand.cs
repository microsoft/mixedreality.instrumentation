using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Completions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRLogs.Commands
{
    public class CustomEventLogCommand : Command
    {
        public CustomEventLogCommand() : base("custom-event-track", "Access and write logs for custom events")
        {
            AddOption(new Option<string>("--name", "The name of the event.")
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
