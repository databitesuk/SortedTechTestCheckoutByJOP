using AOP.PostSharp.Aspects;
using ServiceLayer.Models;
using ServiceLayer.Models.SpecialOffers;
using ServiceLayer.Repositories.Interfaces;
using ServiceLayer.Repositories.SpecialOffers.Interfaces;
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
        private readonly ISpecialOfferItemRepository _specialOfferItemRepository;
        private readonly IDiscountAppliedItemRepository _discountAppliedItemRepository;

        public CheckoutRepository(IItemRepository itemRepository, ISpecialOfferItemRepository specialOfferItemRepository, IDiscountAppliedItemRepository discountAppliedItemRepository)
        {
            _itemRepository = itemRepository;
            _specialOfferItemRepository = specialOfferItemRepository;
            _discountAppliedItemRepository = discountAppliedItemRepository;
        }

        public int ScanAnItemAtCheckout(string sku)
        {
            var item = _itemRepository.GetItem(sku);
            if (item != null)
            {
                DataList.Checkout.Add(
                    Checkout.Create(item.SKU, item.ItemName, 1, item.UnitPrice)
                    );
                // check for any special offers for this sku
                CheckForSpecialOffers(sku);
                return 1;
            }
            else
            {
                return 0;
            }
        }

        private void CheckForSpecialOffers(string sku)
        {
            var offerFound = _specialOfferItemRepository.GetItem(sku);
            if (offerFound != null)
            {
                var skuInCheckout = DataList.Checkout.Where(it => it.SKU.ToUpper() == sku.ToUpper() && it.DiscountApplied == 0).Take(offerFound.Quantity).ToList();
                if (offerFound != null && skuInCheckout != null)
                {
                    if (skuInCheckout.Count() >= offerFound.Quantity)
                    {
                        UpdateDiscount(sku, offerFound, skuInCheckout);
                    }
                }
            }
        }

        private void UpdateDiscount(string sku, SpecialOffer offerFound, List<Checkout> skuInCheckout)
        {
            // insert record in discount applied 
            var item = _itemRepository.GetItem(sku);
            var totalPrice = skuInCheckout
                                .Where(it => it.DiscountApplied == 0)
                                .Sum(s => s.TotalPrice);
            var discountAmt = (totalPrice - offerFound.OfferPrice);

            _discountAppliedItemRepository.AddItem(item.SKU, item.ItemName, discountAmt);

            // update item in checkout as discount applied
            Checkout.UpdateCheckout(skuInCheckout, 1);
        }

        public IEnumerable<Checkout> ListItemInCheckout()
        {
            return DataList.Checkout;
        }

        public decimal RequestTotal()
        {
            return DataList.Checkout.Sum(it => it.TotalPrice);
        }
    }
}
