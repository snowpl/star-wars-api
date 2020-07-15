using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NServiceBus;
using StarWars.Api.Characters.Contracts;
using StarWars.Api.Characters.Storage;
using StarWars.Api.Episodes.Storage;

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
                .UseNServiceBus(context =>
                {
                    var endpointConfiguration = new EndpointConfiguration("StarWars.Api");
                    var transport = endpointConfiguration.UseTransport<LearningTransport>();
                    transport.StorageDirectory("..\\.learningtransport");

                    transport.Routing().RouteToEndpoint(typeof(UpdateCharacterNameCommand), "StarWars.Api.Characters.Messaging");

                    transport.Routing().RouteToEndpoint(typeof(MyMessage), "StarWars.Api.Characters.Messaging");

                    endpointConfiguration.SendOnly();
                    return endpointConfiguration;
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
