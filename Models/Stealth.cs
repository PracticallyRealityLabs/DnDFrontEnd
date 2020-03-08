using System;
using System.Collections.Generic;

namespace DnDFrontEnd.Models
{
    public partial class Stealth
    {
        public Stealth()
        {
            Dexterity = new HashSet<Dexterity>();
        }

        public int Stealthid { get; set; }
        public string Stealthprof { get; set; }

        public virtual ICollection<Dexterity> Dexterity { get; set; }
    }
}
