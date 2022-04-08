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
    public delegate void ActualizarAplicaciones(string nombre);
    public partial class frmAplicaciones : Form
    {

        int _idApp;
        public int IDaPP
        {
            get { return _idApp; }
            set { _idApp = value; }
        }

        private void frmAplicaciones_Load(object sender, EventArgs e)
        {
            this.txtNombre.Text = ((frmRegistros)this.Owner).TextoAplicaciones;
  
            CargarGrilla();
            if ( dgResultado.Rows.Count > 0)
                CargarEntidadDesdeGrilla(0);
            this.ttCarteles.SetToolTip(txtLenguaje, "F1 = alta,F2 = modifica, F3 = baja, F4 = limpiar campos, F5 = consultar, F6 = insertar valor en formulario principal");
        }


        public event ActualizarAplicaciones EvAplicacion;
        public frmAplicaciones()
        {
            InitializeComponent();
        }

        int fila;
        int columna;
        
        Clases.Aplicaciones ap = new Clases.Aplicaciones();

        private void CargarGrilla()
        {
            CargarEntidad();
            dgResultado.DataSource = ap.TraerRegistros();
        }

        private void CargarEntidad()
        {
            ap.Nombre = txtNombre.Text;
            ap.Lenguaje = txtLenguaje.Text;
            ap.SQLversion = txtSQLversion.Text;

        }

        private void CargarCamposConEntidad()
        {
            txtNombre.Text = ap.Nombre;
            txtLenguaje.Text = ap.Lenguaje ;
            txtSQLversion.Text = ap.SQLversion;
            txtNombre.Focus();
        }

        private void LimpiarCampos()
        {
            ap.IdApp = 0;
            txtNombre.Text = "";
            txtLenguaje.Text = "";
            txtSQLversion.Text = "";
            
        }


        private void EventosKeyDown(KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 13:
                    CargarEntidad();
                    ap.GuardaAplicacion();
                    ((frmRegistros)this.Owner).CargarCombosAplicaciones();
                    ((frmRegistros)this.Owner).TextoAplicaciones = txtNombre.Text;
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
                    ap.GuardaAplicacion();
                    ((frmRegistros)this.Owner).CargarCombosAplicaciones();
                    ((frmRegistros)this.Owner).TextoAplicaciones = txtNombre.Text;
                    LimpiarCampos();
                    CargarGrilla();
                    break;
                case 113:
                    CargarEntidad();
                    ap.ModificarAplicacion();
                    ((frmRegistros)this.Owner).CargarCombosAplicaciones();
                    ((frmRegistros)this.Owner).TextoAplicaciones = txtNombre.Text;
                    LimpiarCampos();
                    CargarGrilla();
                    break;
                case 114:
                    CargarEntidad();
                    ap.BorrarAplicacion();
                    ((frmRegistros)this.Owner).CargarCombosAplicaciones();
                    LimpiarCampos();
                    CargarGrilla();
                    break;
                case 115:
                    LimpiarCampos();
                    break;
                case 116:
                    CargarGrilla();
                    break;
                case 118:
                    // f7
                    frmAplicacionesMenues frm = new frmAplicacionesMenues(ap.IdApp);
                    //IDaPP = ap.IdApp;
                    frm.Show(this);
                    break;
                case 119:
                    //f8
                    frmAplicacionesRoles apr = new frmAplicacionesRoles();
                    IDaPP = ap.IdApp;
                    apr.Show(this);
                    break;
                case 120:
                    // f9
                    frmAplicacionesRutas apu = new frmAplicacionesRutas();
                    IDaPP  = ap.IdApp;
                    apu.Show(this);
                    break;
            }
        }
        private void CargarEntidadDesdeGrilla(int f)
        {

            ap.IdApp = Utilidades.IntDeColumna (dgResultado ,f,0);
            ap.Nombre = Utilidades.StringDeColumna(dgResultado , f,1);
            ap.Lenguaje = Utilidades.StringDeColumna(dgResultado, f, 3);
            ap.SQLversion = Utilidades.StringDeColumna(dgResultado, f, 4);
        }

        private void dgResultado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Space )
            {
                int f = fila;
                CargarEntidadDesdeGrilla(f);
                CargarCamposConEntidad();
                
            }
            if (e.KeyChar == (char)Keys.Escape)
            {
                EvAplicacion(txtNombre.Text);
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
                case 118:
                    frmTipos apm = new frmTipos();
                    apm.idap = (int)dgResultado.Rows[fila].Cells[0].Value;
                    apm.Show(this);

                    break;

            }
        }


        private void txtSQLversion_KeyDown(object sender, KeyEventArgs e)
        {
            EventosKeyDown(e);

        }






        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            EventosKeyDown(e);
        }




        private void txtLenguaje_KeyDown(object sender, KeyEventArgs e)
        {
            EventosKeyDown(e);
        }

        private void txtNombre_MouseHover(object sender, EventArgs e)
        {
            ttCarteles.UseAnimation = true;
            ttCarteles.IsBalloon = true;
            ttCarteles.Show("F7 = MENUES, F8 = ROLES, F9 = RUTAS", txtNombre , 3000);

        }

        private void txtNombre_Enter(object sender, EventArgs e)
        {
            ttCarteles.Show("F7 = MENUES, F8 = ROLES, F9 = RUTAS", txtNombre, 3000);
            txtNombre.BackColor = Color.Black;
            txtNombre.ForeColor = Color.White;
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            txtNombre.BackColor = Color.White;
            txtNombre.ForeColor = Color.Black;
        }

        private void txtLenguaje_Enter(object sender, EventArgs e)
        {
            ttCarteles.Show("F7 = MENUES, F8 = ROLES, F9 = RUTAS", txtLenguaje, 3000);
            txtLenguaje.BackColor = Color.Black;
            txtLenguaje.ForeColor = Color.White;
        }

        private void txtLenguaje_Leave(object sender, EventArgs e)
        {
            txtLenguaje.BackColor = Color.White;
            txtLenguaje.ForeColor = Color.Black;
        }

        private void txtSQLversion_Enter(object sender, EventArgs e)
        {
            ttCarteles.Show("F7 = MENUES, F8 = ROLES, F9 = RUTAS", txtSQLversion, 3000);
            txtSQLversion.BackColor = Color.Black;
            txtSQLversion.ForeColor = Color.White;
        }

        private void txtSQLversion_Leave(object sender, EventArgs e)
        {
            txtSQLversion.BackColor = Color.White;
            txtSQLversion.ForeColor = Color.Black;
        }
    }
}
