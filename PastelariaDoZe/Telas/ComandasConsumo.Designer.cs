namespace PastelariaDoZe
{
    partial class ComandasConsumo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComandasConsumo));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridViewComanda = new System.Windows.Forms.DataGridView();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.panel4 = new System.Windows.Forms.Panel();
            this.buttonExcluiComanda = new System.Windows.Forms.Button();
            this.imageListAddConsumo = new System.Windows.Forms.ImageList(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxNumeroComanda = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonSalvarComanda = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridViewAddProduto = new System.Windows.Forms.DataGridView();
            this.buttonAddProduto = new System.Windows.Forms.Button();
            this.buttonExcluirProduto = new System.Windows.Forms.Button();
            this.buttonEditarProduto = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.buttonBuscaProduto = new System.Windows.Forms.Button();
            this.textBoxPesquisaProdutoComanda = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.groupBoxItensComanda = new System.Windows.Forms.GroupBox();
            this.dataGridViewItensComanda = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewComanda)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAddProduto)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.groupBoxItensComanda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItensComanda)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PastelariaDoZe.Properties.Resources.AddComanda__1_;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridViewComanda);
            this.panel2.Controls.Add(this.vScrollBar1);
            this.panel2.Controls.Add(this.panel4);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // dataGridViewComanda
            // 
            this.dataGridViewComanda.AllowUserToAddRows = false;
            this.dataGridViewComanda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewComanda.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            resources.ApplyResources(this.dataGridViewComanda, "dataGridViewComanda");
            this.dataGridViewComanda.MultiSelect = false;
            this.dataGridViewComanda.Name = "dataGridViewComanda";
            this.dataGridViewComanda.RowTemplate.Height = 28;
            this.dataGridViewComanda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewComanda.SelectionChanged += new System.EventHandler(this.dataGridViewComanda_SelectionChanged);
            // 
            // vScrollBar1
            // 
            resources.ApplyResources(this.vScrollBar1, "vScrollBar1");
            this.vScrollBar1.Name = "vScrollBar1";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.buttonExcluiComanda);
            this.panel4.Controls.Add(this.button1);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.textBoxNumeroComanda);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.buttonSalvarComanda);
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.Name = "panel4";
            // 
            // buttonExcluiComanda
            // 
            resources.ApplyResources(this.buttonExcluiComanda, "buttonExcluiComanda");
            this.buttonExcluiComanda.ImageList = this.imageListAddConsumo;
            this.buttonExcluiComanda.Name = "buttonExcluiComanda";
            this.buttonExcluiComanda.UseVisualStyleBackColor = true;
            this.buttonExcluiComanda.Click += new System.EventHandler(this.buttonExcluiComanda_Click);
            // 
            // imageListAddConsumo
            // 
            this.imageListAddConsumo.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListAddConsumo.ImageStream")));
            this.imageListAddConsumo.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListAddConsumo.Images.SetKeyName(0, "addConsumo (2).png");
            this.imageListAddConsumo.Images.SetKeyName(1, "editar.png");
            this.imageListAddConsumo.Images.SetKeyName(2, "excluirconsumo.png");
            this.imageListAddConsumo.Images.SetKeyName(3, "salvar.png");
            this.imageListAddConsumo.Images.SetKeyName(4, "pesquisar.png");
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.ImageList = this.imageListAddConsumo;
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // textBoxNumeroComanda
            // 
            resources.ApplyResources(this.textBoxNumeroComanda, "textBoxNumeroComanda");
            this.textBoxNumeroComanda.Name = "textBoxNumeroComanda";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // buttonSalvarComanda
            // 
            resources.ApplyResources(this.buttonSalvarComanda, "buttonSalvarComanda");
            this.buttonSalvarComanda.ImageList = this.imageListAddConsumo;
            this.buttonSalvarComanda.Name = "buttonSalvarComanda";
            this.buttonSalvarComanda.UseVisualStyleBackColor = true;
            this.buttonSalvarComanda.Click += new System.EventHandler(this.buttonSalvarComanda_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridViewAddProduto);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // dataGridViewAddProduto
            // 
            this.dataGridViewAddProduto.AllowUserToAddRows = false;
            this.dataGridViewAddProduto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAddProduto.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            resources.ApplyResources(this.dataGridViewAddProduto, "dataGridViewAddProduto");
            this.dataGridViewAddProduto.MultiSelect = false;
            this.dataGridViewAddProduto.Name = "dataGridViewAddProduto";
            this.dataGridViewAddProduto.RowTemplate.Height = 28;
            this.dataGridViewAddProduto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // buttonAddProduto
            // 
            resources.ApplyResources(this.buttonAddProduto, "buttonAddProduto");
            this.buttonAddProduto.ImageList = this.imageListAddConsumo;
            this.buttonAddProduto.Name = "buttonAddProduto";
            this.buttonAddProduto.UseVisualStyleBackColor = true;
            this.buttonAddProduto.Click += new System.EventHandler(this.buttonAddProduto_Click);
            // 
            // buttonExcluirProduto
            // 
            resources.ApplyResources(this.buttonExcluirProduto, "buttonExcluirProduto");
            this.buttonExcluirProduto.ImageList = this.imageListAddConsumo;
            this.buttonExcluirProduto.Name = "buttonExcluirProduto";
            this.buttonExcluirProduto.UseVisualStyleBackColor = true;
            this.buttonExcluirProduto.Click += new System.EventHandler(this.buttonExcluirProduto_Click);
            // 
            // buttonEditarProduto
            // 
            resources.ApplyResources(this.buttonEditarProduto, "buttonEditarProduto");
            this.buttonEditarProduto.ImageList = this.imageListAddConsumo;
            this.buttonEditarProduto.Name = "buttonEditarProduto";
            this.buttonEditarProduto.UseVisualStyleBackColor = true;
            this.buttonEditarProduto.Click += new System.EventHandler(this.buttonEditarProduto_Click);
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.buttonBuscaProduto);
            this.panel5.Controls.Add(this.textBoxPesquisaProdutoComanda);
            this.panel5.Controls.Add(this.label4);
            resources.ApplyResources(this.panel5, "panel5");
            this.panel5.Name = "panel5";
            // 
            // buttonBuscaProduto
            // 
            resources.ApplyResources(this.buttonBuscaProduto, "buttonBuscaProduto");
            this.buttonBuscaProduto.ImageList = this.imageListAddConsumo;
            this.buttonBuscaProduto.Name = "buttonBuscaProduto";
            this.buttonBuscaProduto.UseVisualStyleBackColor = true;
            this.buttonBuscaProduto.Click += new System.EventHandler(this.buttonBuscaProduto_Click);
            // 
            // textBoxPesquisaProdutoComanda
            // 
            resources.ApplyResources(this.textBoxPesquisaProdutoComanda, "textBoxPesquisaProdutoComanda");
            this.textBoxPesquisaProdutoComanda.Name = "textBoxPesquisaProdutoComanda";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Controls.Add(this.buttonAddProduto);
            this.panel6.Controls.Add(this.buttonExcluirProduto);
            this.panel6.Controls.Add(this.buttonEditarProduto);
            resources.ApplyResources(this.panel6, "panel6");
            this.panel6.Name = "panel6";
            // 
            // groupBoxItensComanda
            // 
            this.groupBoxItensComanda.Controls.Add(this.dataGridViewItensComanda);
            resources.ApplyResources(this.groupBoxItensComanda, "groupBoxItensComanda");
            this.groupBoxItensComanda.Name = "groupBoxItensComanda";
            this.groupBoxItensComanda.TabStop = false;
            // 
            // dataGridViewItensComanda
            // 
            this.dataGridViewItensComanda.AllowUserToAddRows = false;
            this.dataGridViewItensComanda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewItensComanda.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            resources.ApplyResources(this.dataGridViewItensComanda, "dataGridViewItensComanda");
            this.dataGridViewItensComanda.MultiSelect = false;
            this.dataGridViewItensComanda.Name = "dataGridViewItensComanda";
            this.dataGridViewItensComanda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // ComandasConsumo
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxItensComanda);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ComandasConsumo";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewComanda)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAddProduto)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.groupBoxItensComanda.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItensComanda)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonAddProduto;
        private System.Windows.Forms.Button buttonExcluirProduto;
        private System.Windows.Forms.Button buttonEditarProduto;
        private System.Windows.Forms.Button buttonSalvarComanda;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewComanda;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxNumeroComanda;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox textBoxPesquisaProdutoComanda;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridViewAddProduto;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ImageList imageListAddConsumo;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button buttonBuscaProduto;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBoxItensComanda;
        private System.Windows.Forms.DataGridView dataGridViewItensComanda;
        private System.Windows.Forms.Button buttonExcluiComanda;
    }
}