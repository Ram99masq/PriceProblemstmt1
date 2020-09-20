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

        public double ApplyStrategy(IPromotionStrategy strategy,Item Item)
        {
            _price
                = _price + (Item.UnitPrice - ((Item.OrderItems / 3) * strategy.GetPromotionDiscount()));
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
    }
}
