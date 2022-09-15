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
        AutoCompleteStringCollection produtsColl = new AutoCompleteStringCollection();
        SqlConnection cn = new SqlConnection("workstation id=stareletronics.mssql.somee.com;packet size=4096;user id=daniloitapira_SQLLogin_1;pwd=di63h4yvxh;data source=stareletronics.mssql.somee.com;persist security info=False;initial catalog=stareletronics");
        SqlCommand cmd = null;
        static DataTable n = new DataTable();
        static DataSet ds = new DataSet();
        public pedido()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodPrd.Text != "")
                {
                    /*if (txtCodPrd.Text == t)
                    {
                        i++;
                        MessageBox.Show(i.ToString());
                    }*/
                    string sql = "SELECT * FROM produtos WHERE nome_pr LIKE '%" + txtCodPrd.Text + "%'";
                    cmd = new SqlCommand(sql, cn);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
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
            DateTime dt = DateTime.Now;
            txtData.Text = dt.ToString("dd/MM/yyyy");
            try
            {
                SqlDataReader dReader;
                cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT DISTINCT nome_pr FROM produtos ORDER BY nome_pr ASC";
                cmd.CommandType = CommandType.Text;
                cn.Open();
                dReader = cmd.ExecuteReader();
                if (dReader.HasRows == true)
                {
                    while (dReader.Read())
                        produtsColl.Add(dReader["nome_pr"].ToString());
                }
                else
                {
                    MessageBox.Show("Data not found");
                }
                dReader.Close();
                txtCodPrd.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtCodPrd.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtCodPrd.AutoCompleteCustomSource = produtsColl;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if(num_pedTextBox.Text != "" && cd_cliTextBox.Text != "")
                {
                    string sql = "INSERT INTO  pedido VALUES (@num_ped,@cd_cli,@cd_prod,@data)";
                    cmd = new SqlCommand(sql, cn);
                    cmd.Parameters.Add("@num_ped", SqlDbType.SmallInt).Value = num_pedTextBox.Text;
                    cmd.Parameters.Add("@cd_cli", SqlDbType.Int).Value = cd_cliTextBox.Text;
                    cmd.Parameters.Add("@cd_prod", SqlDbType.SmallInt).Value = txtCodPrd.Text;
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
            // Execução da parte de itens pedidos
            try
            {
                for (int i = 0; i < n.Rows.Count; i++)
                {
                    string sqlData = "INSERT INTO item_pedido VALUES (@cod_prod,@num_pedido)";
                    DataTableReader reader = n.CreateDataReader();
                    if (reader.HasRows == true)
                    {
                        //n.Rows[i][0];
                        object nm_pd = num_pedTextBox.Text;
                        object cd_pr = n.Rows[i][0];
                        SqlCommand cmm = new SqlCommand(sqlData, cn);
                        cmm.Parameters.Add("@num_pedido", SqlDbType.SmallInt).Value = nm_pd;
                        cmm.Parameters.Add("@cod_prod", SqlDbType.SmallInt).Value = cd_pr;
                        cmm.CommandType = CommandType.Text;
                        cn.Open();
                        cmm.ExecuteNonQuery();
                        cn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cn.Close();
                MessageBox.Show("Cadastrados!!!");
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
