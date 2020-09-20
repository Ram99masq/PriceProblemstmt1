using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
            double finalPrice = 0;
            PriceStrategyContext context = null;
            List<Item> items = new List<Item>();

            //<! Inline Block Testing!>
            ////Incase you want to run the code inline and please do uncomment the specific scenario to check the 
            ////Result for different Scenario's
            ////Uncomment Scenarios to test the inline logic for Specific scenarios

            //Scenaria A
            items = new List<Item>();
            items.Add(new Item() { ItemID = "A", UnitPrice = 50, OrderItems = 1 });
            items.Add(new Item() { ItemID = "B", UnitPrice = 30, OrderItems = 1 });
            items.Add(new Item() { ItemID = "C", UnitPrice = 20, OrderItems = 1 });
            context = new PriceStrategyContext(items);
            finalPrice = context.GetCheckoutPrice();
            ViewBag.ScenariaA = finalPrice;
            //// finalprice = Total = 100


            //Scenaria B
            items = new List<Item>();
            items.Add(new Item() { ItemID = "A", UnitPrice = 50, OrderItems = 5 });
            items.Add(new Item() { ItemID = "B", UnitPrice = 30, OrderItems = 5 });
            items.Add(new Item() { ItemID = "C", UnitPrice = 20, OrderItems = 1 });
            context = new PriceStrategyContext(items);
            finalPrice = context.GetCheckoutPrice();
            ViewBag.ScenariaB = finalPrice;
            //// finalprice = Total = 370


            //Scenaria C
            items = new List<Item>();
            items.Add(new Item() { ItemID = "A", UnitPrice = 50, OrderItems = 3 });
            items.Add(new Item() { ItemID = "B", UnitPrice = 30, OrderItems = 5 });
            items.Add(new Item() { ItemID = "C", UnitPrice = 20, OrderItems = 1 });
            items.Add(new Item() { ItemID = "D", UnitPrice = 15, OrderItems = 1 });
            context = new PriceStrategyContext(items);
            finalPrice = context.GetCheckoutPrice();
            ViewBag.ScenariaC = finalPrice;
            // finalprice = Total = 280


            ////Custom Use Case -  All in one Use Case
            items = new List<Item>();            
            items.Add(new Item() { ItemID = "A", UnitPrice = 50, OrderItems = 3 });
            items.Add(new Item() { ItemID = "B", UnitPrice = 30, OrderItems = 2 });
            items.Add(new Item() { ItemID = "C", UnitPrice = 20, OrderItems = 1 });
            items.Add(new Item() { ItemID = "D", UnitPrice = 15, OrderItems = 1 });
            context = new PriceStrategyContext(items);
            finalPrice = context.GetCheckoutPrice();
            ViewBag.Customcase = finalPrice;
            //// finalprice = Total = 205
          

            ////Calling the Business logic for the Price Strategy
            //context = new PriceStrategyContext(items);
            //finalPrice = context.GetCheckoutPrice();
            return View(ViewBag);
            //<! End - Inline Block Testing!>
        }

        public IActionResult GetItemPrice(List<Item> itemList = null)
        {


            try
            {

                double finalPrice = 0;
                PriceStrategyContext context = null;

                if (itemList != null && itemList.Count > 0)
                {
                    context = new PriceStrategyContext(itemList);
                    finalPrice = context.GetCheckoutPrice();
                    return Ok(finalPrice);

                }
                else
                {



                    _logger.LogError($"Invalid ItemList : {itemList} while Fetching PriceAmount");
                    return BadRequest($"Invalid ItemList : {itemList} while Fetching PriceAmount");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Internal Server Error in Fetching PriceAmount : {ex}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server Error");
            }
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
