using System;
using System.Collections.Generic;

namespace DnDFrontEnd.Models
{
    public partial class SleightOfHand
    {
        public SleightOfHand()
        {
            Dexterity = new HashSet<Dexterity>();
        }

        public int Sleightofhandid { get; set; }
        public string Sleightprof { get; set; }

        public virtual ICollection<Dexterity> Dexterity { get; set; }
    }
}
