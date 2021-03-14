using AOP.PostSharp.Aspects;
using ServiceLayer.Models;
using ServiceLayer.Repositories.Interfaces;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Services
{
    [LogOnException]
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public int AddItem(string sku, string itemName, decimal unitPrice)
        {
            return _itemRepository.AddItem(sku, itemName, unitPrice);
        }

        public Item GetItem(string sku)
        {
            return _itemRepository.GetItem(sku);
        }

        public IEnumerable<Item> GetItems()
        {
            return _itemRepository.GetItems();
        }
    }
}
