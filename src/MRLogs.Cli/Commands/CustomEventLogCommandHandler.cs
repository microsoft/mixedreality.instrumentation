// -----------------------------------------------------------------------
// <copyright company="Microsoft">
//     Copyright (c) Microsoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using Microsoft.ApplicationInsights;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Shift.Core.Commands;
using Shift.Core.Models.Common;

namespace MRLogs.Cli.Commands
{
    public sealed record CustomEventLogCommandHandlerInput(
        string Name,
        string Properties,
        string? Metrics
        ) : BaseCommandHandlerInput;

    public class CustomEventLogCommandHandler : BaseCommandHandler<CustomEventLogCommandHandlerInput>
    {
        public CustomEventLogCommandHandler(ILogger logger, IServiceProvider serviceProvider) : base(logger, serviceProvider)
        {
        }

        protected override Task ExecuteAsyncOverride(CustomEventLogCommandHandlerInput input, CancellationToken cancellationToken)
        {
            Logger.LogInformation($"Name {input.Name}, Message {input.Properties}");
            var props = JsonConvert.DeserializeObject<Dictionary<string, string>>(input.Properties);
            var metrics = string.IsNullOrWhiteSpace(input.Metrics) ? null : JsonConvert.DeserializeObject<Dictionary<string, double>>(input.Metrics);
            Telemetry.TrackEvent(input.Name, props, metrics);
            return Task.CompletedTask;
        }
    }
}
