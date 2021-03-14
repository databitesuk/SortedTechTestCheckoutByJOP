using ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Repositories.Interfaces
{
    public interface ICheckoutRepository
    {
        int ScanAnItemAtCheckout(string sku);
        decimal RequestTotal();
    }
}
