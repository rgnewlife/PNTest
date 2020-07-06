using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json;

using GraphQL;
using GraphQL.Types;

using PNServices;
using PNData;

using PNGraphQL.Schemas;
using PNGraphQL.Queries;
using PNGraphQL.Mutations;
using PNGraphQL.Types;

namespace PNWebApi
{
    public class Startup
    {
        public const string GraphQLPath = "/graphql";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            // GraphQL Query throws a JSON error for circular dependencies even when none exist without this.  
            services.AddControllers()
                .AddNewtonsoftJson(
                    options => {
                        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    });

            //The HttpContext is needed to access context services in Middleware
            services.AddHttpContextAccessor();

            //TODO:  Is Singleton OK here?

            //The CosmosClientService is needed by Repositories
            services.AddSingleton<CosmosClientService>(InitializeCosmosClientService(Configuration.GetSection("CosmosDb")));

            services.AddSingleton<ContextService>();
            services.AddSingleton<RepositoryService>();


            //Add repositories
            services.AddTransient<IPrayerGroupRepository, PrayerGroupRepository>();

            // Add GraphQL DocumentExecuter objects
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();

            // Add GraphQL Queries and Mutations
            services.AddSingleton<PrayerGroupQuery>();
            services.AddSingleton<PrayerGroupMutation>();

            //Add GraphQL Schema
            services.AddSingleton<ISchema, PrayerGroupSchema>();

            // Add GraphQL Types
            services.AddSingleton<PrayerGroupType>();
            services.AddSingleton<BelieverType>();
            services.AddSingleton<PrayerGroupInputType>();

            // Add DependencyResolver
            services.AddSingleton<IDependencyResolver>(s => new
                 FuncDependencyResolver(s.GetRequiredService));
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        /// <summary>
        /// Creates a Cosmos DB client service.
        /// </summary>
        /// <returns></returns>
        private static CosmosClientService InitializeCosmosClientService(IConfigurationSection configurationSection)
        {
            string databaseName = configurationSection.GetSection("DatabaseName").Value;
            string endpoint = configurationSection.GetSection("Endpoint").Value;
            string key = configurationSection.GetSection("Key").Value;

            CosmosClientService cosmosClientService = new CosmosClientService(databaseName, endpoint, key);

            return cosmosClientService;
        }
    }
}
