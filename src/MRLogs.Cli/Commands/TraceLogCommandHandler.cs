// -----------------------------------------------------------------------
// <copyright company="Microsoft">
//     Copyright (c) Microsoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Shift.Core.Commands;
using Shift.Core.Models.Common;

namespace MRLogs.Cli.Commands
{
    public sealed record TraceLogCommandHandlerInput(
        string Message,
        SeverityLevel? SeverityLevel,
        string? Properties
        ) : BaseCommandHandlerInput;

    public class TraceLogCommandHandler : BaseCommandHandler<TraceLogCommandHandlerInput>
    {
        public TraceLogCommandHandler(ILogger logger, IServiceProvider serviceProvider) : base(logger, serviceProvider)
        {
        }

        protected override Task ExecuteAsyncOverride(TraceLogCommandHandlerInput input, CancellationToken cancellationToken)
        {
            // init as new so we don't have to implement all method overloads
            var props = string.IsNullOrWhiteSpace(input.Properties) ? new() : JsonConvert.DeserializeObject<Dictionary<string, string>>(input.Properties);
            if (input.SeverityLevel == null)
            {
                Telemetry.TrackTrace(input.Message, props);
            }
            else
            {
                Telemetry.TrackTrace(input.Message, (SeverityLevel)input.SeverityLevel, props);
            }

            return Task.CompletedTask;
        }
    }
}
