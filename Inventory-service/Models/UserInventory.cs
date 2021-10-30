using System;
using System.ComponentModel.DataAnnotations;

namespace InventoryService.Models
{
    public class UserInventory
    {
        [Key]
        public int Id { get; set; }
        public UInt32 Exp { get; set; }
        public int PositiveRating { get; set; }
        public int NegativeRating { get; set; }
        public Trinket[] Trinkets { get; set; }
    }
}
