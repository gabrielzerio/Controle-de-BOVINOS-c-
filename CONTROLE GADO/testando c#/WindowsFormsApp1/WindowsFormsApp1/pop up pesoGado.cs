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
    public partial class pop_up_peso : Form
    {

        //cadastroGado atualizaIDV = new cadastroGado();

        ArrayList recolhe = new ArrayList();
        SqlConnection conexao;
        int incrementaSobre;
        public pop_up_peso()
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
        public string parametro { get; set; }


        private void pop_up_peso_Load(object sender, EventArgs e)
        {
            maskedTextBoxData.Text = DateTime.Now.ToString("dd'/'MM'/'yyyy");
            this.Top = 200;
            this.Left = 900;
            comboBoxID.Text = parametro;
            atualizaListBoxPeso();
            labelarroba.Text = String.Empty;
        }
        public void attcomboid()
        {
            try
            {
                conexao.Open();
                comboBoxID.Items.Clear();
                SqlCommand busca_ID = new SqlCommand("Select ID from Cadastro_Gado ORDER BY ID ASC", conexao);
                SqlDataReader resultado = busca_ID.ExecuteReader();
                while (resultado.Read())
                {
                    comboBoxID.Items.Add(resultado["ID"].ToString());
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

        public void atualizaListBoxPeso()
        {
            if (comboBoxID.Text != String.Empty)
                try
                {
                    listBoxPesoV.Items.Clear();
                    listBoxDataPesoV.Items.Clear();
                    SqlCommand buscaPeso = new SqlCommand("select peso,data,sobrescreve from tabelaPeso where ID=@ID ORDER BY data DESC", conexao);
                    buscaPeso.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt32(comboBoxID.Text);
                    conexao.Open();
                    SqlDataReader resultadoPeso = buscaPeso.ExecuteReader();
   
                    while (resultadoPeso.Read())
                    {
                        recolhe.Add(resultadoPeso["sobrescreve"]).ToString();
                        listBoxPesoV.Items.Add(resultadoPeso["peso"]);
                        listBoxDataPesoV.Items.Add(resultadoPeso["data"]);
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

        public void enviaPeso()
        {
            if (textBoxAddP.Text != String.Empty && maskedTextBoxData.Text != String.Empty && comboBoxID.Text != String.Empty)
            {
                conexao.Open();
                int ID = Convert.ToInt32(comboBoxID.Text);
                SqlCommand busca = new SqlCommand("select MAX(sobrescreve) as sobrescreve FROM tabelaPeso where ID = '" + ID + "' ", conexao);
                SqlDataReader resultado = busca.ExecuteReader();
                if (resultado.Read())
                {
                    if (resultado["sobrescreve"].ToString() == "")
                    {
                        incrementaSobre++;
                    }
                    else if (resultado["sobrescreve"].ToString() != "")
                    {
                        incrementaSobre = Convert.ToInt32(resultado["sobrescreve"]);
                        incrementaSobre++;
                    }
                }
                conexao.Close();

                SqlCommand atualiza = new SqlCommand("insert into tabelaPeso (ID, peso, data, sobrescreve) values(@ID,@peso,@data,@sobrescreve)", conexao);

                atualiza.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt32(comboBoxID.Text);
                atualiza.Parameters.Add("@peso", SqlDbType.Float).Value = textBoxAddP.Text;
                atualiza.Parameters.Add("@data", SqlDbType.DateTime).Value = maskedTextBoxData.Text;
                atualiza.Parameters.Add("@sobrescreve", SqlDbType.Int).Value = incrementaSobre;
                try
                {
                    conexao.Open();
                    atualiza.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conexao.Close();
                    atualizaListBoxPeso();
                }


            }
            else if (comboBoxID.Text == String.Empty)
            {
                MessageBox.Show("Adicione um ID No campo ID", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBoxAddP.Text == String.Empty)
            {
                MessageBox.Show("Adicione o peso No campo PESO", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (maskedTextBoxData.Text == String.Empty)
            {
                MessageBox.Show("Adicione uma data No campo Data", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
        }
        string data1 = String.Empty;
        string data2 = DateTime.Now.ToString("dd'/'MM'/'yyyy");
        public void verificaData()
        { 

            try
            {
                //MAX(sobrescreve) as sobrescreve
                SqlCommand buscaPeso = new SqlCommand("select MAX(data) as data from tabelaPeso where ID=@ID ORDER BY data DESC", conexao);
                buscaPeso.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt32(comboBoxID.Text);
                conexao.Open();
                SqlDataReader resultadoPeso = buscaPeso.ExecuteReader();

                if (resultadoPeso.Read())
                {
                    maskedTextBox1.Text = resultadoPeso["data"].ToString();
                }
                data1 = maskedTextBox1.Text;
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.ToString());
            }
            finally
            {
                conexao.Close();
            }

        }
        private void buttonEnviarPeso_Click(object sender, EventArgs e)
        {
            verificaData();  
            if (data1 == data2)
            {
                if (MessageBox.Show("Ja há um cadastro de Peso HOJE, deseja adicionar mais um ?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    enviaPeso();
                }
            }
            else
            {
                enviaPeso();
            }
            
        }

        private void listBoxPesoV_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxDataPesoV.SelectedIndex = listBoxPesoV.SelectedIndex;

            double pegaPeso = (Convert.ToDouble(listBoxPesoV.SelectedItem)/15)/2;

            if (pegaPeso == 1)
            {
                labelarroba.Text = pegaPeso.ToString("F") + " arroba";
            }
            else if(pegaPeso > 1)
            {
                labelarroba.Text = pegaPeso.ToString("F") + " arrobas";
            }
            else
            {
                labelarroba.Text = String.Empty;
            }
        }

        private void listBoxDataPesoV_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxPesoV.SelectedIndex = listBoxDataPesoV.SelectedIndex;
        }

        private void comboBoxID_DropDown(object sender, EventArgs e)
        {
            attcomboid();
        }

        private void comboBoxID_SelectedIndexChanged(object sender, EventArgs e)
        {
            atualizaListBoxPeso();
        }

        private void buttonExcuir_Click(object sender, EventArgs e)
        {
            int sei = listBoxDataPesoV.SelectedIndex;
            int cont = 0;
            int pegaSobrescreve = 0;
            foreach (object item in recolhe)
            {
                if (cont == sei)
                {
                    pegaSobrescreve = Convert.ToInt32(item);
                   // MessageBox.Show(pegaSobrescreve.ToString());
                }
                cont++;
            }
            
            if (comboBoxID.Text != String.Empty)
            {
                if (MessageBox.Show("Tem certeza que deseja Excluir?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SqlCommand delete = new SqlCommand("delete from tabelaPeso where ID=@ID AND sobrescreve=@sobrescreve", conexao);
                    delete.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt32(comboBoxID.Text);
                    delete.Parameters.Add("@sobrescreve", SqlDbType.Int).Value = pegaSobrescreve;

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
                        atualizaListBoxPeso();
                    }
                }
            }
        }

        private void textBoxAddP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            
            if (char.IsSymbol(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void comboBoxID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            if (char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
            if (char.IsSymbol(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}

