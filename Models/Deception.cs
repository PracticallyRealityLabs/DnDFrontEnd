using System;
using System.Collections.Generic;

namespace DnDFrontEnd.Models
{
    public partial class Deception
    {
        public Deception()
        {
            Charisma = new HashSet<Charisma>();
        }

        public int Deceptionid { get; set; }
        public string Deceptionprof { get; set; }

        public virtual ICollection<Charisma> Charisma { get; set; }
    }
}
