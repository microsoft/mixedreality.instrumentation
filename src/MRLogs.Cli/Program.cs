﻿// -----------------------------------------------------------------------
// <copyright company="Microsoft">
//     Copyright (c) Microsoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using CommandLine;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.ApplicationInsights;
using Microsoft.Extensions.Options;
using MRLogs.Cli.Commands;
using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Hosting;
using System.CommandLine.Parsing;
using System.Linq;
using System.Runtime.CompilerServices;

namespace MRLogs.Cli
{
    //public class Options
    //{
    //    [Option('c', "app-insights-connection-string", Required = false, HelpText = "Application Insights Connection String")]
    //    public string ConnectionString { get; set; }
    //}

    public class Program
    {
        public static async Task Main(string[] args)
        {

            // bind SIGINT and SIGTERM
            var cts = new CancellationTokenSource();
            Console.CancelKeyPress += (o, e) => cts.Cancel();
            AppDomain.CurrentDomain.ProcessExit += (o, e) => cts.Cancel();
            Console.WriteLine($"{string.Join(", ", args)}");
            var rootCommand = new ProgramRootCommand();
            //string connStr = "";
            var exitCode = new CommandLineBuilder(rootCommand)
                //.AddMiddleware(async (context, next) =>
                //{
                //    context.ParseResult.Directives.Con
                //})
                .UseHost(
                    _ => Host.CreateDefaultBuilder(),
                    host =>
                    {
                        host
                            .ConfigureServices((context, services) =>
                            {
                                //string connStr = "";
                                //CommandLine.Parser.Default.ParseArguments<Options>(args)
                                //    .WithParsed(o => { 
                                //        connStr = o.ConnectionString;
                                //    });
                                //Console.WriteLine($"connstring: {connStr}");
                                //var results = parser.ParseArguments(args);
                                //Console.WriteLine($"results");
                                //results.WithParsed<Option>(o =>
                                //{

                                //});
                                InitServiceProvider("", 
                                    services);
                            });
                    })
                .UseDefaults()
                .Build()
                .Invoke(args);
        }

        /// <summary>
        /// Creates a ServiceProvider that contains ILogger and TelemetryClient services.
        /// If <paramref name="connectionString"/> is present, these services will log to the ApplicationInsights resource
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        private static void InitServiceProvider(string connectionString, IServiceCollection services)
        {
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter("Microsoft", LogLevel.Warning)
                    .AddFilter("System", LogLevel.Warning)
                    .AddFilter(typeof(Program).Namespace, LogLevel.Debug)
                    .AddSimpleConsole(options =>
                    {
                        options.SingleLine = true;
                        options.TimestampFormat = "[hh:mm:ss] ";
                    });
            });
            
            services.AddSingleton<ILogger>(loggerFactory.CreateLogger<Program>());

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                services.AddSingleton(new TelemetryClient(new TelemetryConfiguration())); // create unconfigured telemetry service
                return;
            }

            //logger
            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder
                    .AddFilter("Microsoft", LogLevel.Warning)
                    .AddFilter("System", LogLevel.Warning)
                    .AddFilter(typeof(Program).Namespace, LogLevel.Debug)
                    .AddApplicationInsights(
                        configureTelemetryConfiguration: (config) => config.ConnectionString = connectionString,
                        configureApplicationInsightsLoggerOptions: (options) => { })
                    .AddSimpleConsole(options =>
                    {
                        options.SingleLine = true;
                        options.TimestampFormat = "[hh:mm:ss] ";
                    });
            });

            // telemetry
            services.AddApplicationInsightsTelemetryWorkerService(
                config => config.ConnectionString = connectionString);

            //return services.BuildServiceProvider();
        }
    }
}
