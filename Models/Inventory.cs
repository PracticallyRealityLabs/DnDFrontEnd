using System;
using System.Collections.Generic;

namespace DnDFrontEnd.Models
{
    public partial class Inventory
    {
        public Inventory()
        {
            InventoryHasItems = new HashSet<InventoryHasItems>();
        }

        public int Inventoryid { get; set; }
        public string Encumberance { get; set; }
        public int? Characterid { get; set; }

        public virtual PlayerCharacter Character { get; set; }
        public virtual ICollection<InventoryHasItems> InventoryHasItems { get; set; }
    }
}
