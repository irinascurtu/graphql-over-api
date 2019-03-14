using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Api.Data;
using GraphQL.Api.Data.Infrastructure;
using GraphQL.Api.Data.Repositories;
using GraphQL.Api.GraphQL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL.DataLoader;
using Conference.Data.Data.Repositories;

namespace GraphQL.Api
{
    public class Startup
    {
        private readonly IHostingEnvironment env;

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            this.env = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<ConferenceDbContext>(options =>
            {
            //    options.UseLazyLoadingProxies();
                options.UseSqlServer(Configuration["ConnectionStrings:ConferenceDb"]);
            });

            services.AddScoped<SpeakersRepository>();
            services.AddScoped<TalksRepository>();


            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddScoped<ConferenceSchema>();

            //services.AddGraphQL(o => { o.ExposeExceptions = false; })
            //    .AddGraphTypes(ServiceLifetime.Scoped).AddDataLoader(); ;
            services.AddSingleton<IDataLoaderContextAccessor, DataLoaderContextAccessor>();
            services.AddSingleton<DataLoaderDocumentListener>();



            services.AddGraphQL(o => { o.ExposeExceptions = env.IsDevelopment(); })
              .AddGraphTypes(ServiceLifetime.Scoped)
              .AddUserContextBuilder(context => context.User)
              .AddDataLoader();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ConferenceDbContext dbContex)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseGraphQL<ConferenceSchema>();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
            dbContex.Seed();
            // app.UseMvc();
        }
    }
}
