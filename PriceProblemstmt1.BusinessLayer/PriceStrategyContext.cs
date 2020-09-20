using System;
using System.Collections.Generic;

namespace PriceProblemstmt1.BusinessLayer
{
    public class PriceStrategyContext
    {

        double price; // price for some item or air ticket etc.
        Dictionary<string, IPromotionStrategy> strategyContext
            = new Dictionary<string, IPromotionStrategy>();
        public PriceStrategyContext(double price)
        {
            this.price = price;
            strategyContext.Add(nameof(PromotionAStrategy),
                    new PromotionAStrategy());
            strategyContext.Add(nameof(PromotionAStrategy),
                    new PromotionAStrategy());
        }

        public void ApplyStrategy(IPromotionStrategy strategy)
        {
            /*
            Currently applyStrategy has simple implementation. 
            You can Context for populating some more information,
            which is required to call a particular operation
            */
            Console.WriteLine("Price before offer :" + price);
            double finalPrice
                = price - (price * strategy.GetPromotionDiscount());
            Console.WriteLine("Price after offer:" + finalPrice);
        }

        public IPromotionStrategy GetStrategy(int monthNo)
        {
            /*
            In absence of this Context method, client has to import 
            relevant concrete Strategies everywhere.
            Context acts as single point of contact for the Client 
            to get relevant Strategy
            */
            if (monthNo < 6)
            {
                return strategyContext[nameof(PromotionAStrategy)];
            }
            else if(monthNo < 6)
            {
                return strategyContext[nameof(PromotionBStrategy)];
            }
            else 
            {
                return strategyContext[nameof(PromotionCDStrategy)];
            }
        }
    }
}
