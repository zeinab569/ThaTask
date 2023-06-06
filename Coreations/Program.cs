using Core.Entities;
using Core.Interfaces;
using Infrastuctre.Data;
using Infrastuctre.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace Coreations
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ShoppingContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("ShoppingDB")));

            builder.Services.AddIdentity<TheUser, IdentityRole>().AddEntityFrameworkStores<ShoppingContext>();
            //db context configrations
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            builder.Services.AddScoped<IProductRepo, ProductRepo>();
            builder.Services.AddScoped<ICustomerRepo, CustomerRepo>();
            builder.Services.AddScoped<IOrderRepo, OrderRepo>();
            builder.Services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            using var scope = app.Services.CreateScope();
            var Services = scope.ServiceProvider;
            //update database 
            var context = Services.GetRequiredService<ShoppingContext>();
            var logger = Services.GetRequiredService<ILogger<Program>>();

            try
            {
                context.Database.MigrateAsync();

            }
            catch (Exception ex)
            {
                logger.LogError(ex, "error occured while migrations");
            }
            app.Run();
        }
    }
}