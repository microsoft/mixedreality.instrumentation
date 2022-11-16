// -----------------------------------------------------------------------
// <copyright company="Microsoft">
//     Copyright (c) Microsoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using Microsoft.ApplicationInsights;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.Services.Account;
using Shift.Core.Commands;
using Shift.Core.Models.Common;

namespace MRLogs.Cli.Commands
{
    public sealed record DependencyLogCommandHandlerInput(
        string Name,
        string Data,
        DateTimeOffset StartTime,
        TimeSpan Duration,
        bool Success,
        string? Target,
        string? DependencyType,
        string? ResultCode
        ) : BaseCommandHandlerInput;

    public class DependencyLogCommandHandler : BaseCommandHandler<DependencyLogCommandHandlerInput>
    {
        public DependencyLogCommandHandler(ILogger logger, IServiceProvider serviceProvider) : base(logger, serviceProvider)
        {
        }

        protected override Task ExecuteAsyncOverride(DependencyLogCommandHandlerInput input, CancellationToken cancellationToken)
        {

            if (string.IsNullOrWhiteSpace(input.DependencyType))
            {
                Telemetry.TrackDependency(input.Name, input.Data, input.StartTime, input.Duration, input.Success);
            }
            else if (string.IsNullOrWhiteSpace(input.Target))
            {
                Telemetry.TrackDependency(input.DependencyType, input.Name, input.Data, input.StartTime, input.Duration, input.Success);
            }
            else
            {
                if (string.IsNullOrWhiteSpace(input.ResultCode))
                {
                    throw new ArgumentException("--result-code flag must be provided when using --target flag");
                }

                Telemetry.TrackDependency(input.DependencyType, input.Target, input.Name, input.Data, input.StartTime, input.Duration, input.ResultCode, input.Success);
            }

            return Task.CompletedTask;
        }
    }
}
