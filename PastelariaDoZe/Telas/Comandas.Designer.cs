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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Comandas));
            this.textBoxComanda = new System.Windows.Forms.TextBox();
            this.buttonPesquisarComanda = new System.Windows.Forms.Button();
            this.imageListImagemComanda = new System.Windows.Forms.ImageList(this.components);
            this.dateTimePickerDataComanda = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxComandaAberta = new System.Windows.Forms.CheckBox();
            this.checkBoxComandaFechada = new System.Windows.Forms.CheckBox();
            this.checkBoxComandaFiado = new System.Windows.Forms.CheckBox();
            this.panelComandas = new System.Windows.Forms.Panel();
            this.panelComandas.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxComanda
            // 
            resources.ApplyResources(this.textBoxComanda, "textBoxComanda");
            this.textBoxComanda.Name = "textBoxComanda";
            // 
            // buttonPesquisarComanda
            // 
            resources.ApplyResources(this.buttonPesquisarComanda, "buttonPesquisarComanda");
            this.buttonPesquisarComanda.ImageList = this.imageListImagemComanda;
            this.buttonPesquisarComanda.Name = "buttonPesquisarComanda";
            this.buttonPesquisarComanda.UseVisualStyleBackColor = true;
            // 
            // imageListImagemComanda
            // 
            this.imageListImagemComanda.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListImagemComanda.ImageStream")));
            this.imageListImagemComanda.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListImagemComanda.Images.SetKeyName(0, "pesquisar.png");
            // 
            // dateTimePickerDataComanda
            // 
            resources.ApplyResources(this.dateTimePickerDataComanda, "dateTimePickerDataComanda");
            this.dateTimePickerDataComanda.Name = "dateTimePickerDataComanda";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // checkBoxComandaAberta
            // 
            resources.ApplyResources(this.checkBoxComandaAberta, "checkBoxComandaAberta");
            this.checkBoxComandaAberta.Name = "checkBoxComandaAberta";
            this.checkBoxComandaAberta.UseVisualStyleBackColor = true;
            // 
            // checkBoxComandaFechada
            // 
            resources.ApplyResources(this.checkBoxComandaFechada, "checkBoxComandaFechada");
            this.checkBoxComandaFechada.Name = "checkBoxComandaFechada";
            this.checkBoxComandaFechada.UseVisualStyleBackColor = true;
            // 
            // checkBoxComandaFiado
            // 
            resources.ApplyResources(this.checkBoxComandaFiado, "checkBoxComandaFiado");
            this.checkBoxComandaFiado.Name = "checkBoxComandaFiado";
            this.checkBoxComandaFiado.UseVisualStyleBackColor = true;
            // 
            // panelComandas
            // 
            this.panelComandas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panelComandas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelComandas.Controls.Add(this.textBoxComanda);
            this.panelComandas.Controls.Add(this.checkBoxComandaFiado);
            this.panelComandas.Controls.Add(this.buttonPesquisarComanda);
            this.panelComandas.Controls.Add(this.checkBoxComandaFechada);
            this.panelComandas.Controls.Add(this.dateTimePickerDataComanda);
            this.panelComandas.Controls.Add(this.checkBoxComandaAberta);
            this.panelComandas.Controls.Add(this.label1);
            resources.ApplyResources(this.panelComandas, "panelComandas");
            this.panelComandas.Name = "panelComandas";
            // 
            // Comandas
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelComandas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Comandas";
            this.Load += new System.EventHandler(this.Comandas_Load);
            this.panelComandas.ResumeLayout(false);
            this.panelComandas.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxComanda;
        private System.Windows.Forms.Button buttonPesquisarComanda;
        private System.Windows.Forms.DateTimePicker dateTimePickerDataComanda;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxComandaAberta;
        private System.Windows.Forms.CheckBox checkBoxComandaFechada;
        private System.Windows.Forms.CheckBox checkBoxComandaFiado;
        private System.Windows.Forms.ImageList imageListImagemComanda;
        private System.Windows.Forms.Panel panelComandas;
    }
}