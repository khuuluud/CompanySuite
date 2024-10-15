using LinkDev.CompanyBase.DAL.Persistance.Data;
using LinkDev.CompanyBase.DAL.Persistance.Repositories.Depatments;
using LinkDev.CompanyBase.DAL.Persistance.Repositories.Employees;
using LinkDev.CompanyBase.BLL.Services.Departments;
using LinkDev.CompanyBase.BLL.Services.Employees;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LinkDev.CompanyBase.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            #region Configure Services

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //builder.Services.AddScoped<ApplicationDbContext>();
            //builder.Services.AddScoped<DbContextOptions<ApplicationDbContext>>();
            builder.Services.AddDbContext<ApplicationDbContext>((OptionsBuilder) =>
            {
                OptionsBuilder.UseLazyLoadingProxies()
                .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));


            });

            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();

            builder.Services.AddScoped<IDepartmentService, DepartmentService>();

            builder.Services.AddScoped<IEmployeeRepository , EmployeeRepository>();
            builder.Services.AddScoped<IEmployeeService,  EmployeeService>(); 
            #endregion

            var app = builder.Build();

            #region Configure Kestrel Middlewares

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
           


            #endregion

            app.Run();
        }
    }
}
