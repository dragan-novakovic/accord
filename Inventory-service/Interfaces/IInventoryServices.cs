using InventoryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.Interfaces
{
    public abstract class IInventoryServices
    {
        abstract public InventoryItems AddInventoryItems(InventoryItems items);
        abstract public Dictionary<string, InventoryItems> GetInventoryItems();
    }
}
