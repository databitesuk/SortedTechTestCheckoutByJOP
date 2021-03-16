using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AOP.PostSharp.Aspects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Repositories.Interfaces;
using ServiceLayer.Repositories.SpecialOffers.Interfaces;
using TechTestCheckout.Areas.CheckoutItems.Pro;
using TechTestCheckout.Areas.CheckoutItems.View;

namespace TechTestCheckout.Areas.CheckoutItems
{
    [Route("[controller]")]
    [ApiController]
    [LogOnSuccess]
    [LogOnException]
    public class CheckoutController : ControllerBase
    {
        private readonly ICheckoutRepository _checkoutRepository;
        private readonly IDiscountAppliedItemRepository _discountAppliedItemRepository;

        public CheckoutController(ICheckoutRepository checkoutRepository, IDiscountAppliedItemRepository discountAppliedItemRepository )
        {
            _checkoutRepository = checkoutRepository;
            _discountAppliedItemRepository = discountAppliedItemRepository;
        }

        [HttpPost]
        public IActionResult ScanAnItem([FromBody] CheckoutPro pro)
        {
            var item = _checkoutRepository.ScanAnItemAtCheckout(pro.Sku);
            if (item == 1)
            {
                return Ok("Item successfully scanned !");
            }
            else
            {
                return Ok("Item not scanned !");
            }
        }

        [HttpGet]
        [Route("ListItemsInCheckout")]
        public IActionResult ListItemsInCheckout()
        {
            var items = _checkoutRepository.ListItemInCheckout();
            var results = CheckoutView.From(items);
            if (results != null)
            {
                return Ok(results);
            }
            else
            {
                return Ok("No items scanned at checkout !");
            }
        }

        [HttpGet]
        [Route("RequestTotal")]
        public IActionResult RequestTotal()
        {
            var items = _checkoutRepository.ListItemInCheckout();
            var discountItems = _discountAppliedItemRepository.GetItems();

            var total = _checkoutRepository.RequestTotal();
            var discountTotal = _discountAppliedItemRepository.RequestTotalDiscount();

            var result = TotalRequestView.From(items, discountItems);

            var resultView = $"{result}{Environment.NewLine}{Environment.NewLine}";
            var footerView = $"CHECKOUT TOTAL: {total}{Environment.NewLine}DISCOUNTS APPLIED: {discountTotal}{Environment.NewLine}FINAL/NET TOTAL PRICE: {total - discountTotal}";

            return Ok($"{resultView}{footerView}");
        }

        [HttpGet]
        [Route("GetDiscountApplied")]
        public IActionResult GetDiscountApplied()
        {
            var discountedItems = _discountAppliedItemRepository.GetItems();
            var results = DiscountView.From(discountedItems);
            if (results != null)
            {
                return Ok(results);
            }
            else
            {
                return Ok("No discount applied items at checkout !");
            }
        }

    }
}
