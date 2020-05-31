using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using IdentityServer4.Models;
using OAM.Service.Contexts;
using System.Reflection;
using Microsoft.Extensions.Logging;
using IdentityServer4.EntityFramework.DbContexts;
using System.Runtime.CompilerServices;
using OAM.Service.Helpers;
using System.Linq;
using IdentityServer4.EntityFramework.Mappers;

namespace OAM.Service
{
    public class Startup
    {
        private bool IsDevelopment;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
            // Add IdentityServer4 to auth using JWT tokens.
            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddConfigurationStore(option =>
                    option.ConfigureDbContext = builder => builder.UseNpgsql(Configuration.GetConnectionString("IdentityServerConnection"), 
                    options => options.MigrationsAssembly(migrationsAssembly)))
                .AddOperationalStore(option =>
                    option.ConfigureDbContext = builder => builder.UseNpgsql(Configuration.GetConnectionString("IdentityServerConnection"), 
                    options => options.MigrationsAssembly(migrationsAssembly)));


            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = "https://localhost:44384";
                    options.RequireHttpsMetadata = !IsDevelopment;

                    options.Audience = "OAM.Service";
                });

            services.AddDbContext<AssetContext>(options => options.UseNpgsql(Configuration.GetConnectionString("AssetServerConnection")));
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
            
            IsDevelopment = env.IsDevelopment();

            InitializeDatabase(app, IsDevelopment);

            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseAuthentication();

            app.UseAuthorization();
            
            app.UseIdentityServer();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void InitializeDatabase(IApplicationBuilder app, bool IsDevelopment)
        {
            using var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
            var services = scope.ServiceProvider;
            
            try
            {
                services.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();
                services.GetRequiredService<ConfigurationDbContext>().Database.Migrate();
                services.GetRequiredService<AssetContext>().Database.EnsureCreated();

                if (IsDevelopment)
                {
                    Console.WriteLine("Development phase enabled.");
                    var ctx = services.GetRequiredService<ConfigurationDbContext>();
                    if (!ctx.Clients.Any())
                    {
                        foreach (var client in Config.GetClients())
                        {
                            ctx.Clients.Add(client.ToEntity());
                        }
                        ctx.SaveChanges();
                    }

                    if (!ctx.IdentityResources.Any())
                    {
                        foreach (var resource in Config.GetIdentityResources())
                        {
                            ctx.IdentityResources.Add(resource.ToEntity());
                        }
                        ctx.SaveChanges();
                    }

                    if (!ctx.ApiResources.Any())
                    {
                        foreach (var resource in Config.GetApiResources())
                        {
                            ctx.ApiResources.Add(resource.ToEntity());
                        }
                        ctx.SaveChanges();
                    }
                }

            }
            catch (Exception ex)
            {
                services.GetRequiredService<ILogger<Program>>().LogError(ex, "An error occurred creating the required databases.");
            }
        }
    }
}
