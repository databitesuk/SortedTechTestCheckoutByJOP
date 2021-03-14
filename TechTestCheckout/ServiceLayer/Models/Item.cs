using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Models
{
    public class Item
    {
        public string SKU { get; private set; }
        public string ItemName { get; private set; }
        public decimal UnitPrice { get; private set; }

        public static Item Create(string sku, string itemName, decimal unitPrice)
        {
            return new Item
            {
                SKU = sku.ToUpper(),
                ItemName = itemName,
                UnitPrice = unitPrice
            };
        }
    }
}
