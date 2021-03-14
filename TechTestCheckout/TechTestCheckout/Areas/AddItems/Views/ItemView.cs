using ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechTestCheckout.Areas.AddItems.Views
{
    public class ItemView
    {
        public string SKU { get; private set; }
        public string ItemName { get; private set; }
        public decimal UnitPrice { get; private set; }

        public static IEnumerable<ItemView> From(IEnumerable<Item> items)
        {
            var result = items
                            .Select(it =>
                               new ItemView
                               {
                                   SKU = it.SKU,
                                   ItemName = it.ItemName,
                                   UnitPrice = it.UnitPrice
                               })
                            .ToList();

            return result;
        }

        public static ItemView From(Item item)
        {
            var result = new ItemView
            {
                SKU = item.SKU,
                ItemName = item.ItemName,
                UnitPrice = item.UnitPrice
            };

            return result;
        }
    }
}
