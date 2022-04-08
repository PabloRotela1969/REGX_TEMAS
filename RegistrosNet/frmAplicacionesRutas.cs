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
    public partial class frmAplicacionesRutas : Form
    {
        public frmAplicacionesRutas()
        {
            InitializeComponent();
        }


        int fila;
        int columna;
        public int idap;

        Clases.AplicacionesRutas apr = new Clases.AplicacionesRutas();


        private void frmAplicacionesRutas_Load(object sender, EventArgs e)
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
            if (dgResultado.Rows.Count == 2)
            {
                CargarEntidadDesdeGrilla(0);
                CargarCamposDesdeGrilla();
            }
        }

        private void CargarGrilla()
        {
            CargarEntidad();
            dgResultado.DataSource = apr.TraerRegistros();

        }

        private void EjecutarRuta(string nombre)
        {

            if (nombre != "")
            {
        
                try
                {
                    System.Diagnostics.Process.Start(nombre);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("NO SE ENCONTRÓ LA RUTA " + nombre);
                }
            }

        }

        private void EjecutarYEntrar(string nombre)
        {
            EjecutarRuta(nombre);
            Clases.AplicacionesRoles apro = new Clases.AplicacionesRoles();
            apro.IdApp = this.idap;
            DataTable tabla = apro.TraerRegistros();
            string pasw = "";
            string user = "";
            string salto = "";
            string enter = "";
            if (tabla.Rows.Count > 0)
            {
                user = tabla.Rows[0].ItemArray[0].ToString();
                pasw = tabla.Rows[0].ItemArray[1].ToString();
                salto = "{TAB}";
                enter = "{ENTER}";
                System.Threading.Thread.Sleep(3000);
            }
            string cadena = user + salto + pasw + salto;
            SendKeys.Send(cadena);
            System.Threading.Thread.Sleep(500);
            SendKeys.Send(enter);
            
        }

        private void CargarEntidad()
        {
            apr.IdApp  = idap;
            apr.Repositorio = txtRepositorio.Text;
            apr.Rigido = txtRigido.Text;
            apr.Desarrollo = txtDesa.Text;
            apr.Test = txtTest.Text;
            apr.Produccion = txtProd.Text;

        }

        private void CargarCamposDesdeGrilla()
        {
            txtRepositorio.Text = apr.Repositorio;
            txtRigido.Text = apr.Rigido;
            txtDesa.Text = apr.Desarrollo;
            txtTest.Text = apr.Test;
            txtProd.Text = apr.Produccion;
            txtRepositorio.Focus();
        }

        private void LimpiarCampos()
        {
            apr.IdApp = 0;
            apr.Rut = 0;
            apr.FechaCambio = "";
            txtRepositorio.Text = "";
            txtRigido.Text = "";
            txtDesa.Text = "";
            txtTest.Text = "";
            txtProd.Text = "";

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
                    apr.GuardaAplicacionRutas();
                    LimpiarCampos();
                    CargarGrilla();
                    break;
                case 113:
                    CargarEntidad();
                    apr.ModificarAplicacionRutas();
                    LimpiarCampos();
                    CargarGrilla();
                    break;
                case 114:
                    CargarEntidad();
                    apr.BorrarAplicacionRutas();
                    LimpiarCampos();
                    CargarGrilla();
                    break;
                case 115:
                    LimpiarCampos();
                    break;
                case 116:
                    CargarGrilla();
                    break;
 

            }
        }

        private void CargarEntidadDesdeGrilla(int f)
        {
            if ( dgResultado.Rows[f].Cells[6].Value != null )
                apr.IdApp =  (int)dgResultado.Rows[f].Cells[6].Value;
            else
                apr.IdApp = 0;
           

            if (dgResultado.Rows[f].Cells[7].Value != null)
                apr.Rut = (int)dgResultado.Rows[f].Cells[7].Value;
            else
                apr.Rut = 0;
           

            if (dgResultado.Rows[f].Cells[0].Value != null)
                apr.Repositorio = dgResultado.Rows[f].Cells[0].Value.ToString();
            else            
                apr.Repositorio = "";
           

            if (dgResultado.Rows[f].Cells[1].Value != null)
                apr.Rigido = dgResultado.Rows[f].Cells[1].Value.ToString();
            else
                apr.Rigido = "";

            if ( dgResultado.Rows[f].Cells[2].Value != null)
                apr.Desarrollo = dgResultado.Rows[f].Cells[2].Value.ToString();
            else
                apr.Desarrollo = "";

            if (dgResultado.Rows[f].Cells[3].Value != null)
                apr.Test = dgResultado.Rows[f].Cells[3].Value.ToString();
            else
                apr.Test = "";

            if (dgResultado.Rows[f].Cells[4].Value != null)
                apr.Produccion = dgResultado.Rows[f].Cells[4].Value.ToString();
            else
                apr.Produccion = "";

            if (dgResultado.Rows[f].Cells[5].Value != null)
                apr.FechaCambio = dgResultado.Rows[f].Cells[5].Value.ToString();
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
            if (e.KeyChar  == (char) Keys.F12)
            {
                EjecutarRuta(dgResultado.Rows[fila].Cells[columna].Value.ToString());

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
                txtRepositorio.Focus();
        }


        private void txtRepositorio_KeyDown(object sender, KeyEventArgs e)
        {
            EventosKeyDown(e);
            if (e.KeyValue == 123)
                EjecutarYEntrar (txtRepositorio.Text);
        }



        private void txtRigido_KeyDown(object sender, KeyEventArgs e)
        {
            EventosKeyDown(e);
            if (e.KeyValue == 123)
                EjecutarYEntrar(txtRigido.Text);
        }



        private void txtDesa_KeyDown(object sender, KeyEventArgs e)
        {
            EventosKeyDown(e);
            if (e.KeyValue == 123)
                EjecutarYEntrar(txtDesa.Text);
        }



        private void txtTest_KeyDown(object sender, KeyEventArgs e)
        {
            EventosKeyDown(e);
            if (e.KeyValue == 123)
                EjecutarYEntrar(txtTest.Text);
        }



        private void txtProd_KeyDown(object sender, KeyEventArgs e)
        {
            EventosKeyDown(e);
            if (e.KeyValue == 123)
                EjecutarYEntrar(txtProd.Text);
        }

    }
}
