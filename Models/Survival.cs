using System;
using System.Collections.Generic;

namespace DnDFrontEnd.Models
{
    public partial class Survival
    {
        public Survival()
        {
            Wisdom = new HashSet<Wisdom>();
        }

        public int Survivalid { get; set; }
        public string Survivalprof { get; set; }

        public virtual ICollection<Wisdom> Wisdom { get; set; }
    }
}
