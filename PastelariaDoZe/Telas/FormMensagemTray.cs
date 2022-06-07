using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PastelariaDoZe.Telas
{
    public partial class FormMensagemTray : Form
    {
        public FormMensagemTray()
        {
            InitializeComponent();

            if (Thread.CurrentThread.CurrentUICulture.Name == "pt-BR")
            {
                labelMensagem.Text = "O que deseja fazer?";
                buttonContinuar.Text = "Continuar";
                buttonSair.Text = "Sair";
                buttonBandeija.Text = "Enviar para a bandeija";
            }

            if (Thread.CurrentThread.CurrentUICulture.Name == "en-US")
            {
                labelMensagem.Text = "What do you wish to do?";
                buttonContinuar.Text = "Continue";
                buttonSair.Text = "Exit";
                buttonBandeija.Text = "Send to tray";
            }

            if (Thread.CurrentThread.CurrentUICulture.Name == "es-ES")
            {
                labelMensagem.Text = "¿O que quieres hacer?";
                buttonContinuar.Text = "Continuar";
                buttonSair.Text = "Salir";
                buttonBandeija.Text = "Enviar a la bandeja";
            }
        }

        private void buttonContinuar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        private void buttonSair_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void buttonBandeija_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
