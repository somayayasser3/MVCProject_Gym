using GymApp.Models;
using GymApp.Repository.Interfaces;
using GymApp.Repository.ModelsRepos;
using Microsoft.EntityFrameworkCore;

namespace GymApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            var app = builder.Build();

            builder.Services.AddDbContext<GymManagementContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("GymCon")));

            builder.Services.AddScoped<IClassRepository, ClassRepository>();
            builder.Services.AddScoped<ICoachRepository, CoachRepository>();
            builder.Services.AddScoped<IDietPlanRepository, DietPlanRepository>();
            builder.Services.AddScoped<IInBodyTestRepository, InBodyTestRepository>();
            builder.Services.AddScoped<IMembershipTypeRepository, MembershipTypeRepository>();
            builder.Services.AddScoped<IProgramRepository, ProgramRepository>();
            builder.Services.AddScoped<ITraineeRepository, TraineeRepository>();


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapRazorPages()
               .WithStaticAssets();

            app.Run();
        }
    }
}
