using System;
using System.Collections.Generic;
using System.Linq;

namespace WpfApp15.Classess
{
    public partial class Sotrudniki
    {
        public int IdSotrudniki { get; set; }
        public string SecondName { get; set; } 
        public string FirstName { get; set; } 
        public string Patronimyc { get; set; }
        public string IO
        {
            get
            {
                string IOout = FirstName.First() + ". ";
                if (Patronimyc !=null)
                    IOout+=Patronimyc.First()+ ".";
                return IOout;
            }
        }
        public string FIO => SecondName + " " + IO;
        public override string ToString()
        {
            return FIO;
        }
        public int Doljn { get; set; }
        public int Zona { get; set; }
        public int Smena { get; set; }
        public int TipStavki { get; set; }
        public decimal Stavka { get; set; }

        public virtual Doljnosti DoljnNavigation { get; set; } = null!;
        public virtual Smena SmenaNavigation { get; set; } = null!;
        public virtual Stavka TipStavkiNavigation { get; set; } = null!;
        public virtual Zona ZonaNavigation { get; set; } = null!;
        
    }
}
