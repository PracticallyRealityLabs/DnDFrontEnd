using System;
using System.Collections.Generic;

namespace DnDFrontEnd.Models
{
    public partial class Investigation
    {
        public Investigation()
        {
            Intelligence = new HashSet<Intelligence>();
        }

        public int Investigationid { get; set; }
        public string Investigationprof { get; set; }

        public virtual ICollection<Intelligence> Intelligence { get; set; }
    }
}
