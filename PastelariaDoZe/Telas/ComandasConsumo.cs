using PastelariaDoZe.Biblioteca;
using PastelariaDoZe.DAO;
using PastelariaDoZe.Telas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PastelariaDoZe
{
    public partial class ComandasConsumo : Form
    {
        private Comanda comanda;
        private ComandaDAO dao;
        private Produto produto;
        private ProdutoDAO daoProduto;
        private ComandaProdutos comandaProdutos;
        public ComandasConsumo()
        {
            InitializeComponent();

            AtualizarTela();
            AtualizarTela(true);

            textBoxNumeroComanda.Enter += new EventHandler(Utilitarios.CampoEventoEnter);
            textBoxNumeroComanda.Leave += new EventHandler(Utilitarios.CampoEventoLeave);

            textBoxPesquisaProdutoComanda.Enter += new EventHandler(Utilitarios.CampoEventoEnter);
            textBoxPesquisaProdutoComanda.Leave += new EventHandler(Utilitarios.CampoEventoLeave);

            this.KeyDown += new KeyEventHandler(Utilitarios.FormEventoKeyDown);
        }

        public void AtualizarTela(bool produtoTela = false)
        {
            if (produtoTela)
            {
                produto = new Produto();
                daoProduto = new ProdutoDAO();

                try
                {
                    DataTable linhas = daoProduto.SelectDbProviderAll(
                                        ConfigurationManager.ConnectionStrings["BD"].ProviderName,
                                        ConfigurationManager.ConnectionStrings["BD"].ConnectionString,
                                        produto);
                    dataGridViewAddProduto.AutoGenerateColumns = true;
                    dataGridViewAddProduto.DataSource = linhas;
                    dataGridViewAddProduto.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Pastelaria do Zé", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            comanda = new Comanda();
            dao = new ComandaDAO();
            comanda.StatusComanda = 0;
            try
            {
                // chama o metodo para buscar todos os dados da nossa camada model
                DataTable linhas = dao.ListaComandas(
                ConfigurationManager.ConnectionStrings["BD"].ProviderName,
                ConfigurationManager.ConnectionStrings["BD"].ConnectionString, comanda);
                // seta o data souce com os dados retornados
                dataGridViewComanda.AutoGenerateColumns = true;
                dataGridViewComanda.DataSource = linhas;
                dataGridViewComanda.Refresh();
                //buttonBuscaProduto_Click(null, null);
                //LimparTela();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Pastelaria do Zé", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSalvarComanda_Click(object sender, EventArgs e)
        {
            if(textBoxNumeroComanda.TextLength < 1)
            {
                MessageBox.Show("Digite um número de comanda!", "Pastelaria do Zé", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            comanda = new Comanda(textBoxNumeroComanda.Text, 0, DateTime.Now);
            dao = new ComandaDAO();

            try
            {
                // chama o método para inseir da nossa camada model
                /*
                * NÃO PODE TER OUTRA COMANDA COM MESMO NUMERO E STATUS 0
                * => SE TIVER DAR ALARME
                * => SE NÃO TIVER ABRIR
                */
                if (!dao.AbreNovaComanda(ConfigurationManager.ConnectionStrings["BD"].ProviderName,
                ConfigurationManager.ConnectionStrings["BD"].ConnectionString, comanda))
                {
                    MessageBox.Show("ERRO!!! Comanda " + textBoxNumeroComanda.Text + " já esta aberta!!!");
                    Utilitarios.SalvaLog("ERRO", "Comanda já aberta", Program.idLogado);
                }
                else
                {
                    AtualizarTela();
                    MessageBox.Show("Comanda aberta com sucesso!");
                    Utilitarios.SalvaLog("SQL", "INSERT Comanda", Program.idLogado);
                    Utilitarios.SalvaLog("INFO", "Comanda aberta com sucesso!", Program.idLogado);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Utilitarios.SalvaLog("ERRO", ex.Message, Program.idLogado);
            }
        }

        private void buttonAddProduto_Click(object sender, EventArgs e)
        {



            if (dataGridViewAddProduto.SelectedCells.Count > 0)
            {
                //pega o ID e o NUMERO da comanda selecionada
                DataGridViewRow selectedRowComanda = dataGridViewComanda.Rows[dataGridViewComanda.SelectedCells[0].RowIndex];
                int idComanda = Convert.ToInt32(selectedRowComanda.Cells[0].Value);
                int numeroComanda = Convert.ToInt32(selectedRowComanda.Cells[1].Value);
                //pega o ID, NOME e VALOR do produto selecionado
                DataGridViewRow selectedRowProduto = dataGridViewAddProduto.Rows[dataGridViewAddProduto.SelectedCells[0].RowIndex];
                int idProduto = Convert.ToInt32(selectedRowProduto.Cells[0].Value);
                double valorProduto = Convert.ToDouble(selectedRowProduto.Cells[4].Value);
                string nomeProduto = Convert.ToString(selectedRowProduto.Cells[1].Value);
                //abrir tela confirmação e também para indicar a quantidade

                var quantidade = new FormQuantidade();
                quantidade.ShowDialog();
                var unidades = Convert.ToInt32(quantidade.textBoxQuantidade.Text);
                if (unidades > 0)
                {
                    if (quantidade.DialogResult == DialogResult.OK)
                    {
                        comandaProdutos = new ComandaProdutos(
                            idComanda,
                            idProduto,
                            unidades,
                            valorProduto,
                            Program.idLogado);
                        try
                        {
                            // chama o método para inseir da nossa camada model
                            dao.AddItemComanda(ConfigurationManager.ConnectionStrings["BD"].ProviderName,
                            ConfigurationManager.ConnectionStrings["BD"].ConnectionString, comandaProdutos);
                            AtualizarTelaItensComanda(idComanda);
                            Utilitarios.SalvaLog("SQL", "INSERT Comanda_Produto", Program.idLogado);
                            Utilitarios.SalvaLog("INFO", "Produto adicionado a comanda" + comandaProdutos.IdComanda, Program.idLogado);

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            Utilitarios.SalvaLog("ERRO", ex.Message, Program.idLogado);
                        }
                    }
                }
            }

        }

        private void AtualizarTelaItensComanda(int idComanda)
        {
            var comandaProdutos = new ComandaProdutos();
            comandaProdutos.IdComanda = idComanda;

            try
            {
                // chama o método para buscar todos os dados da nossa camada model
                DataTable linhas =
                dao.ListaItensComanda(ConfigurationManager.ConnectionStrings["BD"].ProviderName
                , ConfigurationManager.ConnectionStrings["BD"].ConnectionString,
                comandaProdutos);
                // seta o data source com os dados retornados
                dataGridViewItensComanda.AutoGenerateColumns = true;
                dataGridViewItensComanda.DataSource = linhas;
                dataGridViewItensComanda.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewComanda_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewComanda.SelectedCells.Count > 0)
            {
                //pega a linha selecionada
                DataGridViewRow selectedRow =
                dataGridViewComanda.Rows[dataGridViewComanda.SelectedCells[0].RowIndex];
                //pega a primeira coluna, que esta com o ID, da linha selecionada
                int idComanda = Convert.ToInt32(selectedRow.Cells[0].Value);
                AtualizarTelaItensComanda(idComanda);
            }
        }

        private void buttonEditarProduto_Click(object sender, EventArgs e)
        {
            if (dataGridViewItensComanda.SelectedCells.Count > 0)
            {
                //pega o ID da comanda selecionada
                DataGridViewRow selectedRowComanda = dataGridViewComanda.Rows[dataGridViewComanda.SelectedCells[0].RowIndex];
                int idComanda = Convert.ToInt32(selectedRowComanda.Cells[0].Value);

                // pega o ID e a Quantidade do produto na comanda
                DataGridViewRow selectedRowComandaItens =
                dataGridViewItensComanda.Rows[dataGridViewItensComanda.SelectedCells[0].RowIndex];
                int idComandaProduto = Convert.ToInt32(selectedRowComandaItens.Cells[0].Value);
                string qtdaProduto = Convert.ToString(selectedRowComandaItens.Cells[2].Value);

                var quantidade = new FormQuantidade();
                quantidade.ShowDialog();
                var unidades = Convert.ToInt32(quantidade.textBoxQuantidade.Text);
                if (unidades > 0)
                {
                    if (quantidade.DialogResult == DialogResult.OK)
                    {
                        comandaProdutos = new ComandaProdutos(idComandaProduto, unidades, Program.idLogado);

                        try
                        {
                            dao = new ComandaDAO();

                            dao.EditaItemComanda(ConfigurationManager.ConnectionStrings["BD"].ProviderName,
                                                 ConfigurationManager.ConnectionStrings["BD"].ConnectionString,
                                                 comandaProdutos);
                            AtualizarTelaItensComanda(idComanda);
                            Utilitarios.SalvaLog("SQL", "UPDATE Comanda_Produtos", Program.idLogado);
                            Utilitarios.SalvaLog("INFO", "Editado produto na comanda " + comandaProdutos.IdComanda, Program.idLogado);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Pastelaria do Zé", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Utilitarios.SalvaLog("ERROR", ex.Message, Program.idLogado);
                        }
                    }
                }



            }
        }

        private void buttonExcluirProduto_Click(object sender, EventArgs e)
        {
            if (dataGridViewItensComanda.SelectedCells.Count > 0)
            {
                //pega o ID da comanda selecionada
                DataGridViewRow selectedRowComanda = dataGridViewComanda.Rows[dataGridViewComanda.SelectedCells[0].RowIndex];
                int idComanda = Convert.ToInt32(selectedRowComanda.Cells[0].Value);

                // pega o ID produto na comanda
                DataGridViewRow selectedRowComandaItens =
                dataGridViewItensComanda.Rows[dataGridViewItensComanda.SelectedCells[0].RowIndex];
                int idComandaProduto = Convert.ToInt32(selectedRowComandaItens.Cells[0].Value);

                try
                {
                    dao = new ComandaDAO();
                    comandaProdutos = new ComandaProdutos(idComandaProduto);

                    dao.ExcluiItemComanda(ConfigurationManager.ConnectionStrings["BD"].ProviderName,
                                          ConfigurationManager.ConnectionStrings["BD"].ConnectionString,
                                          comandaProdutos);
                    AtualizarTelaItensComanda(idComanda);
                    Utilitarios.SalvaLog("SQL", "DELETE Comanda_Produtos", Program.idLogado);
                    Utilitarios.SalvaLog("INFO", "Produto excluído da comanda " + comandaProdutos.IdComanda, Program.idLogado);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Pastelaria do Zé", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Utilitarios.SalvaLog("ERRO", ex.Message, Program.idLogado);
                }

            }
        }

        private void buttonExcluiComanda_Click(object sender, EventArgs e)
        {
            if(dataGridViewItensComanda.Rows.Count > 0)
            {
                MessageBox.Show("Não pode excluir comanda com itens!", "Pastelaria do Zé", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(dataGridViewComanda.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Deseja realmente excluir a comanda?", "Pastelaria do Zé", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    comanda = new Comanda();
                    DataGridViewRow selectedRowComanda = dataGridViewComanda.Rows[dataGridViewComanda.SelectedCells[0].RowIndex];
                    comanda.IdComanda = Convert.ToInt32(selectedRowComanda.Cells[0].Value);

                    try
                    {
                        dao.ExcluiComanda(ConfigurationManager.ConnectionStrings["BD"].ProviderName,
                        ConfigurationManager.ConnectionStrings["BD"].ConnectionString,
                        comanda);
                        AtualizarTela();
                        Utilitarios.SalvaLog("SQL", "DELETE Comanda", Program.idLogado);
                        Utilitarios.SalvaLog("INFO", "Comanda deletada com sucesso!", Program.idLogado);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Pastelaria do Zé", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Utilitarios.SalvaLog("ERROR", ex.Message, Program.idLogado);
                    }
                    
                }
            }
            
            
        }

        private void buttonBuscaProduto_Click(object sender, EventArgs e)
        {
            if(textBoxPesquisaProdutoComanda.TextLength > 0)
            {
                produto = new Produto(textBoxPesquisaProdutoComanda.Text);
                daoProduto = new ProdutoDAO();

                try
                {
                    DataTable linhas = daoProduto.SelectDbProviderNome(ConfigurationManager.ConnectionStrings["BD"].ProviderName,
                        ConfigurationManager.ConnectionStrings["BD"].ConnectionString,
                        produto);

                    dataGridViewAddProduto.AutoGenerateColumns = true;
                    dataGridViewAddProduto.DataSource = linhas;
                    dataGridViewAddProduto.Refresh();
                    Utilitarios.SalvaLog("SQL", "SELECT Produto", Program.idLogado);
                    Utilitarios.SalvaLog("INFO", "Produto buscado para comanda com sucesso!", Program.idLogado);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Pastelaria do Zé", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Utilitarios.SalvaLog("ERRO", ex.Message, Program.idLogado);
                }
            }
            else
            {
                AtualizarTela(true);
            }
        }
    }
}
