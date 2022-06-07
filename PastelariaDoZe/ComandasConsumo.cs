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
    public partial class ComandasConsumo : Form
    {
        public ComandasConsumo()
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
            CadastroClientes telaCliente = new CadastroClientes();
            telaCliente.Show();
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadastroProdutos telaProd = new CadastroProdutos();
            telaProd.Show();
        }

        private void comandasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Comandas telaComandas = new Comandas();
            telaComandas.Show();
        }

        private void configuraçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TelaConfiguracoes telaConf = new TelaConfiguracoes();
            telaConf.Show();
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuPrincipal telaMenu = new MenuPrincipal();
            telaMenu.Show();
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }
    }
}
