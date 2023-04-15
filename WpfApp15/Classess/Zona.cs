using System;
using System.Collections.Generic;

namespace WpfApp15.Classess
{
    public partial class Zona
    {
        public Zona()
        {
            Sotrudnikis = new HashSet<Sotrudniki>();
        }

        public int IdZona { get; set; }
        public string Zona1 { get; set; } = null!;

        public virtual ICollection<Sotrudniki> Sotrudnikis { get; set; }
    }
}
