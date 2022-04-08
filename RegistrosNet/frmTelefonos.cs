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
    public partial class frmTelefonos : Form
    {
        public frmTelefonos()
        {
            InitializeComponent();
        }

        public int idapp;

        int fila;
        int columna;

        Clases.Telefonos te = new Clases.Telefonos();

        private void frmTelefonos_Load(object sender, EventArgs e)
        {
            CargarComboPersonas();

             //Utilidades.SeleccionarPorValor(cmbPersonas, ((frmRegistros)this.Tag).TextoPersonas);
            try
            {
                Utilidades.SeleccionarPorValor(cmbPersonas, ((frmRegistros)this.Owner).TextoPersonas);
            }
            catch (Exception ex)
            {

                Utilidades.SeleccionarPorValor(cmbPersonas, ((frmPersona)this.Owner).IDperS.ToString());
            }

            CargarGrilla();
           

        }

        private void CargarGrilla()
        {
            CargarEntidad();
            dgResultado.DataSource = te.TraerRegistros();
        }

        private void CargarComboPersonas()
        {
            cmbPersonas.DataSource = Utilidades.AgregarFilaVaciaInicial( (new Clases.Personas()).TraerRegistros());
            cmbPersonas.DisplayMember = "apellido";
            cmbPersonas.ValueMember = "idPer";

            //if (idapp != 0)
            //    cmbPersonas.SelectedValue = idapp;

        }


        private void CargarEntidad()
        {
            te.IdPer = (cmbPersonas.Text != ""? Convert.ToInt32(cmbPersonas.SelectedValue) :0 );
            te.Telefono = txtTelefono.Text;
        }

        private void CargarCamposDesdeGrilla()
        {
            cmbPersonas.SelectedValue = te.IdPer;
            txtTelefono.Text = te.Telefono;
            cmbPersonas.Focus();
        }

        private void LimpiarCampos()
        {
            te.FechaCambio = "";
            cmbPersonas.SelectedIndex = 0;
            txtTelefono.Text = "";
            te.IdTel = 0;
            te.IdPer = 0;
            te.Telefono = "";
            te.FechaCambio = "";
            
        }


        private void EventosKeyDown(KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 27:
                    // escape
                    this.Close();
                    break;
                case 40:
                    dgResultado.Focus();
                    break;

                case 112:
                    CargarEntidad();
                    te.GuardarTelefonos();
                    LimpiarCampos();
                    CargarGrilla();
                    break;
                case 113:
                    CargarEntidad();
                    te.ModificarTelefonos();
                    LimpiarCampos();
                    CargarGrilla();
                    break;
                case 114:
                    CargarEntidad();
                    te.BorrarTelefonos();
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

                case 118:

                    break;
            }
        }


        private void dgResultado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space )
            {
                int f = fila;
                // los parametros son correctos
                te.IdTel = (int)dgResultado.Rows[f].Cells[5].Value;
                te.IdPer = (int)dgResultado.Rows[f].Cells[4].Value;
                te.Telefono  = (string)dgResultado.Rows[f].Cells[3].Value;
                te.FechaCambio = (string)dgResultado.Rows[f].Cells[6].Value;
                CargarCamposDesdeGrilla();


            }
            if (e.KeyChar == (char)Keys.Escape)
            {
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
                    cmbPersonas.Focus();
                    break;
                case 45:
                    if (dgResultado.GetCellCount(DataGridViewElementStates.Selected) > 0)
                    {
                        Clipboard.SetDataObject(this.dgResultado.GetClipboardContent());
                        string mensaje = "";
                        foreach (DataGridViewCell celda in dgResultado.SelectedCells)
                        {
                            mensaje += celda.Value.ToString() + ";";
                        }
                        this.lblclip.Text = mensaje;
                    }               
                    break;

                case 117:
                    // INSERTAR EN FORMULARIO REGISTROS
                    break;

            }
        }

        private void cmbPersonas_KeyDown(object sender, KeyEventArgs e)
        {
            EventosKeyDown(e);
        }



        private void txtTelefono_KeyDown(object sender, KeyEventArgs e)
        {
            EventosKeyDown(e);
        }



    }
}
