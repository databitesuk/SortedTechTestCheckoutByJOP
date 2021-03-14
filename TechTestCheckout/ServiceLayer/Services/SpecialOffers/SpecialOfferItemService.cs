using ServiceLayer.Models.SpecialOffers;
using ServiceLayer.Repositories.SpecialOffers.Interfaces;
using ServiceLayer.Services.SpecialOffers.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Services.SpecialOffers
{
    public class SpecialOfferItemService : ISpecialOfferItemService
    {
        private readonly ISpecialOfferItemRepository _specialOfferItemRepository;

        public SpecialOfferItemService(ISpecialOfferItemRepository specialOfferItemRepository)
        {
            _specialOfferItemRepository = specialOfferItemRepository;
        }

        public int AddItem(string sku, int Quantity, decimal OfferPrice)
        {
            return _specialOfferItemRepository.AddItem(sku, Quantity, OfferPrice);
        }

        public SpecialOffer GetItem(string sku)
        {
            return _specialOfferItemRepository.GetItem(sku);
        }

        public IEnumerable<SpecialOffer> GetItems()
        {
            return _specialOfferItemRepository.GetItems();
        }
    }
}
