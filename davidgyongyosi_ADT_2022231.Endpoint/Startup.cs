using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using davidgyongyosi_ADT_2022231.Logic;
using davidgyongyosi_ADT_2022231.Logic.Classes;
using davidgyongyosi_ADT_2022231.Models;
using davidgyongyosi_ADT_2022231.Repository;

namespace davidgyongyosi_ADT_2022231.Endpoint
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IGenericRepository<Game>, GameRepository>();
            services.AddTransient<IGenericRepository<Genre>, GenreRepository>();
            services.AddTransient<IGenericRepository<Platform>, PlatformRepository>();
            services.AddTransient<IGameRepository, GameRepository>();
            services.AddTransient<IGenreRepository, GenreRepository>();
            services.AddTransient<IPlatformRepository, PlatformRepository>();


            services.AddTransient<IGameLogic, GameLogic>();
            services.AddTransient<IGenreLogic, GenreLogic>();
            services.AddTransient<IPlatformLogic, PlatformLogic>();
         
            services.AddDbContext<GamesDbContext>(opt =>
            {
                opt.UseLazyLoadingProxies()
                    .UseInMemoryDatabase("GamesDB");
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "davidgyongyosi_ADT_2022231.Endpoint", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "davidgyongyosi_ADT_2022231.Endpoint v1"));
            }

            app.UseRouting();
            app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

