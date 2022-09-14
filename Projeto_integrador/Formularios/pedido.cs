using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Projeto_integrador.Formularios
{
    public partial class pedido : Form
    { 
        SqlConnection cn = new SqlConnection("workstation id=stareletronics.mssql.somee.com;packet size=4096;user id=daniloitapira_SQLLogin_1;pwd=di63h4yvxh;data source=stareletronics.mssql.somee.com;persist security info=False;initial catalog=stareletronics");
        SqlCommand cmd = null;
        public pedido()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 1;
            string t = txtCodPrd.Text;
            
            try
            {
                if (txtCodPrd.Text != "")
                {
                    if (txtCodPrd.Text == t)
                    {
                        i++;
                        MessageBox.Show(i.ToString());
                    }
                    string sql = "SELECT * FROM produtos WHERE nome_pr LIKE '%" + txtCodPrd.Text + "%'";
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    da.Fill(n);
                    dataGridView1.DataSource = n;
                }
                else
                {
                    MessageBox.Show("Erro", "Preencha o campo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
            finally
            { 
                cn.Close();
            }
        }

        private void pedido_Load(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Today;
            txtData.Text = dt.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if(num_pedTextBox.Text != "" && cd_cliTextBox.Text != "" && txtNomeCli.Text != "")
                {
                    string sql = "INSERT INTO pedido VALUES (@num_ped,@cd_cli,cd_pr,@nome_cli,@data)";
                    cmd = new SqlCommand(sql, cn);
                    cmd.Parameters.Add("@num_ped", SqlDbType.SmallInt).Value = num_pedTextBox.Text;
                    cmd.Parameters.Add("@cd_cli", SqlDbType.Int).Value = cd_cliTextBox.Text;
                    cmd.Parameters.Add("@cd_pr", SqlDbType.SmallInt).Value = txtCodPrd.Text;
                    cmd.Parameters.Add("@nome_cli", SqlDbType.VarChar).Value = txtNomeCli.Text;
                    cmd.Parameters.Add("@data", SqlDbType.VarChar).Value = txtData.Text;
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
