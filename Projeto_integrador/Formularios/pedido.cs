using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_integrador.Formularios
{
    public partial class pedido : Form
    {
        private const int TextBoxX = 5;                //Posição horizontal do textbox no painel
        private const int TextBoxWidth = 300;          //Largura do textbox
        private const int ButtonX = TextBoxWidth + 10; //Posição horizontal do button no painel
        private int _controlY = 16;
        public pedido()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Controls.AddRange(new Control[]
            {
                new TextBox
                {
                    Location = new Point(TextBoxX, _controlY),
                    Size = new Size(300, 20)
                },

                new Button
                {
                    Text = "Texto",
                    Location = new Point(ButtonX, _controlY),
                    Size = new Size(100, 20)
                }
            });
            _controlY += 25;
        }
    }
}
