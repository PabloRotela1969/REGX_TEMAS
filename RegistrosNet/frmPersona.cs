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
    public delegate void ActualizarPersona(string apellido);
    public partial class frmPersona : Form
    {
        int _idpers;
        public int IDperS
        {
            get { return _idpers; }
            set { _idpers = value ;}
        }

        public event ActualizarPersona  EvActualizarPersona;
        public frmPersona()
        {
            InitializeComponent();
        }

        private void frmPersona_Load(object sender, EventArgs e)
        {
            this.txtApellido.Text = ((frmRegistros)this.Owner).TextoPersonas;
            CargarGrilla();
        }
        int fila;
        int columna;

        Clases.Personas pe = new Clases.Personas();

        private void CargarGrilla()
        {
            CargarEntidad();
            DataTable tabla  = pe.TraerRegistros();
            dgResultado.DataSource = tabla;
        }


        private void CargarEntidad()
        {
            pe.Nombre = txtNombre.Text;
            pe.Apellido = txtApellido.Text;
            pe.Empresa = txtEmpresa.Text;
        }

        private void CargarCamposDesdeGrilla()
        {
            txtNombre.Text = pe.Nombre;
            txtApellido.Text = pe.Apellido;
            txtEmpresa.Text = pe.Empresa;
            txtNombre.Focus();
        }

        private void LimpiarCampos()
        {
            pe.IdPer = 0;
            pe.Nombre = "";
            pe.Apellido = "";
            pe.Empresa = "";
            pe.Fecha_Cambio = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtEmpresa.Text = "";
        }


        private void EventosKeyDown(KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 27:
                    this.Close();
                    break;
                case 13:
                    CargarEntidad();
                    pe.GuardarPersonas();
                    ((frmRegistros)this.Owner).CargaComboPersonas();
                    ((frmRegistros)this.Owner).TextoPersonas = this.txtApellido.Text;
                    this.Close();
                    break;
                case 40:
                    dgResultado.Focus();
                    break;

                case 112:
                    CargarEntidad();
                    pe.GuardarPersonas();
                    ((frmRegistros)this.Owner).CargaComboPersonas();
                    ((frmRegistros)this.Owner).TextoPersonas = this.txtApellido.Text;
                    LimpiarCampos();
                    CargarGrilla();
                    break;
                case 113:
                    CargarEntidad();
                    pe.ModificarPersonas();
                    ((frmRegistros)this.Owner).CargaComboPersonas();
                    ((frmRegistros)this.Owner).TextoPersonas = this.txtApellido.Text;
                    LimpiarCampos();
                    CargarGrilla();
                    break;
                case 114:
                    CargarEntidad();
                    pe.BorrarPersonas();
                    ((frmRegistros)this.Owner).CargaComboPersonas();
                    ((frmRegistros)this.Owner).TextoPersonas = this.txtApellido.Text;
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
                   // EvActualizarPersona(txtApellido.Text);
                    this.Hide();
                    break;

                case 118:
                    // consultar telefono
                    frmTelefonos te = new frmTelefonos();
                        IDperS  = pe.IdPer;
                        te.Show(this);
                    
                    break;
            }
        }


        private void dgResultado_KeyPress(object sender, KeyPressEventArgs e)
        {
            int f = fila;
            if (e.KeyChar == (char)Keys.Space )
            {

                pe.IdPer = Utilidades.IntDeColumna(dgResultado, f, 4);
                pe.Nombre = Utilidades.StringDeColumna(dgResultado, f, 0);
                pe.Apellido = Utilidades.StringDeColumna(dgResultado, f, 1);
                pe.Empresa = Utilidades.StringDeColumna(dgResultado, f, 2);
                pe.Fecha_Cambio = Utilidades.StringDeColumna(dgResultado, f, 3);
                
                CargarCamposDesdeGrilla();

            }
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }
            if (e.KeyChar == (char)Keys.F6)
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
                    txtNombre.Focus();
                    break;


                case 117:
                    // INSERTAR EN FORMULARIO REGISTROS
                    break;

            }
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            EventosKeyDown(e);
        }



        private void txtApellido_KeyDown(object sender, KeyEventArgs e)
        {
            EventosKeyDown(e);
        }



        private void txtEmpresa_KeyDown(object sender, KeyEventArgs e)
        {
            EventosKeyDown(e);
        }

        private void txtNombre_Enter(object sender, EventArgs e)
        {
            ttCarteles.Show("F1 = Alta, F2 = Modifica, F3 = Baja", txtNombre, 3000);
            txtNombre.BackColor = Color.Black;
            txtNombre.ForeColor = Color.White;
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            txtNombre.BackColor = Color.White;
            txtNombre.ForeColor = Color.Black;
        }

        private void txtApellido_Enter(object sender, EventArgs e)
        {
            ttCarteles.Show("F1 = Alta, F2 = Modifica, F3 = Baja", txtNombre, 3000);
            txtApellido.BackColor = Color.Black;
            txtApellido.ForeColor = Color.White;
        }

        private void txtApellido_Leave(object sender, EventArgs e)
        {
            txtApellido.BackColor = Color.White;
            txtApellido.ForeColor = Color.Black;
        }

        private void txtEmpresa_Enter(object sender, EventArgs e)
        {
            ttCarteles.Show("F1 = Alta, F2 = Modifica, F3 = Baja", txtNombre, 3000);
            txtEmpresa.BackColor = Color.Black;
            txtEmpresa.ForeColor = Color.White;
        }

        private void txtEmpresa_Leave(object sender, EventArgs e)
        {
            txtEmpresa.BackColor = Color.White;
            txtEmpresa.ForeColor = Color.Black;
        }





    }
}
