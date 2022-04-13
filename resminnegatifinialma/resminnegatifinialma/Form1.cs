using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace resminnegatifinialma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            OpenFileDialog sfd = new OpenFileDialog();
            sfd.Filter = "resimler|*.bmp|All Files|*.*";
            if (sfd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            pictureBox1.ImageLocation = sfd.FileName;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Color OkunanRenk, DonusenRenk;
            int R = 0, G = 0, B = 0;

            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(pictureBox1.Image);

            int ResimGenisligi = GirisResmi.Width;//girisresmi global tanımlandı içerisine görüntü yüklendi.
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);//çıkış resmi oluşturuluyor.boyutlar giriş resmi ile aynı olur tanımlaması globalde yapıldı.

            int i = 0, j = 0;
            for(int x=0; x<ResimGenisligi;x++)
            {
                for(int y=0; y<ResimYuksekligi;y++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x, y);

                    R = 255 - OkunanRenk.R;
                    G = 255 - OkunanRenk.G;
                    B = 255 - OkunanRenk.B;

                    DonusenRenk = Color.FromArgb(R, G, B);
                    CikisResmi.SetPixel(x, y, DonusenRenk);

                }
            }
            pictureBox2.Image = CikisResmi;

        }
    }
}
