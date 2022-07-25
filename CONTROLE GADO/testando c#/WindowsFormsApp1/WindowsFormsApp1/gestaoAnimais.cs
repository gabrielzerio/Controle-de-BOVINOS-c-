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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
      

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        

       

        private void gadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
          if (Application.OpenForms.OfType<cadastroGado>().Count() == 0)
           {
             Form form2 = new cadastroGado();
             form2.Show();
           }    
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void cadastrarNoLoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        

        private void aplicarLoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void criarAtualizarExcluirToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void informaçõesLoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<mostraLote>().Count() == 0)
            {
                Form mostralote = new mostraLote();
                mostralote.Show();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<pop_up_cadastroLote>().Count() == 0)
            {
                Form cadastralote = new pop_up_cadastroLote();
                cadastralote.Show();
            }
        }
    }
}
