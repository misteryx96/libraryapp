using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Email;
using Application.Commands;
using Application.Interfaces;
using EfCommands;
using EfDataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApp
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<LibraryContext>();
            services.AddTransient<IGetBooksCommand, EfGetBooksCommand>();
            services.AddTransient<IGetBookCommand, EfGetBookCommand>();
            services.AddTransient<IAddBookCommand, EfAddBookCommand>();
            services.AddTransient<IUpdateBookCommand, EfUpdateBookCommand>();
            services.AddTransient<IDeleteBookCommand, EfDeleteBookCommand>();
            services.AddTransient<IGetGenresCommand, EfGetGenresCommand>();
            services.AddTransient<IGetPagedBooksCommand, EfGetPagedBooksCommand>();
            services.AddTransient<ICreateBookCommand, EfCreateBookCommand>();
            services.AddTransient<IGetForWebCommand, EfGetForWebCommand>();
            services.AddTransient<IEditBookCommand, EfEditBookCommand>();
            services.AddTransient<IDeleteBookCommand, EfDeleteBookCommand>();
            services.AddTransient<IGetReserervationsCommand, EfGetReservationsCommand>();
            services.AddTransient<IGetReservationCommand, EfGetReservationCommand>();
            services.AddTransient<IDeleteReservationCommand, EfDeleteReservationCommand>();
            services.AddTransient<ICreateReservationCommand, EfCreateReservationCommand>();
            services.AddTransient<IGetReservationForWebCommand, EfGetReservationForWebCommand>();
            services.AddTransient<IEditReservationCommand, EfEditReservationCommand>();
            services.AddTransient<ITookABookCommand, EfTookABookCommand>();

            var section = Configuration.GetSection("Email");

            var sender = new SmtpEmailSender(section["host"], Int32.Parse(section["port"]), section["fromaddress"], section["password"]);

            services.AddSingleton<IEmailSender>(sender);
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
