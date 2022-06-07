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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PastelariaDoZe
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            //utilizado para criptografia
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ConnectionStringsSection section = config.GetSection("connectionStrings") as ConnectionStringsSection;
            if (!section.SectionInformation.IsProtected)
            {
                // Encrypt the section.
                section.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
            }
            else
            {
                // Remove encryption.
                section.SectionInformation.UnprotectSection();
            }
            config.Save();

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(ConfigurationManager.AppSettings.Get("Cultura"));
            InitializeComponent();

            funcionáriosToolStripMenuItem.Enabled = false;
            clientesToolStripMenuItem.Enabled = false;
            produtosToolStripMenuItem.Enabled = false;
            comandasToolStripMenuItem.Enabled = false;
            configuraçõesToolStripMenuItem.Enabled = false;
            fiadosToolStripMenuItem.Enabled = false;
            desconectarToolStripMenuItem.Enabled = false;
        }
        /// <summary>
        /// Abre um form no panel principal do menu
        /// </summary>
        /// <typeparam name="Forms">Formulário que deseja abrir no panel.</typeparam>
        private void AbrirFormNoPanel<Forms>() where Forms : Form, new()
        {
            Form formulario;
            formulario = panelPrincipal.Controls.OfType<Forms>().FirstOrDefault();

            if (formulario == null)
            {
                formulario = new Forms();
                formulario.TopLevel = false;
                panelPrincipal.Controls.Add(formulario);
                panelPrincipal.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
                return;
            }
           
                if (formulario.WindowState == FormWindowState.Minimized)
                    formulario.WindowState = FormWindowState.Normal;
                formulario.BringToFront();
            
        } 

       

        private void funcionáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            AbrirFormNoPanel<Funcionarios>();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormNoPanel<CadastroClientes>();
        }

        private void comandasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirFormNoPanel<Comandas>();
        }

        private void configuraçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormNoPanel<TelaConfiguracoes>();
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormNoPanel<CadastroProdutos>();
        }

        private void comandasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void acrescentarConsumoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormNoPanel<ComandasConsumo>();
        }

        private void fecharComandaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormNoPanel<FecharComanda>();
        } 

       

        private void receberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormNoPanel<RecebeFiado>();
        }                   

        private void conectarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new TelaLogin();            
            var dao = new FuncionarioDAO();
            
            Program.logado = false;
            if (f.ShowDialog() == DialogResult.OK)
            {
                try
                {
                     
                    var funcionario = new Funcionario(Utilitarios.CriptografaSenha(f.textBoxSenha.Text),f.textBoxLogin.Text);

                    DataTable linhas = dao.ValidaLogin(ConfigurationManager.ConnectionStrings["BD"].ProviderName, ConfigurationManager.ConnectionStrings["BD"].ConnectionString, funcionario);
                                         
                        
                        foreach (DataRow row in linhas.Rows)
                        {
                            Program.logado = true;
                            Program.idLogado = Convert.ToInt32(row[0].ToString());
                            Program.nomeLogado = row[1].ToString();
                            Program.grupoLogado = row[5].ToString().Equals("Admin")? 1:2;
                        
                            var m = new FormMensagem(Program.nomeLogado);
                            m.ShowDialog();
                            AjustaTela();
                            labelNomeLogado.Text = Program.nomeLogado;
                            labelGrupoLogado.Text = Program.grupoLogado == 1 ? "Admin" : "Balcão";
                            Utilitarios.SalvaLog("INFO", "Login realizado com sucesso!", Program.idLogado);
                        return;
                        }

                    MessageBox.Show("Login/Senha estão errados!", "Pastelaria do Zé", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Utilitarios.SalvaLog("ERRO", "Login/Senha estão errados", Program.idLogado);

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Pastelaria do Zé", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    var config = new TelaConfiguracoes();
                    config.panelBanco.Enabled = true;
                    config.panelConfigPadrao.Enabled = false;
                    config.Show();
                }
                




            }
        }

        private void desconectarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mensagemPT_BR = new FormLogout("Deseja realmente se desconectar?","Sim","Não");
            var mensagemEN_US = new FormLogout("Do you wish to logout?", "Yes", "No");
            var mensagemES_ES = new FormLogout("Quieres realmente desconectar?", "Sí", "No");
            bool resultadoMensagem =false;
            if (Thread.CurrentThread.CurrentUICulture.Name == "en-US")
            {
                 mensagemEN_US.ShowDialog();
                 resultadoMensagem = mensagemEN_US.DialogResult == DialogResult.Yes;
            }
            if (Thread.CurrentThread.CurrentUICulture.Name == "pt-BR")
            {
                 mensagemPT_BR.ShowDialog();
                 resultadoMensagem = mensagemPT_BR.DialogResult == DialogResult.Yes;
            }
            if (Thread.CurrentThread.CurrentUICulture.Name == "es-ES")
            {
                mensagemES_ES.ShowDialog();
                resultadoMensagem = mensagemES_ES.DialogResult == DialogResult.Yes;
            }

           if(resultadoMensagem)
            {
                Utilitarios.SalvaLog("INFO", "Logout feito com sucesso!", Program.idLogado);
                Program.logado = false;
                AjustaTela();
                labelNomeLogado.Text = "";
                labelGrupoLogado.Text = "";

                panelPrincipal.Controls.Clear();
                
            }
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilitarios.SalvaLog("INFO", "Aplicação fechada", Program.idLogado);
            Close();
        }

        private void receberToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AbrirFormNoPanel<RecebeFiado>();
        }

        private void portuguêsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
            this.Controls.Clear();
            this.InitializeComponent();

            if (conectarToolStripMenuItem.Enabled) 
            {
                funcionáriosToolStripMenuItem.Enabled = false;
                clientesToolStripMenuItem.Enabled = false;
                produtosToolStripMenuItem.Enabled = false;
                comandasToolStripMenuItem.Enabled = false;
                configuraçõesToolStripMenuItem.Enabled = false;
                desconectarToolStripMenuItem.Enabled = false;
                fiadosToolStripMenuItem.Enabled = false;
                conectarToolStripMenuItem.Enabled = true;

            }
            
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            this.Controls.Clear();
            this.InitializeComponent();

            if (conectarToolStripMenuItem.Enabled)
            {
                funcionáriosToolStripMenuItem.Enabled = false;
                clientesToolStripMenuItem.Enabled = false;
                produtosToolStripMenuItem.Enabled = false;
                comandasToolStripMenuItem.Enabled = false;
                configuraçõesToolStripMenuItem.Enabled = false;
                desconectarToolStripMenuItem.Enabled = false;
                fiadosToolStripMenuItem.Enabled = false;
                conectarToolStripMenuItem.Enabled = true;

            }


        }

        private void españolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-ES");
            this.Controls.Clear();
            this.InitializeComponent();
            if (conectarToolStripMenuItem.Enabled)
            {
                funcionáriosToolStripMenuItem.Enabled = false;
                clientesToolStripMenuItem.Enabled = false;
                produtosToolStripMenuItem.Enabled = false;
                comandasToolStripMenuItem.Enabled = false;
                configuraçõesToolStripMenuItem.Enabled = false;
                desconectarToolStripMenuItem.Enabled = false;
                fiadosToolStripMenuItem.Enabled = false;
                conectarToolStripMenuItem.Enabled = true;

            }


        }

        private void MenuPrincipal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void MenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {

            var mensagem = new FormMensagemTray();
            mensagem.ShowDialog();

            if (mensagem.DialogResult == DialogResult.Abort)
            {
                e.Cancel=true;
                return;
            }
            if (mensagem.DialogResult == DialogResult.OK)
            {
                e.Cancel = true;
                this.Hide();
                notifyIconSystemTray.Visible = true;                
                notifyIconSystemTray.ShowBalloonTip(1000);
            }     
                 





        }

        private void continuarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void sairToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void enviarParaABandeijaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Pastelaria do Zé");
        }

        /// <summary>
        /// Habilita ou desabilita funções da aplicação de acordo com as permissões do usuário logado
        /// </summary>
        private void AjustaTela()
        {

            if (Program.logado)
            {
                funcionáriosToolStripMenuItem.Enabled = Program.grupoLogado == 1 ? true : false; ;
                clientesToolStripMenuItem.Enabled = Program.grupoLogado == 1 ? true : false;
                produtosToolStripMenuItem.Enabled = Program.grupoLogado == 1 ? true : false;
                comandasToolStripMenuItem.Enabled = true;
                configuraçõesToolStripMenuItem.Enabled = Program.grupoLogado == 1 ? true : false;
                desconectarToolStripMenuItem.Enabled = true;
                fiadosToolStripMenuItem.Enabled = Program.grupoLogado == 1 ? true : false;
                conectarToolStripMenuItem.Enabled = false;
            }

            else
            {
                funcionáriosToolStripMenuItem.Enabled = false;
                clientesToolStripMenuItem.Enabled = false;
                produtosToolStripMenuItem.Enabled = false;
                comandasToolStripMenuItem.Enabled = false;
                configuraçõesToolStripMenuItem.Enabled = false;
                desconectarToolStripMenuItem.Enabled = false;
                fiadosToolStripMenuItem.Enabled = false;
                conectarToolStripMenuItem.Enabled = true;
            }
            
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormNoPanel<Comandas>();
        }

        private void notifyIconSystemTray_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Maximized;
        }

        private void MenuPrincipal_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIconSystemTray.Visible = true;
                notifyIconSystemTray.ShowBalloonTip(1000);
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIconSystemTray.Visible = false;
            }
        }
    }
}
