using System;
using System.Collections.Generic;

namespace DnDFrontEnd.Models
{
    public partial class Persuasion
    {
        public Persuasion()
        {
            Charisma = new HashSet<Charisma>();
        }

        public int Persuasionid { get; set; }
        public string Persausionprof { get; set; }

        public virtual ICollection<Charisma> Charisma { get; set; }
    }
}
