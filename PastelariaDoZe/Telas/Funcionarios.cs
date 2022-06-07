using PastelariaDoZe.Biblioteca;
using PastelariaDoZe.DAO;
using PastelariaDoZe.Telas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace PastelariaDoZe
{
    public partial class Funcionarios : Form
    {
        private Funcionario funcionario;
        private FuncionarioDAO dao;
        UserControlBusca busca = new UserControlBusca(7, 65);
        public Funcionarios()
        {
            InitializeComponent();
            
            this.Controls.Add(busca);

            AtualizarTela();

            busca.buttonSalvarDados.Click += new EventHandler(SalvaDados);
            busca.buttonPesquisar.Click += ButtonPesquisar_Click;
            busca.buttonEditar.Click += ButtonEditar_Click;
            busca.buttonExcluir.Click += ButtonExcluir_Click;

            textBoxIDFunc.Enter += new System.EventHandler(Utilitarios.CampoEventoEnter);
            textBoxIDFunc.Leave += new System.EventHandler(Utilitarios.CampoEventoLeave);

            textBoxNome.Enter += new System.EventHandler(Utilitarios.CampoEventoEnter);
            textBoxNome.Leave += new System.EventHandler(Utilitarios.CampoEventoLeave);

            textBoxMatricula.Enter += new System.EventHandler(Utilitarios.CampoEventoEnter);
            textBoxMatricula.Leave += new System.EventHandler(Utilitarios.CampoEventoLeave);

            textBoxSenha.Enter += new System.EventHandler(Utilitarios.CampoEventoEnter);
            textBoxSenha.Leave += new System.EventHandler(Utilitarios.CampoEventoLeave);

            textBoxReSenha.Enter += new System.EventHandler(Utilitarios.CampoEventoEnter);
            textBoxReSenha.Leave += new System.EventHandler(Utilitarios.CampoEventoLeave);

            maskedTextBoxCPF.Enter += new System.EventHandler(Utilitarios.CampoEventoEnter);
            maskedTextBoxCPF.Leave += new System.EventHandler(Utilitarios.CampoEventoLeave);

            maskedTextBoxTelefone.Enter += new System.EventHandler(Utilitarios.CampoEventoEnter);
            maskedTextBoxTelefone.Leave += new System.EventHandler(Utilitarios.CampoEventoLeave);

            this.KeyDown += new KeyEventHandler(Utilitarios.FormEventoKeyDown);
        }

        private void ButtonExcluir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxIDFunc.Text))
            {
                return;
            }
            dao = new FuncionarioDAO();
            funcionario.IdFuncionario = Convert.ToInt32(textBoxIDFunc.Text);
            var mensagem = new FormLogout("Deseja realmente excluir os dados?", "Sim", "Não");
            mensagem.ShowDialog();       
         
            if(mensagem.DialogResult == DialogResult.Yes)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    dao.ExcluirDbProvider(ConfigurationManager.ConnectionStrings["BD"].ProviderName, ConfigurationManager.ConnectionStrings["BD"].ConnectionString, funcionario);
                    MessageBox.Show("Dados excluídos com Sucesso!");
                    AtualizarTela();
                    LimpaFormulario();
                    Utilitarios.SalvaLog("SQL", "DELETE Funcionario", Program.idLogado);
                    Utilitarios.SalvaLog("INFO","Dados de Funcionário excluídos com sucesso!", Program.idLogado);
                    this.Cursor = Cursors.Default;

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
            dao = new FuncionarioDAO();
            int grupo = radioButtonAdministrador.Checked ? 1 : 2;



            try
            {

                    
                    //Instância objeto e preenche objeto
                    funcionario = new Funcionario(textBoxNome.Text, grupo, textBoxMatricula.Text, maskedTextBoxCPF.Text, maskedTextBoxTelefone.Text);
                    funcionario.IdFuncionario = Convert.ToInt32(textBoxIDFunc.Text);
                    Utilitarios.ValidaClasse(funcionario);
                
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
                dao.EditarDbProvider(ConfigurationManager.ConnectionStrings["BD"].ProviderName, ConfigurationManager.ConnectionStrings["BD"].ConnectionString, funcionario);
                this.Cursor = Cursors.Default;
                AtualizarTela();
                MessageBox.Show("Dados alterados com sucesso!");
                Utilitarios.SalvaLog("SQL", "UPDATE Funcionario", Program.idLogado);
                Utilitarios.SalvaLog("INFO", "Dados de funcionário alterados com sucesso!", Program.idLogado);
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
            funcionario = new Funcionario(busca.textBoxBusca.Text);
            dao = new FuncionarioDAO();

            try
            {
                DataTable linhas = dao.SelectDbProviderNome(ConfigurationManager.ConnectionStrings["BD"].ProviderName, ConfigurationManager.ConnectionStrings["BD"].ConnectionString, funcionario);

                dataGridViewDados.AutoGenerateColumns = true;
                dataGridViewDados.DataSource = linhas;
                dataGridViewDados.Refresh();
                Utilitarios.SalvaLog("SQL", "SELECT Funcionario", Program.idLogado);
                Utilitarios.SalvaLog("INFO", "Busca de funcionário feita com sucesso!", Program.idLogado);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Pastelaria do Zé", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void SalvaDados(object sender, EventArgs e)
        {
            dao = new FuncionarioDAO();
            int grupo = radioButtonAdministrador.Checked? 1 : 2;
            
           

            try
            {
                if (Utilitarios.ConfirmaSenha(textBoxSenha.Text, textBoxReSenha.Text))
                {
                    string senhaCripto = Utilitarios.CriptografaSenha(textBoxSenha.Text);
                    //Instância objeto e preenche objeto
                     funcionario = new Funcionario(textBoxNome.Text, senhaCripto, grupo, textBoxMatricula.Text, maskedTextBoxCPF.Text, maskedTextBoxTelefone.Text);
                    Utilitarios.ValidaClasse(funcionario);   
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
                MessageBox.Show(ex.Message,"Pastelaria do Zé",MessageBoxButtons.OK,MessageBoxIcon.Error);
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
                dao.InserirDbProvider(ConfigurationManager.ConnectionStrings["BD"].ProviderName, ConfigurationManager.ConnectionStrings["BD"].ConnectionString, funcionario);
                this.Cursor = Cursors.Default;
                AtualizarTela();

                MessageBox.Show("Dados inseridos com sucesso!");
                Utilitarios.SalvaLog("SQL", "INSERT Funcionario", Program.idLogado);
                Utilitarios.SalvaLog("INFO", "Dados de funcionário inseridos com sucesso!", Program.idLogado);
            }            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Pastelaria do Zé",MessageBoxButtons.OK,MessageBoxIcon.Error);
                this.Cursor = Cursors.Default;
                Utilitarios.SalvaLog("ERRO", ex.Message, Program.idLogado);
            }
        }

        /// <summary>
        /// Atualiza a lista de Funcionários do banco de dados na tabela
        /// </summary>
        public void AtualizarTela()
        {
            funcionario = new Funcionario();
            dao = new FuncionarioDAO();

            try
            {
                DataTable linhas = dao.SelectDbProviderAll(ConfigurationManager.ConnectionStrings["BD"].ProviderName, ConfigurationManager.ConnectionStrings["BD"].ConnectionString, funcionario);

                dataGridViewDados.AutoGenerateColumns = true;
                dataGridViewDados.DataSource = linhas;
                dataGridViewDados.Refresh();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Pastelaria do Zé", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         

            
        }

        /// <summary>
        /// Pega da lista um Funcionário e coloca os dados no formulário
        /// </summary>
        /// <param name="id">Id do Funcionário escolhido</param>
        public void AtualizarTelaOne(int id)
        {
            funcionario = new Funcionario();
            dao = new FuncionarioDAO();
            funcionario.IdFuncionario = id;

            try
            {
                DataTable linhas = dao.SelectDbProviderOne(ConfigurationManager.ConnectionStrings["BD"].ProviderName, ConfigurationManager.ConnectionStrings["BD"].ConnectionString, funcionario);
               
                foreach (DataRow row in linhas.Rows)
                {
                    textBoxIDFunc.Text = row[0].ToString();
                    textBoxNome.Text = row[1].ToString();
                    maskedTextBoxCPF.Text = row[2].ToString();
                    maskedTextBoxTelefone.Text = row[3].ToString();
                    textBoxMatricula.Text = row[4].ToString();
                    if (row[5].Equals("Admin"))
                    {
                        radioButtonAdministrador.Checked = true;
                    }
                    else
                    {
                        radioButtonBalcao.Checked = true;
                    }
                    
                    
                }
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Pastelaria do Zé", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewDados_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(dataGridViewDados.SelectedCells.Count > 0)
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
            textBoxIDFunc.Text = "";
            textBoxNome.Text = "";
            textBoxMatricula.Text = "";
            maskedTextBoxCPF.Text = "";
            maskedTextBoxTelefone.Text = "";
            textBoxSenha.Text = "";
            textBoxReSenha.Text = "";

        }
    }
}
    
