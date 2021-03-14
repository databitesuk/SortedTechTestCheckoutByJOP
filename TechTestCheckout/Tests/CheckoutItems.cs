using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceLayer.Repositories;
using ServiceLayer.Repositories.Interfaces;
using ServiceLayer.Services;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    [TestClass]
    public class CheckoutItems
    {
        public CheckoutItems()
        {
            // create items 
            IItemRepository itemRepository = new ItemRepository();
            IItemService itemService = new ItemService(itemRepository);

            var sku = "A99";
            var itemName = "Apple";
            var unitPrice = "0.50";
            var created = itemService.AddItem(sku, itemName, decimal.Parse(unitPrice.ToString()));

            sku = "B15";
            itemName = "Biscuits";
            unitPrice = "0.30";
            created = itemService.AddItem(sku, itemName, decimal.Parse(unitPrice.ToString()));

            sku = "C40";
            itemName = "Carrot";
            unitPrice = "0.60";
            created = itemService.AddItem(sku, itemName, decimal.Parse(unitPrice.ToString()));
        }

        [TestMethod]
        public void Scan_Item_To_Add_To_Checkout()
        {
            #region Arrange
            var checkout = 1;
            var sku = "B15";
            IItemRepository itemRepository = new ItemRepository();
            ICheckoutRepository checkoutRepository = new CheckoutRepository(itemRepository);
            #endregion

            #region Act
            var result = checkoutRepository.ScanAnItemAtCheckout(sku);
            #endregion

            #region Assert
            Assert.AreEqual(checkout, result);
            #endregion
        }

        [TestMethod]
        public void Request_For_Total_Price_At_Checkout()
        {
            #region Arrange
            IItemRepository itemRepository = new ItemRepository();
            ICheckoutRepository checkoutRepository = new CheckoutRepository(itemRepository);
            var sku = "B15";
            var unitPrice = "0.50";
            var sku2 = "A99";
            var unitPrice2 = "0.30";
            var sku3 = "C40";
            var unitPrice3 = "0.60";
            var totalPrice = decimal.Parse(unitPrice) + decimal.Parse(unitPrice2) + decimal.Parse(unitPrice3);
            #endregion

            #region Act
            checkoutRepository.ScanAnItemAtCheckout(sku);
            checkoutRepository.ScanAnItemAtCheckout(sku2);
            checkoutRepository.ScanAnItemAtCheckout(sku3);
            var requestTotal = checkoutRepository.RequestTotal();
            #endregion

            #region Assert
            Assert.AreEqual(totalPrice, requestTotal);
            #endregion
        }
    }
}
