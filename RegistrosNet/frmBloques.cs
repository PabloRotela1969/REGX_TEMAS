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

    public partial class frmBloques : Form
    {

        public frmBloques()
        {
            InitializeComponent();
        }

        int fila;
        int columna;


        Clases.Bloques bl = new Clases.Bloques();

        private void frmBloques_Load(object sender, EventArgs e)
        {
            
            this.txtBloque.Text = ((frmRegistros)this.Owner ).TextoBloques;
            this.txtTemas.Text = ((frmRegistros)this.Owner).TextoTemas;
            this.txtPersona.Text = ((frmRegistros)this.Owner).TextoPersonas;
            this.txtVerbo.Text = ((frmRegistros)this.Owner).TextoVerbos;
            this.txtNexo.Text = ((frmRegistros)this.Owner).TextoNexos;
            this.txtModo.Text = ((frmRegistros)this.Owner).TextoModos;
            this.txtObjeto.Text = ((frmRegistros)this.Owner).TextoObjetos;
            this.txtArchivo.Text = ((frmRegistros)this.Owner).TextoArchivos;
            this.txtAplicacion.Text = ((frmRegistros)this.Owner).TextoAplicaciones;

            bl.Bloque = txtBloque.Text;
            DataRow indice = bl.TraerBloques().Rows[0];
            if ( indice[9] != null )
                bl.Id = Convert.ToInt32(indice[9]);

            //CargarGrilla();
            dgResultado.DataSource = bl.TraerBloques();
            FormarAnchoColumnasPorAnchoCampos(dgResultado);

        }

        private void CargarGrilla()
        {
            CargarEntidad();
            dgResultado.DataSource = bl.TraerBloques();
            
        }

        private void FormarAnchoColumnasPorAnchoCampos(DataGridView d)
        {
            int compensacion = 3;
            
            d.Columns[0].Width = txtBloque.Size.Width + compensacion;
            d.Columns[1].Width = txtTemas.Size.Width + compensacion;
            d.Columns[2].Width = txtPersona.Size.Width + compensacion;
            d.Columns[3].Width = txtVerbo.Size.Width + compensacion;
            d.Columns[4].Width = txtNexo.Size.Width + compensacion;
            d.Columns[5].Width = txtModo.Size.Width + compensacion;
            d.Columns[6].Width = txtObjeto.Size.Width + compensacion;
            d.Columns[7].Width = txtArchivo.Size.Width + compensacion;
            d.Columns[8].Width = txtAplicacion.Size.Width + compensacion;

        }


        private void CargarEntidad()
        {
            bl.Tema = txtTemas.Text;
            bl.Bloque = txtBloque.Text;
            bl.Persona = txtPersona.Text;
            bl.Verbo = txtVerbo.Text;
            bl.Nexo = txtNexo.Text;
            bl.Modo = txtModo.Text;
            bl.Objeto = txtObjeto.Text;
            bl.Archivo = txtArchivo.Text;
            bl.Aplicacion = txtAplicacion.Text;

        }

        private void CargarCamposDesdeGrilla()
        {
            txtBloque.Text = bl.Bloque;
            txtTemas.Text = bl.Tema;
            txtPersona.Text = bl.Persona;
            txtVerbo.Text = bl.Verbo;
            txtNexo.Text = bl.Nexo;
            txtModo.Text = bl.Modo;
            txtObjeto.Text = bl.Objeto;
            txtArchivo.Text = bl.Archivo;
            txtAplicacion.Text = bl.Aplicacion;
            txtBloque.Focus();
        }

        private void LimpiarCampos()
        {
            bl.Id = 0;
            bl.Bloque = "";
            bl.Tema = "";
            bl.Persona = "";
            bl.Nexo = "";
            bl.Verbo = "";
            bl.Modo = "";
            bl.Objeto = "";
            bl.Archivo = "";
            bl.Aplicacion = "";
            txtBloque.Text = "";
            txtTemas.Text = "";
            txtPersona.Text = "";
            txtVerbo.Text = "";
            txtNexo.Text = "";
            txtModo.Text = "";
            txtObjeto.Text = "";
            txtArchivo.Text = "";
            txtAplicacion.Text = "";

        }


        private void EventosKeyDown(KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 13:
                    CargarEntidad();
                    bl.GuardaBloques();
                    ((frmRegistros)this.Owner).CargarComboBloques();
                    ((frmRegistros)this.Owner).TextoBloques = bl.Bloque;
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
                    if (bl.Bloque != "")
                    {
                        bl.GuardaBloques ();
                        ((frmRegistros)this.Owner).CargarComboBloques();
                        ((frmRegistros)this.Owner).TextoBloques = bl.Bloque;
                        LimpiarCampos();
                        CargarGrilla();
                        FormarAnchoColumnasPorAnchoCampos(dgResultado);
                    }
                     else
                     {
                         MessageBox.Show("INGRESAR NOMBRE DE BLOQUE");
                     }
                    break;
                case 113:
                    CargarEntidad();
                    if (bl.Bloque != "")
                    {
                        bl.ModificarBloques();
                        ((frmRegistros)this.Owner).CargarComboBloques();
                        ((frmRegistros)this.Owner).TextoBloques = bl.Bloque;
                        LimpiarCampos();
                        CargarGrilla();
                        FormarAnchoColumnasPorAnchoCampos(dgResultado);
                    }
                    else
                    {
                        MessageBox.Show("INGRESAR NOMBRE DE BLOQUE");
                    }
                    break;
                case 114:
                    CargarEntidad();
                    bl.BorrarBloques ();
                    ((frmRegistros)this.Owner).CargarComboBloques();
                     LimpiarCampos();
                    CargarGrilla();
                    FormarAnchoColumnasPorAnchoCampos(dgResultado);
                    break;
                case 115:
                    LimpiarCampos();
                    break;
                case 116:
                    CargarGrilla();
                    FormarAnchoColumnasPorAnchoCampos(dgResultado);
                    break;
                case 117:
                    // INSERTAR EN FORMULARIO REGISTROS
                    //EvBloque(txtBloque.Text);
                    this.Close();
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


                bl.Bloque = Utilidades.StringDeColumna(dgResultado, f, 0);
                bl.Tema = Utilidades.StringDeColumna(dgResultado, f, 1);
                bl.Persona = Utilidades.StringDeColumna(dgResultado, f, 2);
                bl.Verbo = Utilidades.StringDeColumna(dgResultado, f, 3);
                bl.Nexo = Utilidades.StringDeColumna(dgResultado, f, 4);
                bl.Modo = Utilidades.StringDeColumna(dgResultado, f, 5);
                bl.Objeto = Utilidades.StringDeColumna(dgResultado, f, 6);
                bl.Archivo = Utilidades.StringDeColumna(dgResultado, f, 7);
                bl.Aplicacion = Utilidades.StringDeColumna(dgResultado, f, 8);
                bl.Id = Utilidades.IntDeColumna(dgResultado, f, 9);
                CargarCamposDesdeGrilla();

            }
            if (e.KeyChar == (char)Keys.Escape)
            {
                //EvBloque(txtBloque.Text);
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
                    txtBloque.Focus();
                    break;

            }
        }

        private void txtBloque_KeyDown(object sender, KeyEventArgs e)
        {
            EventosKeyDown(e);
        }


        private void txtPersona_KeyDown(object sender, KeyEventArgs e)
        {
            EventosKeyDown(e);
        }



        private void txtVerbo_KeyDown(object sender, KeyEventArgs e)
        {
            EventosKeyDown(e);
        }


        private void txtNexo_KeyDown(object sender, KeyEventArgs e)
        {
            EventosKeyDown(e);
        }



        private void txtModo_KeyDown(object sender, KeyEventArgs e)
        {
            EventosKeyDown(e);
        }



        private void txtObjeto_KeyDown(object sender, KeyEventArgs e)
        {
            EventosKeyDown(e);
        }



        private void txtArchivo_KeyDown(object sender, KeyEventArgs e)
        {
            EventosKeyDown(e);
        }



        private void txtAplicacion_KeyDown(object sender, KeyEventArgs e)
        {
            EventosKeyDown(e);
        }

        private void txtTemas_KeyDown(object sender, KeyEventArgs e)
        {
            EventosKeyDown(e);
        }


    }
}
