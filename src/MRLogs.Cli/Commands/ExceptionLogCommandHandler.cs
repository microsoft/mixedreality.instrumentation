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
    public sealed record ExceptionLogCommandHandlerInput(
        string ExceptionMessage,
        string? Properties,
        string? Metrics
        ) : BaseCommandHandlerInput;

    public class ExceptionLogCommandHandler : BaseCommandHandler<ExceptionLogCommandHandlerInput>
    {
        public ExceptionLogCommandHandler(ILogger logger, IServiceProvider serviceProvider) : base(logger, serviceProvider)
        {
        }

        protected override Task ExecuteAsyncOverride(ExceptionLogCommandHandlerInput input, CancellationToken cancellationToken)
        {
            var exceptionObject = new Exception(input.ExceptionMessage);
            var props = string.IsNullOrWhiteSpace(input.Properties) ? null : JsonConvert.DeserializeObject<Dictionary<string, string>>(input.Properties);
            var metrics = string.IsNullOrWhiteSpace(input.Metrics) ? null : JsonConvert.DeserializeObject<Dictionary<string, double>>(input.Metrics);
            Telemetry.TrackException(exceptionObject, props, metrics);
            return Task.CompletedTask;
        }
    }
}
