using System;
using System.Collections.Generic;

namespace PriceProblemstmt1.BusinessLayer
{
    public class PriceStrategyContext
    {

        List<Item> _items; // price for some item or air ticket etc.
        Dictionary<string, IPromotionStrategy> strategyContext
            = new Dictionary<string, IPromotionStrategy>();

        double _price = 0;
        int _discountQuantity = 0;
        public PriceStrategyContext(List<Item> items)
        {
            this._items = items;
            strategyContext.Add(nameof(PromotionAStrategy),
                    new PromotionAStrategy());
            strategyContext.Add(nameof(PromotionBStrategy),
                    new PromotionBStrategy());
            strategyContext.Add(nameof(PromotionCDStrategy),
                   new PromotionCDStrategy());
            strategyContext.Add(nameof(PromotionNoStrategy),
                 new PromotionNoStrategy());

        }

        public double ApplyStrategy(IPromotionStrategy strategy, Item item)
        {
            switch (item.ItemID)
            {
                case "A":
                    _discountQuantity = 3;
                    _price
                        = _price
                        + ((item.UnitPrice * item.OrderItems)
                        - ((item.OrderItems / _discountQuantity) * strategy.GetPromotionDiscount()));

                    break;
                case "B":
                    _discountQuantity = 2;
                    _price
                       = _price
                       + ((item.UnitPrice * item.OrderItems)
                       - ((item.OrderItems / _discountQuantity) * strategy.GetPromotionDiscount()));
                    break;
                case "C":
                case "D":                  
                    _price = _price + ((item.UnitPrice * item.OrderItems));
                    break;
                case "CD":
                    _discountQuantity = item.OrderItems;
                    _price = _price - (_discountQuantity * strategy.GetPromotionDiscount());
                    break;

            }

            return _price;
        }

        public IPromotionStrategy GetStrategy(int quantity, string skuId)
        {
            if (skuId == "A" && quantity > 2)
            {
                return strategyContext[nameof(PromotionAStrategy)];
            }
            if (skuId == "B" && quantity > 1)
            {
                return strategyContext[nameof(PromotionBStrategy)];
            }
            else if ((skuId == "CD" && quantity > 0))
            {
                return strategyContext[nameof(PromotionCDStrategy)];
            }
            else
                return strategyContext[nameof(PromotionNoStrategy)];
        }


        //public GetCheckout Price()
        //{
        //    Item itemCD = new Item();
        //    int countC = 0;
        //    int countD = 0;
        //    int countCD = 0;
        //    PriceStrategyContext context = new PriceStrategyContext(items);

        //    IPromotionStrategy strategy = null;
        //    double finalprice = 0;
        //    foreach (Item item in items)
        //    {
        //        if (item.ItemID == "C") countC = countC + item.OrderItems;
        //        if (item.ItemID == "D") countD = countD + item.OrderItems;
        //        strategy = context.GetStrategy(item.OrderItems, item.ItemID);
        //        finalprice = context.ApplyStrategy(strategy, item);
        //    }

        //    //Special logic for C & D
        //    if (countC > 0 && countD > 0)
        //    {
        //        countCD = (countC > countD) ? countD : countC;
        //        itemCD = new Item() { ItemID = "CD", UnitPrice = 35, OrderItems = countCD };
        //        strategy = context.GetStrategy(itemCD.OrderItems, itemCD.ItemID);
        //        finalprice = context.ApplyStrategy(strategy, itemCD);
        //    }


        //}

    }
}
