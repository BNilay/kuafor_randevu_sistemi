using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Odevv
{
    public partial class Randevular : Form
    {
        public Randevular()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string dosyaadı = "Musteri.txt";

            using (StreamReader sr = new StreamReader(dosyaadı))
            {
                string satir;
                while ((satir = sr.ReadLine()) != null)
                {
                    richTextBox1.AppendText(satir + Environment.NewLine);
                }
            }
        }
    }
}
