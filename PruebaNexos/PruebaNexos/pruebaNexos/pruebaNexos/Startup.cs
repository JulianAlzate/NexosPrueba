using AutoMapper;
using BLL;
using BLL.Comunes;
using BLL.DTO;
using BLL.Interfaces;
using BLL.RN;
using DataBase.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace pruebaNexos
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
            services.AddRazorPages();

            //Unity Injection Dependencia
            services.AddMvc().AddControllersAsServices()
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddSingleton(provider => Configuration);

            //Conección
            services.AddEntityFrameworkSqlServer();
            services.AddDbContext<NexosContext>(config =>
            {
                config.UseSqlServer(Configuration.GetConnectionString("CorrespoConnection"));
            });
            services.AddDbContext<DbContext>(config =>
            {
                config.UseSqlServer(Configuration.GetConnectionString("CorrespoConnection"));
            });


            services.AddAutoMapper(typeof(Startup));

            #region Registrar Dependencias

            services.AddScoped<IBusinessLogic<LibroDTO>, LibroBLL>();
            services.AddScoped<IBusinessLogic<AutorDTO>, AutorBLL>();

            #endregion
            #region Mapper
            services.AddScoped(provider => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            }).CreateMapper());
            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapRazorPages();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Libro}/{action=Index}/{id?}");
            });
        }
    }
}
