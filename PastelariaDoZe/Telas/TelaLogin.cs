using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PastelariaDoZe
{
    public partial class TelaLogin : Form
    {
        public string Login { get; private set; }
        public string Senha { get; private set; }
        public TelaLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonEntrar_Click(object sender, EventArgs e)
        {
            Login = textBoxLogin.Text;
            Senha = textBoxSenha.Text;
            DialogResult = DialogResult.OK;
            
           
            
        }

        private void buttonFechar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void TelaLogin_Load(object sender, EventArgs e)
        {
            textBoxLogin.Focus();
        }
    }
}
