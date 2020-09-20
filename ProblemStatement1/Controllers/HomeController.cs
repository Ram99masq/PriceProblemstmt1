using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PriceProblemstmt1.BusinessLayer;
using ProblemStatement1.Models;

namespace ProblemStatement1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Item item1 = new Item() {ItemID="A",UnitPrice=50, OrderItems=3 };
            Item item2 = new Item() {ItemID="B",UnitPrice=30, OrderItems=1 };
            Item item3 = new Item() {ItemID="C",UnitPrice=20, OrderItems=1 };
            Item item4 = new Item() {ItemID="D",UnitPrice=15, OrderItems=1 };

            PriceStrategyContext context = new PriceStrategyContext(item1);
            IPromotionStrategy strategy = context.GetStrategy(item1.OrderItems, "A");
            context.ApplyStrategy(strategy);
            Console.ReadLine();
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
