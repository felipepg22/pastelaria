namespace PastelariaDoZe
{
    partial class Funcionarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Funcionarios));
            this.imageListBotoes = new System.Windows.Forms.ImageList(this.components);
            this.dataGridViewDados = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.maskedTextBoxCPF = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxTelefone = new System.Windows.Forms.MaskedTextBox();
            this.checkBoxVerSenha = new System.Windows.Forms.CheckBox();
            this.radioButtonBalcao = new System.Windows.Forms.RadioButton();
            this.radioButtonAdministrador = new System.Windows.Forms.RadioButton();
            this.labelPermissao = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxReSenha = new System.Windows.Forms.TextBox();
            this.textBoxSenha = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxMatricula = new System.Windows.Forms.TextBox();
            this.textBoxNome = new System.Windows.Forms.TextBox();
            this.textBoxIDFunc = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDados)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
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
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label9);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PastelariaDoZe.Properties.Resources.empregado;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.maskedTextBoxCPF);
            this.panel3.Controls.Add(this.maskedTextBoxTelefone);
            this.panel3.Controls.Add(this.checkBoxVerSenha);
            this.panel3.Controls.Add(this.radioButtonBalcao);
            this.panel3.Controls.Add(this.radioButtonAdministrador);
            this.panel3.Controls.Add(this.labelPermissao);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.textBoxReSenha);
            this.panel3.Controls.Add(this.textBoxSenha);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.textBoxMatricula);
            this.panel3.Controls.Add(this.textBoxNome);
            this.panel3.Controls.Add(this.textBoxIDFunc);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // maskedTextBoxCPF
            // 
            resources.ApplyResources(this.maskedTextBoxCPF, "maskedTextBoxCPF");
            this.maskedTextBoxCPF.Name = "maskedTextBoxCPF";
            this.maskedTextBoxCPF.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // maskedTextBoxTelefone
            // 
            this.maskedTextBoxTelefone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.maskedTextBoxTelefone.HideSelection = false;
            resources.ApplyResources(this.maskedTextBoxTelefone, "maskedTextBoxTelefone");
            this.maskedTextBoxTelefone.Name = "maskedTextBoxTelefone";
            this.maskedTextBoxTelefone.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // checkBoxVerSenha
            // 
            resources.ApplyResources(this.checkBoxVerSenha, "checkBoxVerSenha");
            this.checkBoxVerSenha.Name = "checkBoxVerSenha";
            this.checkBoxVerSenha.UseVisualStyleBackColor = true;
            this.checkBoxVerSenha.CheckedChanged += new System.EventHandler(this.checkBoxVerSenha_CheckedChanged);
            // 
            // radioButtonBalcao
            // 
            resources.ApplyResources(this.radioButtonBalcao, "radioButtonBalcao");
            this.radioButtonBalcao.Name = "radioButtonBalcao";
            this.radioButtonBalcao.TabStop = true;
            this.radioButtonBalcao.UseVisualStyleBackColor = true;
            // 
            // radioButtonAdministrador
            // 
            resources.ApplyResources(this.radioButtonAdministrador, "radioButtonAdministrador");
            this.radioButtonAdministrador.Name = "radioButtonAdministrador";
            this.radioButtonAdministrador.TabStop = true;
            this.radioButtonAdministrador.UseVisualStyleBackColor = true;
            // 
            // labelPermissao
            // 
            resources.ApplyResources(this.labelPermissao, "labelPermissao");
            this.labelPermissao.Name = "labelPermissao";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Name = "label7";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // textBoxReSenha
            // 
            resources.ApplyResources(this.textBoxReSenha, "textBoxReSenha");
            this.textBoxReSenha.Name = "textBoxReSenha";
            this.textBoxReSenha.UseSystemPasswordChar = true;
            // 
            // textBoxSenha
            // 
            resources.ApplyResources(this.textBoxSenha, "textBoxSenha");
            this.textBoxSenha.Name = "textBoxSenha";
            this.textBoxSenha.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Name = "label1";
            // 
            // textBoxMatricula
            // 
            resources.ApplyResources(this.textBoxMatricula, "textBoxMatricula");
            this.textBoxMatricula.Name = "textBoxMatricula";
            // 
            // textBoxNome
            // 
            resources.ApplyResources(this.textBoxNome, "textBoxNome");
            this.textBoxNome.Name = "textBoxNome";
            // 
            // textBoxIDFunc
            // 
            resources.ApplyResources(this.textBoxIDFunc, "textBoxIDFunc");
            this.textBoxIDFunc.Name = "textBoxIDFunc";
            // 
            // Funcionarios
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridViewDados);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Funcionarios";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDados)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewDados;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ImageList imageListBotoes;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxCPF;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxTelefone;
        private System.Windows.Forms.CheckBox checkBoxVerSenha;
        private System.Windows.Forms.RadioButton radioButtonBalcao;
        private System.Windows.Forms.RadioButton radioButtonAdministrador;
        private System.Windows.Forms.Label labelPermissao;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxReSenha;
        private System.Windows.Forms.TextBox textBoxSenha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxMatricula;
        private System.Windows.Forms.TextBox textBoxNome;
        private System.Windows.Forms.TextBox textBoxIDFunc;
    }
}