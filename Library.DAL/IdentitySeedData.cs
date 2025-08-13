using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Library.DAL {
    public static class IdentitySeedData {
        public static async Task Initialize(IServiceProvider serviceProvider) {
            using var scope = serviceProvider.CreateScope();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

            string[] roleNames = { "Admin", "Staff", "Reader" };
            foreach (var roleName in roleNames) {
                if (!await roleManager.RoleExistsAsync(roleName)) {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            var users = new[]
            {
                new { Email = "admin1@library.com", Role = "Admin", Password = "Admin@123" },
                new { Email = "admin2@library.com", Role = "Admin", Password = "Admin@123" },
                new { Email = "admin3@library.com", Role = "Admin", Password = "Admin@123" },
                new { Email = "admin4@library.com", Role = "Admin", Password = "Admin@123" },
                new { Email = "admin5@library.com", Role = "Admin", Password = "Admin@123" },
                new { Email = "staff1@library.com", Role = "Staff", Password = "Staff@123" },
                new { Email = "staff2@library.com", Role = "Staff", Password = "Staff@123" },
                new { Email = "staff3@library.com", Role = "Staff", Password = "Staff@123" },
                new { Email = "staff4@library.com", Role = "Staff", Password = "Staff@123" },
                new { Email = "staff5@library.com", Role = "Staff", Password = "Staff@123" },
                new { Email = "reader1@library.com", Role = "Reader", Password = "Reader@123" },
                new { Email = "reader2@library.com", Role = "Reader", Password = "Reader@123" },
                new { Email = "reader3@library.com", Role = "Reader", Password = "Reader@123" },
                new { Email = "reader4@library.com", Role = "Reader", Password = "Reader@123" },
                new { Email = "reader5@library.com", Role = "Reader", Password = "Reader@123" },
                new { Email = "reader6@library.com", Role = "Reader", Password = "Reader@123" },
                new { Email = "reader7@library.com", Role = "Reader", Password = "Reader@123" },
                new { Email = "reader8@library.com", Role = "Reader", Password = "Reader@123" },
                new { Email = "reader9@library.com", Role = "Reader", Password = "Reader@123" },
                new { Email = "reader10@library.com", Role = "Reader", Password = "Reader@123" },
                new { Email = "reader11@library.com", Role = "Reader", Password = "Reader@123" },
                new { Email = "reader12@library.com", Role = "Reader", Password = "Reader@123" },
                new { Email = "reader13@library.com", Role = "Reader", Password = "Reader@123" },
                new { Email = "reader14@library.com", Role = "Reader", Password = "Reader@123" },
                new { Email = "reader15@library.com", Role = "Reader", Password = "Reader@123" },
                new { Email = "reader16@library.com", Role = "Reader", Password = "Reader@123" },
                new { Email = "reader17@library.com", Role = "Reader", Password = "Reader@123" },
                new { Email = "reader18@library.com", Role = "Reader", Password = "Reader@123" },
                new { Email = "reader19@library.com", Role = "Reader", Password = "Reader@123" },
                new { Email = "reader20@library.com", Role = "Reader", Password = "Reader@123" },
                new { Email = "reader21@library.com", Role = "Reader", Password = "Reader@123" },
                new { Email = "reader22@library.com", Role = "Reader", Password = "Reader@123" },
                new { Email = "reader23@library.com", Role = "Reader", Password = "Reader@123" },
                new { Email = "reader24@library.com", Role = "Reader", Password = "Reader@123" },
                new { Email = "reader25@library.com", Role = "Reader", Password = "Reader@123" },
                new { Email = "reader26@library.com", Role = "Reader", Password = "Reader@123" },
                new { Email = "reader27@library.com", Role = "Reader", Password = "Reader@123" },
                new { Email = "reader28@library.com", Role = "Reader", Password = "Reader@123" },
                new { Email = "reader29@library.com", Role = "Reader", Password = "Reader@123" },
                new { Email = "reader30@library.com", Role = "Reader", Password = "Reader@123" },
                new { Email = "reader31@library.com", Role = "Reader", Password = "Reader@123" },
                new { Email = "reader32@library.com", Role = "Reader", Password = "Reader@123" },
                new { Email = "reader33@library.com", Role = "Reader", Password = "Reader@123" },
                new { Email = "reader34@library.com", Role = "Reader", Password = "Reader@123" },
                new { Email = "reader35@library.com", Role = "Reader", Password = "Reader@123" },
                new { Email = "reader36@library.com", Role = "Reader", Password = "Reader@123" },
                new { Email = "reader37@library.com", Role = "Reader", Password = "Reader@123" },
                new { Email = "reader38@library.com", Role = "Reader", Password = "Reader@123" },
                new { Email = "reader39@library.com", Role = "Reader", Password = "Reader@123" },
                new { Email = "reader40@library.com", Role = "Reader", Password = "Reader@123" },
                new { Email = "reader41@library.com", Role = "Reader", Password = "Reader@123" },
                new { Email = "reader42@library.com", Role = "Reader", Password = "Reader@123" },
                new { Email = "reader43@library.com", Role = "Reader", Password = "Reader@123" },
                new { Email = "reader44@library.com", Role = "Reader", Password = "Reader@123" },
                new { Email = "reader45@library.com", Role = "Reader", Password = "Reader@123" },
                new { Email = "reader46@library.com", Role = "Reader", Password = "Reader@123" },
                new { Email = "reader47@library.com", Role = "Reader", Password = "Reader@123" },
                new { Email = "reader48@library.com", Role = "Reader", Password = "Reader@123" },
                new { Email = "reader49@library.com", Role = "Reader", Password = "Reader@123" },
                new { Email = "reader50@library.com", Role = "Reader", Password = "Reader@123" }
            };

            foreach (var user in users) {
                var identityUser = await userManager.FindByEmailAsync(user.Email);
                if (identityUser == null) {
                    identityUser = new IdentityUser { UserName = user.Email, Email = user.Email };
                    var result = await userManager.CreateAsync(identityUser, user.Password);
                    if (result.Succeeded) {
                        await userManager.AddToRoleAsync(identityUser, user.Role);
                    }
                } else {
                    if (!await userManager.IsInRoleAsync(identityUser, user.Role)) {
                        await userManager.AddToRoleAsync(identityUser, user.Role);
                    }
                }
            }
        }
    }
}