using System;
using System.Collections.Generic;

namespace DnDFrontEnd.Models
{
    public partial class Acrobatics
    {
        public Acrobatics()
        {
            Dexterity = new HashSet<Dexterity>();
        }

        public int Acrobaticsid { get; set; }
        public string Acrobaticsprof { get; set; }

        public virtual ICollection<Dexterity> Dexterity { get; set; }
    }
}
