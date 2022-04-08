namespace RegistrosNet
{
    partial class frmAplicacionesMenues
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
            this.txtMenu = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgResultado = new System.Windows.Forms.DataGridView();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lblclip = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgResultado)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, -3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "item";
            // 
            // txtMenu
            // 
            this.txtMenu.Location = new System.Drawing.Point(4, 11);
            this.txtMenu.MaxLength = 50;
            this.txtMenu.Name = "txtMenu";
            this.txtMenu.Size = new System.Drawing.Size(321, 20);
            this.txtMenu.TabIndex = 0;
            this.txtMenu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMenu_KeyDown);
            this.txtMenu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMenu_KeyPress);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(331, 11);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(613, 48);
            this.txtDescripcion.TabIndex = 1;
            this.txtDescripcion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDescripcion_KeyDown);
            this.txtDescripcion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescripcion_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(398, -3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Descripcion";
            // 
            // dgResultado
            // 
            this.dgResultado.AllowUserToAddRows = false;
            this.dgResultado.AllowUserToDeleteRows = false;
            this.dgResultado.AllowUserToOrderColumns = true;
            this.dgResultado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgResultado.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgResultado.CausesValidation = false;
            this.dgResultado.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dgResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgResultado.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgResultado.GridColor = System.Drawing.SystemColors.Highlight;
            this.dgResultado.Location = new System.Drawing.Point(4, 65);
            this.dgResultado.Name = "dgResultado";
            this.dgResultado.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgResultado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgResultado.Size = new System.Drawing.Size(940, 238);
            this.dgResultado.TabIndex = 2;
            this.dgResultado.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgResultado_CellEnter);
            this.dgResultado.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgResultado_CellLeave);
            this.dgResultado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgResultado_KeyPress);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(6, 34);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(319, 25);
            this.textBox2.TabIndex = 8;
            this.textBox2.Text = "F1=alta F2=modifica F3=baja F4=limpiar F5=consultar";
            // 
            // lblclip
            // 
            this.lblclip.AutoSize = true;
            this.lblclip.Location = new System.Drawing.Point(4, 310);
            this.lblclip.Name = "lblclip";
            this.lblclip.Size = new System.Drawing.Size(0, 13);
            this.lblclip.TabIndex = 9;
            // 
            // frmAplicacionesMenues
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 330);
            this.Controls.Add(this.lblclip);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.dgResultado);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMenu);
            this.Controls.Add(this.label1);
            this.Name = "frmAplicacionesMenues";
            this.Text = "APLICACIONES MENUES";
            this.Load += new System.EventHandler(this.frmAplicacionesMenues_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgResultado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMenu;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgResultado;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lblclip;
    }
}