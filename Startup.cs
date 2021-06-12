using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using RSEBack.data;
using RSEBack.Data;

namespace RSEBack
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
            services.AddDbContext<RSEContext>(opt => opt.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("RSEConnection")));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RSEBack", Version = "v1" });
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // whenever our application asks for IActualiteRepo, we give the second argument
            // if this changes, all we need to do is swap the second argument out, 
            // the rest of the code stays the same, this is dependency injection
            services.AddScoped<IActualiteRepo, SqlActualiteRepo>();
            services.AddScoped<IUtilisateurRepo, SqlUtilisateurRepo>();
            services.AddScoped<ISuggestionRepo, SqlSuggestionRepo>();
            services.AddScoped<IPartenaireRepo, SqlPartenaireRepo>();
            services.AddScoped<IProjetRepo, SqlProjetRepo>();
            services.AddScoped<IImpactRepo, SqlImpactRepo>();
            services.AddScoped<IProfilRepo, SqlProfilRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(builder => builder
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RSEBack v1"));
            }

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
