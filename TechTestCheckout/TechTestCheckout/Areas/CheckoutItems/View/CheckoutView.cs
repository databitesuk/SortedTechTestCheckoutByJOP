using ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechTestCheckout.Areas.CheckoutItems.View
{
    public class CheckoutView
    {
        public string SKU { get; private set; }
        public string ItemName { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal TotalPrice { get; private set; }

        public static IEnumerable<CheckoutView> From(IEnumerable<Checkout> items)
        {
            var result = items
                            .Select(it =>
                            new CheckoutView
                            {
                                SKU = it.SKU,
                                ItemName = it.ItemName,
                                Quantity = it.Quantity,
                                UnitPrice = it.UnitPrice,
                                TotalPrice = it.TotalPrice
                            })
                            .ToList();

            return result;
        }
    }
}
