using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using PastelariaDoZe.Biblioteca;

namespace PastelariaDoZe
{
    public partial class RecebeFiado : Form
    {
        public RecebeFiado()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(Utilitarios.FormEventoKeyDown);
        }       

        

        private void buttonFinalizaFiado_Click(object sender, EventArgs e)
        {
            if (checkBoxComprovante.Checked)
            {
                string comprovante = $"Valor: R$ 100,00\n" +
                    $"Desconto: 5%";
                string diaMes = DateTime.Now.Date.ToString().Replace('/', '-').Replace(" ", "_").Replace(':', '-');
                ;

                MessageBox.Show(diaMes);

                //string caminho = $"Comprovante_{diaMes}.doc";


                //File.WriteAllText(caminho, comprovante);

                

                
            }
        }

        

        private void RecebeFiado_Load(object sender, EventArgs e)
        {
            textBoxNomeCliente.Focus();
        }
    }
}
