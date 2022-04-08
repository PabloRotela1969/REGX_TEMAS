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
    public delegate void ActualizarNexo(string nexo);
    public partial class frmNexos : Form
    {

        private void frmNexos_Load(object sender, EventArgs e)
        {

            this.txtNexo.Text = ((frmRegistros)this.Owner).TextoNexos;

            CargarGrilla();
        }
        public event ActualizarNexo EvNexo;
        public frmNexos()
        {
            InitializeComponent();
        }

        int fila;
        int columna;

        Clases.Nexos ne = new Clases.Nexos();

        private void CargarGrilla()
        {
            CargarEntidad();
            dgResultado.DataSource = ne.TraerRegistros();
        }



        private void CargarEntidad()
        {
            ne.Nexo = txtNexo.Text;
        }

        private void CargarCamposDesdeGrilla()
        {
            txtNexo.Text = ne.Nexo;
            txtNexo.Focus();
        }

        private void LimpiarCampos()
        {
            txtNexo.Text = "";
            ne.IdNex  = 0;
            ne.FechaCambio = "";

        }


        private void EventosKeyDown(KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 13:
                    CargarEntidad();
                    ne.GuardaNexos();
                    ((frmRegistros)this.Owner).CargaComboNexos();
                    ((frmRegistros)this.Owner).TextoNexos = txtNexo.Text;
                    this.Close();
                    break;
                case 27:
                    this.Close();
                    break;
                case 39:
                    //EvNexo(txtNexo.Text);
                    this.Hide();
                    break;
                case 40:
                    dgResultado.Focus();
                    break;

                case 112:
                    CargarEntidad();
                    ne.GuardaNexos();
                    ((frmRegistros)this.Owner).CargaComboNexos();
                    ((frmRegistros)this.Owner).TextoNexos = txtNexo.Text;
                    LimpiarCampos();
                    CargarGrilla();
                    break;
                case 113:
                    CargarEntidad();
                    ne.ModificarNexos();
                    ((frmRegistros)this.Owner).CargaComboNexos();
                    ((frmRegistros)this.Owner).TextoNexos = txtNexo.Text;
                    LimpiarCampos();
                    CargarGrilla();
                    break;
                case 114:
                    CargarEntidad();
                    ne.BorrarNexos();
                    ((frmRegistros)this.Owner).CargaComboNexos();
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
                    //EvNexo(txtNexo.Text);
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
                ne.IdNex = Utilidades.IntDeColumna(dgResultado, f, 0);
                ne.Nexo = Utilidades.StringDeColumna(dgResultado, f, 1);
                ne.FechaCambio = Utilidades.StringDeColumna(dgResultado, f, 2);
                CargarCamposDesdeGrilla();


            }
            if (e.KeyChar == (char)Keys.Escape)
            {
                //EvNexo(txtNexo.Text);
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
                    txtNexo.Focus();
                    break;


                case 117:
                    // INSERTAR EN FORMULARIO REGISTROS
                    EvNexo(txtNexo.Text);
                    this.Hide();
                    break;

            }
        }

        private void txtNexo_KeyDown(object sender, KeyEventArgs e)
        {
            EventosKeyDown(e);
        }


    }

}
