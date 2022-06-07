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
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void funcionáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Funcionarios cadFunc = new Funcionarios();
            cadFunc.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadastroClientes cadCliente = new CadastroClientes();
            cadCliente.Show();
        }

        private void comandasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Comandas telaComandas = new Comandas();
            telaComandas.Show();
        }

        private void configuraçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TelaConfiguracoes telaConf = new TelaConfiguracoes();
            telaConf.Show();
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadastroProdutos cadProd = new CadastroProdutos();
            cadProd.Show();
        }

        private void comandasToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void acrescentarConsumoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComandasConsumo telaConsumo = new ComandasConsumo();
            telaConsumo.Show();
        }

        private void fecharComandaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FecharComanda telaFechamento = new FecharComanda();
            telaFechamento.Show();
        }
    }
}
