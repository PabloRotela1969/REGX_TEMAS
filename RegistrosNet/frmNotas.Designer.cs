namespace RegistrosNet
{
    partial class frmNotas
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
            this.rtbNota = new System.Windows.Forms.RichTextBox();
            this.lblDesbordamiento = new System.Windows.Forms.Label();
            this.cmbConstruyeTexto = new System.Windows.Forms.ComboBox();
            this.rtbTitulo = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtbNota
            // 
            this.rtbNota.AutoWordSelection = true;
            this.rtbNota.Location = new System.Drawing.Point(2, 52);
            this.rtbNota.Name = "rtbNota";
            this.rtbNota.Size = new System.Drawing.Size(1255, 384);
            this.rtbNota.TabIndex = 0;
            this.rtbNota.Text = "";
            this.rtbNota.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richTextBox1_KeyDown);
            // 
            // lblDesbordamiento
            // 
            this.lblDesbordamiento.AutoSize = true;
            this.lblDesbordamiento.Location = new System.Drawing.Point(1199, 6);
            this.lblDesbordamiento.Name = "lblDesbordamiento";
            this.lblDesbordamiento.Size = new System.Drawing.Size(0, 13);
            this.lblDesbordamiento.TabIndex = 5;
            // 
            // cmbConstruyeTexto
            // 
            this.cmbConstruyeTexto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbConstruyeTexto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbConstruyeTexto.DropDownHeight = 200;
            this.cmbConstruyeTexto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbConstruyeTexto.FormattingEnabled = true;
            this.cmbConstruyeTexto.IntegralHeight = false;
            this.cmbConstruyeTexto.Location = new System.Drawing.Point(12, 12);
            this.cmbConstruyeTexto.Name = "cmbConstruyeTexto";
            this.cmbConstruyeTexto.Size = new System.Drawing.Size(409, 21);
            this.cmbConstruyeTexto.TabIndex = 6;
            this.cmbConstruyeTexto.SelectionChangeCommitted += new System.EventHandler(this.cmbConstruyeTexto_SelectionChangeCommitted);
            this.cmbConstruyeTexto.SelectedValueChanged += new System.EventHandler(this.cmbConstruyeTexto_SelectedValueChanged);
            this.cmbConstruyeTexto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbConstruyeTexto_KeyDown);
            // 
            // rtbTitulo
            // 
            this.rtbTitulo.Location = new System.Drawing.Point(2, 0);
            this.rtbTitulo.Name = "rtbTitulo";
            this.rtbTitulo.Size = new System.Drawing.Size(1142, 46);
            this.rtbTitulo.TabIndex = 7;
            this.rtbTitulo.Text = "";
            this.rtbTitulo.TextChanged += new System.EventHandler(this.rtbTitulo_TextChanged);
            this.rtbTitulo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTituloNota_KeyDown);
            // 
            // frmNotas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 440);
            this.Controls.Add(this.rtbTitulo);
            this.Controls.Add(this.cmbConstruyeTexto);
            this.Controls.Add(this.lblDesbordamiento);
            this.Controls.Add(this.rtbNota);
            this.Name = "frmNotas";
            this.Text = "Mensajes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbNota;
        private System.Windows.Forms.Label lblDesbordamiento;
        private System.Windows.Forms.ComboBox cmbConstruyeTexto;
        private System.Windows.Forms.RichTextBox rtbTitulo;
    }
}