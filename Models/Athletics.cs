using System;
using System.Collections.Generic;

namespace DnDFrontEnd.Models
{
    public partial class Athletics
    {
        public Athletics()
        {
            Strength = new HashSet<Strength>();
        }

        public int Athleticsid { get; set; }
        public string Athleticsproficiency { get; set; }

        public virtual ICollection<Strength> Strength { get; set; }
    }
}
