using Microsoft.Extensions.Logging;
using Shift.Core.Commands;
using Shift.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRLogs.Commands
{
    public sealed record DependencyLogCommandHandlerInput(
        string path,
        string components,
        string versions,
        string bundle = null
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
