namespace RegistrosNet
{
    partial class frmDirectorio
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
            this.fldCarpetas = new System.Windows.Forms.FolderBrowserDialog();
            this.dgCarpetas = new System.Windows.Forms.DataGridView();
            this.dgArchivos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgCarpetas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgArchivos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgCarpetas
            // 
            this.dgCarpetas.AllowUserToOrderColumns = true;
            this.dgCarpetas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgCarpetas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgCarpetas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCarpetas.Location = new System.Drawing.Point(6, 3);
            this.dgCarpetas.MultiSelect = false;
            this.dgCarpetas.Name = "dgCarpetas";
            this.dgCarpetas.Size = new System.Drawing.Size(403, 329);
            this.dgCarpetas.StandardTab = true;
            this.dgCarpetas.TabIndex = 0;
            this.dgCarpetas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgCarpetas_CellClick);
            this.dgCarpetas.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgCarpetas_CellEnter);
            this.dgCarpetas.Enter += new System.EventHandler(this.dgCarpetas_Enter);
            this.dgCarpetas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgCarpetas_KeyDown);
            // 
            // dgArchivos
            // 
            this.dgArchivos.AllowUserToAddRows = false;
            this.dgArchivos.AllowUserToDeleteRows = false;
            this.dgArchivos.AllowUserToOrderColumns = true;
            this.dgArchivos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgArchivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgArchivos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgArchivos.GridColor = System.Drawing.SystemColors.Highlight;
            this.dgArchivos.Location = new System.Drawing.Point(417, 3);
            this.dgArchivos.Name = "dgArchivos";
            this.dgArchivos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgArchivos.ShowEditingIcon = false;
            this.dgArchivos.ShowRowErrors = false;
            this.dgArchivos.Size = new System.Drawing.Size(605, 329);
            this.dgArchivos.TabIndex = 1;
            this.dgArchivos.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgArchivos_CellEnter);
            this.dgArchivos.Enter += new System.EventHandler(this.dgArchivos_Enter);
            this.dgArchivos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgArchivos_KeyDown);
            // 
            // frmDirectorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 334);
            this.Controls.Add(this.dgArchivos);
            this.Controls.Add(this.dgCarpetas);
            this.Name = "frmDirectorio";
            this.Text = "frmDirectorio";
            this.Load += new System.EventHandler(this.frmDirectorio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgCarpetas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgArchivos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog fldCarpetas;
        private System.Windows.Forms.DataGridView dgCarpetas;
        private System.Windows.Forms.DataGridView dgArchivos;
    }
}