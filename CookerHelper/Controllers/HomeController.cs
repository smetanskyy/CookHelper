using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CookerHelper.Models;
using CookerHelper.DAL.Interfaces;
using CookerHelper.ViewModels;
using System.IO;

namespace CookerHelper.Controllers
{
    public class HomeController : Controller
    {
        private readonly IKindsOfDishes _kindsOfDishes;
        public HomeController(IKindsOfDishes kindsOfDishes)
        {
            _kindsOfDishes = kindsOfDishes;
        }

        public IActionResult Index()
        {
            //////KindsOfDishesVM kindsOfDishesVM = new KindsOfDishesVM();
            //////kindsOfDishesVM.KindsOfDishes = _kindsOfDishes.KindsOfDishes.ToList();
            //////foreach (var item in kindsOfDishesVM.KindsOfDishes)
            //////{
            //////    item.Image = Path.Combine("/imgKindsOfDishes", item.Image);
            //////}
            //////kindsOfDishesVM.Length = _kindsOfDishes.KindsOfDishes.Count();

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
