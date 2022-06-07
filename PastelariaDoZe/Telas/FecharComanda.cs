using PastelariaDoZe.Biblioteca;
using PastelariaDoZe.DAO;
using PastelariaDoZe.Telas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PastelariaDoZe
{
    public partial class FecharComanda : Form
    {
        Comanda comanda;
        ComandaDAO dao = new ComandaDAO();
        ComandaProdutos comandaProdutos;
        Cliente cliente;
        ClienteDAO daoCli = new ClienteDAO();
        public FecharComanda()
        {
            InitializeComponent();
            AtualizarTela();

            textBoxBuscaCliente.Enter += new EventHandler(Utilitarios.CampoEventoEnter);
            textBoxBuscaCliente.Leave += new EventHandler(Utilitarios.CampoEventoLeave);          

            textBoxValorDesconto.Enter += new EventHandler(Utilitarios.CampoEventoEnter);
            textBoxValorDesconto.Leave += new EventHandler(Utilitarios.CampoEventoLeave);

            textBoxValorDesconto.KeyPress += new KeyPressEventHandler(Utilitarios.NumericoKeyPress);
            
            

            this.KeyDown += new KeyEventHandler(Utilitarios.FormEventoKeyDown);
        }

        private void AtualizarTela()
        {
            comboBoxComandasAbertas.Text = "";
            comboBoxComandasAbertas.Items.Clear();
            comanda = new Comanda();
            comanda.StatusComanda = 0;
            dataGridViewComandaItens.Rows.Clear();
            try
            {
                // chama o método para buscar todos os dados da nossa camada model
                DataTable linhas = dao.ListaComandas(
                ConfigurationManager.ConnectionStrings["BD"].ProviderName,
                ConfigurationManager.ConnectionStrings["BD"].ConnectionString,
                comanda);
                // carrega os dados retornados no comboBox
                foreach (DataRow row in linhas.Rows)
                {
                    if (row["Status"].Equals("Aberta"))
                    {
                    comboBoxComandasAbertas.Items.Add(
                    new Comanda(Convert.ToInt32(row["ID"].ToString()),
                    row["Comanda"].ToString()));
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBoxComandasAbertas_SelectedIndexChanged(object sender, EventArgs e)
        {
            //pega o objeto do tipo comanda que foi armazenado no comboBox
            Comanda aux = comboBoxComandasAbertas.SelectedItem as Comanda;
            comandaProdutos = new ComandaProdutos();
            comandaProdutos.IdComanda = aux.IdComanda;
            try
            {
                // chama o método para buscar todos os dados da nossa camada model
                DataTable linhas = dao.ListaItensComanda(
                ConfigurationManager.ConnectionStrings["BD"].ProviderName,
                ConfigurationManager.ConnectionStrings["BD"].ConnectionString, comandaProdutos);
                // seta o data source com os dados retornados
                dataGridViewComandaItens.AutoGenerateColumns = true;
                dataGridViewComandaItens.DataSource = linhas;
                dataGridViewComandaItens.Refresh();
                //busca o total da comanda e atualiza em tela
                double totalComanda = dao.TotalComanda(
                ConfigurationManager.ConnectionStrings["BD"].ProviderName,
                ConfigurationManager.ConnectionStrings["BD"].ConnectionString, comandaProdutos);

                string[] valorArray = totalComanda.ToString().Split(',');
                var comandaTotal = valorArray[0].Length < 3 ? totalComanda.ToString("00.00") : totalComanda.ToString("000.00");
                textBoxValorTotal.Text = "" + comandaTotal;
                textBoxValorDesconto.Text = "0";
                textBoxValorAPagar.Text = "" + comandaTotal;
                Utilitarios.SalvaLog("INFO", "Comanda pronta para fechar", Program.idLogado);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Utilitarios.SalvaLog("ERRO", ex.Message, Program.idLogado);
            }
        }

        private void buttonBuscaCliente_Click(object sender, EventArgs e)
        {
            cliente = new Cliente(0,textBoxBuscaCliente.Text);
            
            try
            {
                // chama o método para buscar todos os dados da nossa camada model
                DataTable linhas = daoCli.SelectDbProviderOne(
                ConfigurationManager.ConnectionStrings["BD"].ProviderName,
                ConfigurationManager.ConnectionStrings["BD"].ConnectionString, cliente,true);

                if(linhas.Rows.Count < 1)
                {
                    MessageBox.Show("CPF não encontrado!", "Pastelaria do Zé", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


                // seta os dados na tela
                foreach (DataRow row in linhas.Rows)
                {
                    labelID.Text = row[0].ToString();
                    labelNome.Text = row[1].ToString();
                    labelCPF.Text =  Utilitarios.FormataCPF(row[2].ToString());
                    labelTelefone.Text = Utilitarios.FormataTelefone(row[3].ToString());
                    labelFiado.Text = row[4].ToString();
                    labelVencimento.Text = row[5].ToString();
                }

                
                
                Utilitarios.SalvaLog("SQL", "SELECT Cliente", Program.idLogado);
                Utilitarios.SalvaLog("INFO","CLiente buscado para fechar comanda", Program.idLogado);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Utilitarios.SalvaLog("ERRO", ex.Message, Program.idLogado);
            }

            //Busca as informações sobre o cliente estar ou não inadimplente
            comanda = new Comanda();
            if(labelID.Text.Length < 1)
            {
                return;
            }
            comanda.IdCliente = Convert.ToInt32(labelID.Text);
            comanda.DataHora = DateTime.Now.AddDays(-30);
            try
            {
                // chama o método para buscar todos os dados da nossa camada model
                if (!dao.ValidaInadimplencia(
                ConfigurationManager.ConnectionStrings["BD"].ProviderName,
                ConfigurationManager.ConnectionStrings["BD"].ConnectionString, comanda))
                {
                    labelStatus.Text = "Sem inadimplência";
                    labelStatus.ForeColor = Color.Green;
                    
                }
                else
                {
                    labelStatus.Text = "Cliente inadimplente!";
                    labelStatus.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Utilitarios.SalvaLog("ERROR", ex.Message, Program.idLogado);
            }
        }

        private void buttonPagAVista_Click(object sender, EventArgs e)
        {
            //pega o objeto do tipo comanda que foi armazenado no comboBox
            Comanda auxIdComanda = comboBoxComandasAbertas.SelectedItem as Comanda;
            var idCliente = Convert.ToInt32((labelID.Text.Length > 0) ? labelID.Text : "0");
            comanda = new Comanda(auxIdComanda.IdComanda, 1, 1, Program.idLogado, idCliente, Convert.ToDouble(textBoxValorAPagar.Text));

            
            try
            {
                dao.RecebeComandaAVista(ConfigurationManager.ConnectionStrings["BD"].ProviderName,
                ConfigurationManager.ConnectionStrings["BD"].ConnectionString, comanda);
                AtualizarTela();
                MessageBox.Show("Comanda paga A Vista com sucesso!","Pastelaria do Zé",MessageBoxButtons.OK,MessageBoxIcon.Information);
                Utilitarios.SalvaLog("SQL", "UPDATE Comanda", Program.idLogado);
                Utilitarios.SalvaLog("INFO", "Pagamento a vista feito com sucesso!", Program.idLogado);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Pastelaria do Zé",MessageBoxButtons.OK,MessageBoxIcon.Error);
                Utilitarios.SalvaLog("ERRO", ex.Message, Program.idLogado);
            }
        }

        private bool ValidaLiberaFiado()
        {
            //valida se o cliente foi escolhido, se é autorizado a realizar fiado e se a senha digitada por ele esta OK
            if (labelID.Text.Length > 0 && labelCPF.Text.Length > 0)
            {
                //valida se é autorizado a realizar FIADO
                if (!labelFiado.Text.Equals("Sim"))
                {
                    MessageBox.Show("Cliente NÃO HABILITADO para realizar FIADO!");
                    return false;
                }
                //solicita e valida a SENHA do Cliente
                var formSenha = new FormSenhaCliente();
                formSenha.ShowDialog();
                var senha = formSenha.textBoxSenhaCliente.Text;
                if (formSenha.DialogResult == DialogResult.OK)
                {
                    var auxSenha = Utilitarios.CriptografaSenha(senha);

                    cliente = new Cliente(Utilitarios.FormataCPF(labelCPF.Text,true), auxSenha);
                  
                    try
                    {
                        // chama o método para validar a senha no model cliente
                        if (!daoCli.ValidaSenhaCliente(
                        ConfigurationManager.ConnectionStrings["BD"].ProviderName,
                        ConfigurationManager.ConnectionStrings["BD"].ConnectionString, cliente))
                        {
                            MessageBox.Show("Senha errada!");
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Senha do Cliente não informada!");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Cliente não selecionado!");
                return false;
            }
            return true;
        }

        private void buttonPagFiado_Click(object sender, EventArgs e)
        {
            //executa as validações do cliente
            if (!ValidaLiberaFiado())
            {
                return;
            }
            //pega o objeto do tipo comanda que foi armazenado no comboBox
            Comanda auxIdComanda = comboBoxComandasAbertas.SelectedItem as Comanda;

            comanda = new Comanda(auxIdComanda.IdComanda, DateTime.Now, 0, 2, Program.idLogado, Convert.ToInt32(labelID.Text));

            
            
            try
            {
                // chama o método para editar o pagamento em nossa model
                dao.RegistraComandaFiado(ConfigurationManager.ConnectionStrings["BD"].ProviderName,
                    ConfigurationManager.ConnectionStrings["BD"].ConnectionString, comanda);
                AtualizarTela();
                MessageBox.Show("Comanda registrada como FIADO com sucesso!");
                Utilitarios.SalvaLog("SQL", "UPDATE Comanda", Program.idLogado);
                Utilitarios.SalvaLog("INFO","Registro de fiado feito com sucesso!", Program.idLogado);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Utilitarios.SalvaLog("ERRO", ex.Message, Program.idLogado);
            }
        }

        private void textBoxValorDesconto_TextChanged(object sender, EventArgs e)
        {
            double valorAPagar =0;
            if(textBoxValorDesconto.TextLength > 0)
            {
                valorAPagar = Convert.ToDouble(textBoxValorTotal.Text) - Convert.ToDouble(textBoxValorDesconto.Text);
                string[] valorArray = valorAPagar.ToString().Split(',');
                textBoxValorAPagar.Text = valorArray[0].Length < 3 ? valorAPagar.ToString("00.00") : valorAPagar.ToString("000.00");
                return;
            }

            textBoxValorAPagar.Text = textBoxValorTotal.Text;


        }
    }
}
