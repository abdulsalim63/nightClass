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
using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework
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

            services.AddDbContext<HandphoneContext>(opt => opt.UseNpgsql("Host=ec2-52-86-33-50.compute-1.amazonaws.com;Username=qleouwkrkjorzd;" +
                "Password=326fc145ba8f6dbf38d86b06e4cf56884efd96bb7d3efab27b9b836a11316858; Database=d2ea8qbco2rjo;SSL Mode=Require; Trust Server Certificate=true")) ;
            services.AddDbContext<AccesoriesContext>(opt => opt.UseNpgsql("Host=ec2-52-86-33-50.compute-1.amazonaws.com;Username=qleouwkrkjorzd;" +
                "Password=326fc145ba8f6dbf38d86b06e4cf56884efd96bb7d3efab27b9b836a11316858; Database=d2ea8qbco2rjo;SSL Mode=Require; Trust Server Certificate=true"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
