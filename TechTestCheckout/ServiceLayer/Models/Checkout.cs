using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Models
{
    public class Checkout
    {
        public string SKU { get; private set; }
        public string ItemName { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal TotalPrice { get; private set; }

        public int DiscountApplied { get; private set; }

        public static Checkout Create(string sku, string itemName, int quantity, decimal unitPrice)
        {
            return new Checkout
            {
                SKU = sku,
                ItemName = itemName,
                Quantity = quantity,
                UnitPrice = unitPrice,
                TotalPrice = (quantity * unitPrice)
            };
        }

        public static void UpdateCheckout(List<Checkout> checkouts, int discountApplied )
        {
            foreach (var item in checkouts)
            {
                item.DiscountApplied = discountApplied;
            }
        }
    }
}
