using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookerHelper.DAL.EFContext
{
    public class SeederDB
    {
        private static void SeedRole(RoleManager<DbRole> _manager)
        {
            // "Owner", "Administrator", "Manager", "Editor", "Buyer", "Business", "Seller", "Subscriber"

            var roleAdmin = new DbRole()
            {
                Name = "administrator",
                NormalizedName = "ADMINISTRATOR"
            };

            if (!_manager.Roles.Any(r => r.Name == roleAdmin.Name))
            {
                var result = _manager.CreateAsync(roleAdmin).Result;
            }

            var roleSubscriber = new DbRole()
            {
                Name = "subscriber",
                NormalizedName = "SUBSCRIBER"
            };

            if (!_manager.Roles.Any(r => r.Name == roleSubscriber.Name))
            {
                var result = _manager.CreateAsync(roleSubscriber).Result;
            }
        }
        private static void SeedUser(UserManager<DbUser> _manager)
        {
            var roleName = "administrator";
            var user = new DbUser();
            user.Email = "stepan@gmail.com";
            user.NormalizedEmail = "STEPAN@GMAIL.COM";
            user.EmailConfirmed = true;
            user.UserName = "stepan@gmail.com"; ;
            user.NormalizedUserName = "STEPAN@GMAIL.COM";
            user.PhoneNumber = "HUAWEI";
            user.PhoneNumberConfirmed = true;
            user.SecurityStamp = Guid.NewGuid().ToString("D");
            user.TwoFactorEnabled = true;

            var password = new PasswordHasher<DbUser>();
            var hashed = password.HashPassword(user, "!QWEry123456");
            user.PasswordHash = hashed;

            user.UserProfile = new UserProfile()
            {
                FirstName = "Stepan",
                LastName = "Stepanskyy",
                MiddleName = "Stepanovich",
                RegistrationDate = DateTime.Now,
                Photo = "stepanPhoto.jpg"
            };

            if (!_manager.Users.Any(u => u.UserName == user.UserName))
            {
                var result = _manager.CreateAsync(user).Result;
                if (result.Succeeded)
                {
                    var resultRole = _manager.AddToRoleAsync(user, roleName).Result;
                }
            }
        }
        private static void SeedRecipes(EFDbContext context)
        {
            context.SaveChangesAsync();
        }

        public static void SeedData(IServiceProvider services, IHostingEnvironment env, IConfiguration config)
        {
            using (var scope = services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<DbRole>>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<DbUser>>();
                var context = scope.ServiceProvider.GetRequiredService<EFDbContext>();
                SeedRole(roleManager);
                SeedUser(userManager);
                SeedRecipes(context);
            }
        }
    }
}
