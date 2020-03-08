using System;
using System.Collections.Generic;

namespace DnDFrontEnd.Models
{
    public partial class Perception
    {
        public Perception()
        {
            Wisdom = new HashSet<Wisdom>();
        }

        public int Perceptionid { get; set; }
        public string Perceptionprof { get; set; }

        public virtual ICollection<Wisdom> Wisdom { get; set; }
    }
}
