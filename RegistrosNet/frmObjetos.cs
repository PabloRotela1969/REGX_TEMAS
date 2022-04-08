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
    public delegate void ActualizarObjeto(string objeto);
    public partial class frmObjetos : Form
    {

        private void frmObjetos_Load(object sender, EventArgs e)
        {
            this.txtObj.Text = ((frmRegistros)this.Owner).TextoObjetos;

            CargarGrilla();
        }

        public event ActualizarObjeto EvObjeto;
        public frmObjetos()
        {
            InitializeComponent();
        }

        int fila;
        int columna;

        Clases.Objetos ob = new Clases.Objetos();

        private void CargarGrilla()
        {
            CargarEntidad();
            dgResultado.DataSource = ob.TraerRegistros();
        }



        private void CargarEntidad()
        {
            ob.Nombre  = txtObj.Text;
        }

        private void CargarCamposDesdeGrilla()
        {
            txtObj.Text = ob.Nombre;
            txtObj.Focus();
        }

        private void LimpiarCampos()
        {
            ob.Nombre = "";
            ob.IdObj  = 0;
            ob.FechaCambio = "";
            txtObj.Text = "";

        }


        private void EventosKeyDown(KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 13:
                    CargarEntidad();
                    ob.GuardaObjetos();
                    ((frmRegistros)this.Owner).CargarComboObjetos();
                    ((frmRegistros)this.Owner).TextoObjetos = txtObj.Text;
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
                    ob.GuardaObjetos();
                    ((frmRegistros)this.Owner).CargarComboObjetos();
                    ((frmRegistros)this.Owner).TextoObjetos = txtObj.Text;
                    LimpiarCampos();
                    CargarGrilla();
                    break;
                case 113:
                    CargarEntidad();
                    ob.ModificarObjetos();
                    ((frmRegistros)this.Owner).CargarComboObjetos();
                    ((frmRegistros)this.Owner).TextoObjetos = txtObj.Text;
                    LimpiarCampos();
                    CargarGrilla();
                    break;
                case 114:
                    CargarEntidad();
                    ob.BorrarObjetos();
                    ((frmRegistros)this.Owner).CargarComboObjetos();
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
                   // EvObjeto(txtObj.Text);
                    this.Hide();
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

                ob.IdObj = Utilidades.IntDeColumna(dgResultado, f, 0);
                ob.Nombre = Utilidades.StringDeColumna(dgResultado, f, 1);
                ob.FechaCambio = Utilidades.StringDeColumna(dgResultado, f, 2);

                CargarCamposDesdeGrilla();


            }
            if (e.KeyChar == (char)Keys.Escape)
            {
               // EvObjeto(txtObj.Text);
                this.Hide();
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
                    txtObj.Focus();
                    break;


                case 117:
                    // INSERTAR EN FORMULARIO REGISTROS
                    break;

            }
        }

        private void txtObj_KeyDown(object sender, KeyEventArgs e)
        {
            EventosKeyDown(e);
        }

        private void txtObj_Enter(object sender, EventArgs e)
        {
            ttCarteles.Show("F1 = Graba , F2 = modifica , F3 = Elimina", txtObj, 3000);
        }

        private void txtObj_Leave(object sender, EventArgs e)
        {

        }

       
    }
}
