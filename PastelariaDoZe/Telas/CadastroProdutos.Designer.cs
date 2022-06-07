namespace PastelariaDoZe
{
    partial class CadastroProdutos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CadastroProdutos));
            this.imageListBotoes = new System.Windows.Forms.ImageList(this.components);
            this.panelDados = new System.Windows.Forms.Panel();
            this.textBoxDescricao = new System.Windows.Forms.TextBox();
            this.labelMoeda = new System.Windows.Forms.Label();
            this.textBoxValor = new System.Windows.Forms.TextBox();
            this.buttonAddFoto = new System.Windows.Forms.Button();
            this.imageListImagem = new System.Windows.Forms.ImageList(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBoxProduto = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxIDProduto = new System.Windows.Forms.TextBox();
            this.textBoxNomeProduto = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridViewDados = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelDados.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProduto)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDados)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // imageListBotoes
            // 
            this.imageListBotoes.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListBotoes.ImageStream")));
            this.imageListBotoes.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListBotoes.Images.SetKeyName(0, "editar.png");
            this.imageListBotoes.Images.SetKeyName(1, "pesquisar.png");
            this.imageListBotoes.Images.SetKeyName(2, "salvar.png");
            this.imageListBotoes.Images.SetKeyName(3, "addImagem.png");
            // 
            // panelDados
            // 
            this.panelDados.BackColor = System.Drawing.SystemColors.Control;
            this.panelDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados.Controls.Add(this.textBoxDescricao);
            this.panelDados.Controls.Add(this.labelMoeda);
            this.panelDados.Controls.Add(this.textBoxValor);
            this.panelDados.Controls.Add(this.buttonAddFoto);
            this.panelDados.Controls.Add(this.panel4);
            this.panelDados.Controls.Add(this.label4);
            this.panelDados.Controls.Add(this.label3);
            this.panelDados.Controls.Add(this.label1);
            this.panelDados.Controls.Add(this.label2);
            this.panelDados.Controls.Add(this.textBoxIDProduto);
            this.panelDados.Controls.Add(this.textBoxNomeProduto);
            resources.ApplyResources(this.panelDados, "panelDados");
            this.panelDados.Name = "panelDados";
            // 
            // textBoxDescricao
            // 
            resources.ApplyResources(this.textBoxDescricao, "textBoxDescricao");
            this.textBoxDescricao.Name = "textBoxDescricao";
            // 
            // labelMoeda
            // 
            resources.ApplyResources(this.labelMoeda, "labelMoeda");
            this.labelMoeda.Name = "labelMoeda";
            // 
            // textBoxValor
            // 
            resources.ApplyResources(this.textBoxValor, "textBoxValor");
            this.textBoxValor.Name = "textBoxValor";
            // 
            // buttonAddFoto
            // 
            resources.ApplyResources(this.buttonAddFoto, "buttonAddFoto");
            this.buttonAddFoto.ImageList = this.imageListImagem;
            this.buttonAddFoto.Name = "buttonAddFoto";
            this.buttonAddFoto.UseVisualStyleBackColor = true;
            this.buttonAddFoto.Click += new System.EventHandler(this.buttonAddFoto_Click);
            // 
            // imageListImagem
            // 
            this.imageListImagem.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListImagem.ImageStream")));
            this.imageListImagem.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListImagem.Images.SetKeyName(0, "addImagem.png");
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.pictureBoxProduto);
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.Name = "panel4";
            // 
            // pictureBoxProduto
            // 
            this.pictureBoxProduto.Image = global::PastelariaDoZe.Properties.Resources.Imagem_Pastelaria1;
            resources.ApplyResources(this.pictureBoxProduto, "pictureBoxProduto");
            this.pictureBoxProduto.Name = "pictureBoxProduto";
            this.pictureBoxProduto.TabStop = false;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Name = "label2";
            // 
            // textBoxIDProduto
            // 
            resources.ApplyResources(this.textBoxIDProduto, "textBoxIDProduto");
            this.textBoxIDProduto.Name = "textBoxIDProduto";
            // 
            // textBoxNomeProduto
            // 
            resources.ApplyResources(this.textBoxNomeProduto, "textBoxNomeProduto");
            this.textBoxNomeProduto.Name = "textBoxNomeProduto";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridViewDados);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // dataGridViewDados
            // 
            this.dataGridViewDados.AllowUserToAddRows = false;
            this.dataGridViewDados.AllowUserToDeleteRows = false;
            this.dataGridViewDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDados.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            resources.ApplyResources(this.dataGridViewDados, "dataGridViewDados");
            this.dataGridViewDados.MultiSelect = false;
            this.dataGridViewDados.Name = "dataGridViewDados";
            this.dataGridViewDados.ReadOnly = true;
            this.dataGridViewDados.RowTemplate.Height = 28;
            this.dataGridViewDados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDados.TabStop = false;
            this.dataGridViewDados.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewDados_MouseDoubleClick);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.maskedTextBox1);
            this.panel5.Controls.Add(this.pictureBox1);
            this.panel5.Controls.Add(this.label5);
            resources.ApplyResources(this.panel5, "panel5");
            this.panel5.Name = "panel5";
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.maskedTextBox1.HidePromptOnLeave = true;
            resources.ApplyResources(this.maskedTextBox1, "maskedTextBox1");
            this.maskedTextBox1.Name = "maskedTextBox1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PastelariaDoZe.Properties.Resources.produto;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // CadastroProdutos
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panelDados);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "CadastroProdutos";
            this.panelDados.ResumeLayout(false);
            this.panelDados.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProduto)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDados)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelDados;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxIDProduto;
        private System.Windows.Forms.TextBox textBoxNomeProduto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonAddFoto;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBoxProduto;
        private System.Windows.Forms.DataGridView dataGridViewDados;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ImageList imageListBotoes;
        private System.Windows.Forms.ImageList imageListImagem;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.TextBox textBoxValor;
        private System.Windows.Forms.Label labelMoeda;
        private System.Windows.Forms.TextBox textBoxDescricao;
    }
}