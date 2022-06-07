namespace PastelariaDoZe
{
    partial class Comandas
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
            this.textBoxComanda = new System.Windows.Forms.TextBox();
            this.buttonPesquisarComanda = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxComandaAberta = new System.Windows.Forms.CheckBox();
            this.checkBoxComandaFechada = new System.Windows.Forms.CheckBox();
            this.checkBoxComandaFiado = new System.Windows.Forms.CheckBox();
            this.menuStripEscolha = new System.Windows.Forms.MenuStrip();
            this.dashboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comandasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fiadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pagamentosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.funcionáriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.produtosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comandasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recebeFiadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripEscolha.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxComanda
            // 
            this.textBoxComanda.Location = new System.Drawing.Point(27, 65);
            this.textBoxComanda.Name = "textBoxComanda";
            this.textBoxComanda.Size = new System.Drawing.Size(192, 26);
            this.textBoxComanda.TabIndex = 0;
            this.textBoxComanda.Text = "Nº Comanda";
            // 
            // buttonPesquisarComanda
            // 
            this.buttonPesquisarComanda.Location = new System.Drawing.Point(237, 65);
            this.buttonPesquisarComanda.Name = "buttonPesquisarComanda";
            this.buttonPesquisarComanda.Size = new System.Drawing.Size(94, 42);
            this.buttonPesquisarComanda.TabIndex = 1;
            this.buttonPesquisarComanda.Text = "Pesquisar";
            this.buttonPesquisarComanda.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(352, 65);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(135, 26);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(348, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Data";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // checkBoxComandaAberta
            // 
            this.checkBoxComandaAberta.AutoSize = true;
            this.checkBoxComandaAberta.Location = new System.Drawing.Point(527, 65);
            this.checkBoxComandaAberta.Name = "checkBoxComandaAberta";
            this.checkBoxComandaAberta.Size = new System.Drawing.Size(91, 24);
            this.checkBoxComandaAberta.TabIndex = 4;
            this.checkBoxComandaAberta.Text = "Abertas";
            this.checkBoxComandaAberta.UseVisualStyleBackColor = true;
            // 
            // checkBoxComandaFechada
            // 
            this.checkBoxComandaFechada.AutoSize = true;
            this.checkBoxComandaFechada.Location = new System.Drawing.Point(527, 95);
            this.checkBoxComandaFechada.Name = "checkBoxComandaFechada";
            this.checkBoxComandaFechada.Size = new System.Drawing.Size(106, 24);
            this.checkBoxComandaFechada.TabIndex = 5;
            this.checkBoxComandaFechada.Text = "Fechadas";
            this.checkBoxComandaFechada.UseVisualStyleBackColor = true;
            // 
            // checkBoxComandaFiado
            // 
            this.checkBoxComandaFiado.AutoSize = true;
            this.checkBoxComandaFiado.Location = new System.Drawing.Point(527, 125);
            this.checkBoxComandaFiado.Name = "checkBoxComandaFiado";
            this.checkBoxComandaFiado.Size = new System.Drawing.Size(112, 24);
            this.checkBoxComandaFiado.TabIndex = 6;
            this.checkBoxComandaFiado.Text = "Com Fiado";
            this.checkBoxComandaFiado.UseVisualStyleBackColor = true;
            // 
            // menuStripEscolha
            // 
            this.menuStripEscolha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.menuStripEscolha.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStripEscolha.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStripEscolha.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dashboardToolStripMenuItem,
            this.funcionáriosToolStripMenuItem,
            this.clientesToolStripMenuItem,
            this.produtosToolStripMenuItem,
            this.comandasToolStripMenuItem,
            this.recebeFiadoToolStripMenuItem,
            this.configuraçõesToolStripMenuItem});
            this.menuStripEscolha.Location = new System.Drawing.Point(0, 0);
            this.menuStripEscolha.Name = "menuStripEscolha";
            this.menuStripEscolha.Size = new System.Drawing.Size(655, 33);
            this.menuStripEscolha.TabIndex = 7;
            this.menuStripEscolha.Text = "menuStrip1";
            // 
            // dashboardToolStripMenuItem
            // 
            this.dashboardToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.comandasToolStripMenuItem1,
            this.fiadosToolStripMenuItem,
            this.pagamentosToolStripMenuItem});
            this.dashboardToolStripMenuItem.Name = "dashboardToolStripMenuItem";
            this.dashboardToolStripMenuItem.Size = new System.Drawing.Size(116, 29);
            this.dashboardToolStripMenuItem.Text = "Dashboard";
            this.dashboardToolStripMenuItem.Click += new System.EventHandler(this.dashboardToolStripMenuItem_Click);
            // 
            // comandasToolStripMenuItem1
            // 
            this.comandasToolStripMenuItem1.Name = "comandasToolStripMenuItem1";
            this.comandasToolStripMenuItem1.Size = new System.Drawing.Size(270, 34);
            this.comandasToolStripMenuItem1.Text = "Comandas";
            // 
            // fiadosToolStripMenuItem
            // 
            this.fiadosToolStripMenuItem.Name = "fiadosToolStripMenuItem";
            this.fiadosToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.fiadosToolStripMenuItem.Text = "Fiados";
            // 
            // pagamentosToolStripMenuItem
            // 
            this.pagamentosToolStripMenuItem.Name = "pagamentosToolStripMenuItem";
            this.pagamentosToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.pagamentosToolStripMenuItem.Text = "Pagamentos";
            // 
            // funcionáriosToolStripMenuItem
            // 
            this.funcionáriosToolStripMenuItem.Name = "funcionáriosToolStripMenuItem";
            this.funcionáriosToolStripMenuItem.Size = new System.Drawing.Size(128, 29);
            this.funcionáriosToolStripMenuItem.Text = "Funcionários";
            this.funcionáriosToolStripMenuItem.Click += new System.EventHandler(this.funcionáriosToolStripMenuItem_Click);
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(89, 29);
            this.clientesToolStripMenuItem.Text = "Clientes";
            // 
            // produtosToolStripMenuItem
            // 
            this.produtosToolStripMenuItem.Name = "produtosToolStripMenuItem";
            this.produtosToolStripMenuItem.Size = new System.Drawing.Size(101, 29);
            this.produtosToolStripMenuItem.Text = "Produtos";
            // 
            // comandasToolStripMenuItem
            // 
            this.comandasToolStripMenuItem.Checked = true;
            this.comandasToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.comandasToolStripMenuItem.Name = "comandasToolStripMenuItem";
            this.comandasToolStripMenuItem.Size = new System.Drawing.Size(113, 29);
            this.comandasToolStripMenuItem.Text = "Comandas";
            // 
            // recebeFiadoToolStripMenuItem
            // 
            this.recebeFiadoToolStripMenuItem.Name = "recebeFiadoToolStripMenuItem";
            this.recebeFiadoToolStripMenuItem.Size = new System.Drawing.Size(133, 29);
            this.recebeFiadoToolStripMenuItem.Text = "Recebe Fiado";
            // 
            // configuraçõesToolStripMenuItem
            // 
            this.configuraçõesToolStripMenuItem.Name = "configuraçõesToolStripMenuItem";
            this.configuraçõesToolStripMenuItem.Size = new System.Drawing.Size(142, 29);
            this.configuraçõesToolStripMenuItem.Text = "Configurações";
            // 
            // Comandas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 450);
            this.Controls.Add(this.menuStripEscolha);
            this.Controls.Add(this.checkBoxComandaFiado);
            this.Controls.Add(this.checkBoxComandaFechada);
            this.Controls.Add(this.checkBoxComandaAberta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.buttonPesquisarComanda);
            this.Controls.Add(this.textBoxComanda);
            this.Name = "Comandas";
            this.Text = "Comandas";
            this.menuStripEscolha.ResumeLayout(false);
            this.menuStripEscolha.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxComanda;
        private System.Windows.Forms.Button buttonPesquisarComanda;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxComandaAberta;
        private System.Windows.Forms.CheckBox checkBoxComandaFechada;
        private System.Windows.Forms.CheckBox checkBoxComandaFiado;
        private System.Windows.Forms.MenuStrip menuStripEscolha;
        private System.Windows.Forms.ToolStripMenuItem dashboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comandasToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem fiadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pagamentosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem funcionáriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem produtosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comandasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recebeFiadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuraçõesToolStripMenuItem;
    }
}