namespace RegistrosNet
{
    partial class frmTextoRecordatorio
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
            this.rchtBoxTextos = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rchtBoxTextos
            // 
            this.rchtBoxTextos.Location = new System.Drawing.Point(12, 12);
            this.rchtBoxTextos.Name = "rchtBoxTextos";
            this.rchtBoxTextos.Size = new System.Drawing.Size(1421, 594);
            this.rchtBoxTextos.TabIndex = 0;
            this.rchtBoxTextos.Text = "";
            this.rchtBoxTextos.KeyUp += new System.Windows.Forms.KeyEventHandler(this.rchtBoxTextos_KeyUp);
            // 
            // frmTextoRecordatorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1445, 618);
            this.Controls.Add(this.rchtBoxTextos);
            this.Name = "frmTextoRecordatorio";
            this.Text = "frmTextoRecordatorio";
            this.Load += new System.EventHandler(this.frmTextoRecordatorio_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rchtBoxTextos;
    }
}