using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Models.SpecialOffers
{
    public class DiscountApplied
    {
        public string SKU { get; private set; }
        public string DiscountItemName { get; private set; }
        public decimal DiscountPrice { get; private set; }

        public static DiscountApplied Create(string sku, string discountItemName, decimal discountPrice)
        {
            return new DiscountApplied
            {
                SKU = sku,
                DiscountItemName = discountItemName,
                DiscountPrice = discountPrice
            };
        }
    }
}
