using System;
using System.Collections.Generic;

namespace WpfApp15.Classess
{
    public partial class Stavka
    {
        public Stavka()
        {
            Sotrudnikis = new HashSet<Sotrudniki>();
        }

        public int IdStavka { get; set; }
        public string Type { get; set; } = null!;

        public virtual ICollection<Sotrudniki> Sotrudnikis { get; set; }
    }
}
