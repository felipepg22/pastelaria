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
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PastelariaDoZe
{
    public partial class CadastroProdutos : Form
    {
        private Produto produto;
        private ProdutoDAO dao;
        UserControlBusca busca = new UserControlBusca(0, 69);
        public CadastroProdutos()
        {
            InitializeComponent();
            
            this.Controls.Add(busca);
            AtualizarTela();
            
            busca.buttonSalvarDados.Click += new EventHandler(SalvaDados);
            busca.buttonPesquisar.Click += ButtonPesquisar_Click;
            busca.buttonEditar.Click += ButtonEditar_Click;
            busca.buttonExcluir.Click += ButtonExcluir_Click;

            

            textBoxIDProduto.Enter += new System.EventHandler(Utilitarios.CampoEventoEnter);
            textBoxIDProduto.Leave += new System.EventHandler(Utilitarios.CampoEventoLeave);

            textBoxNomeProduto.Enter += new System.EventHandler(Utilitarios.CampoEventoEnter);
            textBoxNomeProduto.Leave += new System.EventHandler(Utilitarios.CampoEventoLeave);

            textBoxValor.Enter += new System.EventHandler(Utilitarios.CampoEventoEnter);
            textBoxValor.Leave += new System.EventHandler(Utilitarios.CampoEventoLeave);

            textBoxDescricao.Enter += new System.EventHandler(Utilitarios.CampoEventoEnter);
            textBoxDescricao.Leave += new System.EventHandler(Utilitarios.CampoEventoLeave);

            textBoxValor.KeyPress += new KeyPressEventHandler(Utilitarios.NumericoKeyPress);

            this.KeyDown += new KeyEventHandler(Utilitarios.FormEventoKeyDown);





        }

        private void ButtonExcluir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxIDProduto.Text))
            {
                return;
            }
            dao = new ProdutoDAO();
            produto.IdProduto = Convert.ToInt32(textBoxIDProduto.Text);
            var mensagem = new FormLogout("Deseja realmente excluir os dados?", "Sim", "Não");
            mensagem.ShowDialog();

            if (mensagem.DialogResult == DialogResult.Yes)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    dao.ExcluirDbProvider(ConfigurationManager.ConnectionStrings["BD"].ProviderName, ConfigurationManager.ConnectionStrings["BD"].ConnectionString, produto);
                    MessageBox.Show("Dados excluídos com Sucesso!");
                    AtualizarTela();
                    LimparFormulário();
                    Utilitarios.SalvaLog("SQL", "DELETE Produto", Program.idLogado);
                    Utilitarios.SalvaLog("INFO", "Dados do produto excluídos com Sucesso!", Program.idLogado);


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
            dao = new ProdutoDAO();          



            try
            {


                //Instância objeto e preenche objeto
                var imagemProduto = ConverteImagemParaByteArray(pictureBoxProduto.Image, pictureBoxProduto);
                produto = new Produto(textBoxNomeProduto.Text, textBoxDescricao.Text, Convert.ToDouble(textBoxValor.Text), imagemProduto);
                produto.IdProduto = Convert.ToInt32(textBoxIDProduto.Text);
                Utilitarios.ValidaClasse(produto);

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
                dao.EditarDbProvider(ConfigurationManager.ConnectionStrings["BD"].ProviderName, ConfigurationManager.ConnectionStrings["BD"].ConnectionString, produto);
                this.Cursor = Cursors.Default;
                AtualizarTela();
                MessageBox.Show("Dados alterados com sucesso!");
                Utilitarios.SalvaLog("SQL", "UPDATE Produto", Program.idLogado);
                Utilitarios.SalvaLog("INFO", "Dados do produto alterados com sucesso!", Program.idLogado);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Pastelaria do Zé", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Utilitarios.SalvaLog("ERRO", ex.Message, Program.idLogado);
                this.Cursor = Cursors.Default;
            }
        }

        private void ButtonPesquisar_Click(object sender, EventArgs e)
        {
            produto = new Produto(busca.textBoxBusca.Text);
            dao = new ProdutoDAO();

            try
            {
                DataTable linhas = dao.SelectDbProviderNome(ConfigurationManager.ConnectionStrings["BD"].ProviderName, ConfigurationManager.ConnectionStrings["BD"].ConnectionString, produto);

                dataGridViewDados.AutoGenerateColumns = true;
                dataGridViewDados.DataSource = linhas;
                dataGridViewDados.Refresh();
                Utilitarios.SalvaLog("SQL", "SELECT Produto", Program.idLogado);
                Utilitarios.SalvaLog("INFO", "Produto buscado com sucesso!", Program.idLogado);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Pastelaria do Zé", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Utilitarios.SalvaLog("ERRO", ex.Message, Program.idLogado);
            }
        }

        private void buttonAddFoto_Click(object sender, EventArgs e)
        {
            var imagem = new OpenFileDialog();
            imagem.Title = "Imagem do Produto";
            imagem.Filter = "Images(*.JPEG; *.BMP; *.JPG; *.GIF; *.PNG; *.)| *.JPEG; *.BMP; *.JPG; *.GIF; *.PNG;*.icon; *.JFIF";
            imagem.InitialDirectory = "C:\\Sistemas de Informação\\3ª Fase\\Desenvolvimento de Sistemas\\Projeto Pastelaria\\Programa\\PastelariaDoZe\\PastelariaDoZe\\Imagens";

            if(imagem.ShowDialog() == DialogResult.OK)
            {
                pictureBoxProduto.Image = Image.FromFile(imagem.FileName);
            }


        }

        private void SalvaDados(object sender, EventArgs e)
        {
             dao = new ProdutoDAO();
           
            
            try
            {
                //Instância objeto e preenche o objeto

                var imagemProduto = ConverteImagemParaByteArray(pictureBoxProduto.Image, pictureBoxProduto);

                produto = new Produto(textBoxNomeProduto.Text, textBoxDescricao.Text, Convert.ToDouble(textBoxValor.Text),imagemProduto);
                Utilitarios.ValidaClasse(produto);
            }
            catch(ValidationException ex)
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
                dao.InserirDbProvider(ConfigurationManager.ConnectionStrings["BD"].ProviderName, ConfigurationManager.ConnectionStrings["BD"].ConnectionString, produto);
                this.Cursor = Cursors.Default;
                AtualizarTela();
                LimparFormulário();
                MessageBox.Show("Dados inseridos com sucesso!");
                Utilitarios.SalvaLog("SQL", "INSERT Produto", Program.idLogado);
                Utilitarios.SalvaLog("INFO", "Dados do produto inseridos com sucesso!", Program.idLogado);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Pastelaria do Zé", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Utilitarios.SalvaLog("ERRO", ex.Message, Program.idLogado);
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Mostra em uma tabela os dados do banco
        /// </summary>
        public void AtualizarTela()
        {
            produto = new Produto();
            dao = new ProdutoDAO();

            try
            {
                DataTable linhas = dao.SelectDbProviderAll(ConfigurationManager.ConnectionStrings["BD"].ProviderName, ConfigurationManager.ConnectionStrings["BD"].ConnectionString, produto);

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
        /// Escolhe da tabela um dado para mostrar nos campos
        /// </summary>
        /// <param name="id">Id do produto que deseja ver as informações</param>
        public void AtualizarTelaOne(int id)
        {
            produto = new Produto();
            dao = new ProdutoDAO();
            produto.IdProduto = id;

            try
            {
                DataTable linhas = dao.SelectDbProviderOne(ConfigurationManager.ConnectionStrings["BD"].ProviderName, ConfigurationManager.ConnectionStrings["BD"].ConnectionString, produto);
                
                foreach (DataRow row in linhas.Rows)
                {
                    textBoxIDProduto.Text = row[0].ToString();
                    textBoxNomeProduto.Text = row[1].ToString();
                    textBoxDescricao.Text = row[2].ToString();
                    textBoxValor.Text = row[4].ToString();
                    pictureBoxProduto.Image = ConverteByteArrayParaImagem((byte[])row[3]);
                   
                    
                           
                 


                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Pastelaria do Zé", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Converte a foto da picture box para um array de bytes
        /// </summary>
        /// <param name="img">Foto do produto</param>
        /// <param name="imagem"></param>
        /// <returns></returns>
        public static byte[] ConverteImagemParaByteArray(Image img,PictureBox imagem)
        {
            MemoryStream ms = new MemoryStream();
            if(imagem.Image != null){

                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            }

            return ms.ToArray();
        }

        /// <summary>
        /// Converte o array de bytes para uma imagem
        /// </summary>
        /// <param name="pData">Array de Bytes</param>
        /// <returns></returns>
        public static Image ConverteByteArrayParaImagem(byte[] pData)
        {
            try
            {
                ImageConverter imgConverter = new ImageConverter();
                return imgConverter.ConvertFrom(pData) as Image;
            }
            catch
            {
                return null;
            }
        }

        private void dataGridViewDados_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dataGridViewDados.SelectedCells.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewDados.Rows[dataGridViewDados.SelectedCells[0].RowIndex];
                int id = Convert.ToInt32(selectedRow.Cells[0].Value);
                AtualizarTelaOne(id);
                textBoxNomeProduto.Focus();
            }
        }

        private void LimparFormulário()
        {
            textBoxIDProduto.Text = "";
            textBoxNomeProduto.Text = "";
            textBoxDescricao.Text = "Descrição(Obrigatório)";
            textBoxValor.Text = "";
            
        }
    }
}
