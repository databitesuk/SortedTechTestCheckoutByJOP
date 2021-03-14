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
    public class CheckoutRepository : ICheckoutRepository
    {
        private readonly IItemRepository _itemRepository;

        public CheckoutRepository(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public int ScanAnItemAtCheckout(string sku)
        {
            var item = _itemRepository.GetItem(sku);
            if (item != null)
            {
                DataList.Checkout.Add(
                    Checkout.Create(item.SKU, item.ItemName, 1, item.UnitPrice)
                    );
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public decimal RequestTotal()
        {
            return DataList.Checkout.Sum(it => it.TotalPrice);
        }
    }
}
