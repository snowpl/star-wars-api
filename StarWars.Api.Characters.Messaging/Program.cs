using NServiceBus;
using System;
using System.Threading.Tasks;

namespace StarWars.Api.Characters.Messaging
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            Console.Title = "StarWars.Api.Characters.Messaging";

            var endpointConfiguration = new EndpointConfiguration("StarWars.Api.Characters.Messaging");
            var transport =endpointConfiguration.UseTransport<LearningTransport>();
            endpointConfiguration.UsePersistence<LearningPersistence>();
            //Due to usage of LearningTransport it is needed to specify path for learningtransport folder.
            transport.StorageDirectory("..\\..\\..\\..\\.learningtransport");

            var endpointInstance = await Endpoint.Start(endpointConfiguration)
                .ConfigureAwait(false);

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

            await endpointInstance.Stop()
                .ConfigureAwait(false);
        }
    }
}
