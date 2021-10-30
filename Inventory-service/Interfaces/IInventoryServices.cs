using InventoryService.Controllers;
using InventoryService.Models;

namespace InventoryService.Interfaces
{
    public abstract class IInventoryServices
    {
        abstract public UserInventory AddExp(UserInventory body);
        abstract public UserInventory GetUserInventory(int id);
        abstract public UserInventory CreateUserInventory(int id);
        internal abstract UserInventory AddRating(UserInventory body);
    }
}
