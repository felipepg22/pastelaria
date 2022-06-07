namespace PastelariaDoZe.Telas
{
    partial class UserControlBusca
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlBusca));
            this.imageListBotoes = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonExcluir = new System.Windows.Forms.Button();
            this.buttonSalvarDados = new System.Windows.Forms.Button();
            this.textBoxBusca = new System.Windows.Forms.TextBox();
            this.buttonEditar = new System.Windows.Forms.Button();
            this.buttonPesquisar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
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
            this.imageListBotoes.Images.SetKeyName(4, "ExcluirBarra.png");
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.buttonExcluir);
            this.panel1.Controls.Add(this.buttonSalvarDados);
            this.panel1.Controls.Add(this.textBoxBusca);
            this.panel1.Controls.Add(this.buttonEditar);
            this.panel1.Controls.Add(this.buttonPesquisar);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // buttonExcluir
            // 
            resources.ApplyResources(this.buttonExcluir, "buttonExcluir");
            this.buttonExcluir.ImageList = this.imageListBotoes;
            this.buttonExcluir.Name = "buttonExcluir";
            this.buttonExcluir.UseVisualStyleBackColor = true;
            // 
            // buttonSalvarDados
            // 
            resources.ApplyResources(this.buttonSalvarDados, "buttonSalvarDados");
            this.buttonSalvarDados.ImageList = this.imageListBotoes;
            this.buttonSalvarDados.Name = "buttonSalvarDados";
            this.buttonSalvarDados.UseVisualStyleBackColor = true;
            // 
            // textBoxBusca
            // 
            resources.ApplyResources(this.textBoxBusca, "textBoxBusca");
            this.textBoxBusca.Name = "textBoxBusca";
            // 
            // buttonEditar
            // 
            resources.ApplyResources(this.buttonEditar, "buttonEditar");
            this.buttonEditar.ImageList = this.imageListBotoes;
            this.buttonEditar.Name = "buttonEditar";
            this.buttonEditar.UseVisualStyleBackColor = true;
            // 
            // buttonPesquisar
            // 
            resources.ApplyResources(this.buttonPesquisar, "buttonPesquisar");
            this.buttonPesquisar.ImageList = this.imageListBotoes;
            this.buttonPesquisar.Name = "buttonPesquisar";
            this.buttonPesquisar.UseVisualStyleBackColor = true;
            // 
            // UserControlBusca
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "UserControlBusca";
            this.Load += new System.EventHandler(this.UserControlBusca_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageListBotoes;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button buttonSalvarDados;
        public System.Windows.Forms.Button buttonExcluir;
        public System.Windows.Forms.Button buttonEditar;
        public System.Windows.Forms.Button buttonPesquisar;
        public System.Windows.Forms.TextBox textBoxBusca;
    }
}
