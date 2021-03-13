using ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Repositories.Interfaces
{
    public interface IItemRepository
    {
        int AddItem(string sku, string itemName, decimal unitPrice);

        Item GetItem(string sku);
    }
}
