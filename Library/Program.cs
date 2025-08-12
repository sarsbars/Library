using Microsoft.EntityFrameworkCore;
using Library.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Library.BLL;

namespace Library {
    public class Program {
        public static void Main(string[] args) {
            // Explicitly set the base path for configuration
            var builder = WebApplication.CreateBuilder(new WebApplicationOptions {
                ApplicationName = typeof(Program).Assembly.FullName,
                ContentRootPath = Directory.GetCurrentDirectory(),
                EnvironmentName = Environments.Development
            });

            // Ensure configuration loads appsettings.json
            builder.Configuration
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Register LibraryDBContext with SQL Server
            builder.Services.AddDbContext<LibraryDBContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Add Identity services
            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<LibraryDBContext>();

            // Repositories
            builder.Services.AddScoped<BookRepository>();
            builder.Services.AddScoped<UserRepository>();

            // Services
            builder.Services.AddScoped<BookService>();
            builder.Services.AddScoped<UserService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment()) {
                app.UseExceptionHandler("/Home/Error");
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
            app.MapRazorPages();

            app.Run();
        }
    }
}
