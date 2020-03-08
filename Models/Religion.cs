using System;
using System.Collections.Generic;

namespace DnDFrontEnd.Models
{
    public partial class Religion
    {
        public Religion()
        {
            Intelligence = new HashSet<Intelligence>();
        }

        public int Religionid { get; set; }
        public string Religionprof { get; set; }

        public virtual ICollection<Intelligence> Intelligence { get; set; }
    }
}
