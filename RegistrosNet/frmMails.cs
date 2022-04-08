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
    public partial class frmMails : Form
    {
        public frmMails()
        {
            InitializeComponent();
        }
        int fila;
        int columna;

        Clases.Mails ma = new Clases.Mails();

        private void frmMails_Load(object sender, EventArgs e)
        {
            CargarComboPersonas();
            Utilidades.SeleccionarPorValor(cmbPersonas, ((frmRegistros)this.Owner).TextoPersonas);
            CargarGrilla();
            
        }



        private void CargarGrilla()
        {
            CargarEntidad();
            dgResultado.DataSource = ma.TraerRegistros();
        }

        private void CargarComboPersonas()
        {
            cmbPersonas.DataSource = Utilidades.AgregarFilaVaciaInicial((new Clases.Personas()).TraerRegistros());
            cmbPersonas.DisplayMember = "apellido";
            cmbPersonas.ValueMember = "idPer";
        }


        private void CargarEntidad()
        {
            
            ma.IdPer = (cmbPersonas.Text != "" ? Convert.ToInt32(cmbPersonas.SelectedValue) : 0);
            ma.Direccion = txtMails.Text;

        }

        private void CargarCamposDesdeGrilla()
        {
            
            cmbPersonas.SelectedValue = ma.IdPer;
            txtMails.Text = ma.Direccion;
            cmbPersonas.Focus();
        }

        private void LimpiarCampos()
        {
            cmbPersonas.SelectedIndex = 0;
            txtMails.Text = "";
            ma.IdPer = 0;
            ma.IdMail = 0;
            ma.Direccion = "";
            ma.FechaCambio = "";
        }


        private void EventosKeyDown(KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 37:
                case 39:
                    this.Close();
                    break;
                case 40:
                    dgResultado.Focus();
                    break;

                case 112:
                    CargarEntidad();
                    ma.GuardaMails();
                    LimpiarCampos();
                    CargarGrilla();
                    break;
                case 113:
                    CargarEntidad();
                    ma.ModificarMails();
                    LimpiarCampos();
                    CargarGrilla();
                    break;
                case 114:
                    CargarEntidad();
                    ma.BorrarMails();
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
        private void EventosKeyPressed(KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)Keys.Escape:
                    this.Close();
                    break;
                case (char)Keys.Enter:
                    CargarComboPersonas();
                    cmbPersonas.DroppedDown = true;
                    break;
            }
        }

        private void dgResultado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space )
            {
                int f = fila;


                ma.IdPer = Utilidades.IntDeColumna(dgResultado, f, 3);
                ma.IdMail = Utilidades.IntDeColumna(dgResultado, f, 4);
                ma.Direccion = Utilidades.StringDeColumna(dgResultado, f, 2);
                ma.FechaCambio = Utilidades.StringDeColumna(dgResultado, f, 5);

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
                    txtMails.Focus();
                    break;


                case 117:
                    // INSERTAR EN FORMULARIO REGISTROS
                    break;

                case 45:
                    if (dgResultado.GetCellCount(DataGridViewElementStates.Selected) > 0)
                    {
                        Clipboard.SetDataObject(this.dgResultado.GetClipboardContent());
                        string mensaje = "";
                        foreach (DataGridViewCell celda in dgResultado.SelectedCells)
                        {
                            mensaje += celda.Value.ToString() + " ; ";
                        }
                        this.lblclip.Text = mensaje;
                    }
                    break;
            }
        }



        private void cmbPersonas_KeyPress(object sender, KeyPressEventArgs e)
        {
            EventosKeyPressed(e);
        }

        

        private void txtMails_KeyDown(object sender, KeyEventArgs e)
        {
            EventosKeyDown(e);
        }

        private void txtMails_KeyPress(object sender, KeyPressEventArgs e)
        {
            EventosKeyPressed(e);
        }

        private void cmbPersonas_KeyDown(object sender, KeyEventArgs e)
        {
            EventosKeyDown(e);
        }

        private void frmMails_Enter(object sender, EventArgs e)
        {
            CargarGrilla();
            CargarComboPersonas();
        }

   
    }
}
