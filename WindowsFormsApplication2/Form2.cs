using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace WindowsFormsApplication2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;

            this.TransparencyKey = Color.Turquoise;
            this.BackColor = Color.Turquoise;
        }

        int x_1, y_1, x_2, y_2;
        int wid, hei;

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            x_1 = e.X;
            y_1 = e.Y;
      
        }

        private void Form2_MouseUp(object sender, MouseEventArgs e)
        {

            x_2 = e.X;
            y_2 = e.Y;

            wid = x_1 - x_2;
            if (wid < 0 ) { wid = wid * (-1); }

            hei = y_1 - y_2;
            if (hei < 0 ) { hei = hei * (-1); }  
            
            Rectangle rect = new Rectangle(x_1, y_1, hei, wid);
            Bitmap bmp = new Bitmap(wid, hei, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bmp);
            g.CopyFromScreen(x_1, y_1, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy);
     

            string user = Environment.UserName;
            bmp.Save(@"C:\Users\" + user + "\\Desktop\\Screenshot" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg", ImageFormat.Jpeg);

            Form1.MainForm.Visible = true;
            this.Close();
        }


        



    } 
}
