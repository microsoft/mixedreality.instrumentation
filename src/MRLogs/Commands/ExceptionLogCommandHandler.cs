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
    public sealed record ExceptionLogCommandHandlerInput(
        string Name,
        string Message
        ) : BaseCommandHandlerInput;

    public class ExceptionLogCommandHandler : BaseCommandHandler<ExceptionLogCommandHandlerInput>
    {
        public ExceptionLogCommandHandler(ILogger logger) : base(logger)
        {
        }

        public ExceptionLogCommandHandler(ILogger logger, IServiceProvider serviceProvider) : base(logger, serviceProvider)
        {
        }

        protected override Task<ShiftResultCode> ExecuteAsyncOverride(ExceptionLogCommandHandlerInput input, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
