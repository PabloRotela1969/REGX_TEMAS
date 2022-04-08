namespace RegistrosNet
{
    partial class frmNexos
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtNexo = new System.Windows.Forms.TextBox();
            this.dgResultado = new System.Windows.Forms.DataGridView();
            this.textBox2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgResultado)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nexo";
            // 
            // txtNexo
            // 
            this.txtNexo.Location = new System.Drawing.Point(7, 18);
            this.txtNexo.Name = "txtNexo";
            this.txtNexo.Size = new System.Drawing.Size(155, 20);
            this.txtNexo.TabIndex = 1;
            this.txtNexo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNexo_KeyDown);
            // 
            // dgResultado
            // 
            this.dgResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgResultado.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgResultado.Location = new System.Drawing.Point(10, 49);
            this.dgResultado.Name = "dgResultado";
            this.dgResultado.Size = new System.Drawing.Size(346, 150);
            this.dgResultado.TabIndex = 2;
            this.dgResultado.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgResultado_CellEnter);
            this.dgResultado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgResultado_KeyDown);
            this.dgResultado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgResultado_KeyPress);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(168, 2);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(188, 36);
            this.textBox2.TabIndex = 14;
            this.textBox2.Text = "F1=alta F2=modifica F3=baja F4=limpiar F5=consultar";
            // 
            // frmNexos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 210);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.dgResultado);
            this.Controls.Add(this.txtNexo);
            this.Controls.Add(this.label1);
            this.Name = "frmNexos";
            this.Text = "NEXOS";
            this.Load += new System.EventHandler(this.frmNexos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgResultado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNexo;
        private System.Windows.Forms.DataGridView dgResultado;
        private System.Windows.Forms.TextBox textBox2;
    }
}