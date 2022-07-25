using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class cadastroGado : Form
    {
        SqlConnection conexao;

        public cadastroGado()
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

        // LOAD AQUII !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        private void Form2_Load(object sender, EventArgs e)
        {
            labelData.Text = DateTime.Now.ToString("dd'/'MM'/'yyyy");
            int ano = DateTime.Now.Year;
            if (HabDesabEdicao == false)
            {
                buttonHabDesEdicao.Text = "Habilitar/Desabilitar edição(Não)";
            }
        }

        /////////////////////COMEÇA AREA DE FUNÇÔES////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////
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

        public void enviaPeso()
        {
            int incrementaSobre = 0;
            if (conexao.State == System.Data.ConnectionState.Open)
            {

            }
            else
            {
                conexao.Open();
            }
            int ID = Convert.ToInt32(textBoxID.Text);
            SqlCommand buscaMaxSobre = new SqlCommand("select MAX(sobrescreve) as sobrescreve FROM tabelaPeso where ID = '" + ID + "' ", conexao);
            SqlDataReader resultadoMax = buscaMaxSobre.ExecuteReader();
            if (resultadoMax.Read())
            {
                if (resultadoMax["sobrescreve"].ToString() == "")
                {
                    incrementaSobre++;
                }
                else if (resultadoMax["sobrescreve"].ToString() != "")
                {
                    incrementaSobre = Convert.ToInt32(resultadoMax["sobrescreve"]);
                    incrementaSobre++;
                }
            }
            conexao.Close();


            SqlCommand enviaPeso = new SqlCommand("insert into tabelaPeso (ID, peso, data, sobrescreve) values(@ID,@peso,@data,@sobrescreve)", conexao);

            enviaPeso.Parameters.Add("@ID", SqlDbType.Int).Value = textBoxID.Text;
            enviaPeso.Parameters.Add("@peso", SqlDbType.Float).Value = textBoxPeso.Text;
            enviaPeso.Parameters.Add("@data", SqlDbType.Date).Value = DateTime.Now.ToString("dd'/'MM'/'yyyy");
            enviaPeso.Parameters.Add("@sobrescreve", SqlDbType.Int).Value = incrementaSobre;
            try
            {
                conexao.Open();
                enviaPeso.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao.Close();
            }
        }

        public void attcombo()
        {
            try
            {
                conexao.Open();
                comboBoxIDV.Items.Clear();
                SqlCommand busca_ID = new SqlCommand("Select ID from Cadastro_Gado", conexao);
                SqlDataReader resultado = busca_ID.ExecuteReader();
                while (resultado.Read())
                {
                    comboBoxIDV.Items.Add(resultado["ID"].ToString());
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

        public void preencheComboLote()
        {
            if (conexao.State == System.Data.ConnectionState.Open)
            {
                conexao.Close();
            }
            try
            {
                comboBoxNumeroLote.Items.Clear();
                conexao.Open();
                SqlCommand buscalotetf = new SqlCommand("Select nLote from Cadastro_Lote_Gado ORDER BY nLote ASC", conexao);
                SqlDataReader resultado = buscalotetf.ExecuteReader();
                while (resultado.Read())
                {
                    comboBoxNumeroLote.Items.Add(resultado["nLote"].ToString());
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


        public void incrementaIdsRelacionadosLote()
        {
            if (conexao.State == System.Data.ConnectionState.Open)
            {

            }
            else
            {
                conexao.Open();
            }
            SqlCommand buscaid = new SqlCommand("select IDs_Relacionados from Cadastro_Lote_Gado where nLote=@nLote", conexao);
            buscaid.Parameters.Add("@nLote", SqlDbType.Int).Value = pegaoID;
            SqlDataReader resultado = buscaid.ExecuteReader();
            if (resultado.Read())
            {
                incrementaIDsLote = resultado["IDs_Relacionados"].ToString();
            }
            conexao.Close();
            SqlCommand incrementa = new SqlCommand("UPDATE Cadastro_Lote_Gado set IDs_Relacionados=@IDs_Relacionados where nLote=@nLote", conexao);
            incrementa.Parameters.Add("@nLote", SqlDbType.Int).Value = pegaoID;
            incrementa.Parameters.Add("@IDs_Relacionados", SqlDbType.VarChar).Value = coletaIdsParaRelacionar + " , " + incrementaIDsLote;

            try
            {
                conexao.Open();
                //MessageBox.Show("depois erro");
                incrementa.ExecuteNonQuery();
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

        public void verificaTemLote()
        {
            if (checkBoxVerificaTemLote.Checked == true && comboBoxNumeroLote.Text == String.Empty)
            {
                temlote = false;
            }
            else
            {
                temlote = true;
            }
        }

        public void cadastraCabeça()
        {
            if (textBoxPeso.Text != String.Empty)
            {
                SqlCommand instrucoes = new SqlCommand("insert into tabelaPeso(ID,peso,data)values(@ID,@peso,@data)", conexao);
                instrucoes.Parameters.Add("@ID", SqlDbType.Int).Value = textBoxID.Text;
                instrucoes.Parameters.Add("@peso", SqlDbType.Float).Value = textBoxPeso.Text;
                instrucoes.Parameters.Add("@data", SqlDbType.Date).Value = DateTime.Now.ToString("dd'/'MM'/'yyyy");
            }
            verificaTemLote();
            try
            {
                //caso o placeholder esteja ativado então zera-lo
                if (textBoxID.Text == "Obrigatorio*")
                    textBoxID.Text = String.Empty;
                else if (comboBoxRaça.Text == "Obrigatorio*")
                    comboBoxRaça.Text = String.Empty;
                else if (comboBoxCor.Text == "Obrigatorio*")
                    comboBoxCor.Text = String.Empty;

                idc = textBoxID.Text; idmae = textBoxMae.Text;
                if (textBoxID.Text != String.Empty && comboBoxRaça.Text != String.Empty && (radioButtonF.Checked != false || radioButtonM.Checked != false) && comboBoxCor.Text != String.Empty && temlote == true) // || int.TryParse(textBoxID.Text, out IDS)
                {
                    if (idc != idmae)
                    {
                        SqlCommand instrucoes;

                        instrucoes = new SqlCommand("insert into Cadastro_Gado(ID,raca,dataNasc,sexo,descricao,mae,cor,dataCompra,precoCusto,lote,lotetf,aquisicaotf)values(@ID,@raca,@dataNasc,@sexo,@descricao,@mae,@cor,@dataCompra,@precoCusto,@lote,@lotetf,@aquisicaotf)", conexao);

                        ID = int.Parse(textBoxID.Text);

                        instrucoes.Parameters.Add("@ID", SqlDbType.Int).Value = ID;

                        instrucoes.Parameters.Add("@raca", SqlDbType.VarChar).Value = comboBoxRaça.Text;
                        if (maskedTextBoxDataNasc.MaskCompleted)
                        {
                            instrucoes.Parameters.Add("@dataNasc", SqlDbType.Date).Value = maskedTextBoxDataNasc.Text;
                        }
                        else
                        {
                            instrucoes.Parameters.Add("@dataNasc", SqlDbType.Date).Value = System.DBNull.Value;
                        }
                        if (radioButtonF.Checked == true)
                        {
                            sexo = "F";
                        }
                        if (radioButtonM.Checked == true)
                        {
                            sexo = "M";
                        }

                        instrucoes.Parameters.Add("@sexo", SqlDbType.VarChar).Value = sexo;

                        instrucoes.Parameters.Add("@descricao", SqlDbType.VarChar).Value = richTextBoxDesc.Text;

                        //instrucoes.Parameters.Add("@vacinas", SqlDbType.VarChar).Value = textBoxVacinas.Text;

                        if (textBoxPC.Text != String.Empty)
                        {
                            instrucoes.Parameters.Add("@precoCusto", SqlDbType.Float).Value = textBoxPC.Text;
                        }
                        else
                        {
                            instrucoes.Parameters.Add("@precoCusto", SqlDbType.Float).Value = System.DBNull.Value;
                        }
                        if (textBoxMae.Text != String.Empty)
                        {
                            instrucoes.Parameters.Add("@mae", SqlDbType.Int).Value = int.Parse(textBoxMae.Text);
                        }
                        else
                        {
                            instrucoes.Parameters.Add("@mae", SqlDbType.Int).Value = System.DBNull.Value;
                        }
                        if (maskedTextBoxDataAquisicao.MaskCompleted)
                        {
                            instrucoes.Parameters.Add("@dataCompra", SqlDbType.Date).Value = maskedTextBoxDataAquisicao.Text;
                        }
                        else
                        {
                            instrucoes.Parameters.Add("@dataCompra", SqlDbType.Date).Value = System.DBNull.Value;
                        }
                        if (checkBoxVerificaTemLote.Checked == true)
                        {
                            instrucoes.Parameters.Add("@lotetf", SqlDbType.Bit).Value = 1;
                            instrucoes.Parameters.Add("@lote", SqlDbType.Int).Value = int.Parse(comboBoxNumeroLote.Text);
                        }
                        else if (checkBoxVerificaTemLote.Checked == false)
                        {
                            instrucoes.Parameters.Add("@lotetf", SqlDbType.Bit).Value = 0;
                            instrucoes.Parameters.Add("@lote", SqlDbType.Int).Value = System.DBNull.Value;
                        }

                        if (checkBoxVerificaAquisição.Checked == true)
                        {
                            instrucoes.Parameters.Add("@aquisicaotf", SqlDbType.Bit).Value = 1;
                        }
                        else
                        {
                            instrucoes.Parameters.Add("@aquisicaotf", SqlDbType.Bit).Value = 0;
                        }

                        instrucoes.Parameters.Add("@cor", SqlDbType.VarChar).Value = comboBoxCor.Text;

                        try
                        {
                            conexao.Open();
                            instrucoes.ExecuteNonQuery();
                            MessageBox.Show("cadastro efetuado");
                            if (checkBoxVerificaTemLote.Checked == true)
                            {
                                coletaIdsParaRelacionar = textBoxID.Text;
                                pegaoID = Convert.ToInt32(comboBoxNumeroLote.Text);
                            }
                            if (checkBoxVerificaTemLote.Checked == true)
                            {
                                incrementaIdsRelacionadosLote();
                            }
                            if (textBoxPeso.Text != String.Empty)
                            {
                                enviaPeso();
                            }
                            limparcadastro();
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
                    else
                    {
                        MessageBox.Show("Não é possivel o mesmo ID Mãe ser o ID do novo Cadastro!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (temlote == false)
                {
                    MessageBox.Show("é obrigatorio o numero do lote, caso contrario desmarque a opção TEM LOTE!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("é necessario informar todos os campos", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (textBoxID.Text == String.Empty)
                        textBoxID.Text = "Obrigatorio*";
                    else if (comboBoxRaça.Text == String.Empty)
                        comboBoxRaça.Text = "Obrigatorio*";
                    else if (comboBoxCor.Text == String.Empty)
                        comboBoxCor.Text = "Obrigatorio*";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //pega a foto exibição
        public void pegaFoto()
        {
            SqlCommand buscaFoto = new SqlCommand("select Data from tabelaImagens where ID=@ID AND FileName=@FileName", conexao);
            buscaFoto.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt32(comboBoxIDV.Text);
            buscaFoto.Parameters.Add("@FileName", SqlDbType.VarChar).Value = "Exibição";
            try
            {
                conexao.Open();
                SqlDataReader resultado = buscaFoto.ExecuteReader();
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

        //NA PARTE DE VISUALIZAÇÃO OS DADOS BASICOS (NÃO INFORMAÇÕES DE LOTE)
        public void mostraDadosBasicos()
        {
            if (comboBoxIDV.Text != String.Empty)
            {

                try
                {
                    conexao.Open();
                    string ncombo = comboBoxIDV.Text;
                    SqlCommand buscaid = new SqlCommand("select * from Cadastro_Gado where ID ='" + ncombo + "'", conexao);


                    SqlDataReader resultado = buscaid.ExecuteReader();
                    if (resultado.Read())
                    {
                        richTextBoxDescV.Text = resultado["descricao"].ToString();
                        //richTextBoxVacinasV.Text = resultado["vacinas"].ToString();
                        textBoxIdMaeV.Text = resultado["mae"].ToString();
                        textBoxCorV.Text = resultado["cor"].ToString();
                        textBoxSexoV.Text = resultado["sexo"].ToString();
                        textBoxRaçaV.Text = resultado["raca"].ToString();
                        maskedTextBoxDataNascimentoV.Text = resultado["dataNasc"].ToString();
                        conexao.Close();
                        pictureBox1.Image = null;
                        pegaFoto();
                    }

                    conexao.Open();
                    int mae = int.Parse(comboBoxIDV.Text);
                    SqlCommand buscaid2 = new SqlCommand("select ID FROM Cadastro_Gado where mae =" + mae, conexao);
                    SqlDataReader resultado2 = buscaid2.ExecuteReader();
                    int i = 0;
                    string addmae = "";
                    panelDivideNaturalidade.Visible = true;
                    while (resultado2.Read())
                    {
                        i++;
                        addmae += resultado2["ID"].ToString() + ", ";
                    }

                    textBoxIdFilhoV.Text = "Qtd: " + i.ToString() + "    ID: " + "(" + addmae + ")";

                    armazenaDadosBasicos();
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
        }

        //PEGA DADOS BOOLEAN 1 PRA TEM LOTE 0 PRA NÃO
        public void pesquisaLoteTf()
        {
            SqlDataReader resultado;
            SqlDataReader mostra;

            string idcombo = comboBoxIDV.Text;
            if (conexao.State == System.Data.ConnectionState.Open)
            {
                conexao.Close();
            }
            try
            {
                conexao.Open();

                SqlCommand buscalote = new SqlCommand("Select lotetf from Cadastro_Gado where ID =" + idcombo, conexao);
                resultado = buscalote.ExecuteReader();
                if (resultado.Read())
                {
                    verificatf = Convert.ToBoolean(resultado["lotetf"]);
                }
                // MessageBox.Show(verificatf.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conexao.Close();
            }

            if (verificatf == true)
            {
                try
                {
                    conexao.Open();
                    SqlCommand adicionarlote = new SqlCommand("Select lote from Cadastro_Gado where ID =" + idcombo, conexao);
                    mostra = adicionarlote.ExecuteReader();
                    if (mostra.Read())
                    {
                        armazenaNumLote = mostra["lote"].ToString();
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
            else
            {
                verificatf = false;
            }
        }

        // BUSCA NOME DA CIDADE DO LOTE
        public void buscaCidade()
        {
            try
            {
                conexao.Open();
                SqlCommand buscaCidade = new SqlCommand("Select cidadeCompra from Cadastro_Lote_Gado where nLote=" + armazenaNumLote, conexao);
                SqlDataReader resultadoC = buscaCidade.ExecuteReader();
                if (resultadoC.Read())
                {
                    textBoxCidadeCompra.Text = resultadoC["cidadeCompra"].ToString();
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
        //MOSTRA SE FOI ADQUIRIDO
        public void mostraAquisicaoSimNao()
        {
            string idcombo = comboBoxIDV.Text;
            if (conexao.State == System.Data.ConnectionState.Open)
            {
                conexao.Close();
            }
            try
            {
                conexao.Open();

                SqlCommand buscaaquitf = new SqlCommand("Select aquisicaotf from Cadastro_Gado where ID =" + idcombo, conexao);
                SqlDataReader resultado = buscaaquitf.ExecuteReader();
                if (resultado.Read())
                {
                    aquisicao = Convert.ToBoolean(resultado["aquisicaotf"]);
                }
                //MessageBox.Show(aquisicao.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conexao.Close();
            }

            if (aquisicao == true)
            {
                try
                {
                    conexao.Open();
                    SqlCommand adicionarlote = new SqlCommand("Select dataCompra, precoCusto from Cadastro_Gado where ID =" + idcombo, conexao);
                    SqlDataReader resultado = adicionarlote.ExecuteReader();
                    if (resultado.Read())
                    {
                        maskedTextBoxDataCompraV.Text = resultado["dataCompra"].ToString();
                        textBoxPCV.Text = resultado["precoCusto"].ToString();
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
            else
            {
                aquisicao = false;
            }
        }

        //MOSTRA SE É NATURAL OU ADQUIRIDO
        public void defineLoteANDNaturezaAnimal()
        {
            pesquisaLoteTf();
            if (verificatf == true)
            {
                textBoxLoteV.Visible = true;
                labelMostraLoteV.Visible = true;
                textBoxCidadeCompra.Visible = true;
                labelMostraCidadeCV.Visible = true;
                textBoxLoteV.Text = armazenaNumLote;
                labelTemNLote.Visible = true;
                labelTemNLote.Text = "Tem Lote!";
                buscaCidade();
            }
            else
            {
                textBoxLoteV.Visible = false;
                labelMostraLoteV.Visible = false;
                textBoxCidadeCompra.Visible = false;
                labelMostraCidadeCV.Visible = false;
                labelTemNLote.Visible = true;
                labelTemNLote.Text = "Não Tem Lote!";
            }

            mostraAquisicaoSimNao();
            if (aquisicao == true)
            {
                labelMostraOriginalidade.Visible = true;
                labelMostraOriginalidade.Text = "Animal Adquirido!";
                maskedTextBoxDataCompraV.Visible = true;
                labelMostraDataCV.Visible = true;
                textBoxPCV.Visible = true;
                labelMostraPCV.Visible = true;
            }
            else
            {
                maskedTextBoxDataCompraV.Visible = false;
                labelMostraDataCV.Visible = false;
                textBoxPCV.Visible = false;
                labelMostraPCV.Visible = false;
                labelMostraOriginalidade.Visible = true;
                labelMostraOriginalidade.Text = "Animal Não Adqurido!";
            }
        }

        public void armazenaDadosBasicos()
        {
            armazenaDescrição = richTextBoxDescV.Text;
            armazenaVacinas = richTextBoxVacinasV.Text;
        }
        /// ////////////////////////////FECHA AREA FUNÇÕES///////////////////////////


        //VERIFICA CONEXAO
        //    if (conexao.State == System.Data.ConnectionState.Closed){}
        //    {

        //   }
        //    if (conexao.State == System.Data.ConnectionState.Open)
        //    {

        ////AREA DAS VARIAVEIS.////// 
        string sexo;
        int ID = 0;
        string descricaov;
        string vacinasv;
        string idc;
        string idmae;
        Boolean aquisicao;
        Boolean temlote;
        Boolean verificatf;
        string armazenaNumLote;
        string coletaIdsParaRelacionar;
        int pegaoID = 0;
        string incrementaIDsLote;
        Boolean HabDesabEdicao = false;
        string armazenaDescrição;
        string armazenaVacinas;
        ///////////AREA DAS VARIAVEIS!!!!!!////


        ///////////////////////////////// AREA DOS LIMPADORES ////////////////////

        public void limparcadastro()
        {
            textBoxID.Text = "Obrigatorio*";
            textBoxID.ForeColor = Color.Blue;
            comboBoxRaça.Text = "Obrigatorio*";
            comboBoxRaça.ForeColor = Color.Blue;
            maskedTextBoxDataNasc.Text = String.Empty;
            radioButtonF.Checked = false;
            radioButtonM.Checked = false;
            textBoxPeso.Text = String.Empty;
            richTextBoxDesc.Text = String.Empty;
            textBoxVacinas.Text = String.Empty;
            comboBoxCor.Text = "Obrigatorio*";
            comboBoxCor.ForeColor = Color.Blue;
            textBoxMae.Text = String.Empty;
            maskedTextBoxDataAquisicao.Text = String.Empty;
            textBoxPC.Text = String.Empty;
            comboBoxNumeroLote.Text = String.Empty;
            checkBoxVerificaAquisição.Checked = false;
            checkBoxVerificaTemLote.Checked = false;
        }
        public void limpavisualizacao()
        {
            richTextBoxDescV.Text = String.Empty;
            richTextBoxVacinasV.Text = String.Empty;
            textBoxIdFilhoV.Text = String.Empty;
            textBoxIdMaeV.Text = String.Empty;
            pictureBox1.Image = null;
            textBoxIdMaeV.Text = String.Empty;
            textBoxIdFilhoV.Text = String.Empty;
            textBoxRaçaV.Text = String.Empty;
            textBoxSexoV.Text = String.Empty;
            textBoxCorV.Text = String.Empty;
            maskedTextBoxDataNascimentoV.Text = String.Empty;
            labelMostraOriginalidade.Text = String.Empty;
            labelMostraOriginalidade.Visible = false;
            panelDivideNaturalidade.Visible = false;
            labelTemNLote.Text = String.Empty;
            labelTemNLote.Visible = false;
            maskedTextBoxDataCompraV.Text = String.Empty;
            textBoxPCV.Text = String.Empty;
            textBoxLoteV.Text = String.Empty;
            textBoxCidadeCompra.Text = String.Empty;
            comboBoxIDV.SelectedIndex = -1;
            comboBoxIDV.Text = String.Empty;
        }


        ///////////////////////////////// FECHA AREA DOS LIMPADORES ////////////////////
        private void button1_Click(object sender, EventArgs e)
        {
            cadastraCabeça();
        }

        private void textBoxPeso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            //if (char.IsPunctuation(e.KeyChar))
            //{
             //   e.Handled = true;
           // }
            if (char.IsSymbol(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void comboBoxIDV_SelectedIndexChanged(object sender, EventArgs e)
        {
            mostraDadosBasicos();
            if (comboBoxIDV.Text != String.Empty)
            {
                defineLoteANDNaturezaAnimal();
            }
        }

        private void buttonAtualizaDesc_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Tem certeza que deseja Alterar?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (comboBoxIDV.Text != String.Empty)
                {

                    if (conexao.State == System.Data.ConnectionState.Open)
                    {
                        conexao.Close();
                    }
                    if (armazenaDescrição != richTextBoxDescV.Text)
                    {
                        conexao.Close();
                        SqlCommand atualiza = new SqlCommand("UPDATE Cadastro_Gado set descricao=@descricao where ID=@ID", conexao);
                        descricaov = richTextBoxDescV.Text;
                        atualiza.Parameters.Add("@ID", SqlDbType.Int).Value = int.Parse(comboBoxIDV.Text);
                        atualiza.Parameters.Add("@descricao", SqlDbType.VarChar).Value = descricaov;


                        try
                        {
                            conexao.Open();
                            //MessageBox.Show("depois erro");
                            atualiza.ExecuteNonQuery();
                            armazenaDescrição = richTextBoxDescV.Text;
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
                        MessageBox.Show("Não há alterações", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("selecione ID!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (comboBoxIDV.Text != String.Empty)
            {
                if (MessageBox.Show("Tem certeza que deseja Excluir?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SqlCommand delete = new SqlCommand("delete from Cadastro_Gado where ID=@ID", conexao);
                    int comboid = int.Parse(comboBoxIDV.Text);
                    delete.Parameters.Add("@ID", SqlDbType.Int).Value = comboid;

                    try
                    {
                        // if (conexao.State == System.Data.ConnectionState.Open)
                        // {
                        //     conexao.Close();
                        // }
                        conexao.Open();
                        delete.ExecuteNonQuery();
                        MessageBox.Show("Deletado!");
                        limpavisualizacao();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    finally
                    {
                        conexao.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Não ha ID para Excluir!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAtualizaVacina_Click_1(object sender, EventArgs e)
        {

            if (MessageBox.Show("Tem certeza que deseja Alterar?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                if (comboBoxIDV.Text != String.Empty)
                {

                    if (conexao.State == System.Data.ConnectionState.Open)
                        conexao.Close();

                    if (armazenaVacinas != richTextBoxVacinasV.Text)
                    {

                        SqlCommand atualiza = new SqlCommand("UPDATE Cadastro_Gado set vacinas=@vacina where ID=@ID", conexao);
                        vacinasv = richTextBoxVacinasV.Text;
                        atualiza.Parameters.Add("@ID", SqlDbType.Int).Value = int.Parse(comboBoxIDV.Text);
                        atualiza.Parameters.Add("@vacina", SqlDbType.VarChar).Value = vacinasv;


                        try
                        {
                            conexao.Open();
                            //MessageBox.Show("depois erro");
                            atualiza.ExecuteNonQuery();
                            armazenaVacinas = richTextBoxVacinasV.Text;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            conexao.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Não há alterações", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("selecione id!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }


       


        private void textBoxRaca_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void textBoxMae_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBoxCor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
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



        private void comboBoxAno_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxPeso.Focus();
        }

        private void textBoxID_KeyPress(object sender, KeyPressEventArgs e)
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





        private void textBoxMae_Leave(object sender, EventArgs e)
        {
            if ((textBoxMae.Text == textBoxID.Text) && textBoxID.Text != "")
            {
                MessageBox.Show("Atenção mesmo ID de cadastro no ID da mãe!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxMae.Focus();
            }

        }


        private void textBoxIdMaeV_TextChanged(object sender, EventArgs e)
        {
            if (textBoxIdMaeV.Text == "0")
            {
                textBoxIdMaeV.Text = null;
            }
        }

        private void textBoxIdFilhoV_TextChanged(object sender, EventArgs e)
        {
            if (textBoxIdFilhoV.Text == "Qtd: 0    ID: ()")
            {
                textBoxIdFilhoV.Text = null;
            }
        }


        private void checkBoxVerificaAquisição_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBoxVerificaAquisição.Checked == true)
            {
                maskedTextBoxDataAquisicao.Visible = true;
                labelTituloMostraAquisi.Visible = true;
                labelMostraPC.Visible = true;
                textBoxPC.Visible = true;
                checkBoxVerificaTemLote.Visible = true;
            }
            if (checkBoxVerificaAquisição.Checked == false)
            {
                maskedTextBoxDataAquisicao.Visible = false;
                labelTituloMostraAquisi.Visible = false;
                labelMostraPC.Visible = false;
                textBoxPC.Visible = false;
                checkBoxVerificaTemLote.Visible = false;
                comboBoxNumeroLote.Text = null;
            }
            if (checkBoxVerificaAquisição.Checked == false && checkBoxVerificaTemLote.Checked == true)
            {
                checkBoxVerificaTemLote.Checked = false;
                comboBoxNumeroLote.Items.Clear();
                comboBoxNumeroLote.Text = null;
            }
            //verificaTab();
        }


        private void textBoxNumeroLote_Leave(object sender, EventArgs e)
        {
            if (checkBoxVerificaTemLote.Checked == true && comboBoxNumeroLote.Text == "")
            {
                MessageBox.Show("é obrigatorio o numero do lote, A OPÇÃO LOTE FOI DESMARCADA!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkBoxVerificaTemLote.Checked = false;
            }
        }

        private void textBoxDataCompra_KeyPress(object sender, KeyPressEventArgs e)
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

        private void buttonAddPeso_Click(object sender, EventArgs e)
        {//aqui eu crio uma ponte pra mandar pro pop peso
            pop_up_peso popeso = new pop_up_peso();
            popeso.parametro = comboBoxIDV.Text;
            popeso.ShowDialog();
        }
        private void button3_Click(object sender, EventArgs e)
        {

        }
        private void comboBoxIDV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                if (comboBoxIDV.Text != String.Empty)
                {
                    mostraDadosBasicos();
                    defineLoteANDNaturezaAnimal();
                }
            }
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

        private void textBoxID_Enter(object sender, EventArgs e)
        {
            if (textBoxID.Text == "Obrigatorio*")
            {
                textBoxID.Text = String.Empty;
                textBoxID.ForeColor = Color.Black;
            }
        }

        private void textBoxID_Leave(object sender, EventArgs e)
        {
            if (textBoxID.Text == String.Empty)
            {
                textBoxID.Text = "Obrigatorio*";
                textBoxID.ForeColor = Color.Blue;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form bancoImg = new bancoDadosImagem();
            bancoImg.ShowDialog();
        }

        private void checkBoxVerificaTemLote_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxVerificaTemLote.Checked == true)
            {
                comboBoxNumeroLote.Visible = true;
                labelMostraTituloLote.Visible = true;
            }
            else
            {
                comboBoxNumeroLote.Visible = false;
                labelMostraTituloLote.Visible = false;
                comboBoxNumeroLote.Items.Clear();
            }
            //verificaTab();
        }
        private void textBoxPC_TextChanged(object sender, EventArgs e)
        {
            moeda(ref textBoxPC);
        }

        private void comboBoxIDV_DropDown(object sender, EventArgs e)
        {
            attcombo();
        }

        private void comboBoxNumeroLote_DropDown(object sender, EventArgs e)
        {
            preencheComboLote();
        }

        private void textBoxIdMaeV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                if (comboBoxIDV.Text != String.Empty && HabDesabEdicao == true)
                {
                    if (MessageBox.Show("Tem certeza que deseja Alterar?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (MessageBox.Show("A informação não podera ser recuperada, deseja Alterar o ID Mãe?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                        {

                            SqlCommand attIDmae = new SqlCommand("UPDATE Cadastro_Gado set mae=@mae where ID=@ID", conexao);
                            attIDmae.Parameters.Add("@ID", SqlDbType.Int).Value = comboBoxIDV.Text;
                            attIDmae.Parameters.Add("@mae", SqlDbType.Int).Value = textBoxIdMaeV.Text;
                            try
                            {
                                conexao.Open();
                                //MessageBox.Show("depois erro");
                                attIDmae.ExecuteNonQuery();
                                MessageBox.Show("Certo!");
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
                    }
                }
                else
                {
                    MessageBox.Show("Voce deve Permitir alterações nesses campos no botão abaixo!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void textBoxRaçaV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                if (comboBoxIDV.Text != String.Empty && HabDesabEdicao == true)
                {
                    if (MessageBox.Show("Tem certeza que deseja Alterar?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (MessageBox.Show("A informação não podera ser recuperada, deseja Alterar a Raça?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                        {
                            SqlCommand attRaça = new SqlCommand("UPDATE Cadastro_Gado set raca=@raca where ID=@ID", conexao);
                            attRaça.Parameters.Add("@ID", SqlDbType.Int).Value = comboBoxIDV.Text;
                            attRaça.Parameters.Add("@raca", SqlDbType.VarChar).Value = textBoxRaçaV.Text;
                            try
                            {
                                conexao.Open();
                                //MessageBox.Show("depois erro");
                                attRaça.ExecuteNonQuery();
                                MessageBox.Show("Certo!");
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
                    }
                }
                else
                {
                    MessageBox.Show("Voce deve Permitir alterações nesses campos no botão abaixo!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void textBoxCorV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter && HabDesabEdicao == true)
            {
                if (comboBoxIDV.Text != String.Empty && HabDesabEdicao == true)
                {
                    if (MessageBox.Show("Tem certeza que deseja Alterar?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (MessageBox.Show("A informação não podera ser recuperada, deseja Alterar a Cor?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                        {


                            SqlCommand attCor = new SqlCommand("UPDATE Cadastro_Gado set cor=@cor where ID=@ID", conexao);
                            attCor.Parameters.Add("@ID", SqlDbType.Int).Value = comboBoxIDV.Text;
                            attCor.Parameters.Add("@cor", SqlDbType.VarChar).Value = textBoxCorV.Text;
                            try
                            {
                                conexao.Open();
                                //MessageBox.Show("depois erro");
                                attCor.ExecuteNonQuery();
                                MessageBox.Show("Certo!");
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
                    }
                }
                else
                {
                    MessageBox.Show("Voce deve Permitir alterações nesses campos no botão abaixo!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void buttonLimpaCamposCadastro_Click(object sender, EventArgs e)
        {
            limparcadastro();
        }

        private void buttonCamposVisualização_Click(object sender, EventArgs e)
        {
            limpavisualizacao();
        }

        private void buttonHabDesEdicao_Click(object sender, EventArgs e)
        {
            if (HabDesabEdicao == false)
            {
                HabDesabEdicao = true;
                buttonHabDesEdicao.Text = "Habilitar/Desabilitar edição(Sim)";
            }
            else if (HabDesabEdicao == true)
            {
                HabDesabEdicao = false;
                buttonHabDesEdicao.Text = "Habilitar/Desabilitar edição(Não)";
            }
        }
        public void buscaDataCompraLote()
        {
            try
            {
                conexao.Open();

                SqlCommand buscaDataLote = new SqlCommand("Select dataCompra from Cadastro_Lote_Gado where nLote =" + comboBoxNumeroLote.Text, conexao);
                SqlDataReader resultado = buscaDataLote.ExecuteReader();
                if (resultado.Read())
                {
                    maskedTextBoxDataAquisicao.Text = resultado["dataCompra"].ToString();
                }
                //MessageBox.Show(aquisicao.ToString());
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

        private void comboBoxNumeroLote_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxNumeroLote.Text != String.Empty)
            {
                buscaDataCompraLote();
            }
        }

        private void textBoxPCV_TextChanged(object sender, EventArgs e)
        {
        }
        double pegaPCv = 0;
        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void comboBoxNumeroLote_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                buscaDataCompraLote();
            }
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

        

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            if (comboBoxRaça.Text == String.Empty)
            {
                comboBoxRaça.Text = "Obrigatorio*";
                comboBoxRaça.ForeColor = Color.Blue;
            }
        }

        private void comboBoxRaça_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
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

        private void comboBoxRaça_Enter(object sender, EventArgs e)
        {
            if (comboBoxRaça.Text == "Obrigatorio*")
            {
                comboBoxRaça.Text = String.Empty;
                comboBoxRaça.ForeColor = Color.Black;
            }
        }

        private void comboBoxRaça_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxRaça.Text == "Nelore")
            {
                comboBoxCor.Text = "Branco";
                comboBoxCor.ForeColor = Color.Black;
            }
            else
            {
                comboBoxCor.Text = "Obrigatorio*";
                comboBoxCor.ForeColor = Color.Blue;
            }

        }

        private void comboBoxCor_Enter(object sender, EventArgs e)
        {
            if (comboBoxCor.Text == "Obrigatorio*")
            {
                comboBoxCor.Text = String.Empty;
                comboBoxCor.ForeColor = Color.Black;
            }
        }

        private void comboBoxCor_Leave(object sender, EventArgs e)
        {
            
            if (comboBoxCor.Text == String.Empty)
            {
                comboBoxCor.Text = "Obrigatorio*";
                comboBoxCor.ForeColor = Color.Blue;
            }
        }

        private void textBoxID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
