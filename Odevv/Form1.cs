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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
/*                                                 SAKARYA ÜNİVERSİTESİ
**			                        	BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
**				                              BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
**				                            NESNEYE DAYALI PROGRAMLAMA DERSİ
**				                             	2023-2024 BAHAR DÖNEMİ
**	
**				ÖDEV NUMARASI..........: PROJE
**				ÖĞRENCİ ADI............: BELKIS NİLAY YILMAZ
**				ÖĞRENCİ NUMARASI.......: B231210376
**              DERSİN ALINDIĞI GRUP...:A
 *                                                 
 
 */
namespace Odevv
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();           
        }
       
       

        private void button1_Click(object sender, EventArgs e)

        {          
            Musteri yeniMusteri = new Musteri();

            yeniMusteri.ad = textBox1.Text;
            yeniMusteri.telefon=maskedTextBox1.Text;
            yeniMusteri.tarih = dateTimePicker1.Value;
            yeniMusteri.saat = comboBox2.Text;
            yeniMusteri.calisan = comboBox1.Text;

            yeniMusteri.fiyat = 0;

            List<string> islemler = new List<string>();
            


            if (checkBox1.Checked)
            {
                islemler.Add(checkBox1.Text);
                yeniMusteri.fiyat = yeniMusteri.fiyat + 150;
            }
            if (checkBox2.Checked)
            {
                islemler.Add(checkBox2.Text);
                yeniMusteri.fiyat += 800;
            }
            if (checkBox3.Checked)
            {
                islemler.Add(checkBox3.Text);
                yeniMusteri.fiyat += 3000;
            }
            if (gunluk.Checked)
            {
                islemler.Add(gunluk.Text);
                yeniMusteri.fiyat += 300;
            }
            if (ozel.Checked)
            {
                islemler.Add(ozel.Text);
                yeniMusteri.fiyat += 600;
            }
            if (pro.Checked)
            {
                islemler.Add(pro.Text);
                yeniMusteri.fiyat += 1000;
            }
            if (manikur.Checked)
            {
                islemler.Add(manikur.Text);
                yeniMusteri.fiyat += 250;
            }
            if (nailart.Checked)
            {
                islemler.Add(nailart.Text);
                yeniMusteri.fiyat += 1000;
            }

            label11.Text = Convert.ToString(yeniMusteri.fiyat);

            string dosyaAdi = "Musteri.txt";
            string[] satirlar = File.ReadAllLines(dosyaAdi);

           
            foreach (string satir in satirlar)
            {
                if (satir.Contains($"Tarih: {yeniMusteri.tarih.ToShortDateString()}") &&
                    satir.Contains($"Saat: {yeniMusteri.saat}") &&
                    satir.Contains($"Çalışan: {yeniMusteri.calisan}"))
                {
                    MessageBox.Show("Seçilen tarihte, saatte ve çalışanda başka bir randevu mevcut. Başka bir saat veya çalışan seçiniz.");
                    return; 
                }
            }
       
            using (StreamWriter sw = new StreamWriter(dosyaAdi, true)) 
            {
              
                sw.Write($"Ad: {yeniMusteri.ad}"+" |");
                sw.Write($"Telefon: {yeniMusteri.telefon}"+" |");
                sw.Write($"Tarih: {yeniMusteri.tarih.ToShortDateString()}" + " |");
                sw.Write($"Saat: {yeniMusteri.saat}" + " |");
                sw.Write($"Fiyat: {yeniMusteri.fiyat}" + " |");
                sw.Write($"Çalışan: {yeniMusteri.calisan}" + " |");
                foreach (string islem in islemler)
                {
                    
                    sw.Write($"İşlem: {islem}" + " |");
                }
                sw.WriteLine();

                MessageBox.Show("Müşteri bilgileri Musteri.txt dosyasına kaydedildi.");
            }

           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string dosyaAdi = "Musteri.txt";
            string[] satirlar = File.ReadAllLines(dosyaAdi); 

            string silinecekIsim = textBox2.Text; 

            bool silindi = false; 
            using (StreamWriter sw = new StreamWriter(dosyaAdi))
            {
                foreach (string satir in satirlar)
                {
                    if (!satir.Contains("Ad: " + silinecekIsim))
                    {
                        sw.WriteLine(satir); 
                        
                    }
                    else
                    {
                        silindi = true; 
                    }
                }
            }

            if (silindi)
            {
                MessageBox.Show($"{silinecekIsim} adlı müşteri bilgileri silindi.");
            }
            else
            {
                MessageBox.Show($"{silinecekIsim} adlı müşteri bulunamadı.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            string dosyaAdi = "Musteri.txt";
            string guncellenecekIsim = textBox3.Text; 
            string yeniAd = textBox1.Text;
            string yeniTelefon = maskedTextBox1.Text;
            DateTime yeniTarih = dateTimePicker1.Value;
            string yeniSaat = comboBox2.Text;
            string yeniCalisan = comboBox1.Text;

            List<string> yeniIslemler = new List<string>();
            int yeniFiyat = 0;

            if (checkBox1.Checked)
            {
                yeniIslemler.Add(checkBox1.Text);
                yeniFiyat += 150;
            }
            if (checkBox2.Checked)
            {
                yeniIslemler.Add(checkBox2.Text);
                yeniFiyat += 800;
            }
            if (checkBox3.Checked)
            {
                yeniIslemler.Add(checkBox3.Text);
                yeniFiyat += 3000;
            }
            if (gunluk.Checked)
            {
                yeniIslemler.Add(gunluk.Text);
                yeniFiyat += 300;
            }
            if (ozel.Checked)
            {
                yeniIslemler.Add(ozel.Text);
                yeniFiyat += 600;
            }
            if (pro.Checked)
            {
                yeniIslemler.Add(pro.Text);
                yeniFiyat += 1000;
            }
            if (manikur.Checked)
            {
                yeniIslemler.Add(manikur.Text);
                yeniFiyat += 250;
            }
            if (nailart.Checked)
            {
                yeniIslemler.Add(nailart.Text);
                yeniFiyat += 1000;
            }


        
            string[] satirlar = File.ReadAllLines(dosyaAdi);


          
            using (StreamWriter sw = new StreamWriter("Gecici.txt"))
            {
                bool guncellendi = false; 

                foreach (string satir in satirlar)
                {
                    if (satir.Contains("Ad: " + guncellenecekIsim)) 
                    {
                        
                        sw.Write($"Ad: {yeniAd} |Telefon: {yeniTelefon} |Tarih: {yeniTarih.ToShortDateString()} |Saat: {yeniSaat} |Fiyat: {yeniFiyat} |Çalışan: {yeniCalisan} |");
                        guncellendi = true; 
                        foreach (string islem in yeniIslemler)
                        {
                            
                            sw.Write($"İşlem: {islem}" + " |");
                        }
                        sw.WriteLine();
                    }
                    else
                    {
                        sw.WriteLine(satir);
                    }

                }
               
                

                if (!guncellendi) 
                {
                    MessageBox.Show($"{guncellenecekIsim} adlı müşteri bulunamadı.");
                }
                else
                {
                    MessageBox.Show($"{guncellenecekIsim} adlı müşterinin bilgileri güncellendi.");
                }
            }

    
            File.Delete(dosyaAdi); 
            File.Move("Gecici.txt", dosyaAdi);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Randevular randevular = new Randevular();
            randevular.Show();
            
          
        }
        private void Form2_IscilerEklendi(List<Isci> isciler)
        {
         
            foreach (var isci in isciler)
            {
                comboBox1.Items.Add(isci.Ad);
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            maskedTextBox1.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            gunluk.Checked = false;
            ozel.Checked = false;
            pro.Checked = false;
            manikur.Checked = false;
            nailart.Checked = false;

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string dosyaAdi = "Musteri.txt";
            string guncellenecekIsim = textBox3.Text;

            string[] satirlar = File.ReadAllLines(dosyaAdi);
            bool bulundu = false;

            foreach (string satir in satirlar)
            {
                if (satir.Contains("Ad: " + guncellenecekIsim))
                {
                    string[] bilgiler = satir.Split(new[] { " |" }, StringSplitOptions.None);
                    foreach (string bilgi in bilgiler)
                    {
                        if (bilgi.StartsWith("Ad: "))
                        {
                            textBox1.Text = bilgi.Replace("Ad: ", "").Trim();
                        }
                        else if (bilgi.StartsWith("Telefon: "))
                        {
                            maskedTextBox1.Text = bilgi.Replace("Telefon: ", "").Trim();
                        }
                        else if (bilgi.StartsWith("Tarih: "))
                        {
                            dateTimePicker1.Value = DateTime.Parse(bilgi.Replace("Tarih: ", "").Trim());
                        }
                        else if (bilgi.StartsWith("Saat: "))
                        {
                            comboBox2.Text = bilgi.Replace("Saat: ", "").Trim();
                        }
                        else if (bilgi.StartsWith("Çalışan: "))
                        {
                            comboBox1.Text = bilgi.Replace("Çalışan: ", "").Trim();
                        }
                        else if (bilgi.StartsWith("İşlem: Kesim"))
                        {
                            checkBox1.Checked = true;
                        }
                        else if (bilgi.StartsWith("İşlem: Boya"))
                        {
                            checkBox2.Checked = true;
                        }
                        else if (bilgi.StartsWith("İşlem: Topuz"))
                        {
                            checkBox3.Checked = true;
                        }
                        else if (bilgi.StartsWith("İşlem: Günlük"))
                        {
                            gunluk.Checked = true;
                        }
                        else if (bilgi.StartsWith("İşlem: özel gün"))
                        {
                            ozel.Checked = true;
                        }
                        else if (bilgi.StartsWith("İşlem: Manikür"))
                        {
                            manikur.Checked = true;
                        }
                        else if (bilgi.StartsWith("İşlem: Nail art"))
                        {
                            nailart.Checked = true;
                        }
                        else if (bilgi.StartsWith("İşlem: profesonel"))
                        {
                            pro.Checked = true;
                        }


                    }

                    bulundu = true;
                    break; 
                }
            }

            if (!bulundu)
            {
                MessageBox.Show("Müşteri bulunamadı.");
            }

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
          
            if (string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Lütfen şifre girin");
            }
            else
            if (textBox4.Text == textBox5.Text)
            {
                
                Form2 form2 = new Form2(); 
                form2.Show(); 
            }



        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
