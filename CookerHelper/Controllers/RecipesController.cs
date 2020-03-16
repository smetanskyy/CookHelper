using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CookerHelper.DAL.Interfaces;
using CookerHelper.Models;
using CookerHelper.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CookerHelper.Controllers
{
    public class RecipesController : Controller
    {
        private readonly IKindsOfDishes _kindsOfDishes;
        public RecipesController(IKindsOfDishes kindsOfDishes)
        {
            _kindsOfDishes = kindsOfDishes;
        }

        public IActionResult Index()
        {
            var userInfo = HttpContext.Session.GetString("SessionUser");

            if (userInfo != null)
            {
                var rezult = JsonConvert.DeserializeObject<UserInfo>(userInfo);
            }

            KindsOfDishesVM kindsOfDishesVM = new KindsOfDishesVM();
            kindsOfDishesVM.KindsOfDishes = _kindsOfDishes.KindsOfDishes.ToList();
            foreach (var item in kindsOfDishesVM.KindsOfDishes)
            {
                item.Image = Path.Combine("/imgKindsOfDishes", item.Image);
            }
            kindsOfDishesVM.Length = _kindsOfDishes.KindsOfDishes.Count();

            return View(kindsOfDishesVM);
        }
    }
}