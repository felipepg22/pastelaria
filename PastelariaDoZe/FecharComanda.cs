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
    public partial class FecharComanda : Form
    {
        public FecharComanda()
        {
            InitializeComponent();
        }

        private void funcionáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Funcionarios telaFunc = new Funcionarios();
            telaFunc.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadastroClientes telaClientes = new CadastroClientes();
            telaClientes.Show();
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadastroProdutos telaProd = new CadastroProdutos();
            telaProd.Show();
        }

        private void acrescentarConsumoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComandasConsumo telaConsumo = new ComandasConsumo();
            telaConsumo.Show();
        }

        private void configuraçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TelaConfiguracoes telaConf = new TelaConfiguracoes();
            telaConf.Show();
        }

        private void comandasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Comandas telaComandas = new Comandas();
            telaComandas.Show();
        }
    }
}
