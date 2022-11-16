// -----------------------------------------------------------------------
// <copyright company="Microsoft">
//     Copyright (c) Microsoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using Microsoft.ApplicationInsights;
using Microsoft.Extensions.Logging;
using Shift.Core.Commands;
using Shift.Core.Models.Common;

namespace MRLogs.Cli.Commands
{
    public sealed record RequestLogCommandHandlerInput(
        string Name,
        DateTimeOffset StartTime,
        TimeSpan Duration,
        string ResponseCode,
        bool Success
        ) : BaseCommandHandlerInput;

    public class RequestLogCommandHandler : BaseCommandHandler<RequestLogCommandHandlerInput>
    {
        public RequestLogCommandHandler(ILogger logger, IServiceProvider serviceProvider) : base(logger, serviceProvider)
        {
        }

        protected override Task ExecuteAsyncOverride(RequestLogCommandHandlerInput input, CancellationToken cancellationToken)
        {
            Telemetry.TrackRequest(input.Name, input.StartTime, input.Duration, input.ResponseCode, input.Success);
            return Task.CompletedTask;
        }
    }
}
