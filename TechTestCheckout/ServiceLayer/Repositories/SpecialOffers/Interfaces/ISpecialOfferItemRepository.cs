using ServiceLayer.Models.SpecialOffers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Repositories.SpecialOffers.Interfaces
{
    public interface ISpecialOfferItemRepository
    {
        int AddItem(string sku, int Quantity, decimal OfferPrice);

        SpecialOffer GetItem(string sku);

        IEnumerable<SpecialOffer> GetItems();
    }
}
