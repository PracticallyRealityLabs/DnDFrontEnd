using System;
using System.Collections.Generic;

namespace DnDFrontEnd.Models
{
    public partial class InventoryHasItems
    {
        public int? InventoryHasItemsid { get; set; }
        public int? Inventoryid { get; set; }
        public int? Itemid { get; set; }
        public bool? Active { get; set; }
        public bool? Isattuned { get; set; }
        public int? Quantity { get; set; }

        public virtual Inventory Inventory { get; set; }
        public virtual Items Item { get; set; }
    }
}
