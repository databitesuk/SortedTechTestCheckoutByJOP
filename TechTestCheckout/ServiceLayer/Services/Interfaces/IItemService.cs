using ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Services.Interfaces
{
    public interface IItemService
    {
        int AddItem(string sku, string itemName, decimal unitPrice);

        Item GetItem(string sku);
    }
}
