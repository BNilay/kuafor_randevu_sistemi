using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odevv
{
    public class Musteri
    {
        public string ad {  get; set; }
        public string telefon { get; set; }
        public DateTime tarih { get; set; }
        public string saat {  get; set; }
        public string islem { get; set; }
        public string calisan { get; set; }
        public int fiyat { get; set; }
        public List<Islem> YapilanIslemler { get; set; }

        public Musteri()
        {
            YapilanIslemler = new List<Islem>();
        }
    }
}

