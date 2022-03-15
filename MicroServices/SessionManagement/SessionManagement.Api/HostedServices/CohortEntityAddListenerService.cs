using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SessionManagement.Core.Entitites;
using SessionManagement.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SessionManagement.Api.HostedServices
{
    public class CohortEntityAddListenerService : IHostedService
    {
        private readonly IConfiguration configuration;
        private ServiceBusClient serviceBusClient;
        private ServiceBusProcessor serviceBusProcessor;
        private readonly ILogger<CohortEntityAddListenerService> logger;
        private readonly IServiceScopeFactory scopedServices;
        public CohortEntityAddListenerService(IConfiguration configuration, 
                                               ILogger<CohortEntityAddListenerService> logger, 
                                               IServiceScopeFactory scopedServices)
        {
            this.configuration = configuration;
            this.logger = logger;
            this.scopedServices = scopedServices;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            serviceBusClient = new ServiceBusClient(configuration["ServiceBusSettings:ConnectionString"]);
            var processorSettings = new ServiceBusProcessorOptions { MaxConcurrentCalls = 1, AutoCompleteMessages = false };
            var Q = configuration["ServiceBusSettings:Cohort_Q"];

            serviceBusProcessor = serviceBusClient.CreateProcessor(Q, processorSettings);

            logger.LogInformation("Start method executed");
            serviceBusProcessor.ProcessMessageAsync += ServiceBusProcessor_ProcessMessageAsync;
            serviceBusProcessor.ProcessErrorAsync += ServiceBusProcessor_ProcessErrorAsync;
            await serviceBusProcessor.StartProcessingAsync().ConfigureAwait(false);
        }

        private Task ServiceBusProcessor_ProcessErrorAsync(ProcessErrorEventArgs arg)
        {
            logger.LogInformation("Error processing message from queue");
            logger.LogError(arg.Exception.Message);
            return Task.CompletedTask;
        }

        private async Task ServiceBusProcessor_ProcessMessageAsync(ProcessMessageEventArgs arg)
        {
            var CohortObj = arg.Message.Body.ToObjectFromJson<Cohort>();
            using (var scope = scopedServices.CreateScope())
            {
                ISessionService sessionService = scope.ServiceProvider.GetRequiredService<ISessionService>();
                await sessionService.AddCohort(CohortObj);
                logger.LogInformation($"Cohort added. Id={CohortObj.Id}, Cohort Code={CohortObj.CohortCode}");
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            serviceBusProcessor.DisposeAsync().ConfigureAwait(false);
            serviceBusClient.DisposeAsync().ConfigureAwait(false);
            return Task.CompletedTask;
        }
    }
}
