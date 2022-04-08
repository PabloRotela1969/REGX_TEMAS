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
    public delegate void ActualizarVerbos(string verbo);
    public partial class frmVerbos : Form
    {

        public frmVerbos()
        {
            InitializeComponent();
        }

        private void frmVerbos_Load(object sender, EventArgs e)
        {

           this.txtVerbos.Text = ((frmRegistros)this.Owner).TextoVerbos;
    
            CargarGrilla();

        }


        int fila;
        int columna;

        Clases.Verbos ve = new Clases.Verbos();

        private void CargarGrilla()
        {
            CargarEntidad();
            dgResultado.DataSource = ve.TraerRegistros();
        }



        private void CargarEntidad()
        {
            ve.Nombre = txtVerbos.Text;

        }

        private void CargarCamposDesdeGrilla()
        {
            txtVerbos.Text = ve.Nombre;
            txtVerbos.Focus();
        }

        private void LimpiarCampos()
        {
            ve.idVer = 0;
            ve.FechaCambio = "";
            txtVerbos.Text = "";
        }


        private void EventosKeyDown(KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 13:
                    CargarEntidad();
                    ve.GuardarAccion();
                    ((frmRegistros)this.Owner).CargaComboVerbos();
                    ((frmRegistros)this.Owner).TextoVerbos = txtVerbos.Text;
                    this.Close();
                    break;
                case 27:
                    this.Close();
                    break;
                case 40:
                    dgResultado.Focus();
                    break;

                case 112:
                    CargarEntidad();
                    ve.GuardarAccion();
                    ((frmRegistros)this.Owner).CargaComboVerbos();
                    ((frmRegistros)this.Owner).TextoVerbos = txtVerbos.Text;
                    LimpiarCampos();
                    CargarGrilla();
                    break;
                case 113:
                    CargarEntidad();
                    ve.ModificarAccion();
                    ((frmRegistros)this.Owner).CargaComboVerbos();
                    ((frmRegistros)this.Owner).TextoVerbos = txtVerbos.Text;
                    LimpiarCampos();
                    CargarGrilla();
                    break;
                case 114:
                    CargarEntidad();
                    ve.BorrarAccion();
                    ((frmRegistros)this.Owner).CargaComboVerbos();
                    LimpiarCampos();
                    CargarGrilla();
                    break;
                case 115:
                    LimpiarCampos();
                    break;
                case 116:
                    CargarGrilla();
                    break;
                case 117:
                    // INSERTAR EN FORMULARIO REGISTROS
                   // EvVerbo(txtVerbos.Text);
                    this.Close();
                    break;

            }
        }


        private void dgResultado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space )
            {
                int f = fila;
                ve.idVer = (int)dgResultado.Rows[f].Cells[0].Value;
                ve.Nombre = (string)dgResultado.Rows[f].Cells[1].Value;
                ve.FechaCambio = (string)dgResultado.Rows[f].Cells[2].Value;
                CargarCamposDesdeGrilla();

            }
            if (e.KeyChar == (char)Keys.Escape)
            {
               // EvVerbo(txtVerbos.Text);
                this.Close();
            }

        }


        private void dgResultado_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex;
            columna = e.ColumnIndex;

        }

        private void dgResultado_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyValue)
            {
                case 36:
                    txtVerbos.Focus();
                    break;


            }
        }

        private void txtVerbos_KeyDown(object sender, KeyEventArgs e)
        {
            EventosKeyDown(e);
        }


    }
}

