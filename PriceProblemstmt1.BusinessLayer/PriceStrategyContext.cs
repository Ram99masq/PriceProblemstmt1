using System;
using System.Collections.Generic;

namespace PriceProblemstmt1.BusinessLayer
{
    public class PriceStrategyContext
    {

        Item _item; // price for some item or air ticket etc.
        Dictionary<string, IPromotionStrategy> strategyContext
            = new Dictionary<string, IPromotionStrategy>();
        public PriceStrategyContext(Item item)
        {
            this._item = item;
            strategyContext.Add(nameof(PromotionAStrategy),
                    new PromotionAStrategy());
            strategyContext.Add(nameof(PromotionBStrategy),
                    new PromotionAStrategy());
            strategyContext.Add(nameof(PromotionCDStrategy),
                   new PromotionAStrategy());

        }

        public void ApplyStrategy(IPromotionStrategy strategy)
        {
            Console.WriteLine("Price before offer :" + _item.UnitPrice);
            double finalPrice
                = _item.UnitPrice - (_item.UnitPrice * strategy.GetPromotionDiscount());
            Console.WriteLine("Price after offer:" + finalPrice);
        }

        public IPromotionStrategy GetStrategy(int quantity, string skuId)
        {
            if (skuId == "A" && quantity > 3)
            {
                return strategyContext[nameof(PromotionAStrategy)];
            }
            if (skuId == "B" && quantity > 2)
            {
                return strategyContext[nameof(PromotionBStrategy)];
            }
            else if ((skuId == "CD" && quantity > 0))
            {
                return strategyContext[nameof(PromotionCDStrategy)];
            }
            else
                return strategyContext[nameof(PromotionCDStrategy)];
        }
    }
}
