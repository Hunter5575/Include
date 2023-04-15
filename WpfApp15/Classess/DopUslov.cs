using System;
using System.Collections.Generic;

namespace WpfApp15.Classess
{
    public partial class DopUslov
    {
        public int IdDopUslov { get; set; }
        public string Uslov { get; set; } = null!;
        public int Type { get; set; }
        public decimal Summa { get; set; }

        public virtual TypeUslov TypeNavigation { get; set; } = null!;
    }
}
