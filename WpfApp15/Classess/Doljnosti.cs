using System;
using System.Collections.Generic;

namespace WpfApp15.Classess
{
    public partial class Doljnosti
    {
        public Doljnosti()
        {
            Sotrudnikis = new HashSet<Sotrudniki>();
        }

        public int IdDoljnosti { get; set; }
        public string Doljns { get; set; } = null!;

        public virtual ICollection<Sotrudniki> Sotrudnikis { get; set; }
    }
}
