using PastelariaDoZe.Biblioteca;
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
    public partial class FormQuantidade : Form
    {
        public FormQuantidade()
        {
            InitializeComponent();

            this.KeyDown += new KeyEventHandler(Utilitarios.FormEventoKeyDown);
            textBoxQuantidade.KeyPress += new KeyPressEventHandler(Utilitarios.NumericoKeyPress);
            
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
