using ServiceLayer.Models.SpecialOffers;
using ServiceLayer.Repositories.SpecialOffers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.Repositories.SpecialOffers
{
    public class SpecialOfferItemRepository : ISpecialOfferItemRepository
    {
        public int AddItem(string sku, int Quantity, decimal OfferPrice)
        {
            DataListSpecialOffers.SpecialOffers.Add(
                SpecialOffer.Create(sku, Quantity, OfferPrice)
                );
            return 1;
        }

        public SpecialOffer GetItem(string sku)
        {
            return DataListSpecialOffers.SpecialOffers
                        .Where(it => it.SKU == sku)
                        .FirstOrDefault();
        }

        public IEnumerable<SpecialOffer> GetItems()
        {
            return DataListSpecialOffers.SpecialOffers;
        }
    }
}
