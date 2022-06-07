using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;

namespace PastelariaDoZe.Telas
{
    public partial class FormMensagem : Form
    {
        public FormMensagem(string nomeUsuario)
        {
            InitializeComponent();
            
           
            if (Thread.CurrentThread.CurrentUICulture.Name == "en-US")
            {
                labelMensagem.Text = $"Welcome {nomeUsuario} !";
            }
            if (Thread.CurrentThread.CurrentUICulture.Name == "es-ES")
            {
                labelMensagem.Text = $"Bienvenido {nomeUsuario} !";
            }
            if (Thread.CurrentThread.CurrentUICulture.Name == "pt-BR")
            {
                labelMensagem.Text = $"Bem vindo {nomeUsuario} !";
            }

            
            buttonOK.Text = "OK";
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
