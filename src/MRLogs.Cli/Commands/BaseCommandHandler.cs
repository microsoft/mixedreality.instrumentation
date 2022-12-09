using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace MRLogs.Cli.Commands
{
    public abstract record BaseCommandHandlerInput;

    /// <summary>
    /// Abstract class for defining a command handler.
    /// </summary>
    /// <typeparam name="TBaseCommandInput">Types handler to specific input type.</typeparam>
    public abstract class BaseCommandHandler<TBaseCommandInput> where TBaseCommandInput : BaseCommandHandlerInput
    {
        /// <summary>
        /// Logger for handler. Used for logging warnings, errors, and other bits of information.
        /// </summary>
        protected ILogger Logger { get; }

        /// <summary>
        /// Telemetry Client for handler. User for logging custom telemetry to Application Insights
        /// </summary>
        protected TelemetryClient Telemetry { get; }
        protected IServiceProvider ServiceProvider { get; }
        
        /// <summary>
        /// Initialization for base handler.
        /// </summary>
        /// <param name="logger">Used to set logger for handler.</param>
        public BaseCommandHandler(ILogger logger)
        {
            Logger = logger;
            Telemetry = new TelemetryClient(new Microsoft.ApplicationInsights.Extensibility.TelemetryConfiguration());
        }


        public BaseCommandHandler(ILogger logger, IServiceProvider serviceProvider)
        {
            Logger = logger;
            Telemetry = serviceProvider.GetRequiredService<TelemetryClient>();
            ServiceProvider = serviceProvider;
        }


        /// <summary>
        /// Code to run execute command logic. Catches and logs any errors encountered during runtime.
        /// </summary>
        /// <param name="input">Command input, defined by BaseCommandHandlerInput.</param>
        /// <param name="cancellationToken">For cancellation purposes.</param>
        /// <returns></returns>
        public async Task ExecuteAsync(TBaseCommandInput input, CancellationToken cancellationToken = default)
        {
            Logger.LogTrace($"Start_{GetType().Name}");

            //var result = AutoUnlockResultCode.Unknown;
            try
            {
                await ExecuteAsyncOverride(input, cancellationToken);
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception ex)
            {
                Logger.LogError("An unexpected exception occured.");
                Logger.LogDebug(ex, ex.Message);
            }
            finally
            {
                Logger.LogTrace($"Stop_{GetType().Name}");
                Telemetry.Flush();
            }

            //Logger.LogDebug($"{GetType().Name} completed with exit code: {result}");
        }

        /// <summary>
        /// Abstract method representing the specific command logic for a particular handler.
        /// </summary>
        /// <param name="input">Command input, defined by BaseCommandHandlerInput.</param>
        /// <param name="cancellationToken">For cancellation purposes.</param>
        /// <returns></returns>
        protected abstract Task ExecuteAsyncOverride(TBaseCommandInput input, CancellationToken cancellationToken);
    }
}
