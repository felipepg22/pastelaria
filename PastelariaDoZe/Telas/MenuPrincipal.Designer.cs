namespace PastelariaDoZe
{
    partial class MenuPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuPrincipal));
            this.menuStripEscolha = new System.Windows.Forms.MenuStrip();
            this.principalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conectarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.desconectarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.funcionáriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.produtosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comandasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acrescentarConsumoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fecharComandaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dashboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fiadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.receberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.idiomaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.portuguêsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.españolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelPrincipal = new System.Windows.Forms.Panel();
            this.contextMenuStripTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.continuarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.enviarParaABandeijaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIconSystemTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.labelNomeLogado = new System.Windows.Forms.Label();
            this.labelGrupoLogado = new System.Windows.Forms.Label();
            this.menuStripEscolha.SuspendLayout();
            this.contextMenuStripTray.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripEscolha
            // 
            this.menuStripEscolha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.menuStripEscolha.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStripEscolha.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStripEscolha.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.principalToolStripMenuItem,
            this.funcionáriosToolStripMenuItem,
            this.clientesToolStripMenuItem,
            this.produtosToolStripMenuItem,
            this.comandasToolStripMenuItem,
            this.fiadosToolStripMenuItem,
            this.configuraçõesToolStripMenuItem,
            this.idiomaToolStripMenuItem});
            this.menuStripEscolha.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            resources.ApplyResources(this.menuStripEscolha, "menuStripEscolha");
            this.menuStripEscolha.Name = "menuStripEscolha";
            // 
            // principalToolStripMenuItem
            // 
            this.principalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.conectarToolStripMenuItem,
            this.desconectarToolStripMenuItem,
            this.sairToolStripMenuItem});
            this.principalToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.principalToolStripMenuItem.Image = global::PastelariaDoZe.Properties.Resources.Icone_pastel;
            this.principalToolStripMenuItem.Name = "principalToolStripMenuItem";
            resources.ApplyResources(this.principalToolStripMenuItem, "principalToolStripMenuItem");
            // 
            // conectarToolStripMenuItem
            // 
            this.conectarToolStripMenuItem.Image = global::PastelariaDoZe.Properties.Resources.login;
            this.conectarToolStripMenuItem.Name = "conectarToolStripMenuItem";
            resources.ApplyResources(this.conectarToolStripMenuItem, "conectarToolStripMenuItem");
            this.conectarToolStripMenuItem.Click += new System.EventHandler(this.conectarToolStripMenuItem_Click);
            // 
            // desconectarToolStripMenuItem
            // 
            this.desconectarToolStripMenuItem.Image = global::PastelariaDoZe.Properties.Resources.logout;
            this.desconectarToolStripMenuItem.Name = "desconectarToolStripMenuItem";
            resources.ApplyResources(this.desconectarToolStripMenuItem, "desconectarToolStripMenuItem");
            this.desconectarToolStripMenuItem.Click += new System.EventHandler(this.desconectarToolStripMenuItem_Click);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Image = global::PastelariaDoZe.Properties.Resources.sair;
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            resources.ApplyResources(this.sairToolStripMenuItem, "sairToolStripMenuItem");
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // funcionáriosToolStripMenuItem
            // 
            this.funcionáriosToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.funcionáriosToolStripMenuItem.Image = global::PastelariaDoZe.Properties.Resources.empregado;
            this.funcionáriosToolStripMenuItem.Name = "funcionáriosToolStripMenuItem";
            resources.ApplyResources(this.funcionáriosToolStripMenuItem, "funcionáriosToolStripMenuItem");
            this.funcionáriosToolStripMenuItem.Click += new System.EventHandler(this.funcionáriosToolStripMenuItem_Click);
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.clientesToolStripMenuItem.Image = global::PastelariaDoZe.Properties.Resources.cliente;
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            resources.ApplyResources(this.clientesToolStripMenuItem, "clientesToolStripMenuItem");
            this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
            // 
            // produtosToolStripMenuItem
            // 
            this.produtosToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.produtosToolStripMenuItem.Image = global::PastelariaDoZe.Properties.Resources.produto;
            this.produtosToolStripMenuItem.Name = "produtosToolStripMenuItem";
            resources.ApplyResources(this.produtosToolStripMenuItem, "produtosToolStripMenuItem");
            this.produtosToolStripMenuItem.Click += new System.EventHandler(this.produtosToolStripMenuItem_Click);
            // 
            // comandasToolStripMenuItem
            // 
            this.comandasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acrescentarConsumoToolStripMenuItem,
            this.fecharComandaToolStripMenuItem,
            this.dashboardToolStripMenuItem});
            this.comandasToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.comandasToolStripMenuItem.Image = global::PastelariaDoZe.Properties.Resources.comanda;
            this.comandasToolStripMenuItem.Name = "comandasToolStripMenuItem";
            resources.ApplyResources(this.comandasToolStripMenuItem, "comandasToolStripMenuItem");
            // 
            // acrescentarConsumoToolStripMenuItem
            // 
            this.acrescentarConsumoToolStripMenuItem.Image = global::PastelariaDoZe.Properties.Resources.AddComanda__1_;
            this.acrescentarConsumoToolStripMenuItem.Name = "acrescentarConsumoToolStripMenuItem";
            resources.ApplyResources(this.acrescentarConsumoToolStripMenuItem, "acrescentarConsumoToolStripMenuItem");
            this.acrescentarConsumoToolStripMenuItem.Click += new System.EventHandler(this.acrescentarConsumoToolStripMenuItem_Click);
            // 
            // fecharComandaToolStripMenuItem
            // 
            this.fecharComandaToolStripMenuItem.Image = global::PastelariaDoZe.Properties.Resources.icons8_carteira_64;
            this.fecharComandaToolStripMenuItem.Name = "fecharComandaToolStripMenuItem";
            resources.ApplyResources(this.fecharComandaToolStripMenuItem, "fecharComandaToolStripMenuItem");
            this.fecharComandaToolStripMenuItem.Click += new System.EventHandler(this.fecharComandaToolStripMenuItem_Click);
            // 
            // dashboardToolStripMenuItem
            // 
            this.dashboardToolStripMenuItem.Image = global::PastelariaDoZe.Properties.Resources.dashboard;
            this.dashboardToolStripMenuItem.Name = "dashboardToolStripMenuItem";
            resources.ApplyResources(this.dashboardToolStripMenuItem, "dashboardToolStripMenuItem");
            this.dashboardToolStripMenuItem.Click += new System.EventHandler(this.dashboardToolStripMenuItem_Click);
            // 
            // fiadosToolStripMenuItem
            // 
            this.fiadosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.receberToolStripMenuItem});
            this.fiadosToolStripMenuItem.Image = global::PastelariaDoZe.Properties.Resources.dinheiro;
            this.fiadosToolStripMenuItem.Name = "fiadosToolStripMenuItem";
            resources.ApplyResources(this.fiadosToolStripMenuItem, "fiadosToolStripMenuItem");
            // 
            // receberToolStripMenuItem
            // 
            this.receberToolStripMenuItem.Image = global::PastelariaDoZe.Properties.Resources.receberFiado;
            this.receberToolStripMenuItem.Name = "receberToolStripMenuItem";
            resources.ApplyResources(this.receberToolStripMenuItem, "receberToolStripMenuItem");
            this.receberToolStripMenuItem.Click += new System.EventHandler(this.receberToolStripMenuItem_Click_1);
            // 
            // configuraçõesToolStripMenuItem
            // 
            this.configuraçõesToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.configuraçõesToolStripMenuItem.Image = global::PastelariaDoZe.Properties.Resources.configuracoes;
            this.configuraçõesToolStripMenuItem.Name = "configuraçõesToolStripMenuItem";
            resources.ApplyResources(this.configuraçõesToolStripMenuItem, "configuraçõesToolStripMenuItem");
            this.configuraçõesToolStripMenuItem.Click += new System.EventHandler(this.configuraçõesToolStripMenuItem_Click);
            // 
            // idiomaToolStripMenuItem
            // 
            this.idiomaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.portuguêsToolStripMenuItem,
            this.englishToolStripMenuItem,
            this.españolToolStripMenuItem});
            this.idiomaToolStripMenuItem.Image = global::PastelariaDoZe.Properties.Resources.globo;
            this.idiomaToolStripMenuItem.Name = "idiomaToolStripMenuItem";
            resources.ApplyResources(this.idiomaToolStripMenuItem, "idiomaToolStripMenuItem");
            // 
            // portuguêsToolStripMenuItem
            // 
            this.portuguêsToolStripMenuItem.Image = global::PastelariaDoZe.Properties.Resources.Flag_of_Brazil;
            this.portuguêsToolStripMenuItem.Name = "portuguêsToolStripMenuItem";
            resources.ApplyResources(this.portuguêsToolStripMenuItem, "portuguêsToolStripMenuItem");
            this.portuguêsToolStripMenuItem.Click += new System.EventHandler(this.portuguêsToolStripMenuItem_Click);
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Image = global::PastelariaDoZe.Properties.Resources.Flag_of_the_United_States;
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            resources.ApplyResources(this.englishToolStripMenuItem, "englishToolStripMenuItem");
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.englishToolStripMenuItem_Click);
            // 
            // españolToolStripMenuItem
            // 
            this.españolToolStripMenuItem.Image = global::PastelariaDoZe.Properties.Resources.Flag_of_Spain;
            this.españolToolStripMenuItem.Name = "españolToolStripMenuItem";
            resources.ApplyResources(this.españolToolStripMenuItem, "españolToolStripMenuItem");
            this.españolToolStripMenuItem.Click += new System.EventHandler(this.españolToolStripMenuItem_Click);
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.BackgroundImage = global::PastelariaDoZe.Properties.Resources.Imagem_Pastelaria1;
            resources.ApplyResources(this.panelPrincipal, "panelPrincipal");
            this.panelPrincipal.Name = "panelPrincipal";
            // 
            // contextMenuStripTray
            // 
            this.contextMenuStripTray.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStripTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.continuarToolStripMenuItem,
            this.sairToolStripMenuItem1,
            this.enviarParaABandeijaToolStripMenuItem});
            this.contextMenuStripTray.Name = "contextMenuStripTray";
            resources.ApplyResources(this.contextMenuStripTray, "contextMenuStripTray");
            // 
            // continuarToolStripMenuItem
            // 
            this.continuarToolStripMenuItem.Name = "continuarToolStripMenuItem";
            resources.ApplyResources(this.continuarToolStripMenuItem, "continuarToolStripMenuItem");
            this.continuarToolStripMenuItem.Click += new System.EventHandler(this.continuarToolStripMenuItem_Click);
            // 
            // sairToolStripMenuItem1
            // 
            this.sairToolStripMenuItem1.Name = "sairToolStripMenuItem1";
            resources.ApplyResources(this.sairToolStripMenuItem1, "sairToolStripMenuItem1");
            this.sairToolStripMenuItem1.Click += new System.EventHandler(this.sairToolStripMenuItem1_Click);
            // 
            // enviarParaABandeijaToolStripMenuItem
            // 
            this.enviarParaABandeijaToolStripMenuItem.Name = "enviarParaABandeijaToolStripMenuItem";
            resources.ApplyResources(this.enviarParaABandeijaToolStripMenuItem, "enviarParaABandeijaToolStripMenuItem");
            this.enviarParaABandeijaToolStripMenuItem.Click += new System.EventHandler(this.enviarParaABandeijaToolStripMenuItem_Click);
            // 
            // notifyIconSystemTray
            // 
            resources.ApplyResources(this.notifyIconSystemTray, "notifyIconSystemTray");
            this.notifyIconSystemTray.ContextMenuStrip = this.contextMenuStripTray;
            this.notifyIconSystemTray.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIconSystemTray_MouseDoubleClick);
            // 
            // labelNomeLogado
            // 
            resources.ApplyResources(this.labelNomeLogado, "labelNomeLogado");
            this.labelNomeLogado.BackColor = System.Drawing.Color.Transparent;
            this.labelNomeLogado.Name = "labelNomeLogado";
            // 
            // labelGrupoLogado
            // 
            resources.ApplyResources(this.labelGrupoLogado, "labelGrupoLogado");
            this.labelGrupoLogado.Name = "labelGrupoLogado";
            // 
            // MenuPrincipal
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelNomeLogado);
            this.Controls.Add(this.labelGrupoLogado);
            this.Controls.Add(this.panelPrincipal);
            this.Controls.Add(this.menuStripEscolha);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStripEscolha;
            this.Name = "MenuPrincipal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MenuPrincipal_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MenuPrincipal_KeyDown);
            this.Resize += new System.EventHandler(this.MenuPrincipal_Resize);
            this.menuStripEscolha.ResumeLayout(false);
            this.menuStripEscolha.PerformLayout();
            this.contextMenuStripTray.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStripEscolha;
        private System.Windows.Forms.ToolStripMenuItem funcionáriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem produtosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comandasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuraçõesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acrescentarConsumoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fecharComandaToolStripMenuItem;
        private System.Windows.Forms.Panel panelPrincipal;
        private System.Windows.Forms.ToolStripMenuItem dashboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem principalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem conectarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem desconectarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fiadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem receberToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem idiomaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem portuguêsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem españolToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTray;
        private System.Windows.Forms.ToolStripMenuItem continuarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem enviarParaABandeijaToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIconSystemTray;
        private System.Windows.Forms.Label labelNomeLogado;
        private System.Windows.Forms.Label labelGrupoLogado;
    }
}