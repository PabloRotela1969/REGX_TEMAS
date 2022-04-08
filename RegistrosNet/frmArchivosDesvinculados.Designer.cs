namespace RegistrosNet
{
    partial class frmArchivosDesvinculados
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
            this.lstResultados = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstResultados
            // 
            this.lstResultados.FormattingEnabled = true;
            this.lstResultados.Location = new System.Drawing.Point(1, -1);
            this.lstResultados.Name = "lstResultados";
            this.lstResultados.Size = new System.Drawing.Size(678, 407);
            this.lstResultados.Sorted = true;
            this.lstResultados.TabIndex = 0;
            this.lstResultados.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.lstResultados_PreviewKeyDown);
            // 
            // frmArchivosDesvinculados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 408);
            this.Controls.Add(this.lstResultados);
            this.Name = "frmArchivosDesvinculados";
            this.Text = "frmArchivosDesvinculados";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstResultados;
    }
}