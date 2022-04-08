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

    public partial class frmModos : Form
    {

        private void frmModos_Load(object sender, EventArgs e)
        {
            this.txtModo.Text = ((frmRegistros)this.Owner).TextoModos;

            CargarGrilla();
        }


        public frmModos()
        {
            InitializeComponent();
        }

        int fila;
        int columna;

        Clases.Modos mo = new Clases.Modos();

        private void CargarGrilla()
        {
            CargarEntidad();
            dgResultado.DataSource = mo.TraerRegistros();
            
        }



        private void CargarEntidad()
        {
            mo.Nombre = txtModo.Text;


        }

        private void CargarCamposDesdeGrilla()
        {
            txtModo.Text = mo.Nombre;
            txtModo.Focus();
        }

        private void LimpiarCampos()
        {
            txtModo.Text = "";
            mo.IdMod = 0;
            mo.FechaCambio = "";

        }


        private void EventosKeyDown(KeyEventArgs e)
        {
            switch (e.KeyValue) 
            {
                case 13:
                    CargarEntidad();
                    mo.GuardaModo();
                    ((frmRegistros)this.Owner).CargarComboModos();
                    ((frmRegistros)this.Owner).TextoModos = txtModo.Text;
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
                    mo.GuardaModo();
                    ((frmRegistros)this.Owner).CargarComboModos();
                    ((frmRegistros)this.Owner).TextoModos = txtModo.Text;
                    LimpiarCampos();
                    CargarGrilla();
                    break;
                case 113:
                    CargarEntidad();
                    mo.ModificarModo();
                    ((frmRegistros)this.Owner).CargarComboModos();
                    ((frmRegistros)this.Owner).TextoModos = txtModo.Text;
                    LimpiarCampos();
                    CargarGrilla();
                    break;
                case 114:
                    CargarEntidad();
                    mo.BorrarModo();
                    ((frmRegistros)this.Owner).CargarComboModos();
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
                    //EvModo(txtModo.Text);
                    this.Close();
                    break;

                case 118:

                    break;
            }
        }
 

        private void dgResultado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space )
            {
                int f = fila;
                
                mo.Nombre = Utilidades.StringDeColumna(dgResultado, f, 0);
                mo.FechaCambio = Utilidades.StringDeColumna(dgResultado, f, 1);
                mo.IdMod = Utilidades.IntDeColumna(dgResultado, f, 2);
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
                    txtModo.Focus();
                    break;


                case 117:
                    // INSERTAR EN FORMULARIO REGISTROS
                    break;

            }
        }

        private void txtModo_KeyDown(object sender, KeyEventArgs e)
        {
            EventosKeyDown(e);
        }




 
    }
}
