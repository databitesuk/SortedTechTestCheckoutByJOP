using ServiceLayer.Models.SpecialOffers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechTestCheckout.Areas.AddSpecialOffers.Pro
{
    public class SpecialOfferPro
    {
        public string SKU { get; set; }
        public int Quantity { get; set; }
        public decimal OfferPrice { get; set; }

        public SpecialOffer ToModel()
        {
            return SpecialOffer.Create(SKU, Quantity, OfferPrice);
        }
    }
}
