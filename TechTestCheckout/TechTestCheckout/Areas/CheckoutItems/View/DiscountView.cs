using ServiceLayer.Models.SpecialOffers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechTestCheckout.Areas.CheckoutItems.View
{
    public class DiscountView
    {
        public string SKU { get; private set; }
        public string DiscountItemName { get; private set; }
        public decimal DiscountPrice { get; private set; }

        public static IEnumerable<DiscountView> From(IEnumerable<DiscountApplied> items)
        {
            var result = items
                            .Select(it =>
                            new DiscountView
                            {
                                SKU = it.SKU,
                                DiscountItemName = it.DiscountItemName,
                                DiscountPrice = it.DiscountPrice
                            })
                            .ToList();

            return result;
        }
    }
}
