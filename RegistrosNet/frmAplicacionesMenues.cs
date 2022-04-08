using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace RegistrosNet
{
    public partial class frmAplicacionesMenues : Form
    {
        public frmAplicacionesMenues()
        {
            InitializeComponent();
            CargarGrilla();

        }

        public frmAplicacionesMenues(int idAplicacion)
        {
            InitializeComponent();
            this.idap = idAplicacion;
            CargarGrilla();

        }
        int fila;
        int columna;
        public int idap;

        Clases.AplicacionesMenues apm = new Clases.AplicacionesMenues();

        private void frmAplicacionesMenues_Load(object sender, EventArgs e)
        {
        }

        private void CargarGrilla()
        {
            CargarEntidad();
            dgResultado.DataSource = apm.TraerRegistros();
        }

        private void CargarEntidad()
        {
            apm.IdApp = idap;
            apm.Menu =  txtMenu.Text;
            apm.Descripcion = txtDescripcion.Text;
            
        }



        private void LimpiarCampos()
        {
            apm.IdApp = 0;
            apm.Menu = "";
            apm.FechaCambio = "";
            txtMenu.Text = "";
            txtDescripcion.Text = "";

        }

        private void EventosKeyDown(KeyEventArgs e)
        {
            switch ((Keys) e.KeyValue)
            {
                case Keys.Escape :
                    this.Close();
                    break;
                case Keys.PageDown :
                    dgResultado.Focus();
                    break;

                case Keys.F1 :
                    CargarEntidad();
                    apm.GuardaAplicacionMenues();
                    LimpiarCampos();
                    CargarGrilla();
                    break;
                case Keys.F2 :
                    CargarEntidad();
                    apm.ModificarAplicacionMenues();
                    LimpiarCampos();
                    CargarGrilla();
                    break;
                case Keys.F3 :
                    CargarEntidad();
                    apm.BorrarAplicacionMenues();
                    LimpiarCampos();
                    CargarGrilla();
                    break;
                case Keys.F4 :
                    LimpiarCampos();
                    break;
                case Keys.F6 :
                    CargarGrilla();
                    break;
                case Keys.F12:
                    EjecutarRuta(this.txtDescripcion.Text);
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

        private void CargarEntidadYCamposDesdeGrilla()
        {
            int f = fila;


            if (dgResultado.Rows[f].Cells[3].Value != null)
                apm.IdApp = (int)dgResultado.Rows[f].Cells[3].Value;
            else
                apm.IdApp = 0;

            if (dgResultado.Rows[f].Cells[0].Value != null)
                apm.Menu = dgResultado.Rows[f].Cells[0].Value.ToString();
            else
                apm.Menu = "";

            if (dgResultado.Rows[f].Cells[1].Value != null)
                apm.Descripcion = dgResultado.Rows[f].Cells[1].Value.ToString();
            else
                apm.Descripcion = "";

            if (dgResultado.Rows[f].Cells[2].Value != null)
                apm.FechaCambio = dgResultado.Rows[f].Cells[2].Value.ToString();
            else
                apm.FechaCambio = "";

            txtMenu.Text = apm.Menu.ToString();
            txtDescripcion.Text = apm.Descripcion;
            txtMenu.Focus();
        }


        private void dgResultado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space )
            {
                CargarEntidadYCamposDesdeGrilla();


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

            this.Text = "APLICACIONES MENUES ( " + fila.ToString() + " )";
        }



        private void EjecutarRuta(string ruta)
        {
            if (ruta != "")
            {
                
                try
                {
                    System.Diagnostics.Process.Start(ruta);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("NO SE ENCONTRÓ EL ARCHIVO CUYO :" + ruta + " O NO ES UNA RUTA VÁLIDA");
                }
           
            }
        }



        private void txtMenu_KeyDown(object sender, KeyEventArgs e)
        {
            EventosKeyDown(e);
        }

        private void txtMenu_KeyPress(object sender, KeyPressEventArgs e)
        {
            EventosKeyPressed(e);
        }

        private void txtDescripcion_KeyDown(object sender, KeyEventArgs e)
        {
            EventosKeyDown(e);
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            EventosKeyPressed(e);
        }

        private void dgResultado_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex;
            columna = e.ColumnIndex;

            this.Text = "APLICACIONES MENUES ( " + fila.ToString() + " )";
        }


    }
}
