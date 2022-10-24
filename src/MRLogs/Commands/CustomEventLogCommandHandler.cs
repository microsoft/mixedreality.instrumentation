using Microsoft.Extensions.Logging;
using Shift.Core.Commands;
using Shift.Core.Models.Common;

namespace MRLogs.Commands
{
    public sealed record CustomEventLogCommandHandlerInput(
        string path,
        string components,
        string versions,
        string bundle = null
        ) : BaseCommandHandlerInput;

    public class CustomEventLogCommandHandler : BaseCommandHandler<CustomEventLogCommandHandlerInput>
    {
        public CustomEventLogCommandHandler(ILogger logger) : base(logger)
        {
        }

        public CustomEventLogCommandHandler(ILogger logger, IServiceProvider serviceProvider) : base(logger, serviceProvider)
        {
        }

        protected override Task<ShiftResultCode> ExecuteAsyncOverride(CustomEventLogCommandHandlerInput input, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
