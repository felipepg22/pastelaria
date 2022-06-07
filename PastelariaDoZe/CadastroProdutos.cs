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
    public partial class CadastroProdutos : Form
    {
        public CadastroProdutos()
        {
            InitializeComponent();
        }

        private void buttonAddFoto_Click(object sender, EventArgs e)
        {
            folderBrowserDialogFotoProduto.ShowDialog();
            
        }

        private void pictureBoxProduto_Click(object sender, EventArgs e)
        {

        }

        private void comandasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Comandas telaComandas = new Comandas();
            telaComandas.Show();
        }
    }
}
