using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryService.Interfaces;
using InventoryService.Models;

namespace InventoryService.Services
{
    public class InventoriesServices: IInventoryServices
    {
        private readonly Dictionary<string, InventoryItems> _inventoryItems;


        public InventoriesServices()
        {
            _inventoryItems = new Dictionary<string, InventoryItems>();
        }
        override public InventoryItems AddInventoryItems(InventoryItems items)
        {
            _inventoryItems.Add(items.ItemName, items);

            return items;
        }


        override public Dictionary<string, InventoryItems> GetInventoryItems()
        {

            return _inventoryItems;
        }
    }
}
