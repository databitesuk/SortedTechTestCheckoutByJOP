using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.SpecialOffers.Interfaces;
using TechTestCheckout.Areas.AddSpecialOffers.Pro;
using TechTestCheckout.Areas.AddSpecialOffers.Views;

namespace TechTestCheckout.Areas.AddSpecialOffers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddSpecialOffersController : ControllerBase
    {
        private readonly ISpecialOfferItemService _specialOfferItemService;

        public AddSpecialOffersController(ISpecialOfferItemService specialOfferItemService)
        {
            _specialOfferItemService = specialOfferItemService;
        }

        [HttpPost]
        public IActionResult CreateAnOffer([FromBody] SpecialOfferPro pro)
        {
            var item = pro.ToModel();
            var result = _specialOfferItemService.AddItem(item.SKU, pro.Quantity, pro.OfferPrice);
            var msg = "Item Offer successfully created !";
            if (result < 1)
            {
                msg = "Offer not created !";
            }

            return Ok(msg);
        }

        [HttpGet]
        [Route("ReadItems")]
        public IActionResult GetItems()
        {
            var items = _specialOfferItemService.GetItems();
            var result = SpecialOfferView.From(items);
            var msg = "Offer Items successfully read !";
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                msg = "Offer Items not found !";
                return Ok(msg);
            }
        }

        [HttpGet]
        [Route("GetItem")]
        public IActionResult GetItem([FromQuery] string sku)
        {
            var item = _specialOfferItemService.GetItem(sku);
            var result = SpecialOfferView.From(item);
            var msg = "Item successfully read !";
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                msg = "Item not found !";
                return Ok(msg);
            }
        }

    }
}
