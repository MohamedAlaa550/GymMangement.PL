using GymMangement.BLL.Services.Classes;
using GymMangement.BLL.Services.IntrerFaces;
using GymMangement.DAL.Models;
using GymMangement.DAL.Persistence.Data.Context;
using GymMangement.DAL.Persistence.Repositories.Classes;
using GymMangement.DAL.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace GymMangement.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Conguration Services
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<GymDbContext>((OptionsBuilder) =>
            {
                OptionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnction"));
            });
           // builder.Services.AddScoped<IGenericRepository<ModelBase>, GenericRepository<ModelBase>>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IAnalyticsService, AnalyticsService>();
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            #region Middlewares
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets(); 
            #endregion

            app.Run();
        }
    }
}
