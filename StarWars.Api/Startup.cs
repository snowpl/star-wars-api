using System;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NServiceBus;
using StarWars.Api.BackgroundService;
using StarWars.Api.Characters;
using StarWars.Api.Characters.Contracts;
using StarWars.Api.Characters.Storage;
using StarWars.Api.Episodes;
using StarWars.Api.Episodes.Storage;

namespace StarWars.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Star Wars API",
                    Description = "A simple Star Wars API",
                    Contact = new OpenApiContact
                    {
                        Name = "Kacper Werema",
                        Email = "kacper.werema@gmail.com",
                        Url = new Uri("https://www.linkedin.com/in/kacper-werema-a188b5115/"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under MIT",
                        Url = new Uri("https://opensource.org/licenses/MIT"),
                    }
                });
            });


            services.AddMvc()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UpdateCharacterNameCommand>());

            services.AddDbContextPool<CharactersDbContext>(options => options.UseInMemoryDatabase(databaseName: "Characters"));
            services.AddDbContextPool<EpisodesDbContext>(options => options.UseInMemoryDatabase(databaseName: "Episodes"));
            services.AddTransient<ICharactersService, CharactersService>();
            services.AddTransient<ICharacterRepository, CharacterRepository>();
            services.AddTransient<IEpisodeRepository, EpisodeRepository>();
            services.AddTransient<IEpisodesService, EpisodesService>();
            services.AddTransient<IFriendsService, FriendsService>();

            services.AddSingleton<IHostedService>(provider => new NServiceBusServiceHost(CreateEndpointConfiguration(provider)));
        }

        private EndpointConfiguration CreateEndpointConfiguration(IServiceProvider provider)
        {
            var _endpointConfiguration = new EndpointConfiguration("StarWars.Api.Characters.Messaging");
            var transport = _endpointConfiguration.UseTransport<LearningTransport>();
            _endpointConfiguration.UsePersistence<LearningPersistence>();

            //Due to usage of LearningTransport it is needed to specify path for learningtransport folder.
            transport.StorageDirectory("..\\.learningtransport");

            //This registration is needed to work with background task and DI.
            //I personally don't like how the DI is working in NServiceBus.
            _endpointConfiguration.RegisterComponents(
            registration: configureComponents =>
            {
                configureComponents.ConfigureComponent(componentFactory: () =>
                {
                    var opts = provider.GetService<DbContextOptions<CharactersDbContext>>();
                    return new CharactersDbContext(opts);
                }, DependencyLifecycle.SingleInstance);

                configureComponents.ConfigureComponent(componentFactory: () =>
                {
                    var opts = provider.GetService<DbContextOptions<EpisodesDbContext>>();
                    return new EpisodesDbContext(opts);
                }, DependencyLifecycle.SingleInstance);

                configureComponents.ConfigureComponent<CharacterRepository>(DependencyLifecycle.InstancePerUnitOfWork);
                configureComponents.ConfigureComponent<EpisodesService>(DependencyLifecycle.SingleInstance);
                configureComponents.ConfigureComponent<EpisodeRepository>(DependencyLifecycle.SingleInstance);
                configureComponents.ConfigureComponent<CharactersService>(DependencyLifecycle.SingleInstance);
                configureComponents.ConfigureComponent<FriendsService>(DependencyLifecycle.SingleInstance);
            });
            return _endpointConfiguration;
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Star Wars API V1");
                c.RoutePrefix = string.Empty;
            });
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
