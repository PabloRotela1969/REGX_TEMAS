namespace RegistrosNet
{
    partial class frmErroresBackup
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
            this.txtErrores = new System.Windows.Forms.TextBox();
            this.lstErrores = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // txtErrores
            // 
            this.txtErrores.Location = new System.Drawing.Point(13, 13);
            this.txtErrores.Multiline = true;
            this.txtErrores.Name = "txtErrores";
            this.txtErrores.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtErrores.Size = new System.Drawing.Size(908, 171);
            this.txtErrores.TabIndex = 0;
            // 
            // lstErrores
            // 
            this.lstErrores.FormattingEnabled = true;
            this.lstErrores.Location = new System.Drawing.Point(13, 191);
            this.lstErrores.Name = "lstErrores";
            this.lstErrores.Size = new System.Drawing.Size(908, 147);
            this.lstErrores.Sorted = true;
            this.lstErrores.TabIndex = 1;
            // 
            // frmErroresBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 351);
            this.Controls.Add(this.lstErrores);
            this.Controls.Add(this.txtErrores);
            this.Name = "frmErroresBackup";
            this.Text = "frmErroresBackup";
            this.Load += new System.EventHandler(this.frmErroresBackup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtErrores;
        private System.Windows.Forms.ListBox lstErrores;
    }
}