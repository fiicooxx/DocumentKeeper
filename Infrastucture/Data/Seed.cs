//using Infrastructure.Data.Entity;
//using Infrastructure.Data;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.Identity.Client;
//using System.Net;
//using Microsoft.Extensions.DependencyInjection;

//namespace DocuKeeper.Data
//{
//    public class Seed
//    {
//        public static void SeedData(IApplicationBuilder applicationBuilder)
//        {
//            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
//            {

//            }
//        }
//        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
//        {
//            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
//            {
//                // Roles
//                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

//                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
//                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
//                if (!await roleManager.RoleExistsAsync(UserRoles.User))
//                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

//                // Users
//                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
//                string adminUserEmail = "admin@gmail.com";

//                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
//                if (adminUser == null)
//                {
//                    var newAdminUser = new AppUser()
//                    {
//                        UserName = "adminuser",
//                        Email = adminUserEmail,
//                        EmailConfirmed = true
//                    };
//                    await userManager.CreateAsync(newAdminUser, "Admin1234?");
//                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
//                }

//                string appUserEmail = "user@gmail.com";

//                var appUser = await userManager.FindByEmailAsync(appUserEmail);
//                if (appUser == null)
//                {
//                    var newAppUser = new AppUser()
//                    {
//                        UserName = "appuser",
//                        Email = appUserEmail,
//                        EmailConfirmed = true
//                    };
//                    await userManager.CreateAsync(newAppUser, "User1234?");
//                    await userManager.AddToRoleAsync(appUser, UserRoles.User);
//                }
//            }
//        }
//    }
//}