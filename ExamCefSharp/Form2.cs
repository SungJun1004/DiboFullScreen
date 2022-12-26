using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FullScreen
{

        public partial class Form2 : Form
    {
        public static string URLMessage  = "";
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            URLMessage = textBox1.Text;
            Properties.Settings.Default.strURL = textBox1.Text;
            Properties.Settings.Default.Save();
            this.Close(); 
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // this.Size = new Size(2000, 1400);
            // this.Location = new Point(1000,2000);
            Rectangle fullScrenn_bounds; 
            fullScrenn_bounds = Rectangle.Empty;

            foreach (var screen in Screen.AllScreens)
            {
                fullScrenn_bounds = Rectangle.Union(fullScrenn_bounds, screen.Bounds);
            }
            this.Location = new Point(fullScrenn_bounds.Width/2 - 300, fullScrenn_bounds.Height/2 - 100);

            textBox1.Text = Properties.Settings.Default.strURL;
        }
    }
}
