using Microsoft.AspNetCore.Mvc;
using InventoryService.Models;
using InventoryService.Interfaces;
using System;

namespace InventoryService.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class InventoryController : Controller
    {
        private readonly IInventoryServices _service;
        public InventoryController(IInventoryServices services)
        {
            _service = services;
        }

        [HttpPost]
        [Route("create")]
        public ActionResult<UserInventory> CreateUserInventory([FromBody] UserInventory requestBody)
        {
            UserInventory userInventory = _service.CreateUserInventory(requestBody.Id);

            if (userInventory == null)
            {
                return NotFound();
            }
            return userInventory;
        }

        [HttpPost]
        [Route("AddExp")]
        public ActionResult<UserInventory> AddExp([FromBody] UserInventory requestBody)
        {
            UserInventory userInventory = _service.AddExp(requestBody);

            if (userInventory == null)
            {
                return NotFound();
            }
            return userInventory;
        }

        [HttpPost]
        [Route("AddRating")]
        public ActionResult<UserInventory> AddRating([FromBody] UserInventory requestBody)

        {
            UserInventory inventoryItems = _service.AddRating(requestBody);

            if (inventoryItems == null)
            {
                return NotFound();
            }
            return inventoryItems;
        }

        [HttpPost]
        [Route("inventory")]
        public ActionResult<UserInventory> GetUserInventory([FromBody] UserInventory reqBody)
        {

            var userInventory = _service.GetUserInventory(reqBody.Id);

            if (userInventory == null)
            {
                return NotFound();
            }


            return userInventory;
        }
    }
}


