using System;
using System.Collections.Generic;

namespace WpfApp15.Classess
{
    public partial class TypeUslov
    {
        public TypeUslov()
        {
            DopUslovs = new HashSet<DopUslov>();
        }

        public int IdTypeUslov { get; set; }
        public string Type { get; set; } = null!;

        public virtual ICollection<DopUslov> DopUslovs { get; set; }
    }
}
