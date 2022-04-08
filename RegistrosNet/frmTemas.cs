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
    public delegate void DelegadoMensaje(object sender, EventArgs e);
    public delegate void TemaActualizado(string tema);

    
    public partial class frmTemas : Form  
    {
        public frmTemas()
        {
            InitializeComponent();
        }

        private void frmTemas_Load(object sender, EventArgs e)
        {

            this.txtTemas.Text = ((frmRegistros)this.Owner ).TextoTemas;

            CargarGrilla();
            CargarComboTipos();
            CargarCamposDesdeGrilla(0);
        }


        private void cmbEstado_Enter(object sender, EventArgs e)
        {
            cmbEstado.DroppedDown = true;

        }  

 
        int fila = 1;
        int columna = 0;

        Clases.Temas te = new Clases.Temas();

        private void CargarGrilla()
        {
            CargarEntidad();
            dgResultado.DataSource = te.TraerRegistrosAlfabeticamente();
        }

        private void CargarComboTipos()
        {
            List<string> lista = new List<string>();
            lista.Add("");
            lista.Add("Iniciado");
            lista.Add("Actual");
            lista.Add("Pendiente");
            lista.Add("Terminado");
            cmbEstado.DataSource = lista;

        }


        private void CargarEntidad()
        {
            te.Nombre = txtTemas.Text;
            te.Estado = cmbEstado.Text;
        }

        private void CargarCamposDesdeGrilla(int f)
        {
            
            if (dgResultado.Rows.Count > 0)
            {
                te.IdTem = (int)dgResultado.Rows[f].Cells[3].Value;
                te.Nombre = (string)dgResultado.Rows[f].Cells[1].Value;
                te.Estado = (string)dgResultado.Rows[f].Cells[0].Value;
                te.FechaCambio = (string)dgResultado.Rows[f].Cells[2].Value;
                txtTemas.Text = te.Nombre;
                cmbEstado.Text = te.Estado;
                
            }
            cmbEstado.Focus();
        }

        private void LimpiarCampos()
        {
            txtTemas.Text = "";
            cmbEstado.SelectedIndex = 0;
            te.IdTem = 0;
            te.Estado = "";
            te.Nombre = "";
            te.FechaCambio = "";

        }


        private void EventosKeyDown(KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 13:
                    CargarEntidad();
                    te.GuardarTemas();
                    ((frmRegistros)this.Owner).CargarComboTemaAlfabeticamente();
                    ((frmRegistros)this.Owner).TextoTemas = te.Nombre;
                    this.Close();
                    break;

                case 40:
                    dgResultado.Focus();
                    break;

                case 112:
                    CargarEntidad();
                    te.GuardarTemas();
                    ((frmRegistros)this.Owner).CargarComboTemaUltimo();
                    ((frmRegistros)this.Owner).TextoTemas = te.Nombre;
                    LimpiarCampos();
                    CargarGrilla();
                    break;
                case 113:
                    CargarEntidad();
                    te.ModificarTemas();
                    ((frmRegistros)this.Owner).CargarComboTemaUltimo();
                    ((frmRegistros)this.Owner).TextoTemas = te.Nombre;
                    LimpiarCampos();
                    CargarGrilla();
                    break;
                case 114:
                    CargarEntidad();
                    te.BorrarTemas();
                    ((frmRegistros)this.Owner).CargarComboTemaUltimo();
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
                    //F6
                    // INSERTAR EN FORMULARIO REGISTROS
                   // EvActualizado(txtTemas.Text);
                    this.Close();
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
                   // EvActualizado(txtTemas.Text);
                    this.Close();    
                    break;
                case (char)Keys.Enter:
                    if (cmbEstado.DroppedDown == false)
                    {
                        cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
                        cmbEstado.DroppedDown = true;
                        
                    }
                    else
                    {
                        cmbEstado.DroppedDown = false;
                        cmbEstado.Focus();
                    }

                    break;

            }
        }

        private void dgResultado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space )
            {
                if (fila == 1)
                {

                    int f = fila;
                    CargarCamposDesdeGrilla(f);
                }

            }
            if (e.KeyChar == (char)Keys.Escape)
            {

              //  EvActualizado(txtTemas.Text);
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
                    cmbEstado.Focus();
                    break;


                case 117:
                    // INSERTAR EN FORMULARIO REGISTROS
                    break;

            }
        }

        private void txtTemas_KeyDown(object sender, KeyEventArgs e)
        {
            EventosKeyDown(e);
        }

        private void txtTemas_KeyPress(object sender, KeyPressEventArgs e)
        {
            EventosKeyPressed(e);
        }

        private void cmbEstado_KeyDown(object sender, KeyEventArgs e)
        {
            EventosKeyDown(e);
        }

        private void cmbEstado_KeyPress(object sender, KeyPressEventArgs e)
        {
            EventosKeyPressed(e);
        }

        private void txtTemas_Enter(object sender, EventArgs e)
        {
            ttCarteles.Show("F1 = Alta, F2 = Modifica, F3 = Baja", txtTemas, 3000);
            txtTemas.BackColor = Color.Black;
            txtTemas.ForeColor = Color.White;
        }

        private void txtTemas_Leave(object sender, EventArgs e)
        {
            txtTemas.BackColor = Color.White;
            txtTemas.ForeColor = Color.Black;
        }


    }
}
