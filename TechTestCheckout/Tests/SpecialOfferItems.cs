using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceLayer.Repositories.SpecialOffers;
using ServiceLayer.Repositories.SpecialOffers.Interfaces;
using ServiceLayer.Services.SpecialOffers;
using ServiceLayer.Services.SpecialOffers.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    [TestClass]
    public class SpecialOfferItems
    {
        public SpecialOfferItems()
        {
            // create items 
            ISpecialOfferItemRepository specialOfferItemRepository = new SpecialOfferItemRepository();
            ISpecialOfferItemService specialOfferItemService = new SpecialOfferItemService(specialOfferItemRepository);

            var sku = "A99";
            var quantity = 3;
            var offerPrice = "1.30";
            var created = specialOfferItemService.AddItem(sku, quantity, decimal.Parse(offerPrice.ToString()));

            sku = "B15";
            quantity = 2;
            offerPrice = "0.45";
            created = specialOfferItemService.AddItem(sku, quantity, decimal.Parse(offerPrice.ToString()));

            sku = "C40";
            quantity = 2;
            offerPrice = "0.60";
            created = specialOfferItemService.AddItem(sku, quantity, decimal.Parse(offerPrice.ToString()));
        }

        [TestMethod]
        public void Returns_An_Item_If_Exists()
        {
            #region Arrange
            var sku = "B15";
            ISpecialOfferItemRepository specialOfferItemRepository = new SpecialOfferItemRepository();
            ISpecialOfferItemService specialOfferItemService = new SpecialOfferItemService(specialOfferItemRepository);
            #endregion

            #region Act
            var result = specialOfferItemService.GetItem(sku);
            #endregion

            #region Assert
            Assert.AreEqual(sku, result.SKU);
            #endregion
        }
    }
}
