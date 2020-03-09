using CookerHelper.Models;
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

        private static void SeedKindsOfIngredients(EFDbContext context)
        {
            var kindOfIngredient = new KindOfIngredient()
            {
                KindOfIngredientId = 1,
                KindOfIngredientNameENG = "Vegetables",
                KindOfIngredientNameUA = "Овочі",
                Image = "Vegetables.jpg"
            };
            if (!context.KindsOfIngredients.Any(k => k.KindOfIngredientNameENG == kindOfIngredient.KindOfIngredientNameENG))
            {
                context.KindsOfIngredients.Add(kindOfIngredient);
                context.SaveChanges();
            }

            kindOfIngredient = new KindOfIngredient()
            {
                KindOfIngredientId = 2,
                KindOfIngredientNameENG = "Spices and Herbs",
                KindOfIngredientNameUA = "Спеції та трави",
                Image = "SpicesAndHerbs.jpg"
            };
            if (!context.KindsOfIngredients.Any(k => k.KindOfIngredientNameENG == kindOfIngredient.KindOfIngredientNameENG))
            {
                context.KindsOfIngredients.Add(kindOfIngredient);
                context.SaveChanges();
            }

            kindOfIngredient = new KindOfIngredient()
            {
                KindOfIngredientId = 3,
                KindOfIngredientNameENG = "Cereals and Pulses",
                KindOfIngredientNameUA = "Зернові та бобові культури",
                Image = "CerealsAndPulses.jpg"
            };
            if (!context.KindsOfIngredients.Any(k => k.KindOfIngredientNameENG == kindOfIngredient.KindOfIngredientNameENG))
            {
                context.KindsOfIngredients.Add(kindOfIngredient);
                context.SaveChanges();
            }

            kindOfIngredient = new KindOfIngredient()
            {
                KindOfIngredientId = 4,
                KindOfIngredientNameENG = "Meat",
                KindOfIngredientNameUA = "М'ясо",
                Image = "Meat.jpg"
            };
            if (!context.KindsOfIngredients.Any(k => k.KindOfIngredientNameENG == kindOfIngredient.KindOfIngredientNameENG))
            {
                context.KindsOfIngredients.Add(kindOfIngredient);
                context.SaveChanges();
            }

            kindOfIngredient = new KindOfIngredient()
            {
                KindOfIngredientId = 5,
                KindOfIngredientNameENG = "Poultry",
                KindOfIngredientNameUA = "Птиця",
                Image = "Poultry.jpg"
            };
            if (!context.KindsOfIngredients.Any(k => k.KindOfIngredientNameENG == kindOfIngredient.KindOfIngredientNameENG))
            {
                context.KindsOfIngredients.Add(kindOfIngredient);
                context.SaveChanges();
            }

            kindOfIngredient = new KindOfIngredient()
            {
                KindOfIngredientId = 6,
                KindOfIngredientNameENG = "Pork",
                KindOfIngredientNameUA = "Свинина",
                Image = "Pork.jpg"
            };
            if (!context.KindsOfIngredients.Any(k => k.KindOfIngredientNameENG == kindOfIngredient.KindOfIngredientNameENG))
            {
                context.KindsOfIngredients.Add(kindOfIngredient);
                context.SaveChanges();
            }

            kindOfIngredient = new KindOfIngredient()
            {
                KindOfIngredientId = 7,
                KindOfIngredientNameENG = "Dairy Products",
                KindOfIngredientNameUA = "Молочні продукти",
                Image = "DairyProducts.jpg"
            };
            if (!context.KindsOfIngredients.Any(k => k.KindOfIngredientNameENG == kindOfIngredient.KindOfIngredientNameENG))
            {
                context.KindsOfIngredients.Add(kindOfIngredient);
                context.SaveChanges();
            }

            kindOfIngredient = new KindOfIngredient()
            {
                KindOfIngredientId = 8,
                KindOfIngredientNameENG = "Fruits",
                KindOfIngredientNameUA = "Фрукти",
                Image = "Fruits.jpg"
            };
            if (!context.KindsOfIngredients.Any(k => k.KindOfIngredientNameENG == kindOfIngredient.KindOfIngredientNameENG))
            {
                context.KindsOfIngredients.Add(kindOfIngredient);
                context.SaveChanges();
            }

            kindOfIngredient = new KindOfIngredient()
            {
                KindOfIngredientId = 9,
                KindOfIngredientNameENG = "Fish & Seafood",
                KindOfIngredientNameUA = "Риба і морепродукти",
                Image = "Seafood.jpg"
            };
            if (!context.KindsOfIngredients.Any(k => k.KindOfIngredientNameENG == kindOfIngredient.KindOfIngredientNameENG))
            {
                context.KindsOfIngredients.Add(kindOfIngredient);
                context.SaveChanges();
            }

            kindOfIngredient = new KindOfIngredient()
            {
                KindOfIngredientId = 10,
                KindOfIngredientNameENG = "Sugar and Sugar Products",
                KindOfIngredientNameUA = "Цукор та цукрові продукти",
                Image = "SugarAndSugarProducts.jpg"
            };
            if (!context.KindsOfIngredients.Any(k => k.KindOfIngredientNameENG == kindOfIngredient.KindOfIngredientNameENG))
            {
                context.KindsOfIngredients.Add(kindOfIngredient);
                context.SaveChanges();
            }

            kindOfIngredient = new KindOfIngredient()
            {
                KindOfIngredientId = 11,
                KindOfIngredientNameENG = "Nuts and Oilseeds",
                KindOfIngredientNameUA = "Горіхи та олійні культури",
                Image = "NutsAndOilseeds.jpg"
            };
            if (!context.KindsOfIngredients.Any(k => k.KindOfIngredientNameENG == kindOfIngredient.KindOfIngredientNameENG))
            {
                context.KindsOfIngredients.Add(kindOfIngredient);
                context.SaveChanges();
            }

            kindOfIngredient = new KindOfIngredient()
            {
                KindOfIngredientId = 12,
                KindOfIngredientNameENG = "Eggs",
                KindOfIngredientNameUA = "Яйця",
                Image = "Eggs.jpg"
            };
            if (!context.KindsOfIngredients.Any(k => k.KindOfIngredientNameENG == kindOfIngredient.KindOfIngredientNameENG))
            {
                context.KindsOfIngredients.Add(kindOfIngredient);
                context.SaveChanges();
            }

            kindOfIngredient = new KindOfIngredient()
            {
                KindOfIngredientId = 13,
                KindOfIngredientNameENG = "Other Ingredients",
                KindOfIngredientNameUA = "Інші інгредієнти",
                Image = "OtherIngredients.jpg"
            };
            if (!context.KindsOfIngredients.Any(k => k.KindOfIngredientNameENG == kindOfIngredient.KindOfIngredientNameENG))
            {
                context.KindsOfIngredients.Add(kindOfIngredient);
                context.SaveChanges();
            }
        }
        private static void SeedKindsOfKitchens(EFDbContext context)
        {
            var kindOfKitchen = new KindOfKitchen()
            {
                KindOfKitchenId = 1,
                KindOfKitchenNameENG = "Ukrainian Kitchen",
                KindOfKitchenNameUA = "Українська кухня",
                Image = "UkrainianKitchen.jpg"
            };
            if (!context.KindsOfKitchens.Any(k => k.KindOfKitchenNameENG == kindOfKitchen.KindOfKitchenNameENG))
            {
                context.KindsOfKitchens.Add(kindOfKitchen);
                context.SaveChanges();
            }

            kindOfKitchen = new KindOfKitchen()
            {
                KindOfKitchenId = 2,
                KindOfKitchenNameENG = "Italian Kitchen",
                KindOfKitchenNameUA = "Італійська кухня",
                Image = "UkrainianKitchen.jpg"
            };
            if (!context.KindsOfKitchens.Any(k => k.KindOfKitchenNameENG == kindOfKitchen.KindOfKitchenNameENG))
            {
                context.KindsOfKitchens.Add(kindOfKitchen);
                context.SaveChanges();
            }
        }
        private static void SeedKindsOfDishes(EFDbContext context)
        {
            var kindOfDish = new KindOfDish()
            {
              KindOfDishId = 1,
              KindOfDishNameENG = "Pasta & risotto",
              KindOfDishNameUA = "Паста та різотто",
              Image = "PastaRisotto.jpg"
            };
            if (!context.KindsOfDishes.Any(k => k.KindOfDishNameENG == kindOfDish.KindOfDishNameENG))
            {
                context.KindsOfDishes.Add(kindOfDish);
                context.SaveChanges();
            }

            kindOfDish = new KindOfDish()
            {
                KindOfDishId = 2,
                KindOfDishNameENG = "Salad",
                KindOfDishNameUA = "Салат",
                Image = "Salad.jpg"
            };
            if (!context.KindsOfDishes.Any(k => k.KindOfDishNameENG == kindOfDish.KindOfDishNameENG))
            {
                context.KindsOfDishes.Add(kindOfDish);
                context.SaveChanges();
            }

            kindOfDish = new KindOfDish()
            {
                KindOfDishId = 3,
                KindOfDishNameENG = "Bread & doughs",
                KindOfDishNameUA = "Хліб і тісто",
                Image = "BreadDoughs.jpg"
            };
            if (!context.KindsOfDishes.Any(k => k.KindOfDishNameENG == kindOfDish.KindOfDishNameENG))
            {
                context.KindsOfDishes.Add(kindOfDish);
                context.SaveChanges();
            }

            kindOfDish = new KindOfDish()
            {
                KindOfDishId = 4,
                KindOfDishNameENG = "Curry",
                KindOfDishNameUA = "Каррі",
                Image = "Curry.jpg"
            };
            if (!context.KindsOfDishes.Any(k => k.KindOfDishNameENG == kindOfDish.KindOfDishNameENG))
            {
                context.KindsOfDishes.Add(kindOfDish);
                context.SaveChanges();
            }

            kindOfDish = new KindOfDish()
            {
                KindOfDishId = 5,
                KindOfDishNameENG = "Vegetable sides",
                KindOfDishNameUA = "Овочеві гарніри",
                Image = "VegetableSides.jpg"
            };
            if (!context.KindsOfDishes.Any(k => k.KindOfDishNameENG == kindOfDish.KindOfDishNameENG))
            {
                context.KindsOfDishes.Add(kindOfDish);
                context.SaveChanges();
            }

            kindOfDish = new KindOfDish()
            {
                KindOfDishId = 6,
                KindOfDishNameENG = "Soup",
                KindOfDishNameUA = "Супи",
                Image = "Soup.jpg"
            };
            if (!context.KindsOfDishes.Any(k => k.KindOfDishNameENG == kindOfDish.KindOfDishNameENG))
            {
                context.KindsOfDishes.Add(kindOfDish);
                context.SaveChanges();
            }

            kindOfDish = new KindOfDish()
            {
                KindOfDishId = 7,
                KindOfDishNameENG = "Antipasti",
                KindOfDishNameUA = "Закуски",
                Image = "Antipasti.jpg"
            };
            if (!context.KindsOfDishes.Any(k => k.KindOfDishNameENG == kindOfDish.KindOfDishNameENG))
            {
                context.KindsOfDishes.Add(kindOfDish);
                context.SaveChanges();
            }

            kindOfDish = new KindOfDish()
            {
                KindOfDishId = 8,
                KindOfDishNameENG = "Roast",
                KindOfDishNameUA = "Смаження. Печення",
                Image = "Roast.jpg"
            };
            if (!context.KindsOfDishes.Any(k => k.KindOfDishNameENG == kindOfDish.KindOfDishNameENG))
            {
                context.KindsOfDishes.Add(kindOfDish);
                context.SaveChanges();
            }

            kindOfDish = new KindOfDish()
            {
                KindOfDishId = 9,
                KindOfDishNameENG = "BBQ food",
                KindOfDishNameUA = "BBQ страви",
                Image = "BBQfood.jpg"
            };
            if (!context.KindsOfDishes.Any(k => k.KindOfDishNameENG == kindOfDish.KindOfDishNameENG))
            {
                context.KindsOfDishes.Add(kindOfDish);
                context.SaveChanges();
            }

            kindOfDish = new KindOfDish()
            {
                KindOfDishId = 10,
                KindOfDishNameENG = "Stew",
                KindOfDishNameUA = "Тушковане м'ясо",
                Image = "Stew.jpg"
            };
            if (!context.KindsOfDishes.Any(k => k.KindOfDishNameENG == kindOfDish.KindOfDishNameENG))
            {
                context.KindsOfDishes.Add(kindOfDish);
                context.SaveChanges();
            }

            kindOfDish = new KindOfDish()
            {
                KindOfDishId = 11,
                KindOfDishNameENG = "Pizza",
                KindOfDishNameUA = "Піца",
                Image = "Pizza.jpg"
            };
            if (!context.KindsOfDishes.Any(k => k.KindOfDishNameENG == kindOfDish.KindOfDishNameENG))
            {
                context.KindsOfDishes.Add(kindOfDish);
                context.SaveChanges();
            }

            kindOfDish = new KindOfDish()
            {
                KindOfDishId = 12,
                KindOfDishNameENG = "Sandwiches & wraps",
                KindOfDishNameUA = "Бутерброди. Роли",
                Image = "SandwichesWraps.jpg"
            };
            if (!context.KindsOfDishes.Any(k => k.KindOfDishNameENG == kindOfDish.KindOfDishNameENG))
            {
                context.KindsOfDishes.Add(kindOfDish);
                context.SaveChanges();
            }

            kindOfDish = new KindOfDish()
            {
                KindOfDishId = 13,
                KindOfDishNameENG = "Cakes & teatime treats",
                KindOfDishNameUA = "Торти та частування до чаю",
                Image = "CakesTeatimeTreats.jpg"
            };
            if (!context.KindsOfDishes.Any(k => k.KindOfDishNameENG == kindOfDish.KindOfDishNameENG))
            {
                context.KindsOfDishes.Add(kindOfDish);
                context.SaveChanges();
            }

            kindOfDish = new KindOfDish()
            {
                KindOfDishId = 14,
                KindOfDishNameENG = "Pies & pastries",
                KindOfDishNameUA = "Пироги та випічка",
                Image = "PiesPastries.jpg"
            };
            if (!context.KindsOfDishes.Any(k => k.KindOfDishNameENG == kindOfDish.KindOfDishNameENG))
            {
                context.KindsOfDishes.Add(kindOfDish);
                context.SaveChanges();
            }

            kindOfDish = new KindOfDish()
            {
                KindOfDishId = 15,
                KindOfDishNameENG = "Sauces & condiments",
                KindOfDishNameUA = "Соуси та заправки",
                Image = "SaucesCondiments.jpg"
            };
            if (!context.KindsOfDishes.Any(k => k.KindOfDishNameENG == kindOfDish.KindOfDishNameENG))
            {
                context.KindsOfDishes.Add(kindOfDish);
                context.SaveChanges();
            }

            kindOfDish = new KindOfDish()
            {
                KindOfDishId = 16,
                KindOfDishNameENG = "Puddings & desserts",
                KindOfDishNameUA = "Пудинги та десерти",
                Image = "PuddingsDesserts.jpg"
            };
            if (!context.KindsOfDishes.Any(k => k.KindOfDishNameENG == kindOfDish.KindOfDishNameENG))
            {
                context.KindsOfDishes.Add(kindOfDish);
                context.SaveChanges();
            }

            kindOfDish = new KindOfDish()
            {
                KindOfDishId = 17,
                KindOfDishNameENG = "Drinks",
                KindOfDishNameUA = "Напої",
                Image = "Drinks.jpg"
            };
            if (!context.KindsOfDishes.Any(k => k.KindOfDishNameENG == kindOfDish.KindOfDishNameENG))
            {
                context.KindsOfDishes.Add(kindOfDish);
                context.SaveChanges();
            }

            kindOfDish = new KindOfDish()
            {
                KindOfDishId = 18,
                KindOfDishNameENG = "Cookies",
                KindOfDishNameUA = "Печиво",
                Image = "Cookies.jpg"
            };
            if (!context.KindsOfDishes.Any(k => k.KindOfDishNameENG == kindOfDish.KindOfDishNameENG))
            {
                context.KindsOfDishes.Add(kindOfDish);
                context.SaveChanges();
            }

            kindOfDish = new KindOfDish()
            {
                KindOfDishId = 19,
                KindOfDishNameENG = "Meatballs",
                KindOfDishNameUA = "Фрикадельки. Котлети",
                Image = "Meatballs.jpg"
            };
            if (!context.KindsOfDishes.Any(k => k.KindOfDishNameENG == kindOfDish.KindOfDishNameENG))
            {
                context.KindsOfDishes.Add(kindOfDish);
                context.SaveChanges();
            }

            kindOfDish = new KindOfDish()
            {
                KindOfDishId = 20,
                KindOfDishNameENG = "Muffins",
                KindOfDishNameUA = "Булочки. Кекси",
                Image = "Muffins.jpg"
            };
            if (!context.KindsOfDishes.Any(k => k.KindOfDishNameENG == kindOfDish.KindOfDishNameENG))
            {
                context.KindsOfDishes.Add(kindOfDish);
                context.SaveChanges();
            }

            kindOfDish = new KindOfDish()
            {
                KindOfDishId = 21,
                KindOfDishNameENG = "Bakes",
                KindOfDishNameUA = "Запіканки",
                Image = "Bakes.jpg"
            };
            if (!context.KindsOfDishes.Any(k => k.KindOfDishNameENG == kindOfDish.KindOfDishNameENG))
            {
                context.KindsOfDishes.Add(kindOfDish);
                context.SaveChanges();
            }
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
                SeedKindsOfIngredients(context);
                SeedKindsOfKitchens(context);
                SeedKindsOfDishes(context);
                SeedRecipes(context);
            }
        }
    }
}
