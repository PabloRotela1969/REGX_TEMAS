namespace RegistrosNet
{
    partial class frmObjetos
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtObj = new System.Windows.Forms.TextBox();
            this.dgResultado = new System.Windows.Forms.DataGridView();
            this.ttCarteles = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgResultado)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Objeto";
            // 
            // txtObj
            // 
            this.txtObj.Location = new System.Drawing.Point(11, 21);
            this.txtObj.Multiline = true;
            this.txtObj.Name = "txtObj";
            this.txtObj.Size = new System.Drawing.Size(674, 65);
            this.txtObj.TabIndex = 1;
            this.txtObj.Enter += new System.EventHandler(this.txtObj_Enter);
            this.txtObj.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtObj_KeyDown);
            this.txtObj.Leave += new System.EventHandler(this.txtObj_Leave);
            // 
            // dgResultado
            // 
            this.dgResultado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgResultado.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgResultado.Location = new System.Drawing.Point(12, 92);
            this.dgResultado.Name = "dgResultado";
            this.dgResultado.Size = new System.Drawing.Size(673, 150);
            this.dgResultado.TabIndex = 2;
            this.dgResultado.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgResultado_CellEnter);
            this.dgResultado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgResultado_KeyDown);
            this.dgResultado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgResultado_KeyPress);
            // 
            // frmObjetos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 254);
            this.Controls.Add(this.dgResultado);
            this.Controls.Add(this.txtObj);
            this.Controls.Add(this.label1);
            this.Name = "frmObjetos";
            this.Text = "OBJETOS";
            this.Load += new System.EventHandler(this.frmObjetos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgResultado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtObj;
        private System.Windows.Forms.DataGridView dgResultado;
        private System.Windows.Forms.ToolTip ttCarteles;
    }
}