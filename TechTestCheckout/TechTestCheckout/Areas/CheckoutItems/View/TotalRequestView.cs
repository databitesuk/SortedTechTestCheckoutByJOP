using AOP.PostSharp.Aspects;
using ServiceLayer.Models;
using ServiceLayer.Models.SpecialOffers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechTestCheckout.Areas.CheckoutItems.View
{
    [LogOnException]
    public class TotalRequestView
    {
        public static string From(IEnumerable<Checkout> checkouts, IEnumerable<DiscountApplied> discounts)
        {
            var itemLines = $"Items:-{Environment.NewLine}";
            foreach (var item in checkouts)
            {
                itemLines += $"{item.SKU} - {item.ItemName} - {item.Quantity} - {item.TotalPrice}{Environment.NewLine}";
            }

            var discountLines = $"{Environment.NewLine}Discounts Applied:-{Environment.NewLine}";
            if (discountLines.Count() >= 1)
            {
                foreach (var item in discounts)
                {
                    discountLines += $"{item.SKU} - {item.DiscountItemName} - {item.DiscountPrice}{Environment.NewLine}";
                }
            }
            else
            {
                discountLines += $"----- No items discounted -----{Environment.NewLine}";
            }

            var results = $"{itemLines}{discountLines}";

            return results;
        }
    }
}
