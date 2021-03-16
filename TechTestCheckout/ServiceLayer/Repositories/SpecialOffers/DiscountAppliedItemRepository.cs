using AOP.PostSharp.Aspects;
using ServiceLayer.Models.SpecialOffers;
using ServiceLayer.Repositories.SpecialOffers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.Repositories.SpecialOffers
{
    [LogOnException]
    public class DiscountAppliedItemRepository : IDiscountAppliedItemRepository
    {
        public int AddItem(string sku, string discountItemName, decimal discountPrice)
        {
            DataListSpecialOffers.ItemDiscounts.Add(
                DiscountApplied.Create(sku, discountItemName, discountPrice)
                );
            return 1;
        }

        public IEnumerable<DiscountApplied> GetItems()
        {
            return DataListSpecialOffers.ItemDiscounts;
        }

        public decimal RequestTotalDiscount()
        {
            return DataListSpecialOffers.ItemDiscounts.Sum(it => it.DiscountPrice);
        }
    }
}
