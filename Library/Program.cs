using Library.BLL;
using Library.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Library.BLL;

namespace Library {
    public class Program {
        public static async Task Main(string[] args) {

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
            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<LibraryDBContext>();

            // Repositories
            builder.Services.AddScoped<BookRepository>();
            builder.Services.AddScoped<UserRepository>();
            builder.Services.AddScoped<LocationRepository>();
            builder.Services.AddScoped<LoanRepository>();

            // Services
            builder.Services.AddScoped<BookService>();
            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<LocationService>();
            builder.Services.AddScoped<LoanService>();

            var app = builder.Build();

            // Seed roles and users
            using (var scope = app.Services.CreateScope()) {
                await IdentitySeedData.Initialize(scope.ServiceProvider);
            }

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
