using AOP.PostSharp.Aspects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceLayer.Repositories;
using ServiceLayer.Repositories.Interfaces;
using ServiceLayer.Services;
using ServiceLayer.Services.Interfaces;

namespace Tests
{
    [TestClass]
    public class GenerateItems
    {
        public GenerateItems()
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
        public void Returns_An_Item_If_Exists()
        {
            #region Arrange
            var sku = "B15";
            IItemRepository itemRepository = new ItemRepository();
            IItemService itemService = new ItemService(itemRepository);
            #endregion

            #region Act
            var result = itemService.GetItem(sku);
            #endregion

            #region Assert
            Assert.AreEqual(sku, result.SKU);
            #endregion
        }
    }
}
