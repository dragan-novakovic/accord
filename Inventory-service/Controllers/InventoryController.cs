using Microsoft.AspNetCore.Mvc;
using InventoryService.Models;
using InventoryService.Services;
using InventoryService.Interfaces;
using System.Collections.Generic;

namespace InventoryService.Controllers
{
    [Route("v1/")]
    [ApiController]
    public class InventoryController : Controller
    {
        private readonly IInventoryServices _service;
        public InventoryController(IInventoryServices services)
        {
            _service = services;
        }

        [HttpPost]
        [Route("AddInventoryItems")]
        public ActionResult<InventoryItems> AddInventoryItems(InventoryItems items)
        {
            InventoryItems inventoryItems = _service.AddInventoryItems(items);

            if (inventoryItems == null)
            {
                return NotFound();
            }
            return inventoryItems;
        }

        [HttpGet]
        [Route("GetInventoryItems")]
        public ActionResult<Dictionary<string, InventoryItems>> GetInventoryItems()
        {

            var inventoryItems = _service.GetInventoryItems();

            if (inventoryItems.Count == 0)
            {
                return NotFound();
            }


            return inventoryItems;
        }
    }
}
