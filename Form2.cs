using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aspose.Pdf;

namespace islami
{
    public partial class Form2 : Form
    {
        int x, y, d = 0;

        public Form2()
        {
            InitializeComponent();
        }
        //Form move start
        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            d = 1;
            x = e.X;
            y = e.Y;
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (d == 1)
            {
                this.SetDesktopLocation(MousePosition.X - x, MousePosition.Y - y);
            }
        }

        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            d = 0;
        }
        //form move end

        private void Form2_Load(object sender, EventArgs e)
        {
            pdfViewer1.DocumentFilePath = "quran.pdf";
            
         
            
          
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
          
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

    }
}

