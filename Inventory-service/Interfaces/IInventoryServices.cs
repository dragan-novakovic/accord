using InventoryService.Models;

namespace InventoryService.Interfaces
{
    public abstract class IInventoryServices
    {
        abstract public UserInventory AddExp(uint amount);
        abstract public UserInventory GetUserInventory(int id);
        abstract public UserInventory CreateUserInventory(int id);
    }
}
