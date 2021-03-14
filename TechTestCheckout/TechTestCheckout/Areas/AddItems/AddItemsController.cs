using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.Interfaces;
using TechTestCheckout.Areas.AddItems.Pro;
using TechTestCheckout.Areas.AddItems.Views;

namespace TechTestCheckout.Areas.AddItems
{
    [ApiController]
    [Route("[controller]")]
    public class AddItemsController : ControllerBase
    {
        private readonly IItemService _itemService;

        public AddItemsController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpPost]
        public IActionResult CreateItem([FromBody] ItemPro pro)
        {
            var item = pro.ToModel();
            var result = _itemService.AddItem(item.SKU, item.ItemName, item.UnitPrice);
            var msg = "Item successfully created !";
            if (result < 1)
            {
                msg = "Item not created !";
            }

            return Ok(msg);
        }

        [HttpGet]
        [Route("ReadItems")]
        public IActionResult GetItems()
        {
            var items = _itemService.GetItems();
            var result = ItemView.From(items);
            var msg = "Items successfully read !";
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                msg = "Items not found !";
                return Ok(msg);
            }
        }

        [HttpGet]
        [Route("GetItem")]
        public IActionResult GetItem([FromQuery] string sku)
        {
            var item = _itemService.GetItem(sku);
            var result = ItemView.From(item);
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
