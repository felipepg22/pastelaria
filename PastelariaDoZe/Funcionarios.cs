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
    public partial class Funcionarios : Form
    {
        public Funcionarios()
        {
            InitializeComponent();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadastroClientes cadCliente = new CadastroClientes();
            cadCliente.Show();
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuPrincipal menu = new MenuPrincipal();
            menu.Show();
        }

        private void acrescentarConsumoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComandasConsumo telaConsumo = new ComandasConsumo();
            telaConsumo.Show();
        }
    }
}
