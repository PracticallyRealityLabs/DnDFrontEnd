using System;
using System.Collections.Generic;

namespace DnDFrontEnd.Models
{
    public partial class Insight
    {
        public Insight()
        {
            Wisdom = new HashSet<Wisdom>();
        }

        public int Insightid { get; set; }
        public string Insighprof { get; set; }

        public virtual ICollection<Wisdom> Wisdom { get; set; }
    }
}
