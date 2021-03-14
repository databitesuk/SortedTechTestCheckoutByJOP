using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Models.SpecialOffers
{
    public class DataListSpecialOffers
    {
        public static List<SpecialOffer> SpecialOffers { get; set; } = new List<SpecialOffer>();
        public static List<DiscountApplied> ItemDiscounts { get; set; } = new List<DiscountApplied>();
    }
}
