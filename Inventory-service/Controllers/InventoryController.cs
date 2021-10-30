using Microsoft.AspNetCore.Mvc;
using InventoryService.Models;
using InventoryService.Interfaces;

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
        public ActionResult<string> CreateUserInventory(int id)
        {
           // UserInventory userInventory = _service.CreateUserInventory(id);

           // if (userInventory == null)
          //  {
          //      return NotFound();
         //   }
            return "HI";
        }

        [HttpPost]
        [Route("AddExp")]
        public ActionResult<UserInventory> AddExp(uint amount)
        {
            UserInventory userInventory = _service.AddExp(amount);

            if (userInventory == null)
            {
                return NotFound();
            }
            return userInventory;
        }

        [HttpPost]
        [Route("AddRating")]
        public ActionResult<UserInventory> AddRating(int rating)
        {
            UserInventory inventoryItems = null;

            if (inventoryItems == null)
            {
                return NotFound();
            }
            return inventoryItems;
        }

        [HttpPost]
        [Route("inventory")]
        public ActionResult<UserInventory> GetUserInventory(int id)
        {

            var userInventory = _service.GetUserInventory(id);

            if (userInventory == null)
            {
                return NotFound();
            }


            return userInventory;
        }
    }
}
