using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NServiceBus;
using StarWars.Api.Characters.Contracts;
using StarWars.Api.Characters.Contracts.Commands;

namespace StarWars.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                DataGenerator.Initialize(services);
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .UseNServiceBus(context =>
                {
                    var endpointConfiguration = new EndpointConfiguration("StarWars.Api");
                    var transport = endpointConfiguration.UseTransport<LearningTransport>();
                    transport.StorageDirectory("..\\.learningtransport");

                    transport.Routing().RouteToEndpoint(typeof(UpdateCharacterNameCommand), "StarWars.Api.Characters.Messaging");
                    transport.Routing().RouteToEndpoint(typeof(CreateCharacterCommand), "StarWars.Api.Characters.Messaging");
                    transport.Routing().RouteToEndpoint(typeof(ActivateCharacterCommand), "StarWars.Api.Characters.Messaging");
                    transport.Routing().RouteToEndpoint(typeof(DeactivateCharacterCommand), "StarWars.Api.Characters.Messaging");
                    transport.Routing().RouteToEndpoint(typeof(AddFriendsCommand), "StarWars.Api.Characters.Messaging");
                    transport.Routing().RouteToEndpoint(typeof(RemoveFriendCommand), "StarWars.Api.Characters.Messaging");

                    endpointConfiguration.SendOnly();
                    return endpointConfiguration;
                });
    }
}
