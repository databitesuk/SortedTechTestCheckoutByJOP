using ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Services.Interfaces
{
    public interface ICheckoutService
    {
        int ScanAnItemAtCheckout(string sku);
        IEnumerable<Checkout> ListItemInCheckout();
        decimal RequestTotal();
    }
}
