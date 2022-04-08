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
    public partial class frmTipos : Form
    {
        public frmTipos()
        {
            InitializeComponent();
        }

        int fila;
        int columna;
        public int idap;

        Clases.Tipos ti = new Clases.Tipos();

        private void CargarGrilla()
        {
            CargarEntidad();
            dgResultado.DataSource = ti.TraerRegistros();
        }

        private void CargarEntidad()
        {
            ti.Nombre = txtTipos.Text;
        }

        private void CargarCamposDesdeGrilla()
        {
            txtTipos.Text = ti.Nombre;
            txtTipos.Focus();
        }

        private void LimpiarCampos()
        {
            ti.IdTipo = 0;
            ti.Nombre = "";
            ti.FechaCambio = "";
            txtTipos.Text = "";
        }


        private void EventosKeyDown(KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 27:
                    this.Close();
                    break;
                case 40:
                    dgResultado.Focus();
                    break;

                case 112:
                    CargarEntidad();
                    ti.GuardaTipos();
                    LimpiarCampos();
                    CargarGrilla();
                    break;
                case 113:
                    CargarEntidad();
                    ti.ModificarTipos();
                    LimpiarCampos();
                    CargarGrilla();
                    break;
                case 114:
                    CargarEntidad();
                    ti.BorrarTipos();
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
                    break;

            }
        }


        private void dgResultado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space )
            {
                int f = fila;
                ti.IdTipo = (int)dgResultado.Rows[f].Cells[2].Value;
                ti.Nombre = (string)dgResultado.Rows[f].Cells[0].Value;
                ti.FechaCambio = (string)dgResultado.Rows[f].Cells[1].Value;
                
                CargarCamposDesdeGrilla();
                
            }
            if (e.KeyChar == (char)Keys.Escape)
            {
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
                    txtTipos.Focus();
                    break;


                case 117:
                    // INSERTAR EN FORMULARIO REGISTROS
                    break;
   
            }
        }

        private void txtTipos_KeyDown(object sender, KeyEventArgs e)
        {
            EventosKeyDown(e);

        }


        private void frmTipos_Load(object sender, EventArgs e)
        {

            this.idap = ((frmArchivos)this.Owner).IDarchivo;
            CargarGrilla();
        }

        private void txtTipos_Enter(object sender, EventArgs e)
        {
            ttCarteles.Show("F1 = Alta, F2 = Modifica, F3 = Baja", txtTipos, 3000);
            txtTipos.BackColor = Color.Black;
            txtTipos.ForeColor = Color.White;
        }

        private void txtTipos_Leave(object sender, EventArgs e)
        {
            txtTipos.BackColor = Color.White;
            txtTipos.ForeColor = Color.Black;
        }

    }
}
