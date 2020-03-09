using CookerHelper.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookerHelper.DAL.EFContext
{
    public class EFDbContext : IdentityDbContext<DbUser, DbRole, string, IdentityUserClaim<string>,
  DbUserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public EFDbContext(DbContextOptions<EFDbContext> options) : base(options) { }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<KindOfDish> KindsOfDishes { get; set; }
        public virtual DbSet<KindOfIngredient> KindsOfIngredients { get; set; }
        public virtual DbSet<KindOfKitchen> KindsOfKitchens { get; set; }
        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<RecipeImage> RecipesImages { get; set; }
        public virtual DbSet<RecipeIngredients> RecipesIngredients { get; set; }
        public virtual DbSet<Measuring> Measurings { get; set; }

        public virtual DbSet<UserProfile> UserProfile { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<DbUserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });
        }
    }
}
