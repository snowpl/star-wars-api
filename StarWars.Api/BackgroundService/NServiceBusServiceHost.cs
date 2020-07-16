using Microsoft.Extensions.Hosting;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StarWars.Api.BackgroundService
{
    public class NServiceBusServiceHost : IHostedService
    {
        EndpointConfiguration _config;
        TaskCompletionSource<IEndpointInstance> _endpointTcs;

        public NServiceBusServiceHost(EndpointConfiguration config)
        {
            _config = config;
            _endpointTcs = new TaskCompletionSource<IEndpointInstance>(TaskCreationOptions.RunContinuationsAsynchronously);
        }

        public Task<IEndpointInstance> EndpointInstance => _endpointTcs.Task;

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {
                var endpoint = await Endpoint.Start(_config).ConfigureAwait(false);
                _endpointTcs.TrySetResult(endpoint);
            }
            catch (Exception e)
            {
                _endpointTcs.TrySetException(e);
                throw;
            }
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            var endpoint = await EndpointInstance.ConfigureAwait(false);
            await endpoint.Stop().ConfigureAwait(false);
        }
    }
}
