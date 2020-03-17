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
                Name = "user",
                NormalizedName = "USER"
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
            user.UserName = "stepan"; ;
            user.NormalizedUserName = "STEPAN";
            user.PhoneNumber = "HUAWEI";
            user.PhoneNumberConfirmed = true;
            user.SecurityStamp = Guid.NewGuid().ToString("D");
            //user.TwoFactorEnabled = true;

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
        private static void SeedIngredients(EFDbContext context)
        {
            int id = 0;
            var ingredient = new Ingredient()
            {
                IngredientId = ++id,
                NameUA = "Абрикоси",
                NameENG = "",
                ProteinPer100g = 0.9,
                FatPer100g = 0.0,
                CarbohydratesPer100g = 10.5,
                CaloriesPer100g = 45,
                Worth1kg = 1.0,
                KindOfIngredientId = 8,
                Image = ".jpg"
            };
            if (!context.Ingredients.Any(i => i.NameUA == ingredient.NameUA))
            {
                context.Ingredients.Add(ingredient);
                context.SaveChanges();
            }

            ingredient = new Ingredient()
            {
                IngredientId = ++id,
                NameUA = "Аґрус",
                NameENG = "",
                ProteinPer100g = 0.7,
                FatPer100g = 0.0,
                CarbohydratesPer100g = 9.9,
                CaloriesPer100g = 42,
                Worth1kg = 1.0,
                KindOfIngredientId = 8,
                Image = ".jpg"
            };
            if (!context.Ingredients.Any(i => i.NameUA == ingredient.NameUA))
            {
                context.Ingredients.Add(ingredient);
                context.SaveChanges();
            }

            ingredient = new Ingredient()
            {
                IngredientId = ++id,
                NameUA = "Айва",
                NameENG = "",
                ProteinPer100g = 0.6,
                FatPer100g = 0.0,
                CarbohydratesPer100g = 8.9,
                CaloriesPer100g = 38,
                Worth1kg = 1.0,
                KindOfIngredientId = 8,
                Image = ".jpg"
            };
            if (!context.Ingredients.Any(i => i.NameUA == ingredient.NameUA))
            {
                context.Ingredients.Add(ingredient);
                context.SaveChanges();
            }

            ingredient = new Ingredient()
            {
                IngredientId = ++id,
                NameUA = "Алича",
                NameENG = "",
                ProteinPer100g = 0.2,
                FatPer100g = 0.0,
                CarbohydratesPer100g = 7.4,
                CaloriesPer100g = 30,
                Worth1kg = 1.0,
                KindOfIngredientId = 8,
                Image = ".jpg"
            };
            if (!context.Ingredients.Any(i => i.NameUA == ingredient.NameUA))
            {
                context.Ingredients.Add(ingredient);
                context.SaveChanges();
            }

            ingredient = new Ingredient()
            {
                IngredientId = ++id,
                NameUA = "Ананас",
                NameENG = "",
                ProteinPer100g = 0.4,
                FatPer100g = 0.0,
                CarbohydratesPer100g = 11.8,
                CaloriesPer100g = 48,
                Worth1kg = 3.0,
                KindOfIngredientId = 8,
                Image = ".jpg"
            };
            if (!context.Ingredients.Any(i => i.NameUA == ingredient.NameUA))
            {
                context.Ingredients.Add(ingredient);
                context.SaveChanges();
            }

            ingredient = new Ingredient()
            {
                IngredientId = ++id,
                NameUA = "Апельсин",
                NameENG = "",
                ProteinPer100g = 0.9,
                FatPer100g = 0.0,
                CarbohydratesPer100g = 8.4,
                CaloriesPer100g = 37,
                Worth1kg = 1,
                KindOfIngredientId = 8,
                Image = ".jpg"
            };
            if (!context.Ingredients.Any(i => i.NameUA == ingredient.NameUA))
            {
                context.Ingredients.Add(ingredient);
                context.SaveChanges();
            }

            ingredient = new Ingredient()
            {
                IngredientId = ++id,
                NameUA = "Арахіс",
                NameENG = "",
                ProteinPer100g = 26.3,
                FatPer100g = 45.2,
                CarbohydratesPer100g = 9.7,
                CaloriesPer100g = 550,
                Worth1kg = 4,
                KindOfIngredientId = 3,
                Image = ".jpg"
            };
            if (!context.Ingredients.Any(i => i.NameUA == ingredient.NameUA))
            {
                context.Ingredients.Add(ingredient);
                context.SaveChanges();
            }

            ingredient = new Ingredient()
            {
                IngredientId = ++id,
                NameUA = "Баклажани",
                NameENG = "",
                ProteinPer100g = 0.6,
                FatPer100g = 0.1,
                CarbohydratesPer100g = 5.5,
                CaloriesPer100g = 25,
                Worth1kg = 1,
                KindOfIngredientId = 1,
                Image = ".jpg"
            };
            if (!context.Ingredients.Any(i => i.NameUA == ingredient.NameUA))
            {
                context.Ingredients.Add(ingredient);
                context.SaveChanges();
            }

            ingredient = new Ingredient()
            {
                IngredientId = ++id,
                NameUA = "Банани",
                NameENG = "",
                ProteinPer100g = 1.5,
                FatPer100g = 0.0,
                CarbohydratesPer100g = 22,
                CaloriesPer100g = 94,
                Worth1kg = 1,
                KindOfIngredientId = 8,
                Image = ".jpg"
            };
            if (!context.Ingredients.Any(i => i.NameUA == ingredient.NameUA))
            {
                context.Ingredients.Add(ingredient);
                context.SaveChanges();
            }

            ingredient = new Ingredient()
            {
                IngredientId = ++id,
                NameUA = "Баранина",
                NameENG = "",
                ProteinPer100g = 16.3,
                FatPer100g = 15.3,
                CarbohydratesPer100g = 0,
                CaloriesPer100g = 202,
                Worth1kg = 8,
                KindOfIngredientId = 4,
                Image = ".jpg"
            };
            if (!context.Ingredients.Any(i => i.NameUA == ingredient.NameUA))
            {
                context.Ingredients.Add(ingredient);
                context.SaveChanges();
            }

            ingredient = new Ingredient()
            {
                IngredientId = ++id,
                NameUA = "Бички",
                NameENG = "12.8",
                ProteinPer100g = 12.8,
                FatPer100g = 8.1,
                CarbohydratesPer100g = 5.2,
                CaloriesPer100g = 144,
                Worth1kg = 1,
                KindOfIngredientId = 9,
                Image = ".jpg"
            };
            if (!context.Ingredients.Any(i => i.NameUA == ingredient.NameUA))
            {
                context.Ingredients.Add(ingredient);
                context.SaveChanges();
            }

            ingredient = new Ingredient()
            {
                IngredientId = ++id,
                NameUA = "Боби",
                NameENG = "",
                ProteinPer100g = 6,
                FatPer100g = 0.1,
                CarbohydratesPer100g = 8.3,
                CaloriesPer100g = 58,
                Worth1kg = 2,
                KindOfIngredientId = 3,
                Image = ".jpg"
            };
            if (!context.Ingredients.Any(i => i.NameUA == ingredient.NameUA))
            {
                context.Ingredients.Add(ingredient);
                context.SaveChanges();
            }

            ingredient = new Ingredient()
            {
                IngredientId = ++id,
                NameUA = "Борошно житнє",
                NameENG = "",
                ProteinPer100g = 6.9,
                FatPer100g = 1.1,
                CarbohydratesPer100g = 76.9,
                CaloriesPer100g = 345,
                Worth1kg = 2,
                KindOfIngredientId = 3,
                Image = ".jpg"
            };
            if (!context.Ingredients.Any(i => i.NameUA == ingredient.NameUA))
            {
                context.Ingredients.Add(ingredient);
                context.SaveChanges();
            }

            ingredient = new Ingredient()
            {
                IngredientId = ++id,
                NameUA = "Борошно пшеничне",
                NameENG = "",
                ProteinPer100g = 10.3,
                FatPer100g = 0.9,
                CarbohydratesPer100g = 74.2,
                CaloriesPer100g = 346,
                Worth1kg = 1.5,
                KindOfIngredientId = 3,
                Image = ".jpg"
            };
            if (!context.Ingredients.Any(i => i.NameUA == ingredient.NameUA))
            {
                context.Ingredients.Add(ingredient);
                context.SaveChanges();
            }

            ingredient = new Ingredient()
            {
                IngredientId = ++id,
                NameUA = "Бринза",
                NameENG = "",
                ProteinPer100g = 17.9,
                FatPer100g = 20.1,
                CarbohydratesPer100g = 0.0,
                CaloriesPer100g = 252,
                Worth1kg = 5,
                KindOfIngredientId = 7,
                Image = ".jpg"
            };
            if (!context.Ingredients.Any(i => i.NameUA == ingredient.NameUA))
            {
                context.Ingredients.Add(ingredient);
                context.SaveChanges();
            }

            ingredient = new Ingredient()
            {
                IngredientId = ++id,
                NameUA = "Бруква",
                NameENG = "",
                ProteinPer100g = 1.2,
                FatPer100g = 0.1,
                CarbohydratesPer100g = 8.1,
                CaloriesPer100g = 38,
                Worth1kg = 1.5,
                KindOfIngredientId = 1,
                Image = ".jpg"
            };
            if (!context.Ingredients.Any(i => i.NameUA == ingredient.NameUA))
            {
                context.Ingredients.Add(ingredient);
                context.SaveChanges();
            }

            ingredient = new Ingredient()
            {
                IngredientId = ++id,
                NameUA = "Брусниця",
                NameENG = "",
                ProteinPer100g = 0.7,
                FatPer100g = 0,
                CarbohydratesPer100g = 8.6,
                CaloriesPer100g = 37,
                Worth1kg = 3,
                KindOfIngredientId = 13,
                Image = ".jpg"
            };
            if (!context.Ingredients.Any(i => i.NameUA == ingredient.NameUA))
            {
                context.Ingredients.Add(ingredient);
                context.SaveChanges();
            }

            ingredient = new Ingredient()
            {
                IngredientId = ++id,
                NameUA = "Буряк",
                NameENG = "",
                ProteinPer100g = 1.7,
                FatPer100g = 0,
                CarbohydratesPer100g = 10.8,
                CaloriesPer100g = 50,
                Worth1kg = 0.5,
                KindOfIngredientId = 1,
                Image = ".jpg"
            };
            if (!context.Ingredients.Any(i => i.NameUA == ingredient.NameUA))
            {
                context.Ingredients.Add(ingredient);
                context.SaveChanges();
            }

            ingredient = new Ingredient()
            {
                IngredientId = ++id,
                NameUA = "Вершки 10% жирності",
                NameENG = "",
                ProteinPer100g = 3,
                FatPer100g = 10,
                CarbohydratesPer100g = 4,
                CaloriesPer100g = 118,
                Worth1kg = 1.5,
                KindOfIngredientId = 7,
                Image = ".jpg"
            };
            if (!context.Ingredients.Any(i => i.NameUA == ingredient.NameUA))
            {
                context.Ingredients.Add(ingredient);
                context.SaveChanges();
            }

            ingredient = new Ingredient()
            {
                IngredientId = ++id,
                NameUA = "Вершки 20% жирності",
                NameENG = "",
                ProteinPer100g = 2.8,
                FatPer100g = 20,
                CarbohydratesPer100g = 3.6,
                CaloriesPer100g = 205,
                Worth1kg = 2,
                KindOfIngredientId = 7,
                Image = ".jpg"
            };
            if (!context.Ingredients.Any(i => i.NameUA == ingredient.NameUA))
            {
                context.Ingredients.Add(ingredient);
                context.SaveChanges();
            }

            ingredient = new Ingredient()
            {
                IngredientId = ++id,
                NameUA = "Виноград",
                NameENG = "",
                ProteinPer100g = 1,
                FatPer100g = 1,
                CarbohydratesPer100g = 18,
                CaloriesPer100g = 85,
                Worth1kg = 3,
                KindOfIngredientId = 8,
                Image = ".jpg"
            };
            if (!context.Ingredients.Any(i => i.NameUA == ingredient.NameUA))
            {
                context.Ingredients.Add(ingredient);
                context.SaveChanges();
            }

            ingredient = new Ingredient()
            {
                IngredientId = ++id,
                NameUA = "Волоський горіх",
                NameENG = "",
                ProteinPer100g = 13.8,
                FatPer100g = 61.3,
                CarbohydratesPer100g = 10.2,
                CaloriesPer100g = 647,
                Worth1kg = 3.5,
                KindOfIngredientId = 11,
                Image = ".jpg"
            };
            if (!context.Ingredients.Any(i => i.NameUA == ingredient.NameUA))
            {
                context.Ingredients.Add(ingredient);
                context.SaveChanges();
            }

            ingredient = new Ingredient()
            {
                IngredientId = ++id,
                NameUA = "Вугільна риба",
                NameENG = "",
                ProteinPer100g = 13.2,
                FatPer100g = 11.6,
                CarbohydratesPer100g = 0.0,
                CaloriesPer100g = 157,
                Worth1kg = 14,
                KindOfIngredientId = 9,
                Image = ".jpg"
            };
            if (!context.Ingredients.Any(i => i.NameUA == ingredient.NameUA))
            {
                context.Ingredients.Add(ingredient);
                context.SaveChanges();
            }

            ingredient = new Ingredient()
            {
                IngredientId = ++id,
                NameUA = "Вугор",
                NameENG = "",
                ProteinPer100g = 14.5,
                FatPer100g = 30.5,
                CarbohydratesPer100g = 0,
                CaloriesPer100g = 332,
                Worth1kg = 20,
                KindOfIngredientId = 9,
                Image = ".jpg"
            };
            if (!context.Ingredients.Any(i => i.NameUA == ingredient.NameUA))
            {
                context.Ingredients.Add(ingredient);
                context.SaveChanges();
            }

            ingredient = new Ingredient()
            {
                IngredientId = ++id,
                NameUA = "Вугор морський",
                NameENG = "",
                ProteinPer100g = 19.1,
                FatPer100g = 1.9,
                CarbohydratesPer100g = 0,
                CaloriesPer100g = 93,
                Worth1kg = 30,
                KindOfIngredientId = 9,
                Image = ".jpg"
            };
            if (!context.Ingredients.Any(i => i.NameUA == ingredient.NameUA))
            {
                context.Ingredients.Add(ingredient);
                context.SaveChanges();
            }

            ingredient = new Ingredient()
            {
                IngredientId = ++id,
                NameUA = "Геркулес",
                NameENG = "",
                ProteinPer100g = 13.1,
                FatPer100g = 6.2,
                CarbohydratesPer100g = 65.7,
                CaloriesPer100g = 371,
                Worth1kg = 1,
                KindOfIngredientId = 3,
                Image = ".jpg"
            };
            if (!context.Ingredients.Any(i => i.NameUA == ingredient.NameUA))
            {
                context.Ingredients.Add(ingredient);
                context.SaveChanges();
            }

            ingredient = new Ingredient()
            {
                IngredientId = ++id,
                NameUA = "Горбуша",
                NameENG = "",
                ProteinPer100g = 21,
                FatPer100g = 7,
                CarbohydratesPer100g = 0,
                CaloriesPer100g = 147,
                Worth1kg = 3,
                KindOfIngredientId = 9,
                Image = ".jpg"
            };
            if (!context.Ingredients.Any(i => i.NameUA == ingredient.NameUA))
            {
                context.Ingredients.Add(ingredient);
                context.SaveChanges();
            }

            ingredient = new Ingredient()
            {
                IngredientId = ++id,
                NameUA = "Горобина",
                NameENG = "",
                ProteinPer100g = 1.4,
                FatPer100g = 0,
                CarbohydratesPer100g = 12.5,
                CaloriesPer100g = 55,
                Worth1kg = 4,
                KindOfIngredientId = 13,
                Image = ".jpg"
            };
            if (!context.Ingredients.Any(i => i.NameUA == ingredient.NameUA))
            {
                context.Ingredients.Add(ingredient);
                context.SaveChanges();
            }

            ingredient = new Ingredient()
            {
                IngredientId = ++id,
                NameUA = "Горох лущений",
                NameENG = "",
                ProteinPer100g = 23,
                FatPer100g = 1.6,
                CarbohydratesPer100g = 57.7,
                CaloriesPer100g = 337,
                Worth1kg = 2,
                KindOfIngredientId = 3,
                Image = ".jpg"
            };
            if (!context.Ingredients.Any(i => i.NameUA == ingredient.NameUA))
            {
                context.Ingredients.Add(ingredient);
                context.SaveChanges();
            }

            ingredient = new Ingredient()
            {
                IngredientId = ++id,
                NameUA = "Горох цілий",
                NameENG = "",
                ProteinPer100g = 23,
                FatPer100g = 1.2,
                CarbohydratesPer100g = 53.3,
                CaloriesPer100g = 316,
                Worth1kg = 2,
                KindOfIngredientId = 3,
                Image = ".jpg"
            };
            if (!context.Ingredients.Any(i => i.NameUA == ingredient.NameUA))
            {
                context.Ingredients.Add(ingredient);
                context.SaveChanges();
            }

            ingredient = new Ingredient()
            {
                IngredientId = ++id,
                NameUA = "Горошок зелений",
                NameENG = "",
                ProteinPer100g = 5,
                FatPer100g = 0.2,
                CarbohydratesPer100g = 13.3,
                CaloriesPer100g = 75,
                Worth1kg = 2,
                KindOfIngredientId = 3,
                Image = ".jpg"
            };
            if (!context.Ingredients.Any(i => i.NameUA == ingredient.NameUA))
            {
                context.Ingredients.Add(ingredient);
                context.SaveChanges();
            }

            ingredient = new Ingredient()
            {
                IngredientId = ++id,
                NameUA = "Гранат",
                NameENG = "",
                ProteinPer100g = 0.9,
                FatPer100g = 0,
                CarbohydratesPer100g = 11.8,
                CaloriesPer100g = 50,
                Worth1kg = 3,
                KindOfIngredientId = 8,
                Image = ".jpg"
            };
            if (!context.Ingredients.Any(i => i.NameUA == ingredient.NameUA))
            {
                context.Ingredients.Add(ingredient);
                context.SaveChanges();
            }

            ingredient = new Ingredient()
            {
                IngredientId = ++id,
                NameUA = "Грейпфрут",
                NameENG = "",
                ProteinPer100g = 0.9,
                FatPer100g = 0,
                CarbohydratesPer100g = 7.3,
                CaloriesPer100g = 32,
                Worth1kg = 2,
                KindOfIngredientId = 8,
                Image = ".jpg"
            };
            if (!context.Ingredients.Any(i => i.NameUA == ingredient.NameUA))
            {
                context.Ingredients.Add(ingredient);
                context.SaveChanges();
            }

            ingredient = new Ingredient()
            {
                IngredientId = ++id,
                NameUA = "Гриби білі свіжі",
                NameENG = "",
                ProteinPer100g = 3.2,
                FatPer100g = 0.7,
                CarbohydratesPer100g = 1.6,
                CaloriesPer100g = 25,
                Worth1kg = 8,
                KindOfIngredientId = 1,
                Image = ".jpg"
            };
            if (!context.Ingredients.Any(i => i.NameUA == ingredient.NameUA))
            {
                context.Ingredients.Add(ingredient);
                context.SaveChanges();
            }

            ingredient = new Ingredient()
            {
                IngredientId = ++id,
                NameUA = "Гриби білі сушені",
                NameENG = "",
                ProteinPer100g = 27.6,
                FatPer100g = 6.8,
                CarbohydratesPer100g = 10,
                CaloriesPer100g = 211,
                Worth1kg = 16,
                KindOfIngredientId = 1,
                Image = ".jpg"
            };
            if (!context.Ingredients.Any(i => i.NameUA == ingredient.NameUA))
            {
                context.Ingredients.Add(ingredient);
                context.SaveChanges();
            }

            ingredient = new Ingredient()
            {
                IngredientId = ++id,
                NameUA = "Грудинка сирокопчена",
                NameENG = "",
                ProteinPer100g = 7.6,
                FatPer100g = 66.8,
                CarbohydratesPer100g = 0,
                CaloriesPer100g = 631,
                Worth1kg = 7,
                KindOfIngredientId = 4,
                Image = ".jpg"
            };
            if (!context.Ingredients.Any(i => i.NameUA == ingredient.NameUA))
            {
                context.Ingredients.Add(ingredient);
                context.SaveChanges();
            }

            ingredient = new Ingredient()
            {
                IngredientId = ++id,
                NameUA = "Журавлина",
                NameENG = "",
                ProteinPer100g = 0.5,
                FatPer100g = 0,
                CarbohydratesPer100g = 4.8,
                CaloriesPer100g = 21,
                Worth1kg = 3,
                KindOfIngredientId = 13,
                Image = ".jpg"
            };
            if (!context.Ingredients.Any(i => i.NameUA == ingredient.NameUA))
            {
                context.Ingredients.Add(ingredient);
                context.SaveChanges();
            }

            ingredient = new Ingredient()
            {
                IngredientId = ++id,
                NameUA = "Зелена квасоля",
                NameENG = "",
                ProteinPer100g = 4,
                FatPer100g = 0,
                CarbohydratesPer100g = 4.3,
                CaloriesPer100g = 33,
                Worth1kg = 2,
                KindOfIngredientId = 3,
                Image = ".jpg"
            };
            if (!context.Ingredients.Any(i => i.NameUA == ingredient.NameUA))
            {
                context.Ingredients.Add(ingredient);
                context.SaveChanges();
            }

            ingredient = new Ingredient()
            {
                IngredientId = ++id,
                NameUA = "Зефір",
                NameENG = "",
                ProteinPer100g = 0.8,
                FatPer100g = 0,
                CarbohydratesPer100g = 78.3,
                CaloriesPer100g = 318,
                Worth1kg = 4,
                KindOfIngredientId = 13,
                Image = ".jpg"
            };
            if (!context.Ingredients.Any(i => i.NameUA == ingredient.NameUA))
            {
                context.Ingredients.Add(ingredient);
                context.SaveChanges();
            }

            ingredient = new Ingredient()
            {
                IngredientId = ++id,
                NameUA = "Індичка",
                NameENG = "",
                ProteinPer100g = 21.6,
                FatPer100g = 12,
                CarbohydratesPer100g = 0.8,
                CaloriesPer100g = 197,
                Worth1kg = 5,
                KindOfIngredientId = 5,
                Image = ".jpg"
            };
            if (!context.Ingredients.Any(i => i.NameUA == ingredient.NameUA))
            {
                context.Ingredients.Add(ingredient);
                context.SaveChanges();
            }

            ingredient = new Ingredient()
            {
                IngredientId = ++id,
                NameUA = "Інжир",
                NameENG = "",
                ProteinPer100g = 0.7,
                FatPer100g = 0,
                CarbohydratesPer100g = 13.9,
                CaloriesPer100g = 58,
                Worth1kg = 5,
                KindOfIngredientId = 8,
                Image = ".jpg"
            };
            if (!context.Ingredients.Any(i => i.NameUA == ingredient.NameUA))
            {
                context.Ingredients.Add(ingredient);
                context.SaveChanges();
            }

            ingredient = new Ingredient()
            {
                IngredientId = ++id,
                NameUA = "Кабачки",
                NameENG = "",
                ProteinPer100g = 0.6,
                FatPer100g = 0.3,
                CarbohydratesPer100g = 5.7,
                CaloriesPer100g = 27,
                Worth1kg = 1,
                KindOfIngredientId = 1,
                Image = ".jpg"
            };
            if (!context.Ingredients.Any(i => i.NameUA == ingredient.NameUA))
            {
                context.Ingredients.Add(ingredient);
                context.SaveChanges();
            }

            ingredient = new Ingredient()
            {
                IngredientId = ++id,
                NameUA = "Кавуни",
                NameENG = "",
                ProteinPer100g = 0.5,
                FatPer100g = 0.2,
                CarbohydratesPer100g = 6,
                CaloriesPer100g = 27,
                Worth1kg = 0.5,
                KindOfIngredientId = 8,
                Image = ".jpg"
            };
            if (!context.Ingredients.Any(i => i.NameUA == ingredient.NameUA))
            {
                context.Ingredients.Add(ingredient);
                context.SaveChanges();
            }

            ingredient = new Ingredient()
            {
                IngredientId = ++id,
                NameUA = "Кальмар",
                NameENG = "",
                ProteinPer100g = 18,
                FatPer100g = 0.3,
                CarbohydratesPer100g = 0,
                CaloriesPer100g = 74,
                Worth1kg = 8,
                KindOfIngredientId = 9,
                Image = ".jpg"
            };
            if (!context.Ingredients.Any(i => i.NameUA == ingredient.NameUA))
            {
                context.Ingredients.Add(ingredient);
                context.SaveChanges();
            }

            ingredient = new Ingredient()
            {
                IngredientId = ++id,
                NameUA = "Камбала",
                NameENG = "",
                ProteinPer100g = 16.1,
                FatPer100g = 2.6,
                CarbohydratesPer100g = 0,
                CaloriesPer100g = 87,
                Worth1kg = 3,
                KindOfIngredientId = 9,
                Image = ".jpg"
            };
            if (!context.Ingredients.Any(i => i.NameUA == ingredient.NameUA))
            {
                context.Ingredients.Add(ingredient);
                context.SaveChanges();
            }

            ingredient = new Ingredient()
            {
                IngredientId = ++id,
                NameUA = "Капуста білокачана",
                NameENG = "",
                ProteinPer100g = 1.8,
                FatPer100g = 0,
                CarbohydratesPer100g = 5.4,
                CaloriesPer100g = 28,
                Worth1kg = 0.5,
                KindOfIngredientId = 1,
                Image = ".jpg"
            };
            if (!context.Ingredients.Any(i => i.NameUA == ingredient.NameUA))
            {
                context.Ingredients.Add(ingredient);
                context.SaveChanges();
            }

            ingredient = new Ingredient()
            {
                IngredientId = ++id,
                NameUA = "Капуста цвітна",
                NameENG = "",
                ProteinPer100g = 2.5,
                FatPer100g = 0,
                CarbohydratesPer100g = 4.9,
                CaloriesPer100g = 29,
                Worth1kg = 1,
                KindOfIngredientId = 1,
                Image = ".jpg"
            };
            if (!context.Ingredients.Any(i => i.NameUA == ingredient.NameUA))
            {
                context.Ingredients.Add(ingredient);
                context.SaveChanges();
            }

            ingredient = new Ingredient()
            {
                IngredientId = ++id,
                NameUA = "Карамель",
                NameENG = "",
                ProteinPer100g = 0,
                FatPer100g = 0.1,
                CarbohydratesPer100g = 77.7,
                CaloriesPer100g = 311,
                Worth1kg = 2,
                KindOfIngredientId = 10,
                Image = ".jpg"
            };
            if (!context.Ingredients.Any(i => i.NameUA == ingredient.NameUA))
            {
                context.Ingredients.Add(ingredient);
                context.SaveChanges();
            }

            ingredient = new Ingredient()
            {
                IngredientId = ++id,
                NameUA = "Карась",
                NameENG = "",
                ProteinPer100g = 17.7,
                FatPer100g = 1.8,
                CarbohydratesPer100g = 0,
                CaloriesPer100g = 87,
                Worth1kg = 2,
                KindOfIngredientId = 9,
                Image = ".jpg"
            };
            if (!context.Ingredients.Any(i => i.NameUA == ingredient.NameUA))
            {
                context.Ingredients.Add(ingredient);
                context.SaveChanges();
            }

            ingredient = new Ingredient()
            {
                IngredientId = ++id,
                NameUA = "Картопля",
                NameENG = "",
                ProteinPer100g = 2,
                FatPer100g = 0.1,
                CarbohydratesPer100g = 19.7,
                CaloriesPer100g = 87,
                Worth1kg = 0.5,
                KindOfIngredientId = 1,
                Image = ".jpg"
            };
            if (!context.Ingredients.Any(i => i.NameUA == ingredient.NameUA))
            {
                context.Ingredients.Add(ingredient);
                context.SaveChanges();
            }

            //ingredient = new Ingredient()
            //{
            //    IngredientId = ++id,
            //    NameUA = "",
            //    NameENG = "",
            //    ProteinPer100g = ,
            //    FatPer100g = ,
            //    CarbohydratesPer100g = ,
            //    CaloriesPer100g = ,
            //    Worth1kg = ,
            //    KindOfIngredientId = ,
            //    Image = ".jpg"
            //};
            //if (!context.Ingredients.Any(i => i.NameUA == ingredient.NameUA))
            //{
            //    context.Ingredients.Add(ingredient);
            //    context.SaveChanges();
            //}

        }

        private static void SeedMeasuring(EFDbContext context)
        {
            var measuring = new Measuring()
            {
                MeasuringId = 1,
                MeasuringNameUA = "кг",
                MeasuringNameENG = "kg"
            };
            if (!context.Measurings.Any(m => m.MeasuringNameUA == measuring.MeasuringNameUA))
            {
                context.Measurings.Add(measuring);
                context.SaveChanges();
            }

            measuring = new Measuring()
            {
                MeasuringId = 2,
                MeasuringNameUA = "г",
                MeasuringNameENG = "g"
            };
            if (!context.Measurings.Any(m => m.MeasuringNameUA == measuring.MeasuringNameUA))
            {
                context.Measurings.Add(measuring);
                context.SaveChanges();
            }

            measuring = new Measuring()
            {
                MeasuringId = 3,
                MeasuringNameUA = "",
                MeasuringNameENG = ""
            };
            if (!context.Measurings.Any(m => m.MeasuringNameUA == measuring.MeasuringNameUA))
            {
                context.Measurings.Add(measuring);
                context.SaveChanges();
            }

            measuring = new Measuring()
            {
                MeasuringId = 4,
                MeasuringNameUA = "шт.",
                MeasuringNameENG = ""
            };
            if (!context.Measurings.Any(m => m.MeasuringNameUA == measuring.MeasuringNameUA))
            {
                context.Measurings.Add(measuring);
                context.SaveChanges();
            }

            measuring = new Measuring()
            {
                MeasuringId = 5,
                MeasuringNameUA = "склянка",
                MeasuringNameENG = ""
            };
            if (!context.Measurings.Any(m => m.MeasuringNameUA == measuring.MeasuringNameUA))
            {
                context.Measurings.Add(measuring);
                context.SaveChanges();
            }

            measuring = new Measuring()
            {
                MeasuringId = 6,
                MeasuringNameUA = "зубки",
                MeasuringNameENG = ""
            };
            if (!context.Measurings.Any(m => m.MeasuringNameUA == measuring.MeasuringNameUA))
            {
                context.Measurings.Add(measuring);
                context.SaveChanges();
            }

            measuring = new Measuring()
            {
                MeasuringId = 7,
                MeasuringNameUA = "ст. л.",
                MeasuringNameENG = ""
            };
            if (!context.Measurings.Any(m => m.MeasuringNameUA == measuring.MeasuringNameUA))
            {
                context.Measurings.Add(measuring);
                context.SaveChanges();
            }

            measuring = new Measuring()
            {
                MeasuringId = 8,
                MeasuringNameUA = "ч. л.",
                MeasuringNameENG = ""
            };
            if (!context.Measurings.Any(m => m.MeasuringNameUA == measuring.MeasuringNameUA))
            {
                context.Measurings.Add(measuring);
                context.SaveChanges();
            }

            measuring = new Measuring()
            {
                MeasuringId = 9,
                MeasuringNameUA = "за смаком",
                MeasuringNameENG = ""
            };
            if (!context.Measurings.Any(m => m.MeasuringNameUA == measuring.MeasuringNameUA))
            {
                context.Measurings.Add(measuring);
                context.SaveChanges();
            }

            measuring = new Measuring()
            {
                MeasuringId = 10,
                MeasuringNameUA = "мл",
                MeasuringNameENG = ""
            };
            if (!context.Measurings.Any(m => m.MeasuringNameUA == measuring.MeasuringNameUA))
            {
                context.Measurings.Add(measuring);
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
                SeedIngredients(context);
                SeedMeasuring(context);
                SeedRecipes(context);
            }
        }
    }
}
