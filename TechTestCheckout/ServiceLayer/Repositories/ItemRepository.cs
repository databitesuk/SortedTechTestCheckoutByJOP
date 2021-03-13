using AOP.PostSharp.Aspects;
using ServiceLayer.Models;
using ServiceLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.Repositories
{
    [LogOnException]
    public class ItemRepository : IItemRepository
    {
        public int AddItem(string sku, string itemName, decimal unitPrice)
        {
            DataList.Items.Add(
                Item.Create(sku, itemName, unitPrice)
                );
            return DataList.Items.Count;
        }

        public Item GetItem(string sku)
        {
            return DataList.Items
                        .Where(it => it.SKU == sku)
                        .FirstOrDefault();
        }
    }
}
