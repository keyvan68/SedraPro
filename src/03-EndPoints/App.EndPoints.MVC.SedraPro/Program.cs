using App.Domain.ApplicationServices;
using App.Domain.Core.Contracts.ApplicationService;
using App.Domain.Core.Contracts.Repository;
using App.Infrastructures.Data.Repositories.Repositories;
using App.Infrastructures.Db.SqlServer.Ef.Database;
using Microsoft.EntityFrameworkCore;

namespace App.EndPoints.MVC.SedraPro
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string  not found.");


            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));


            #region Repository
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserDetailsRepositiry, UserDetailsRepositiry>();
            #endregion Repository

            #region ApplicationServices
            builder.Services.AddScoped<IUserApplicationService, UserApplicationService>();
            builder.Services.AddScoped<IUserDetailsApplicationService, UserDetailsApplicationService>();
            #endregion ApplicationServices


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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}