using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_integrador
{
    public partial class Form1 : Form
    {
        Boolean dark = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void panel3_MouseHover(object sender, EventArgs e)
        {
            if(!dark == false)
                panel3.BackColor = Color.SteelBlue;
            else
                panel3.BackColor = Color.Gray;
        }

        private void panel3_MouseLeave(object sender, EventArgs e)
        {
            if (!dark == false)
                panel3.BackColor = Color.FromArgb(1, 22, 39);
            else
                panel3.BackColor = Color.FromArgb(85, 85, 85);
        }

        private void panel4_MouseHover(object sender, EventArgs e)
        {
            if(!dark == false)
                panel4.BackColor = Color.SteelBlue;
            else
                panel4.BackColor = Color.Gray;
        }

        private void panel4_MouseLeave(object sender, EventArgs e)
        {
            if(!dark == false)
                panel4.BackColor = Color.FromArgb(1, 22, 39);
            else
                panel4.BackColor = Color.FromArgb(68, 68, 68);
        }

        private void panel5_MouseHover(object sender, EventArgs e)
        {
            if(!dark == false)
                panel5.BackColor = Color.SteelBlue;
            else
                panel5.BackColor = Color.Gray;
        }

        private void panel5_MouseLeave(object sender, EventArgs e)
        {
            if(!dark == false)
                panel5.BackColor = Color.FromArgb(1, 22, 39);
            else
                panel5.BackColor = Color.FromArgb(51, 51, 51);
        }

        private void panel6_MouseHover(object sender, EventArgs e)
        {
            if(!dark == false)
                panel6.BackColor = Color.SteelBlue;
            else
                panel6.BackColor = Color.Gray;
        }

        private void panel6_MouseLeave(object sender, EventArgs e)
        {
            if (!dark == false)
                panel6.BackColor = Color.FromArgb(1, 22, 39);
            else
                panel6.BackColor = Color.FromArgb(34, 34, 34);
        }

        private void panel1_MouseHover(object sender, EventArgs e)
        {
            if(!dark == false)
                panel1.BackColor = Color.SteelBlue;
            else
                panel1.BackColor = Color.Gray;
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            if (!dark == false)
              panel1.BackColor = Color.FromArgb(1, 22, 39);
            else
                panel1.BackColor = Color.FromArgb(17, 17, 17);
        }
 
        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            dark = !dark;
            string ImagePath = Application.StartupPath + @"\";
            if (!dark == true)
            {
                BackColor = Color.FromArgb(18, 18, 18);
                ForeColor = Color.FromArgb(246, 247, 248);
                pictureBox1.BackgroundImage = Image.FromFile(ImagePath + @"assets\Container\Container_dark.png");
                pictureBox2.BackgroundImage = Image.FromFile(ImagePath + @"assets\light.png");
                pictureBox3.BackgroundImage = Image.FromFile(ImagePath + @"assets\Logos\Logo_dark.png");
                panel2.BackColor = Color.FromArgb(102,102,102);
                panel3.BackColor = Color.FromArgb(85,85,85);
                panel4.BackColor = Color.FromArgb(68,68,68);
                panel5.BackColor = Color.FromArgb(51,51,51);
                panel6.BackColor = Color.FromArgb(34,34,34);
                panel1.BackColor = Color.FromArgb(17,17,17);
            }
            if (!dark == false)
            {
                BackColor = Color.White;
                ForeColor = Color.Black;
                pictureBox1.BackgroundImage = Image.FromFile(ImagePath + @"assets\Container\Container_light.png");
                pictureBox2.BackgroundImage = Image.FromFile(ImagePath + @"assets\dark_mode.png");
                pictureBox3.BackgroundImage = Image.FromFile(ImagePath + @"assets\Logos\Logo_light.png");
                panel2.BackColor = Color.FromArgb(32, 164, 243);
                panel3.BackColor = Color.FromArgb(1, 22, 39);
                panel4.BackColor = Color.FromArgb(1, 22, 39);
                panel5.BackColor = Color.FromArgb(1, 22, 39);
                panel6.BackColor = Color.FromArgb(1, 22, 39);
                panel1.BackColor = Color.FromArgb(1, 22, 39);
            }
        }

        private void panel3_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Olá");
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            Formularios.pedido t = new Formularios.pedido();
            t.Show();
        }
    }
}
