using System;
using System.Collections.Generic;

namespace DnDFrontEnd.Models
{
    public partial class Performance
    {
        public Performance()
        {
            Charisma = new HashSet<Charisma>();
        }

        public int Performanceid { get; set; }
        public string Performanceprof { get; set; }

        public virtual ICollection<Charisma> Charisma { get; set; }
    }
}
