using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StarsDate.Models;
using Microsoft.EntityFrameworkCore;
using StarsDate.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace StarsDate
{
    public class Startup
    {
    
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(@"Server=EMIRHAZIR\SQLEXPRESS; Database=StarDateDb; User Id=sa; Password=123;"));

            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();


            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseIdentity();

            app.UseMvcWithDefaultRoute();



            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Olum linkleri adam gibi yaz");
            });
        }
    }
}
