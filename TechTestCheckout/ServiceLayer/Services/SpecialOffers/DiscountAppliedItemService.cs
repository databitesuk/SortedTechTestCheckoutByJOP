using AOP.PostSharp.Aspects;
using ServiceLayer.Models.SpecialOffers;
using ServiceLayer.Repositories.SpecialOffers.Interfaces;
using ServiceLayer.Services.SpecialOffers.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Services.SpecialOffers
{
    [LogOnException]
    public class DiscountAppliedItemService : IDiscountAppliedItemService
    {
        private readonly IDiscountAppliedItemRepository _discountAppliedItemRepository;

        public DiscountAppliedItemService(IDiscountAppliedItemRepository discountAppliedItemRepository)
        {
            _discountAppliedItemRepository = discountAppliedItemRepository;
        }

        public int AddItem(string sku, string discountItemName, decimal discountPrice)
        {
            return _discountAppliedItemRepository.AddItem(sku, discountItemName, discountPrice);
        }

        public IEnumerable<DiscountApplied> GetItems()
        {
            return _discountAppliedItemRepository.GetItems();
        }

        public decimal RequestTotalDiscount()
        {
            return _discountAppliedItemRepository.RequestTotalDiscount();
        }
    }
}
