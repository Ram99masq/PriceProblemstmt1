﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PriceProblemstmt1.BusinessLayer
{
   public class PromotionAStrategy : IPromotionStrategy
    {

        public string Name => nameof(PromotionAStrategy);

        public double GetPromotionDiscount()
        {
            return 20;
        }

    }
}
