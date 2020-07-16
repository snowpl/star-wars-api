using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NServiceBus;
using StarWars.Api.Characters.Storage;
using StarWars.Api.Episodes;
using StarWars.Api.Episodes.Storage;
using System;
using System.Threading.Tasks;

namespace StarWars.Api.Characters.Messaging
{
    public class Program
    {
        public static IServiceProvider _serviceProvider;
        static async Task Main(string[] args)
        {

            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
            }

            RegisterServices();

            try
            {
                host.Start();
                await RunMessagingConsole()
                    .ConfigureAwait(false);
            }
            finally
            {
              DisposeServices();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args);
                //.UseNServiceBus(context =>
                //{
                //    var endpointConfiguration = new EndpointConfiguration("StarWars.Api");
                //    var transport = endpointConfiguration.UseTransport<LearningTransport>();
                //    transport.StorageDirectory("..\\.learningtransport");

                //    transport.Routing().RouteToEndpoint(typeof(UpdateCharacterNameCommand), "StarWars.Api.Characters.Messaging");

                //    transport.Routing().RouteToEndpoint(typeof(MyMessage), "StarWars.Api.Characters.Messaging");

                //    endpointConfiguration.SendOnly();
                //    return endpointConfiguration;
                //})
                //.ConfigureWebHostDefaults(webBuilder =>
                //{
                //    webBuilder.UseStartup<Startup>();
                //});

        private static async Task RunMessagingConsole()
        {
            Console.Title = "StarWars.Api.Characters.Messaging";

            var endpointConfiguration = new EndpointConfiguration("StarWars.Api.Characters.Messaging");
            var transport = endpointConfiguration.UseTransport<LearningTransport>();
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

        private static void RegisterServices()

        {
            _serviceProvider = new ServiceCollection()
                    .AddSingleton<ICharactersService, CharactersService>()
                    .AddTransient<ICharactersService, CharactersService>()
                    .AddTransient<ICharacterRepository, CharacterRepository>()
                    .AddTransient<IEpisodeRepository, EpisodeRepository>()
                    .AddTransient<IEpisodesService, EpisodesService>()
                    //.AddSingleton<IUpdateCharacterNameCommandHandler, UpdateCharacterNameCommandHandler>()
                    .BuildServiceProvider();
        }

        private static void DisposeServices()
        {
            if (_serviceProvider == null)
            {
                return;
            }

            if (_serviceProvider is IDisposable)
            {
                ((IDisposable)_serviceProvider).Dispose();
            }
        }
    }
}
