using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Repositories.Interfaces;
using TechTestCheckout.Areas.CheckoutItems.Pro;
using TechTestCheckout.Areas.CheckoutItems.View;

namespace TechTestCheckout.Areas.CheckoutItems
{
    [Route("[controller]")]
    [ApiController]
    public class CheckoutController : ControllerBase
    {
        private readonly ICheckoutRepository _checkoutRepository;

        public CheckoutController(ICheckoutRepository checkoutRepository)
        {
            _checkoutRepository = checkoutRepository;
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
            var total = _checkoutRepository.RequestTotal();
            return Ok($"Checkout Total: {total}");
        }

    }
}
