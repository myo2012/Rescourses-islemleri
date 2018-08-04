using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RescoursesLib
{
    public class Dosya
    {
        System.IO.FileStream fs;
        public delegate void ProgressHandle(object sender, Sonuclar e);

        public event ProgressHandle ProgressChanged;

        public void Cikar(string filename)
        {

            int toplam = 0;
            fs = new System.IO.FileStream(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + filename, System.IO.FileMode.OpenOrCreate);
            byte[] dosya = Properties.Resources.setup;
            Sonuclar i = new Sonuclar();
            i.Toplam = dosya.Length;
            foreach (byte b in dosya)
            {
                i.Anlık = toplam;
                fs.WriteByte(b);
                ProgressChanged(new object(), i);
                toplam++;
            }
            fs.Close();
        }
    }
    public class Sonuclar : EventArgs
    {
        public int Anlık { get; set; }
        public int Toplam { get; set; }
    }
}