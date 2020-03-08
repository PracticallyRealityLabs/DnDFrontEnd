using System;
using System.Collections.Generic;

namespace DnDFrontEnd.Models
{
    public partial class Arcana
    {
        public Arcana()
        {
            Intelligence = new HashSet<Intelligence>();
        }

        public int Arcanaid { get; set; }
        public string Arcanaprof { get; set; }

        public virtual ICollection<Intelligence> Intelligence { get; set; }
    }
}
