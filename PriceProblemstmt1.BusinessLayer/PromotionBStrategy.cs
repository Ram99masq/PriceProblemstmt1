using System;
using System.Collections.Generic;
using System.Text;

namespace PriceProblemstmt1.BusinessLayer
{
    public class PromotionBStrategy : IPromotionStrategy
    {
        public string Name => nameof(PromotionBStrategy);

        public double GetPromotionDiscount()
        {
            return 15;
        }

    }
}
