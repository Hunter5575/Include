using System;
using System.Collections.Generic;

namespace WpfApp15.Classess
{
    public partial class Smena
    {
        public Smena()
        {
            Sotrudnikis = new HashSet<Sotrudniki>();
        }

        public int IdSmena { get; set; }
        public string Type { get; set; } = null!;
        public string Time { get; set; } = null!;

        public virtual ICollection<Sotrudniki> Sotrudnikis { get; set; }
    }
}
