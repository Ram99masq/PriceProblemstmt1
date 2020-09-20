using System;
using System.Collections.Generic;
using System.Text;

namespace PriceProblemstmt1.BusinessLayer
{
    public class PromotionCDStrategy
    {
        public string Name => nameof(PromotionCDStrategy);

        public double GetPromotionDiscount()
        {
            return 0;
        }
    }
}
