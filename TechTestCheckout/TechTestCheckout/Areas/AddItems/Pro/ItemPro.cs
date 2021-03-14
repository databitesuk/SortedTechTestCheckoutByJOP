using ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechTestCheckout.Areas.AddItems.Pro
{
    public class ItemPro
    {
        public string SKU { get; set; }
        public string ItemName { get; set; }
        public decimal UnitPrice { get; set; }

        public Item ToModel()
        {
            return Item.Create(SKU, ItemName, UnitPrice);
        }
    }
}
