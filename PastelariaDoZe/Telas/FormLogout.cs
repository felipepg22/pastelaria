using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PastelariaDoZe.Telas
{
    public partial class FormLogout : Form
    {
        public FormLogout(string mensagem,string botaoSim,string BotaoNao)
        {
            InitializeComponent();

            labelMensagem.Text = mensagem;
            buttonSim.Text = botaoSim;
            buttonNao.Text = BotaoNao;
        }

        private void buttonSim_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }

        private void buttonNao_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }
    }
}
