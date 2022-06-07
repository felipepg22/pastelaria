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

namespace PastelariaDoZe
{
    public partial class Comandas : Form
    {
        public Comandas()
        {
            InitializeComponent();
            textBoxComanda.Enter += new EventHandler(Utilitarios.CampoEventoEnter);
            textBoxComanda.Leave += new EventHandler(Utilitarios.CampoEventoLeave);

            this.KeyDown += new KeyEventHandler(Utilitarios.FormEventoKeyDown);
        }   

      

       

        private void Comandas_Load(object sender, EventArgs e)
        {
            textBoxComanda.Focus();
        }
    }
}
