namespace RegistrosNet
{
    partial class frmMails
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
            this.label2 = new System.Windows.Forms.Label();
            this.cmbPersonas = new System.Windows.Forms.ComboBox();
            this.txtMails = new System.Windows.Forms.TextBox();
            this.dgResultado = new System.Windows.Forms.DataGridView();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lblclip = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgResultado)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Persona";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(127, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Direccion de mail";
            // 
            // cmbPersonas
            // 
            this.cmbPersonas.AllowDrop = true;
            this.cmbPersonas.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbPersonas.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPersonas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPersonas.FormattingEnabled = true;
            this.cmbPersonas.Location = new System.Drawing.Point(3, 18);
            this.cmbPersonas.Name = "cmbPersonas";
            this.cmbPersonas.Size = new System.Drawing.Size(121, 21);
            this.cmbPersonas.TabIndex = 2;
            this.cmbPersonas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbPersonas_KeyPress);
            this.cmbPersonas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbPersonas_KeyDown);
            // 
            // txtMails
            // 
            this.txtMails.Location = new System.Drawing.Point(130, 18);
            this.txtMails.Name = "txtMails";
            this.txtMails.Size = new System.Drawing.Size(197, 20);
            this.txtMails.TabIndex = 3;
            this.txtMails.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMails_KeyDown);
            this.txtMails.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMails_KeyPress);
            // 
            // dgResultado
            // 
            this.dgResultado.AllowUserToAddRows = false;
            this.dgResultado.AllowUserToDeleteRows = false;
            this.dgResultado.AllowUserToOrderColumns = true;
            this.dgResultado.AllowUserToResizeRows = false;
            this.dgResultado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgResultado.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgResultado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgResultado.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dgResultado.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dgResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgResultado.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgResultado.GridColor = System.Drawing.SystemColors.Highlight;
            this.dgResultado.Location = new System.Drawing.Point(8, 53);
            this.dgResultado.Name = "dgResultado";
            this.dgResultado.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgResultado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgResultado.ShowEditingIcon = false;
            this.dgResultado.ShowRowErrors = false;
            this.dgResultado.Size = new System.Drawing.Size(438, 200);
            this.dgResultado.TabIndex = 4;
            this.dgResultado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgResultado_KeyDown);
            this.dgResultado.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgResultado_CellEnter);
            this.dgResultado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgResultado_KeyPress);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(333, 2);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(117, 47);
            this.textBox2.TabIndex = 13;
            this.textBox2.Text = "F1=alta F2=modifica F3=baja F4=limpiar F5=consultar";
            // 
            // lblclip
            // 
            this.lblclip.AutoSize = true;
            this.lblclip.Location = new System.Drawing.Point(11, 266);
            this.lblclip.Name = "lblclip";
            this.lblclip.Size = new System.Drawing.Size(0, 13);
            this.lblclip.TabIndex = 14;
            // 
            // frmMails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 283);
            this.Controls.Add(this.lblclip);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.dgResultado);
            this.Controls.Add(this.txtMails);
            this.Controls.Add(this.cmbPersonas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmMails";
            this.Text = "frmMails";
            this.Load += new System.EventHandler(this.frmMails_Load);
            this.Enter += new System.EventHandler(this.frmMails_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.dgResultado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbPersonas;
        private System.Windows.Forms.TextBox txtMails;
        private System.Windows.Forms.DataGridView dgResultado;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lblclip;
    }
}