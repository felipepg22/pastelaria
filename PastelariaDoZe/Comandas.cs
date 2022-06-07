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
    public partial class Comandas : Form
    {
        public Comandas()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void funcionáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Funcionarios cadFunc = new Funcionarios();
            cadFunc.Show();
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
    }
}
