using ServiceLayer.Models.SpecialOffers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechTestCheckout.Areas.AddSpecialOffers.Views
{
    public class SpecialOfferView
    {
        public string SKU { get; private set; }
        public int Quantity { get; private set; }
        public decimal OfferPrice { get; private set; }

        public static IEnumerable<SpecialOfferView> From(IEnumerable<SpecialOffer> items)
        {
            var result = items
                            .Select(it =>
                                new SpecialOfferView
                                {
                                    SKU = it.SKU,
                                    Quantity = it.Quantity,
                                    OfferPrice = it.OfferPrice
                                })
                            .ToList();

            return result;
        }

        public static SpecialOfferView From(SpecialOffer item)
        {
            var result = new SpecialOfferView
            {
                SKU = item.SKU,
                Quantity = item.Quantity,
                OfferPrice = item.OfferPrice
            };

            return result;
        }
    }
}
