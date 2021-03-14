using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Models.SpecialOffers
{
    public class SpecialOffer
    {
        public string SKU { get; private set; }
        public int Quantity { get; private set; }
        public decimal OfferPrice { get; private set; }

        public static SpecialOffer Create(string sku, int quantity, decimal offerPrice)
        {
            return new SpecialOffer
            {
                SKU = sku,
                Quantity = quantity,
                OfferPrice = offerPrice
            };
        }
    }
}
