using System;
using InventoryService.Interfaces;
using InventoryService.Models;

namespace InventoryService.Services
{
    public class InventoriesServices : IInventoryServices
    {
        private readonly UserInventory _userInventory;
        private readonly InventoryContext _context;


        public InventoriesServices(InventoryContext context)
        {
            _userInventory = new UserInventory();
            _context = context;
        }

        override public UserInventory AddExp(UserInventory reqBody)
        {
            UserInventory userInventory = _context.Find<UserInventory>(reqBody.Id);

            userInventory.Exp = userInventory.Exp + reqBody.Exp;

            _context.Update(userInventory);
            _context.SaveChanges();

            return userInventory;
        }

        public override UserInventory CreateUserInventory(int id)
        {
            UserInventory userInventory = new UserInventory()
            {
                Exp = 0,
                PositiveRating = 0,
                NegativeRating = 0,
                Id = id
            };

            // handle Error?
            _context.Add(userInventory);
            _context.SaveChanges();


            return userInventory;
        }

        public override UserInventory GetUserInventory(int id)
        {
            throw new NotImplementedException();
        }

        internal override UserInventory AddRating(UserInventory body)
        {
            throw new NotImplementedException();
        }
    }
}
