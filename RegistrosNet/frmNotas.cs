using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.ComponentModel;


namespace RegistrosNet
{
    public partial class frmNotas : Form
    {
        int posicion = 0;
        
        public frmNotas()
        {
            InitializeComponent();
            if (Clipboard.ContainsText())
            {
                this.rtbNota.Text = Clipboard.GetText();
            }

            CargaComboConstruyeTexto();


        }
   



        private Point posiciónCursorEnCampo()
        {


            //return this.rtbNota.GetPositionFromCharIndex(this.rtbNota.Text.Length);
            return this.rtbTitulo.GetPositionFromCharIndex(this.rtbTitulo.Text.Length);
        }

        private System.Data.DataTable CargarPersonasArchivosTemas()
        {
            System.Data.DataTable tabla = new DataTable();
            System.Data.DataColumn col = new DataColumn("nombre");
            tabla.Columns.Add(col);
            foreach ( System.Data.DataRow  fila in (new Clases.Personas()).TraerRegistros().Rows)
            {
                System.Data.DataRow filaNueva = tabla.NewRow();
                filaNueva["nombre"] = fila["Apellido"];
                tabla.Rows.Add(filaNueva);
            }




            foreach (System.Data.DataRow fila in (new Clases.Temas()).TraerRegistrosAlfabeticamente().Rows)
            {
                System.Data.DataRow filaNueva = tabla.NewRow();
                filaNueva["nombre"] = ";" + fila["__________________________________________TEMA_____________________________________________________"];
                tabla.Rows.Add(filaNueva);
            }
   
            return tabla;

        }

        private void CargaComboConstruyeTexto()
        {
            System.Data.DataView vista = new DataView(CargarPersonasArchivosTemas());
            vista.Sort = "nombre";
            this.cmbConstruyeTexto.DataSource = vista;
            this.cmbConstruyeTexto.DisplayMember = "nombre";
            this.cmbConstruyeTexto.ValueMember = "nombre";



        }



        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {


            if (e.KeyData == Keys.Escape)
            {
                this.Visible = false;
            }
            if (e.KeyData == Keys.PageUp)
            {
                this.rtbTitulo.Text = rtbTitulo.Text + rtbNota.SelectedText + " ";
                this.rtbTitulo.Focus();
                this.rtbTitulo.GetPositionFromCharIndex(this.rtbTitulo.Text.Length + 5);

            }

        }


        public string rutaEstablecida = "";
        public string NombreArchivoASalvar = "";

        private void txtTituloNota_KeyDown(object sender, KeyEventArgs e)
        {
            string nombre = "";
            if (e.KeyData == Keys.F1)
            {
               
                rutaEstablecida = Utilidades.ConsultarRutasRelativas(((frmRegistros)this.Owner).TextoTemas) + @"\";
                NombreArchivoASalvar = this.rtbTitulo.Text;

                string invalidChars = System.Text.RegularExpressions.Regex.Escape(new string(System.IO.Path.GetInvalidFileNameChars()));
                string invalidRegStr = string.Format(@"([{0}]*\.+$)|([{0}]+)", invalidChars);
                NombreArchivoASalvar = System.Text.RegularExpressions.Regex.Replace(NombreArchivoASalvar, invalidRegStr, "_").Trim();
                NombreArchivoASalvar = rutaEstablecida + NombreArchivoASalvar ;
        

                //frmDirectorioCombos di = new frmDirectorioCombos( NombreArchivoASalvar );
                //di.ShowDialog(this);
                frmElegirRutaParaNombre di = new frmElegirRutaParaNombre(NombreArchivoASalvar);
                di.ShowDialog(this);

                if (!NombreArchivoASalvar.Contains(".txt"))
                    NombreArchivoASalvar += ".txt";

                try
                {
                    rtbNota.SaveFile(NombreArchivoASalvar, RichTextBoxStreamType.PlainText);
                }
                catch (Exception exce)
                {
                    MessageBox.Show("problemas con grabación de Notas del " + NombreArchivoASalvar + " excep : " + exce.Message);
                }

                string[] nombres = NombreArchivoASalvar.Split('\\');
                nombre = nombres[nombres.Length - 1];


                Clases.Archivos ar = new Clases.Archivos();
                ar.Nombre = nombre;
                ar.Ruta = NombreArchivoASalvar;
                int nuevoIndice = ar.GuardaArchivo();
                ((frmRegistros)this.Owner).TextoArchivos = ar.Nombre;
                ((frmRegistros)this.Owner).idTextoArchivos = nuevoIndice;
                this.Visible = false;

               
            }
            if(e.KeyData == Keys.Escape)
            {
                this.Visible = false;
            }

            if( e.KeyData == Keys.PageDown)
            {
                this.rtbNota.Focus();
            }

            //if (e.KeyData == Keys.F2)
            //if (e.Alt && e.KeyCode == Keys.Q)
            if (e.Alt )
            {
                cmbConstruyeTexto.Visible = true;
                cmbConstruyeTexto.DroppedDown = true;
                cmbConstruyeTexto.Focus();
                cmbConstruyeTexto.Location = posiciónCursorEnCampo();
                

            }


        }





        private void cmbConstruyeTexto_KeyDown(object sender, KeyEventArgs e)
        {
            
            switch(e.KeyData )
            {
                case (Keys.Enter):
                    posicion = this.rtbTitulo.SelectionStart;
                    this.rtbTitulo.Text = this.rtbTitulo.Text.Insert(posicion, (cmbConstruyeTexto.Text + " "));
                    this.rtbTitulo.SelectionStart = (posicion + cmbConstruyeTexto.Text.Length + 1);
                    posicion = (posicion + cmbConstruyeTexto.Text.Length + 1);
                    this.rtbTitulo.Focus();
                    this.cmbConstruyeTexto.Visible = false;
                    break;
                case Keys.Escape:

                    this.rtbTitulo.Focus();
                    cmbConstruyeTexto.Visible = false;
                    break;

                default:
   
                    break;

            }
            
        }

        private void rtbTitulo_TextChanged(object sender, EventArgs e)
        {
            if (rtbTitulo.Text.Length > 200)
            {
                this.lblDesbordamiento.Text = rtbTitulo.Text.Length.ToString();

            }
            else
            {
                this.lblDesbordamiento.Text = "";
                cmbConstruyeTexto.Visible = true;

            }
        }

        private void cmbConstruyeTexto_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void cmbConstruyeTexto_SelectedValueChanged(object sender, EventArgs e)
        {

        }
    }
}
