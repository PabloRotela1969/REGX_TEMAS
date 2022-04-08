namespace RegistrosNet
{
    partial class frmDirSeleccionarUnArchivo
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
            this.cmbRutas = new System.Windows.Forms.ComboBox();
            this.txtRutaCompleta = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cmbRutas
            // 
            this.cmbRutas.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbRutas.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbRutas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRutas.FormattingEnabled = true;
            this.cmbRutas.Location = new System.Drawing.Point(15, 29);
            this.cmbRutas.Name = "cmbRutas";
            this.cmbRutas.Size = new System.Drawing.Size(916, 21);
            this.cmbRutas.TabIndex = 0;
            this.cmbRutas.Enter += new System.EventHandler(this.cmbRutas_Enter);
            this.cmbRutas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbRutas_KeyDown);
            // 
            // txtRutaCompleta
            // 
            this.txtRutaCompleta.Location = new System.Drawing.Point(15, 3);
            this.txtRutaCompleta.Name = "txtRutaCompleta";
            this.txtRutaCompleta.Size = new System.Drawing.Size(916, 20);
            this.txtRutaCompleta.TabIndex = 1;
            this.txtRutaCompleta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRutaCompleta_KeyDown);
            // 
            // frmDirSeleccionarUnArchivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 66);
            this.Controls.Add(this.txtRutaCompleta);
            this.Controls.Add(this.cmbRutas);
            this.Name = "frmDirSeleccionarUnArchivo";
            this.Text = "frmDirSeleccionarUnArchivo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbRutas;
        private System.Windows.Forms.TextBox txtRutaCompleta;
    }
}