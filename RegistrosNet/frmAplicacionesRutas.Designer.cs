namespace RegistrosNet
{
    partial class frmAplicacionesRutas
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
            this.txtRepositorio = new System.Windows.Forms.TextBox();
            this.txtRigido = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDesa = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTest = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtProd = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dgResultado = new System.Windows.Forms.DataGridView();
            this.textBox2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgResultado)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Repositorio";
            // 
            // txtRepositorio
            // 
            this.txtRepositorio.Location = new System.Drawing.Point(69, 6);
            this.txtRepositorio.Multiline = true;
            this.txtRepositorio.Name = "txtRepositorio";
            this.txtRepositorio.Size = new System.Drawing.Size(787, 21);
            this.txtRepositorio.TabIndex = 1;
            this.txtRepositorio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRepositorio_KeyDown);
            // 
            // txtRigido
            // 
            this.txtRigido.Location = new System.Drawing.Point(69, 32);
            this.txtRigido.Multiline = true;
            this.txtRigido.Name = "txtRigido";
            this.txtRigido.Size = new System.Drawing.Size(787, 24);
            this.txtRigido.TabIndex = 2;
            this.txtRigido.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRigido_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Rigido";
            // 
            // txtDesa
            // 
            this.txtDesa.Location = new System.Drawing.Point(69, 87);
            this.txtDesa.Multiline = true;
            this.txtDesa.Name = "txtDesa";
            this.txtDesa.Size = new System.Drawing.Size(787, 23);
            this.txtDesa.TabIndex = 4;
            this.txtDesa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDesa_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Desarrollo";
            // 
            // txtTest
            // 
            this.txtTest.Location = new System.Drawing.Point(69, 62);
            this.txtTest.Multiline = true;
            this.txtTest.Name = "txtTest";
            this.txtTest.Size = new System.Drawing.Size(787, 20);
            this.txtTest.TabIndex = 3;
            this.txtTest.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTest_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Test";
            // 
            // txtProd
            // 
            this.txtProd.Location = new System.Drawing.Point(69, 114);
            this.txtProd.Multiline = true;
            this.txtProd.Name = "txtProd";
            this.txtProd.Size = new System.Drawing.Size(787, 23);
            this.txtProd.TabIndex = 5;
            this.txtProd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProd_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Produccion";
            // 
            // dgResultado
            // 
            this.dgResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgResultado.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgResultado.Location = new System.Drawing.Point(6, 143);
            this.dgResultado.Name = "dgResultado";
            this.dgResultado.Size = new System.Drawing.Size(930, 202);
            this.dgResultado.TabIndex = 6;
            this.dgResultado.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgResultado_CellEnter);
            this.dgResultado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgResultado_KeyDown);
            this.dgResultado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgResultado_KeyPress);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(862, 3);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(74, 107);
            this.textBox2.TabIndex = 11;
            this.textBox2.Text = "F1=alta F2=modifica F3=baja F4=limpiar F5=consultar";
            // 
            // frmAplicacionesRutas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 360);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.dgResultado);
            this.Controls.Add(this.txtProd);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTest);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDesa);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtRigido);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRepositorio);
            this.Controls.Add(this.label1);
            this.Name = "frmAplicacionesRutas";
            this.Text = "APLICACIONES RUTAS";
            this.Load += new System.EventHandler(this.frmAplicacionesRutas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgResultado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRepositorio;
        private System.Windows.Forms.TextBox txtRigido;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDesa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTest;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtProd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgResultado;
        private System.Windows.Forms.TextBox textBox2;
    }
}