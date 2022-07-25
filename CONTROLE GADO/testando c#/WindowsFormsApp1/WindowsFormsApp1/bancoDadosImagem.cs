using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class bancoDadosImagem : Form
    {


        SqlConnection conexao;
        public bancoDadosImagem()
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
        ///AREA DAS VARIAVEIS!!!!!
        Bitmap bmp;
        // ArrayList gravaTituFoto = new ArrayList();
        Boolean gravaTituTF;
        Boolean verificaSalvo = true;
        ///

        public void limpaTabelaImagem()
        {
            comboBoxBuscaID.Text = String.Empty;
            textBoxTitulo.Text = String.Empty;
            listBoxLista.Items.Clear();
            pictureBox1.Image = null;
        }
        private void buttonSelecionar_Click(object sender, EventArgs e)
        {
            
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string nome = openFileDialog1.FileName;
                    bmp = new Bitmap(nome);
                    pictureBox1.Image = bmp;
                }
            
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null && textBoxTitulo.Text != String.Empty && comboBoxBuscaID.Text != String.Empty)
            {
                MemoryStream memory = new MemoryStream();
                bmp.Save(memory, ImageFormat.Bmp);
                byte[] foto = memory.ToArray();
                //verifica
                string pegaTexto = textBoxTitulo.Text; // pega texto
                conexao.Open();
                SqlCommand busca = new SqlCommand("select FileName from tabelaImagens where FileName=@FileName AND ID=@ID", conexao);
                busca.Parameters.Add("@FileName", SqlDbType.VarChar).Value = pegaTexto;
                busca.Parameters.Add("@ID", SqlDbType.Int).Value = comboBoxBuscaID.Text;
                SqlDataReader resultado = busca.ExecuteReader();
                if (resultado.Read())
                {
                    if (resultado["FileName"].ToString() == pegaTexto)
                    {
                        pegaTexto += "0";
                    }
                }
                conexao.Close();
                SqlCommand Imagem = new SqlCommand("insert into tabelaImagens (ID, FileName, Data) values(@ID,@FileName,@Data)", conexao);
                Imagem.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt32(comboBoxBuscaID.Text);
                Imagem.Parameters.Add("@FileName", SqlDbType.VarChar).Value = pegaTexto;
                Imagem.Parameters.Add("@Data", SqlDbType.Binary).Value = foto;
                try
                {
                    conexao.Open();
                    Imagem.ExecuteNonQuery();
                }
                catch (Exception E)
                {
                    MessageBox.Show(E.Message);
                }
                finally
                {
                    conexao.Close();
                    verificaSalvo = true;
                    listBoxLista.Items.Add(pegaTexto);
                    listBoxLista.SelectedItem = pegaTexto;
                    textBoxTitulo.Text = String.Empty;
                }
            }
            else if (pictureBox1.Image == null)
                MessageBox.Show("é necessario selecionar uma foto antes de salvar");
            else if (textBoxTitulo.Text == String.Empty)
                MessageBox.Show("é necessario escrever um titulo");
            else if (comboBoxBuscaID.Text == String.Empty)
                MessageBox.Show("é necessario selecionar um ID");
        }

        private void bancoDadosImagem_Load(object sender, EventArgs e)
        {
            attcombo();
        }
        public void attcombo()
        {
            try
            {
                conexao.Open();
                comboBoxBuscaID.Items.Clear();
                SqlCommand busca_ID = new SqlCommand("Select ID from Cadastro_Gado", conexao);
                SqlDataReader resultado = busca_ID.ExecuteReader();
                while (resultado.Read())
                {
                    comboBoxBuscaID.Items.Add(resultado["ID"].ToString());
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxLista.Items.Clear();
            SqlCommand busca = new SqlCommand("select * from tabelaImagens where ID=@ID", conexao);
            busca.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt32(comboBoxBuscaID.Text);
            try
            {
                conexao.Open();
                SqlDataReader resultado = busca.ExecuteReader();
                while (resultado.Read())
                {
                    listBoxLista.Items.Add(resultado["FileName"].ToString());
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.ToString());
            }
            finally
            {
                conexao.Close();
            }
            // foreach (var item in listBox1.Items)
            // {
            //    gravaTituFoto.Add(item);
            //}
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            SqlCommand busca = new SqlCommand("select Data from tabelaImagens where ID=@ID AND FileName=@FileName", conexao);
            busca.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt32(comboBoxBuscaID.Text);
            busca.Parameters.Add("@FileName", SqlDbType.VarChar).Value = Convert.ToString(listBoxLista.SelectedItem);
            try
            {
                conexao.Open();
                SqlDataReader resultado = busca.ExecuteReader();
                if (resultado.Read())
                {
                    byte[] imagem = (byte[])(resultado["Data"]);
                    if (imagem == null)
                    {
                        pictureBox1.Image = null;
                    }
                    else
                    {
                        MemoryStream memory = new MemoryStream(imagem);
                        pictureBox1.Image = Image.FromStream(memory);
                    }
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.ToString());
            }
            finally
            {
                conexao.Close();
            }
        }

        private void bancoDadosImagem_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (verificaSalvo == false)
            {
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    var result = MessageBox.Show(this, "O ultimo Item não foi salvo, deseja fechar? qualquer alteração não salva sera perdida!", "Confirmação", MessageBoxButtons.YesNo);
                    if (result != DialogResult.Yes)
                    {
                        e.Cancel = true;
                    }
                    else
                    {
                        e.Cancel = false;
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void buttonDeleta_Click(object sender, EventArgs e)
        {

            if (comboBoxBuscaID.Text != String.Empty && listBoxLista.SelectedItem != null)
            {
                if (MessageBox.Show("Tem certeza que deseja Excluir?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SqlCommand delete = new SqlCommand("delete from tabelaImagens where ID=@ID AND FileName=@FileName", conexao);
                    delete.Parameters.Add("@ID", SqlDbType.Int).Value = comboBoxBuscaID.Text;
                    delete.Parameters.Add("@FileName", SqlDbType.VarChar).Value = listBoxLista.SelectedItem;

                    try
                    {
                        conexao.Open();
                        delete.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        conexao.Close();
                        MessageBox.Show("Deletado!");
                        limpaTabelaImagem();
                    }
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
