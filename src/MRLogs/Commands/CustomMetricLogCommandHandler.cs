﻿// -----------------------------------------------------------------------
// <copyright company="Microsoft">
//     Copyright (c) Microsoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using Microsoft.Extensions.Logging;
using Shift.Core.Commands;
using Shift.Core.Models.Common;

namespace MRLogs.Commands
{
    public sealed record CustomMetricLogCommandHandlerInput(
        string Name,
        string Message
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
