using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ContactsAPI.Commands.ContactsCommands;
using ContactsAPI.Commands.ContactsCommands.Interfaces;
using ContactsAPI.DbContexts;
using ContactsAPI.Mapper;
using ContactsAPI.Models;
using ContactsAPI.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ContactsAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ContactDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddSingleton<IContactRepository, ContactRepository>();
            services.AddSingleton<IGetAllContactsCommand, GetAllContactsCommand>();
            services.AddSingleton<IGetContactByIdCommand, GetContactByIdCommand>();
            services.AddSingleton<ICreateContactCommand, CreateContactCommand>();
            services.AddSingleton<IDeleteContactCommand, DeleteContactCommand>();
            services.AddSingleton<IUpdateContactCommand, UpdateContactCommand>();

            services.AddMvc();
            services.AddAutoMapper(x => x.AddProfile(new ContactMapper()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseStaticFiles();
            app.UseMvc();
            
            SeedData.EnsurePopulated(app);

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
