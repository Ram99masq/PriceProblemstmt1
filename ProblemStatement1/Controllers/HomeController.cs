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
            List<Item> items = new List<Item>();
            //All Use Case 
            //items.Add(new Item() { ItemID = "A", UnitPrice = 50, OrderItems = 3 });
            //items.Add(new Item() { ItemID = "B", UnitPrice = 30, OrderItems = 2 });
            //items.Add(new Item() { ItemID = "C", UnitPrice = 20, OrderItems = 1 });
            //items.Add(new Item() { ItemID = "D", UnitPrice = 15, OrderItems = 1 });


            //Scenaria A
            //items.Add(new Item() { ItemID = "A", UnitPrice = 50, OrderItems = 1 });
            //items.Add(new Item() { ItemID = "B", UnitPrice = 30, OrderItems = 1 });
            //items.Add(new Item() { ItemID = "C", UnitPrice = 20, OrderItems = 1 });
            // finalprice = Total = 100


            //Scenaria B
            //items.Add(new Item() { ItemID = "A", UnitPrice = 50, OrderItems = 5 });
            //items.Add(new Item() { ItemID = "B", UnitPrice = 30, OrderItems = 5 });
            //items.Add(new Item() { ItemID = "C", UnitPrice = 20, OrderItems = 1 });
            // finalprice = Total = 370


            //Scenaria C
            items.Add(new Item() { ItemID = "A", UnitPrice = 50, OrderItems = 3 });
            items.Add(new Item() { ItemID = "B", UnitPrice = 30, OrderItems = 5 });
            items.Add(new Item() { ItemID = "C", UnitPrice = 20, OrderItems = 1 });
            items.Add(new Item() { ItemID = "D", UnitPrice = 15, OrderItems = 1 });
            // finalprice = Total = 280



            Item itemCD = new Item();
            int countC = 0;
            int countD = 0;
            int countCD = 0;
            PriceStrategyContext context = new PriceStrategyContext(items);

            IPromotionStrategy strategy = null;
            double finalprice = 0;
            foreach (Item item in items)
            {
                if (item.ItemID == "C") countC = countC+ item.OrderItems;
                if (item.ItemID == "D") countD = countD + item.OrderItems;
                strategy = context.GetStrategy(item.OrderItems, item.ItemID);
                finalprice = context.ApplyStrategy(strategy, item);
            }

            //Special logic for C & D
            if (countC > 0 && countD > 0)
            {
                countCD = (countC > countD) ? countD : countC;
                itemCD = new Item() { ItemID = "CD", UnitPrice = 35, OrderItems = countCD };
                strategy = context.GetStrategy(itemCD.OrderItems, itemCD.ItemID);
                finalprice = context.ApplyStrategy(strategy, itemCD);
            }






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
