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
    public partial class frmAplicacionesRoles : Form
    {
        public frmAplicacionesRoles()
        {
            InitializeComponent();
        }


        int fila;
        int columna;
        public int idap;

        Clases.AplicacionesRoles apr = new Clases.AplicacionesRoles();

        private void frmAplicacionesRoles_Load(object sender, EventArgs e)
        {
            try
            {
                this.idap = ((frmAplicaciones)this.Owner).IDaPP;
            }
            catch (Exception ex)
            {
                this.idap = ((frmRegistros)this.Owner).idAplicaciones;
            }
            
            CargarGrilla();
            if (dgResultado.Rows.Count > 0)
                CargarEntidadDesdeGrilla(0);
        }

        private void CargarGrilla()
        {
            CargarEntidad();
            dgResultado.DataSource = apr.TraerRegistros();
        }

        private void CargarEntidad()
        {
            apr.IdApp = idap;
            apr.Usr = txtUsuario.Text;
            apr.Pass = txtPass.Text;
            apr.Perfil = txtPerfil.Text;
        }

        private void CargarCamposDesdeGrilla()
        {
            txtUsuario.Text = apr.Usr;
            txtPass.Text = apr.Pass;
            txtPerfil.Text = apr.Perfil;
            txtUsuario.Focus();
        }

        private void LimpiarCampos()
        {
            apr.IdApp = 0;
            apr.FechaCambio = "";
            txtUsuario.Text = "";
            txtPass.Text = "";
            txtPerfil.Text = "";
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
                    apr.GuardaAplicacionRoles();
                    LimpiarCampos();
                    CargarGrilla();
                    break;
                case 113:
                    CargarEntidad();
                    apr.ModificarAplicacionRoles();
                    LimpiarCampos();
                    CargarGrilla();
                    break;
                case 114:
                    CargarEntidad();
                    apr.BorrarAplicacionRoles();
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
                    // f6
                    // INSERTAR REGISTRO
                    break;
                case 118:
                    // f7
                    break;
                case 119:
                    // f8
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
                    break;
            }
        }

        private void CargarEntidadDesdeGrilla(int f)
        {
            if (dgResultado.Rows[f].Cells[4].Value != null)
                apr.IdApp = (int)dgResultado.Rows[f].Cells[4].Value;
            else
                apr.IdApp = 0;

            if (dgResultado.Rows[f].Cells[0].Value != null)
                apr.Usr = (string)dgResultado.Rows[f].Cells[0].Value.ToString();
            else
                apr.Usr = "";
            if (dgResultado.Rows[f].Cells[1].Value != null)
                apr.Pass = (string)dgResultado.Rows[f].Cells[1].Value.ToString();
            else
                apr.Pass = "";

            if (dgResultado.Rows[f].Cells[2].Value != null)
                apr.Perfil = (string)dgResultado.Rows[f].Cells[2].Value.ToString();
            else
                apr.Perfil = "";


            if (dgResultado.Rows[f].Cells[3].Value != null)
                apr.FechaCambio = (string)dgResultado.Rows[f].Cells[3].Value.ToString();
            else
                apr.FechaCambio = "";

        }

        private void dgResultado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space )
            {
                int f = fila;
                CargarEntidadDesdeGrilla(f);
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

            if (e.KeyValue == 36)
                txtUsuario.Focus();
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            EventosKeyDown(e);
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            EventosKeyPressed(e);
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            EventosKeyDown(e);
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            EventosKeyPressed(e);
        }

        private void txtPerfil_KeyDown(object sender, KeyEventArgs e)
        {
            EventosKeyDown(e);
        }

        private void txtPerfil_KeyPress(object sender, KeyPressEventArgs e)
        {
            EventosKeyPressed(e);
        }

 

    }
}
