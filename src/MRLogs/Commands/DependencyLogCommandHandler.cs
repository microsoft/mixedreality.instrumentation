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
    public sealed record DependencyLogCommandHandlerInput(
        string Name,
        string Message
        ) : BaseCommandHandlerInput;

    public class DependencyLogCommandHandler : BaseCommandHandler<DependencyLogCommandHandlerInput>
    {
        public DependencyLogCommandHandler(ILogger logger) : base(logger)
        {
        }

        public DependencyLogCommandHandler(ILogger logger, IServiceProvider serviceProvider) : base(logger, serviceProvider)
        {
        }

        protected override Task<ShiftResultCode> ExecuteAsyncOverride(DependencyLogCommandHandlerInput input, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
