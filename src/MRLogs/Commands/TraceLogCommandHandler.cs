// -----------------------------------------------------------------------
// <copyright company="Microsoft">
//     Copyright (c) Microsoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using Microsoft.Extensions.Logging;
using Shift.Core.Commands;
using Shift.Core.Models.Common;

namespace MRLogs.Commands
{
    public sealed record TraceLogCommandHandlerInput(
        string Message
        ) : BaseCommandHandlerInput;

    public class TraceLogCommandHandler : BaseCommandHandler<TraceLogCommandHandlerInput>
    {
        public TraceLogCommandHandler(ILogger logger) : base(logger)
        {
        }

        public TraceLogCommandHandler(ILogger logger, IServiceProvider serviceProvider) : base(logger, serviceProvider)
        {
        }

        protected override Task<ShiftResultCode> ExecuteAsyncOverride(TraceLogCommandHandlerInput input, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
