using PastelariaDoZe.Biblioteca;
using PastelariaDoZe.DAO;
using PastelariaDoZe.Telas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PastelariaDoZe
{
    public partial class CadastroClientes : Form
    {
        private Cliente cliente;
        private ClienteDAO dao;
        UserControlBusca busca = new UserControlBusca(8, 53);
        public CadastroClientes()
        {
            InitializeComponent();
            
            this.Controls.Add(busca);

            AtualizarTela();

            busca.buttonSalvarDados.Click += new EventHandler(SalvaDados);
            busca.buttonPesquisar.Click += ButtonPesquisar_Click;
            busca.buttonEditar.Click += ButtonEditar_Click;
            busca.buttonExcluir.Click += ButtonExcluir_Click;

            textBoxIDCliente.Enter += new System.EventHandler(Utilitarios.CampoEventoEnter);
            textBoxIDCliente.Leave += new System.EventHandler(Utilitarios.CampoEventoLeave);

            textBoxNome.Enter += new System.EventHandler(Utilitarios.CampoEventoEnter);
            textBoxNome.Leave += new System.EventHandler(Utilitarios.CampoEventoLeave);

            comboBoxDiaPagamento.Enter += new System.EventHandler(Utilitarios.CampoEventoEnter);
            comboBoxDiaPagamento.Leave += new System.EventHandler(Utilitarios.CampoEventoLeave);

            maskedTextBoxCPF.Enter += new System.EventHandler(Utilitarios.CampoEventoEnter);
            maskedTextBoxCPF.Leave += new System.EventHandler(Utilitarios.CampoEventoLeave);

            maskedTextBoxTelefone.Enter += new System.EventHandler(Utilitarios.CampoEventoEnter);
            maskedTextBoxTelefone.Leave += new System.EventHandler(Utilitarios.CampoEventoLeave);

            textBoxSenha.Enter += new System.EventHandler(Utilitarios.CampoEventoEnter);
            textBoxSenha.Leave += new System.EventHandler(Utilitarios.CampoEventoLeave);

            textBoxReSenha.Enter += new System.EventHandler(Utilitarios.CampoEventoEnter);
            textBoxReSenha.Leave += new System.EventHandler(Utilitarios.CampoEventoLeave);

            this.KeyDown += new KeyEventHandler(Utilitarios.FormEventoKeyDown);






        }

        private void ButtonExcluir_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBoxIDCliente.Text))
            {
                return;
            }
            dao = new ClienteDAO();
            cliente.IdCliente = Convert.ToInt32(textBoxIDCliente.Text);
            var mensagem = new FormLogout("Deseja realmente excluir os dados?", "Sim", "Não");
            mensagem.ShowDialog();

            if (mensagem.DialogResult == DialogResult.Yes)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    dao.ExcluirDbProvider(ConfigurationManager.ConnectionStrings["BD"].ProviderName, ConfigurationManager.ConnectionStrings["BD"].ConnectionString, cliente);
                    MessageBox.Show("Dados excluídos com Sucesso!");
                    LimpaFormulario();
                    AtualizarTela();
                    this.Cursor = Cursors.Default;
                    Utilitarios.SalvaLog("SQL", "DELETE cliente", Program.idLogado);
                    Utilitarios.SalvaLog("INFO", "Dados do cliente excluídos com Sucesso!", Program.idLogado);
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Pastelaria do Zé", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Cursor = Cursors.Default;
                    Utilitarios.SalvaLog("ERRO", ex.Message, Program.idLogado);
                }
            }
        }

        private void ButtonEditar_Click(object sender, EventArgs e)
        {
            dao = new ClienteDAO();
            int fiado = checkBoxFiado.Checked ? 1 : 0;



            try
            {


                //Instância objeto e preenche objeto
                cliente = new Cliente(textBoxNome.Text, maskedTextBoxTelefone.Text, maskedTextBoxCPF.Text, fiado, Convert.ToInt32(comboBoxDiaPagamento.SelectedItem));
                cliente.IdCliente = Convert.ToInt32(textBoxIDCliente.Text);
                Utilitarios.ValidaClasse(cliente);

            }
            catch (ValidationException ex)
            {
                MessageBox.Show(ex.Message, "Pastelaria do Zé", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Utilitarios.SalvaLog("ERRO", ex.Message, Program.idLogado);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Pastelaria do Zé", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Utilitarios.SalvaLog("ERRO", ex.Message, Program.idLogado);
                return;
            }

            try
            {
                // chama o método para inserir da camada model
                this.Cursor = Cursors.WaitCursor;
                dao.EditarDbProvider(ConfigurationManager.ConnectionStrings["BD"].ProviderName, ConfigurationManager.ConnectionStrings["BD"].ConnectionString, cliente);
                this.Cursor = Cursors.Default;
                AtualizarTela();
                MessageBox.Show("Dados alterados com sucesso!");
                Utilitarios.SalvaLog("SQL", "UPDATE cliente", Program.idLogado);
                Utilitarios.SalvaLog("INFO", "Dados do cliente alterados com sucesso!", Program.idLogado);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Pastelaria do Zé", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Cursor = Cursors.Default;
                Utilitarios.SalvaLog("ERRO", ex.Message, Program.idLogado);
            }
        }

        private void ButtonPesquisar_Click(object sender, EventArgs e)
        {
            cliente = new Cliente(busca.textBoxBusca.Text);
            dao = new ClienteDAO();

            try
            {
                DataTable linhas = dao.SelectDbProviderNome(ConfigurationManager.ConnectionStrings["BD"].ProviderName, ConfigurationManager.ConnectionStrings["BD"].ConnectionString, cliente);

                dataGridViewDados.AutoGenerateColumns = true;
                dataGridViewDados.DataSource = linhas;
                dataGridViewDados.Refresh();
                Utilitarios.SalvaLog("SQL", "SELECT cliente", Program.idLogado);
                Utilitarios.SalvaLog("INFO", "Cliente buscado com sucesso!", Program.idLogado);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Pastelaria do Zé", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Utilitarios.SalvaLog("ERRO", ex.Message, Program.idLogado);
            }
        }

        private void SalvaDados(object sender, EventArgs e)
        { 
              
            
            dao = new ClienteDAO();
            int fiado = checkBoxFiado.Checked? 1 : 0;
        
          

            try
            {
                if (Utilitarios.ConfirmaSenha(textBoxSenha.Text, textBoxReSenha.Text))
                {
                    string senhaCripto = Utilitarios.CriptografaSenha(textBoxSenha.Text);
                    //Instância objeto e Preenche objeto
                    
                        cliente = new Cliente(textBoxNome.Text, maskedTextBoxTelefone.Text, maskedTextBoxCPF.Text, fiado, Convert.ToInt32(comboBoxDiaPagamento.SelectedItem), senhaCripto);
                        Utilitarios.ValidaClasse(cliente);           
                    


                }
            }
            catch(ValidationException ex)
            {
                MessageBox.Show(ex.Message, "Pastelaria do Zé", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Utilitarios.SalvaLog("ERRO", ex.Message, Program.idLogado);
                return;

            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Pastelaria do Zé", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Utilitarios.SalvaLog("ERRO", ex.Message, Program.idLogado);
                return;
            }           
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Pastelaria do Zé", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Utilitarios.SalvaLog("ERRO", ex.Message, Program.idLogado);
                return;
            }

            


            try
            {
                // chama o método para inserir da camada model
                this.Cursor = Cursors.WaitCursor;
                dao.InserirDbProvider(ConfigurationManager.ConnectionStrings["BD"].ProviderName, ConfigurationManager.ConnectionStrings["BD"].ConnectionString, cliente);
                this.Cursor = Cursors.Default;
                AtualizarTela();
                MessageBox.Show("Dados inseridos com sucesso!");
                Utilitarios.SalvaLog("SQL", "INSERT cliente", Program.idLogado);
                Utilitarios.SalvaLog("INFO", "Dados do cliente inseridos com Sucesso!", Program.idLogado);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Pastelaria do Zé", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Cursor = Cursors.Default;
                Utilitarios.SalvaLog("ERRO", ex.Message, Program.idLogado);

            }

        }
        
        private void checkBoxVerSenha_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxVerSenha.Checked)
            {
                textBoxSenha.UseSystemPasswordChar = false;
                textBoxReSenha.UseSystemPasswordChar = false;
                return;
            }

            if (!checkBoxVerSenha.Checked)
            {
                textBoxSenha.UseSystemPasswordChar = true;
                textBoxReSenha.UseSystemPasswordChar = true;
            }
        }

        /// <summary>
        /// Atualiza a lista com todos os Clientes do banco de dados
        /// </summary>
        public void AtualizarTela()
        {
            cliente = new Cliente();
            dao = new ClienteDAO();

            try
            {
                DataTable linhas = dao.SelectDbProviderAll(ConfigurationManager.ConnectionStrings["BD"].ProviderName, ConfigurationManager.ConnectionStrings["BD"].ConnectionString, cliente);

                dataGridViewDados.AutoGenerateColumns = true;
                dataGridViewDados.DataSource = linhas;
                dataGridViewDados.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Pastelaria do Zé", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        /// <summary>
        /// Pega os dados de um Cliente da lista e coloca no formulário
        /// </summary>
        /// <param name="id"></param>
        public void AtualizarTelaOne(int id)
        {
            cliente = new Cliente();
            dao = new ClienteDAO();
            cliente.IdCliente = id;

            try
            {
                DataTable linhas = dao.SelectDbProviderOne(ConfigurationManager.ConnectionStrings["BD"].ProviderName, ConfigurationManager.ConnectionStrings["BD"].ConnectionString, cliente);
                
                foreach (DataRow row in linhas.Rows)
                {
                    textBoxIDCliente.Text = row[0].ToString();
                    textBoxNome.Text = row[1].ToString();
                    maskedTextBoxCPF.Text = row[2].ToString();
                    maskedTextBoxTelefone.Text = row[3].ToString();
                    if(row[4].ToString() == "Sim")
                    {
                        checkBoxFiado.Checked = true;
                    }
                    else
                    {
                        checkBoxFiado.Checked = false;
                    }
                    comboBoxDiaPagamento.SelectedItem = row[5].ToString();


                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Pastelaria do Zé", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewDados_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dataGridViewDados.SelectedCells.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewDados.Rows[dataGridViewDados.SelectedCells[0].RowIndex];
                int id = Convert.ToInt32(selectedRow.Cells[0].Value);
                AtualizarTelaOne(id);
                textBoxNome.Focus();
            }
        }

        /// <summary>
        /// Limpa os campos do formulário
        /// </summary>
        private void LimpaFormulario()
        {
            textBoxIDCliente.Text = "";
            textBoxNome.Text = "";
            textBoxSenha.Text = "";
            textBoxReSenha.Text = "";
            comboBoxDiaPagamento.SelectedIndex = -1;
            checkBoxFiado.Checked = false;
            maskedTextBoxCPF.Text = "";
            maskedTextBoxTelefone.Text = "";
        }
    }
}
