using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PastelariaDoZe.Biblioteca;

namespace PastelariaDoZe.Telas
{
    public partial class UserControlBusca : UserControl
    {
        public UserControlBusca(int x, int y)
        {
            InitializeComponent();
            Location = new Point(x, y);
            this.ActiveControl = textBoxBusca;
            textBoxBusca.Focus();

            this.KeyDown += new KeyEventHandler(Utilitarios.FormEventoKeyDown);
           
        }

       



        private void UserControlBusca_Load(object sender, EventArgs e)
        {
            textBoxBusca.Focus();
        }

        
    }
}
