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
    public partial class frmTextoRecordatorio : Form
    {
        Form  origen = null;
        public frmTextoRecordatorio()
        {
            InitializeComponent();
            this.Text = "LISTADO";
        }

        public void frmTextoRecordatorio_Load(object sender, EventArgs e)
        {
            Utilidades.CargarRTF(rchtBoxTextos, @"pendientes.rtf");
            this.rchtBoxTextos.Focus();
            origen = ((frmRegistros)this.Owner);
        }


        private void rchtBoxTextos_KeyUp(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.Escape :
                    ((frmRegistros)origen).LeerPendientes();
                    this.Close();
                break;
                case Keys.F1:
                    
                    Utilidades.SalvarRTF(rchtBoxTextos, @"pendientes.rtf");
                    this.Text = "GUARDADO";
                break;
                default :
                this.Text = "SIN GUARDAR";
                break;

            }
        }


    }
}
