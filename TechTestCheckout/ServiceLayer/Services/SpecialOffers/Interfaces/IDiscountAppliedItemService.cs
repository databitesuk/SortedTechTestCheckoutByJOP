using ServiceLayer.Models.SpecialOffers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Services.SpecialOffers.Interfaces
{
    public interface IDiscountAppliedItemService
    {
        int AddItem(string sku, string discountItemName, decimal discountPrice);

        IEnumerable<DiscountApplied> GetItems();

        decimal RequestTotalDiscount();
    }
}
