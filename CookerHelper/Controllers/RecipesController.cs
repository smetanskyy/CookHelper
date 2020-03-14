using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CookerHelper.DAL.Interfaces;
using CookerHelper.ViewModels;
using Microsoft.AspNetCore.Mvc;

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