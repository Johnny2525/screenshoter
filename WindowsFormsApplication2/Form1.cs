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
using System.IO;
using System.Diagnostics;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {

        public static Form1 MainForm = null;
        public Form1()
        {
            MainForm = this;

            InitializeComponent();

            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void button1_Click(object sender, EventArgs e) //all prtscr
        {
            this.Opacity = 0;

            Bitmap printscreen = new Bitmap
                (Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics graphics = Graphics.FromImage(printscreen as Image);
            graphics.CopyFromScreen(0, 0, 0, 0, printscreen.Size);

            string user = Environment.UserName;

            printscreen.Save(@"C:\Users\" + user + "\\Desktop\\Screenshot" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg", ImageFormat.Jpeg);

            this.Opacity = 100;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2(); 
            f.Show();
            this.Visible = false;
            //this.Close();
        }
    
    }
}
