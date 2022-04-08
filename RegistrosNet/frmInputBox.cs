using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RegistrosNet
{
    public partial class frmInputBox : Form
    {
        Form origen;

        public frmInputBox()
        {
            InitializeComponent();
        }

        public frmInputBox(Form desde)
        {
            InitializeComponent();
            origen = desde;
        }

        private void txtTexto_KeyDown(object sender, KeyEventArgs e)
        {
            frmClipGraf Principal = (frmClipGraf)origen;

            switch (e.KeyData)
            {
                case Keys.End:
                    
                    Principal.TRANSFERENCIA_TEXTO = this.txtTexto.Text;
                    Principal.DibujarTexto();
                    Principal.Focus();
                    this.Close();
                    this.Dispose();
                    break;
                case Keys.Escape:
                    Principal.Focus();
                    this.Close();
                    this.Dispose();
                    break;
            }
        }


    }
}
