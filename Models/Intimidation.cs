using System;
using System.Collections.Generic;

namespace DnDFrontEnd.Models
{
    public partial class Intimidation
    {
        public Intimidation()
        {
            Charisma = new HashSet<Charisma>();
        }

        public int Intimidationid { get; set; }
        public string Intimidationprof { get; set; }

        public virtual ICollection<Charisma> Charisma { get; set; }
    }
}
