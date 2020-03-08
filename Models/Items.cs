using System;
using System.Collections.Generic;

namespace DnDFrontEnd.Models
{
    public partial class Items
    {
        public Items()
        {
            InventoryHasItems = new HashSet<InventoryHasItems>();
        }

        public int Itemsid { get; set; }
        public string Name { get; set; }
        public int? Weight { get; set; }
        public string Type { get; set; }
        public int? Cost { get; set; }
        public string Description { get; set; }
        public bool? Attunementreq { get; set; }

        public virtual ICollection<InventoryHasItems> InventoryHasItems { get; set; }
    }
}
