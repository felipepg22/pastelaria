namespace PastelariaDoZe.Telas
{
    partial class FormLogout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogout));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelMensagem = new System.Windows.Forms.Label();
            this.buttonSim = new System.Windows.Forms.Button();
            this.buttonNao = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PastelariaDoZe.Properties.Resources.icons8_question_mark_96;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // labelMensagem
            // 
            resources.ApplyResources(this.labelMensagem, "labelMensagem");
            this.labelMensagem.Name = "labelMensagem";
            // 
            // buttonSim
            // 
            resources.ApplyResources(this.buttonSim, "buttonSim");
            this.buttonSim.Name = "buttonSim";
            this.buttonSim.UseVisualStyleBackColor = true;
            this.buttonSim.Click += new System.EventHandler(this.buttonSim_Click);
            // 
            // buttonNao
            // 
            resources.ApplyResources(this.buttonNao, "buttonNao");
            this.buttonNao.Name = "buttonNao";
            this.buttonNao.UseVisualStyleBackColor = true;
            this.buttonNao.Click += new System.EventHandler(this.buttonNao_Click);
            // 
            // FormLogout
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonNao);
            this.Controls.Add(this.buttonSim);
            this.Controls.Add(this.labelMensagem);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLogout";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelMensagem;
        private System.Windows.Forms.Button buttonSim;
        private System.Windows.Forms.Button buttonNao;
    }
}