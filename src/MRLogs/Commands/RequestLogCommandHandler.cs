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
    public sealed record RequestLogCommandHandlerInput(
        string path,
        string components,
        string versions,
        string bundle = null
        ) : BaseCommandHandlerInput;

    public class RequestLogCommandHandler : BaseCommandHandler<RequestLogCommandHandlerInput>
    {
        public RequestLogCommandHandler(ILogger logger) : base(logger)
        {
        }

        public RequestLogCommandHandler(ILogger logger, IServiceProvider serviceProvider) : base(logger, serviceProvider)
        {
        }

        protected override Task<ShiftResultCode> ExecuteAsyncOverride(RequestLogCommandHandlerInput input, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
