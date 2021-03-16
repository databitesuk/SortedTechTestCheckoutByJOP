using ServiceLayer.Models.SpecialOffers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Repositories.SpecialOffers.Interfaces
{
    public interface IDiscountAppliedItemRepository
    {
        int AddItem(string sku, string discountItemName, decimal discountPrice);

        IEnumerable<DiscountApplied> GetItems();
        decimal RequestTotalDiscount();
    }
}
