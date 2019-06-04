using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballApi.Repositories;
using FootballApi.Repositories.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Unity;

namespace FootballApi
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
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddControllersAsServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            // Erros gerais
            app.UseExceptionHandler((appError) => {
                appError.Run(async (context) => {
                    var stringBuilder = new System.Text.StringBuilder("This was an error");

                    switch(context.Response.StatusCode) 
                    {
                        case 204:
                            context.Response.StatusCode = 204;
                            stringBuilder = new System.Text.StringBuilder("Sucesso, sem conteudo!");
                        break;
                        case 500:
                            context.Response.StatusCode = 500;
                            stringBuilder = new System.Text.StringBuilder("This was an error");
                        break;
                        default:
                            context.Response.StatusCode = 500;
                            stringBuilder = new System.Text.StringBuilder("Default");
                            break;
                        
                    }
                    // ANALISAR CONTEXT E MUDAR O ERRO E TEXTO DO ERRO
                    
                    var buffer = System.Text.Encoding.UTF8.GetBytes(stringBuilder.ToString());
                    await context.Response.Body.WriteAsync(buffer);
                });
            });
            app.UseMvc();
        }

        public void ConfigureContainer(IUnityContainer container)
        {
            // Could be used to register more types
            container.RegisterType<ICountryRepository, SqlLiteCountryRepository>();
        }
    }
}
