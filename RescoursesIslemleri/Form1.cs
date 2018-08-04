using RescoursesLib;
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

namespace RescoursesIslemleri
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void Çıkar(string dosyaadi)
        {
            byte[] dosya = Properties.Resources.setup; //Rescourses daki dosyayı byte dizisine aktarır
            System.IO.FileStream fs = new System.IO.FileStream(dosyaadi, FileMode.CreateNew);//FileStream sınıfı ile aldığı dosyaadi paramaetresine göre dosya oluşturur
            progressBar1.Maximum = dosya.Length;//Dizinin uzunluğunu progressbar1 in maximum değerini belirtir.
            foreach (byte b in dosya)
            {
                fs.WriteByte(b);//Döngü ile oluşturulan byte dizisini dosyaadi üzerisine yazar
                progressBar1.Value++;//byte yazdırıldıkça progressbar ın valuesi arttırılır ve ekrana yansır
            }
            fs.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog kaydet = new SaveFileDialog();
            kaydet.Filter = "Uygulama Dosyası (*.exe) |*.exe";
            if (kaydet.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox1.Text = kaydet.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Çıkar(textBox1.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Dosya dosya = new Dosya();
            dosya.ProgressChanged += Dosya_ProcChanged;
            dosya.Cikar("Setup.exe");

        }

        void Dosya_ProcChanged(object sender, RescoursesLib.Sonuclar e)
        {
            progressBar1.Maximum = e.Toplam;
            progressBar1.Value = e.Anlık;
        }
    }
}
