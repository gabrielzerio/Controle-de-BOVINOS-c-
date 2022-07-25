using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class pop_up_cadastroLote : Form
    {
        SqlConnection conexao;
        public pop_up_cadastroLote()
        {

            InitializeComponent();
            try
            {
                conexao = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=controleAnimais;Data Source=DESKTOP-KE7MG8N\SQLEXPRESS");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro ao abrir" + ex); //!!!!!!!!!!!!!!!!!
            }
        }
        string dtCompra;
        int nLote;
        float PC;
        string cidadeCompra;




        public static void moeda(ref TextBox txt)
        {
            string n = string.Empty;
            double v = 0;
            try
            {
                n = txt.Text.Replace(",", "").Replace(".", "");
                if (n.Equals(""))
                    n = "";
                n = n.PadLeft(3, '0');
                if (n.Length > 3 & n.Substring(0, 1) == "0")
                    n = n.Substring(1, n.Length - 1);
                v = Convert.ToDouble(n) / 100;
                txt.Text = string.Format("{0:N}", v);
                txt.SelectionStart = txt.Text.Length;

            }
            catch (Exception)
            {

            }
        }

        public void limpaCampos()
        {
            textBoxCadastroCidade.Text = String.Empty;
            textBoxNumLote.Text = String.Empty;
            textBoxPCLote.Text = String.Empty;
            maskedTextBoxDataCompra.Text = String.Empty;
        }
        // LOAD AQUI!!!!!!!!!!!!!!!!
        private void pop_up_cadastroLote_Load(object sender, EventArgs e)
        {
            numeroMaximoLote();
        }

        public void cadastraLote()
        {

            if ((dtCompra != String.Empty) && (textBoxNumLote.Text != String.Empty))
            {

                SqlCommand enviaLote = new SqlCommand("insert into Cadastro_Lote_Gado(nLote,dataCompra,precoCusto,cidadeCompra,fornecedor)values(@nLote,@dataCompra,@precoCusto,@cidadeCompra,@fornecedor)", conexao);

                enviaLote.Parameters.Add("@nLote", SqlDbType.Int).Value = textBoxNumLote.Text;

                enviaLote.Parameters.Add("@dataCompra", SqlDbType.Date).Value = maskedTextBoxDataCompra.Text;

                if (textBoxPCLote.Text != String.Empty)
                {
                    enviaLote.Parameters.Add("@precoCusto", SqlDbType.Float).Value = textBoxPCLote.Text;
                }
                else if (textBoxPCLote.Text == String.Empty)
                {
                    enviaLote.Parameters.Add("@precoCusto", SqlDbType.Float).Value = System.DBNull.Value;
                }

                enviaLote.Parameters.Add("@cidadeCompra", SqlDbType.VarChar).Value = textBoxCadastroCidade.Text;

                enviaLote.Parameters.Add("@fornecedor", SqlDbType.VarChar).Value = textBoxFornecedor.Text;

                try
                {
                    conexao.Open();
                    enviaLote.ExecuteNonQuery();
                    MessageBox.Show("cadastro efetuado");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conexao.Close();
                }
            }
            else
            {

            }
        }


        private void pop_up_cadastroLote_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void buttonEnviar_Click(object sender, EventArgs e)
        {
            cadastraLote();
            limpaCampos();
            numeroMaximoLote();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void textBoxNumLote_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxPCLote_TextChanged(object sender, EventArgs e)
        {
            moeda(ref textBoxPCLote);
        }

        private void buttonDeleta_Click(object sender, EventArgs e)
        {

        }

        public void numeroMaximoLote()
        {
            if (conexao.State == System.Data.ConnectionState.Open)
            {
                conexao.Close();
            }
            try
            {
                conexao.Open();
                SqlCommand buscalotetf = new SqlCommand("Select MAX(nLote) as nLote from Cadastro_Lote_Gado ORDER BY nLote ASC", conexao);
                SqlDataReader resultado = buscalotetf.ExecuteReader();

                if (resultado.Read())
                {
                    if ((resultado["nLote"]) == System.DBNull.Value)
                    {
                        textBoxNumLote.Text = "1";
                    }
                    else
                    {
                        int maxNumLote = Convert.ToInt32(resultado["nLote"]) + 1;
                        textBoxNumLote.Text = maxNumLote.ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conexao.Close();
            }
        }

        private void comboBoxMostraLote_DropDown(object sender, EventArgs e)
        {
            comboBoxMostraLote.Items.Clear();
            if (conexao.State == System.Data.ConnectionState.Open)
            {
                conexao.Close();
            }
            try
            {
                conexao.Open();
                SqlCommand buscalotetf = new SqlCommand("Select nLote from Cadastro_Lote_Gado ORDER BY nLote ASC", conexao);
                SqlDataReader resultado = buscalotetf.ExecuteReader();
                while (resultado.Read())
                {
                    comboBoxMostraLote.Items.Add(resultado["nLote"]);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conexao.Close();
            }
        }

        private void buttonDeletaLote_Click(object sender, EventArgs e)
        {
            if (comboBoxMostraLote.Text != String.Empty)
            {
                if (MessageBox.Show("Tem certeza que deseja Excluir?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SqlCommand delete = new SqlCommand("delete from Cadastro_Lote_Gado where nLote=@nLote", conexao);
                    int comboid = Convert.ToInt32(comboBoxMostraLote.Text);
                    delete.Parameters.Add("@nLote", SqlDbType.Int).Value = comboid;

                    try
                    {
                        // if (conexao.State == System.Data.ConnectionState.Open)
                        // {
                        //     conexao.Close();
                        // }
                        conexao.Open();
                        delete.ExecuteNonQuery();
                        MessageBox.Show("Deletado!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    finally
                    {
                        conexao.Close();
                        comboBoxMostraLote.SelectedIndex = -1;
                    }
                }
                else
                {

                }
            }
            else
            {

            }
        }

        private void comboBoxMostraLote_Leave(object sender, EventArgs e)
        {
            int i;
            if (!int.TryParse(comboBoxMostraLote.Text, out i))
            {
                comboBoxMostraLote.Text = String.Empty;
            }
        }

        private void comboBoxMostraLote_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
