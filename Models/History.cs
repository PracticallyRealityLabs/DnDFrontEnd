using System;
using System.Collections.Generic;

namespace DnDFrontEnd.Models
{
    public partial class History
    {
        public History()
        {
            Intelligence = new HashSet<Intelligence>();
        }

        public int Historyid { get; set; }
        public string Historyprof { get; set; }

        public virtual ICollection<Intelligence> Intelligence { get; set; }
    }
}
