// -----------------------------------------------------------------------
// <copyright company="Microsoft">
//     Copyright (c) Microsoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using Microsoft.ApplicationInsights;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Shift.Core.Commands;
using Shift.Core.Models.Common;

namespace MRLogs.Cli.Commands
{
    public sealed record CustomMetricLogCommandHandlerInput(
        string Name,
        double MetricValue,
        string? Properties
        ) : BaseCommandHandlerInput;

    public class CustomMetricLogCommandHandler : BaseCommandHandler<CustomMetricLogCommandHandlerInput>
    {
        public CustomMetricLogCommandHandler(ILogger logger, IServiceProvider serviceProvider) : base(logger, serviceProvider)
        {
        }

        protected override Task ExecuteAsyncOverride(CustomMetricLogCommandHandlerInput input, CancellationToken cancellationToken)
        {
            var props = string.IsNullOrWhiteSpace(input.Properties) ? null : JsonConvert.DeserializeObject<Dictionary<string, string>>(input.Properties);
            Telemetry.TrackMetric(input.Name, input.MetricValue, props);
            return Task.CompletedTask;
        }
    }
}
