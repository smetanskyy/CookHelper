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
        private static void SeedGame(EFDbContext context)
        {
            // "Owner", "Administrator", "Manager", "Editor", "Buyer", "Business", "Seller", "Subscriber"

            var roleAdmin = new DbRole()
            {
                Name = "administrator",
                NormalizedName = "ADMINISTRATOR"
            };

            if (!context.Roles.Any(r => r.Name == roleAdmin.Name))
            {
                var roleStore = new RoleStore<DbRole>(context);
                var result = roleStore.CreateAsync(roleAdmin);
            }

            var roleSubscriber = new DbRole()
            {
                Name = "subscriber",
                NormalizedName = "SUBSCRIBER"
            };

            if (!context.Roles.Any(r => r.Name == roleSubscriber.Name))
            {
                var roleStore = new RoleStore<DbRole>(context);
                var result = roleStore.CreateAsync(roleSubscriber);
            }

            var user = new DbUser();
            user.Email = "ivanna.pugaiko@gmail.com";
            user.NormalizedEmail = "IVANNA.PUGAIKO@GMAIL.COM";
            user.EmailConfirmed = true;
            user.UserName = "smethan";
            user.NormalizedUserName = "SMETHAN";
            user.PhoneNumber = "HUAWEI";
            user.PhoneNumberConfirmed = true;
            user.SecurityStamp = Guid.NewGuid().ToString("D");
            user.TwoFactorEnabled = true;

            var password = new PasswordHasher<DbUser>();
            var hashed = password.HashPassword(user, "QWEry123456");
            user.PasswordHash = hashed;

            user.UserProfile = new UserProfile()
            {
                FirstName = "Stepan",
                LastName = "Smetanskyy",
                MiddleName = "Ivanovich",
                RegistrationDate = DateTime.Now,
                Photo = "stepanPhoto.jpg"
            };

            if (!context.Users.Any(u => u.UserName == user.UserName))
            {
                var userStore = new UserStore<DbUser>(context);
                var result = userStore.CreateAsync(user);
            }

            if (!context.UserRoles.Any(u => u.UserId == user.Id))
            {
                var roleId = context.Roles.FirstOrDefault(r => r.Name == "administrator").Id;
                var userRole = new DbUserRole()
                {
                    UserId = user.Id,
                    RoleId = roleId
                };
                if (roleId != null)
                    context.UserRoles.Add(userRole);
            }
            context.SaveChangesAsync();
        }

        public static void SeedData(IServiceProvider services, IHostingEnvironment env, IConfiguration config)
        {
            using (var scope = services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<EFDbContext>();
                SeederDB.SeedGame(context);
            }
        }
    }
}
