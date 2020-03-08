using System;
using System.Collections.Generic;

namespace DnDFrontEnd.Models
{
    public partial class AnimalHandling
    {
        public AnimalHandling()
        {
            Wisdom = new HashSet<Wisdom>();
        }

        
        public int AnimalHandlingId { get; set; }
        public string Animalhandprof { get; set; }

        public virtual ICollection<Wisdom> Wisdom { get; set; }
    }
}
