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
    public class CheckoutService : ICheckoutService
    {
        private readonly ICheckoutRepository _checkoutRepository;

        public CheckoutService(ICheckoutRepository checkoutRepository)
        {
            _checkoutRepository = checkoutRepository;
        }

        public int ScanAnItemAtCheckout(string sku)
        {
            return _checkoutRepository.ScanAnItemAtCheckout(sku);
        }

        public IEnumerable<Checkout> ListItemInCheckout()
        {
            return _checkoutRepository.ListItemInCheckout();
        }

        public decimal RequestTotal()
        {
            return _checkoutRepository.RequestTotal();
        }
    }
}
