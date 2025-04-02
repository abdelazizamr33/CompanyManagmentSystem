using Company.Route.BLL.Interfaces;
using Company.Route.BLL.Repositories;
using Company.Route.DAL.Data.Contexts;
using Company.Route.PL.Mapping;
using Company.Route.PL.Services;
using Microsoft.EntityFrameworkCore;

namespace Company.Route.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IDepartmentRepository,DepartmentRepository>(); // Allow Dependency injection for DepartmentRepository
            builder.Services.AddScoped<IEmployeeInterface, Employeerepository>(); // Allow Dependency injection for DepartmentRepository
            builder.Services.AddAutoMapper(typeof(EmployeeProfile));
            builder.Services.AddDbContext<CompanyDbContext>(options=>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")); // instead of writing connection string
            }); // Allow Dependency Injection for CompanyDbContext // which allow CLR to create object from it whenever he wants

            // differ by Life Time
            //builder.Services.AddScoped();     // Create object life time per request - unreachable object
            //builder.Services.AddTransient();  // Create object life time per operation 
            //builder.Services.AddSingleton();  // Create object life time per application

            builder.Services.AddScoped<IScopedService, ScopedService>(); // per request
            builder.Services.AddTransient<ITransientService, TransientService>(); // per operation
            builder.Services.AddSingleton<ISingeltonService, SingeltonService>(); //per application



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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
