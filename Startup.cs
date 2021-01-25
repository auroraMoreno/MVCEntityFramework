using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVCEntityFramework.Data;
using MVCEntityFramework.Models;
using MVCEntityFramework.Repositories;

namespace MVCEntityFramework
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            String cadena = Configuration.GetConnectionString("casasqlhospital");
            services.AddTransient<RepositoryEmpleadosHospital>();
            services.AddTransient<RepositoryDoctores>();
            services.AddTransient<RepositoryEnfermos>();
            services.AddDbContext<EnfermosContext>(options => options.UseSqlServer(cadena));
            services.AddTransient<RepositoryHospital>();
            services.AddTransient<RepositoryPlantilla>();
            services.AddDbContext<HospitalContext>(options => options.UseSqlServer(cadena));
            services.AddTransient<RepositoryEmpleado>();
            services.AddDbContext<EmpleadoContext>(options => options.UseSqlServer(cadena));
            //String cadena = @"Data Source=LAPTOP-KR2NL673\SQLAURORAMASTER;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=sa;Password=MCSD2020";
            services.AddSingleton<IDepartamentosContext>(context => new DepartamentosContextSQL(cadena));
            //services.AddSingleton<IDepartamentosContext>(context=>new DepartamentosContextSQL(cadena));
            //las dependencias de obj se resuelven en los servicios: 
            //dos opciones:
            //primero: usar addtransient que genera un obj por cada petición de inyeccion 
            //services.AddTransient<Coche>();
            //también tenemos la opcion de crear una unica instancia de un objeto para todas las peticiones
            //de inyeccion
            //se realiza con el metodo .addsingletin<T>
            //services.AddSingleton<ICoche, Deportivo>(); 
            services.AddSingleton<ICoche>(z => new Deportivo("Ferrari", "Tter", "original.jpg", 299));
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name:"default",
                    pattern:"{controller=Home}/{action=Index}/{id?}"
                    );
            });
           
        }
    }
}
