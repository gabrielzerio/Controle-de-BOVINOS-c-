using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApp1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        Thread nt;

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if(textBoxUsuario.Text == "1234" && textBoxSenha.Text == "4321" || textBoxUsuario.Text == "avai" && textBoxSenha.Text == "gigagigalu" || textBoxUsuario.Text == "" && textBoxSenha.Text == "")
            {
                this.Close();
                nt = new Thread(novoForm);
                nt.SetApartmentState(ApartmentState.STA);
                nt.Start();
            }
            else
            {
                MessageBox.Show("Login Invalido!", "",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void novoForm()
        {
            Application.Run(new Form1());
        }
    }
}
