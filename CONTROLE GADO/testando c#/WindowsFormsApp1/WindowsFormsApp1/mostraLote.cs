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
    public partial class mostraLote : Form
    {

        SqlConnection conexao;
        public mostraLote()
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
    

        private void mostraLote_Load(object sender, EventArgs e)
        {

        }

        public void mostraLoteDataGrid()
        {
            try
            {
                conexao.Open();
                SqlDataAdapter t = new SqlDataAdapter("select ID,raca,dataNasc,sexo,descricao,mae,cor,dataCompra,precoCusto,lote from Cadastro_Gado where lote='" + comboBoxSelecionaLote.Text + "'", conexao);
                DataSet DS = new DataSet(); // objeto na memória para armazenar tabelas
                t.Fill(DS); // objeto para preencher o DataSet
                dataGridView1.DataSource = DS.Tables[0];
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

        public void mostraLoteTexts()
        {
                try
                {
                    SqlCommand buscaLote = new SqlCommand("select dataCompra,precoCusto,cidadeCompra,fornecedor from Cadastro_Lote_Gado where nLote=@nLote", conexao);
                    buscaLote.Parameters.Add("@nLote", SqlDbType.Int).Value = Convert.ToInt32(comboBoxSelecionaLote.Text);
                    conexao.Open();
                    SqlDataReader resultadoLote = buscaLote.ExecuteReader();
                    if (resultadoLote.Read())
                    {
                    maskedTextBoxDataCompra.Text = resultadoLote["dataCompra"].ToString();
                    textBoxValorLote.Text = resultadoLote["precoCusto"].ToString();
                    richTextBoxCidadeCompra.Text = resultadoLote["cidadeCompra"].ToString();
                    richTextBoxFornecedor.Text = resultadoLote["fornecedor"].ToString();
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

        public void relacionaCabeças()
        {
            int recolheQtd=0;
            string recolheId = String.Empty;
            try
            {
                SqlCommand buscaCabeças = new SqlCommand("select ID from Cadastro_Gado where lote=@lote", conexao);
                buscaCabeças.Parameters.Add("@lote", SqlDbType.Int).Value = Convert.ToInt32(comboBoxSelecionaLote.Text);
                conexao.Open();
                SqlDataReader resultadoCabeças = buscaCabeças.ExecuteReader();
                while (resultadoCabeças.Read())
                {
                    recolheQtd++;
                    if (recolheQtd == 1)
                    {
                        recolheId += resultadoCabeças["ID"].ToString();
                    }
                    else
                    {
                        recolheId += ", " + resultadoCabeças["ID"].ToString();
                    }
                }
                textBoxQtdCabeças.Text = recolheQtd.ToString();
                richTextBoxIds.Text = recolheId;
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
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSelecionaLote.Text != String.Empty)
            {
                mostraLoteDataGrid();
                mostraLoteTexts();
                relacionaCabeças();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            comboBoxSelecionaLote.Items.Clear();
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
                    comboBoxSelecionaLote.Items.Add(resultado["nLote"]);
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

        private void comboBoxSelecionaLote_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                if (comboBoxSelecionaLote.Text != String.Empty)
                {
                    mostraLoteDataGrid();
                    mostraLoteTexts();
                    relacionaCabeças();
                }
            }
        }
    }
}
