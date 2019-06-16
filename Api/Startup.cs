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
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<LibraryContext>();
            services.AddTransient<IGetBooksCommand, EfGetBooksCommand>();
            services.AddTransient<IGetBookCommand, EfGetBookCommand>();
            services.AddTransient<IAddWriterCommand, EfAddWriterCommand>();
            services.AddTransient<IAddBookCommand, EfAddBookCommand>();
            services.AddTransient<IDeleteBookCommand, EfDeleteBookCommand>();
            services.AddTransient<IGetWritersCommand, EfGetWritersCommand>();
            services.AddTransient<IGetWriterCommand, EfGetWriterCommand>();
            services.AddTransient<IUpdateWriterCommand, EfUpdateWriterCommand>();
            services.AddTransient<IDeleteWriterCommand, EfDeleteWriterCommand>();
            services.AddTransient<IGetUsersCommand, EfGetUsersCommand>();
            services.AddTransient<IUpdateUserCommand, EfUpdateUserCommand>();
            services.AddTransient<IDeleteUserCommand, EfDeleteUserCommand>();
            services.AddTransient<IAddUserCommand, EfAddUserCommand>();
            services.AddTransient<IAddBookCommand, EfAddBookCommand>();
            services.AddTransient<IUpdateBookCommand, EfUpdateBookCommand>();
            services.AddTransient<IAddReservationCommand, EfAddReservationCommand>();
            services.AddTransient<IGetReserervationsCommand, EfGetReservationsCommand>();
            services.AddTransient<IGetReservationCommand, EfGetReservationCommand>();
            services.AddTransient<IUpdateReservationCommand, EfUpdateReservationCommand>();
            services.AddTransient<IDeleteReservationCommand, EfDeleteReservationCommand>();
            services.AddTransient<IGetPagedBooksCommand, EfGetPagedBooksCommand>();

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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
