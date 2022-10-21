using Microsoft.Extensions.Logging;
using Shift.Core.Commands;
using Shift.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRLogs.Commands
{
    public sealed record CustomMetricLogCommandHandlerInput(
        string path,
        string components,
        string versions,
        string bundle = null
        ) : BaseCommandHandlerInput;

    public class CustomMetricLogCommandHandler : BaseCommandHandler<CustomMetricLogCommandHandlerInput>
    {
        public CustomMetricLogCommandHandler(ILogger logger) : base(logger)
        {
        }

        public CustomMetricLogCommandHandler(ILogger logger, IServiceProvider serviceProvider) : base(logger, serviceProvider)
        {
        }

        protected override Task<ShiftResultCode> ExecuteAsyncOverride(CustomMetricLogCommandHandlerInput input, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
