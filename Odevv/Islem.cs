using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odevv
{
    public class Islem
    {
        public string IslemAdi { get; set; }
        public int Fiyat { get; set; }

        public Islem(string islemAdi, int fiyat)
        {
            IslemAdi = islemAdi;
            Fiyat = fiyat;
        }

    }
}
