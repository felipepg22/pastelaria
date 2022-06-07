using PastelariaDoZe.Biblioteca;
using PastelariaDoZe.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace PastelariaDoZe
{
    public partial class TelaConfiguracoes : Form
    {
        private Empresa empresa;
        private EmpresaDAO dao;
        public TelaConfiguracoes()
        {
            InitializeComponent();
            AtualizarTelaOne();

            ConnectionStringSettings connectionStringSettings =
                ConfigurationManager.ConnectionStrings["BD"];

            comboBoxProvider.Text = connectionStringSettings.ProviderName;

            textBoxStringConexao.Text = connectionStringSettings.ConnectionString;

            var idioma = ConfigurationManager.AppSettings.Get("Cultura");

            radioButtonPT_BR.Checked = idioma == "pt-BR" ? true : false;
            radioButtonEN_US.Checked = idioma == "en-US" ? true : false;
            radioButtonESP.Checked = idioma == "es-ES" ? true : false;

            textBoxBusca.Enter += new EventHandler(Utilitarios.CampoEventoEnter);
            textBoxBusca.Leave += new EventHandler(Utilitarios.CampoEventoLeave);

            textBoxPercentualJuros.Enter += new EventHandler(Utilitarios.CampoEventoEnter);
            textBoxPercentualJuros.Leave += new EventHandler(Utilitarios.CampoEventoLeave);

            textBoxMultaAtraso.Enter += new EventHandler(Utilitarios.CampoEventoEnter);
            textBoxMultaAtraso.Leave += new EventHandler(Utilitarios.CampoEventoLeave);

            textBoxLocalLog.Enter += new EventHandler(Utilitarios.CampoEventoEnter);
            textBoxLocalLog.Leave += new EventHandler(Utilitarios.CampoEventoLeave);

            textBoxMultaAtraso.KeyPress += new KeyPressEventHandler(Utilitarios.NumericoKeyPress);

            textBoxPercentualJuros.KeyPress += new KeyPressEventHandler(Utilitarios.NumericoKeyPress);

            textBoxLocalLog.Text = ConfigurationManager.AppSettings.Get("LocalLog");


            this.KeyDown += new KeyEventHandler(Utilitarios.FormEventoKeyDown);

            
        }

        private void TelaConfiguracoes_Load(object sender, EventArgs e)
        {
            textBoxBusca.Focus();
        }

       

        public void AtualizarTelaOne()
        {
            empresa = new Empresa();
            dao = new EmpresaDAO();
            
            try
            {
                DataTable linhas = dao.SelectDbProviderOne(ConfigurationManager.ConnectionStrings["BD"].ProviderName, ConfigurationManager.ConnectionStrings["BD"].ConnectionString, empresa);
                
                foreach (DataRow row in linhas.Rows)
                {
                    textBoxPercentualJuros.Text = row[0].ToString();
                    textBoxMultaAtraso.Text = row[1].ToString();


                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Pastelaria do Zé", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonEditarFunc_Click(object sender, EventArgs e)
        {
            empresa = new Empresa(Convert.ToDouble(textBoxPercentualJuros.Text),Convert.ToDouble(textBoxMultaAtraso.Text));
            dao = new EmpresaDAO();

            try
            {
                dao.EditarDbProvider(ConfigurationManager.ConnectionStrings["BD"].ProviderName, ConfigurationManager.ConnectionStrings["BD"].ConnectionString, empresa);
                AtualizarTelaOne();
                MessageBox.Show("Dados alterados com Sucesso!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Pastelaria do Zé", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                //abre o arquivo local como leitura/escrita - PastelariaDoZe.exe.config
                Configuration config =
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                //altera os valores da connectionStrings com nome BD
                config.ConnectionStrings.ConnectionStrings["BD"].ProviderName =
                comboBoxProvider.Text;
                config.ConnectionStrings.ConnectionStrings["BD"].ConnectionString =
                textBoxStringConexao.Text;
                //salva as alterações
                config.Save(ConfigurationSaveMode.Modified, true);
                //recarrega os dados da seção especificada
                ConfigurationManager.RefreshSection("connectionStrings");
                MessageBox.Show("Alterações salvas com sucesso!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        

        private void buttonBuscarLog_Click(object sender, EventArgs e)
        {
            //escolhe o local do LOG e cria o arquivo LOG.TXT
            SaveFileDialog saveFileDialogLog = new SaveFileDialog();
            saveFileDialogLog.Filter = "Arquivo|*.txt";
            saveFileDialogLog.Title = "Selecione o local para salvar";
            saveFileDialogLog.FileName = "LOG.TXT";
            saveFileDialogLog.ShowDialog();
            if (saveFileDialogLog.FileName != "")
            {
                System.IO.FileStream fs =
                (System.IO.FileStream)saveFileDialogLog.OpenFile();
                fs.Close();
            }
            textBoxLocalLog.Text = Convert.ToString(saveFileDialogLog.FileName);
        }

        private void buttonSalvarConfiguracoes_Click(object sender, EventArgs e)
        {
            try
            {
                //abre o arquivo local como leitura/escrita
                Configuration config =
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings.Remove("Cultura");
                var cultura = radioButtonPT_BR.Checked ? "pt-BR" : radioButtonEN_US.Checked ? "en-US" : "es-ES";
                config.AppSettings.Settings.Add("Cultura", cultura);
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");

                //abre o arquivo local como leitura/escrita
                Configuration configlog = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                configlog.AppSettings.Settings.Remove("LocalLog");
                configlog.AppSettings.Settings.Add("LocalLog", textBoxLocalLog.Text);
                configlog.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");

                MessageBox.Show("Alterações feitas! Reinicie a aplicação para salva-lás.");
                Utilitarios.SalvaLog("INFO", "Alterações nas configurações feitas com sucesso!", Program.idLogado);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Utilitarios.SalvaLog("ERRO", ex.Message, Program.idLogado);
            }
        }
    }
}
