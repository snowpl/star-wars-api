using Microsoft.Extensions.Logging;
using NServiceBus;
using System;
using System.Threading;
using System.Threading.Tasks;
using EndpointConfiguration = NServiceBus.EndpointConfiguration;

namespace StarWars.Api.BackgroundService
{
    public class MyBackgroundMessageService : BackgroundService
    {
        private IEndpointInstance _endpointInstance;
        private readonly EndpointConfiguration _endpointConfiguration;

        public MyBackgroundMessageService()
        {
            _endpointConfiguration = new EndpointConfiguration("StarWars.Api.Characters.Messaging");
            var transport = _endpointConfiguration.UseTransport<LearningTransport>();
            _endpointConfiguration.UsePersistence<LearningPersistence>();

            //Due to usage of LearningTransport it is needed to specify path for learningtransport folder.
            transport.StorageDirectory("D:\\Repo\\star-wars-api\\.learningtransport");
            //transport.StorageDirectory("..\\.learningtransport");
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    _endpointInstance = await Endpoint.Start(_endpointConfiguration).ConfigureAwait(false);
                    await Task.Delay(new TimeSpan(0, 10, 0), stoppingToken);
                }
            }
            finally
            {
                await _endpointInstance.Stop().ConfigureAwait(false);
            }
        }

    }
}
