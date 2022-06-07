namespace PastelariaDoZe.Telas
{
    partial class FormMensagemTray
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMensagemTray));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelMensagem = new System.Windows.Forms.Label();
            this.buttonContinuar = new System.Windows.Forms.Button();
            this.buttonSair = new System.Windows.Forms.Button();
            this.buttonBandeija = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PastelariaDoZe.Properties.Resources.pastel_mascote;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // labelMensagem
            // 
            resources.ApplyResources(this.labelMensagem, "labelMensagem");
            this.labelMensagem.Name = "labelMensagem";
            // 
            // buttonContinuar
            // 
            resources.ApplyResources(this.buttonContinuar, "buttonContinuar");
            this.buttonContinuar.Name = "buttonContinuar";
            this.buttonContinuar.UseVisualStyleBackColor = true;
            this.buttonContinuar.Click += new System.EventHandler(this.buttonContinuar_Click);
            // 
            // buttonSair
            // 
            resources.ApplyResources(this.buttonSair, "buttonSair");
            this.buttonSair.Name = "buttonSair";
            this.buttonSair.UseVisualStyleBackColor = true;
            this.buttonSair.Click += new System.EventHandler(this.buttonSair_Click);
            // 
            // buttonBandeija
            // 
            resources.ApplyResources(this.buttonBandeija, "buttonBandeija");
            this.buttonBandeija.Name = "buttonBandeija";
            this.buttonBandeija.UseVisualStyleBackColor = true;
            this.buttonBandeija.Click += new System.EventHandler(this.buttonBandeija_Click);
            // 
            // FormMensagemTray
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonBandeija);
            this.Controls.Add(this.buttonSair);
            this.Controls.Add(this.buttonContinuar);
            this.Controls.Add(this.labelMensagem);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FormMensagemTray";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelMensagem;
        private System.Windows.Forms.Button buttonContinuar;
        private System.Windows.Forms.Button buttonSair;
        private System.Windows.Forms.Button buttonBandeija;
    }
}