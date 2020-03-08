using System;
using System.Collections.Generic;

namespace DnDFrontEnd.Models
{
    public partial class Nature
    {
        public Nature()
        {
            Intelligence = new HashSet<Intelligence>();
        }

        public int Natureid { get; set; }
        public string Natureprof { get; set; }

        public virtual ICollection<Intelligence> Intelligence { get; set; }
    }
}
