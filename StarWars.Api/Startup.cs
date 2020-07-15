using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using StarWars.Api.Characters;
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

        // This method gets called by the runtime. Use this method to add services to the container.
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

            services.AddDbContext<CharactersDbContext>(options => options.UseInMemoryDatabase(databaseName: "Characters"));
            services.AddDbContext<EpisodesDbContext>(options => options.UseInMemoryDatabase(databaseName: "Episodes"));
            services.AddTransient<ICharactersService, CharactersService>();
            services.AddTransient<ICharacterRepository, CharacterRepository>();
            services.AddTransient<IEpisodeRepository, EpisodeRepository>();
            services.AddTransient<IEpisodesService, EpisodesService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
