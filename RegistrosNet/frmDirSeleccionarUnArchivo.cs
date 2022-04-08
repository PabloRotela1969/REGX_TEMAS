using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace RegistrosNet
{
    public struct Elemento
    {
        public string nombre;
        public enum tipo
        {
            unidad, carpeta, archivo
        }
        public tipo es;
        public Elemento(string nom, tipo ti)
        {
            this.nombre = nom;
            this.es = ti;
        }

        public override string ToString()
        {
            return nombre;
        }
    }

        
    public partial class frmDirSeleccionarUnArchivo : Form
    {
        public frmDirSeleccionarUnArchivo()
        {
            InitializeComponent();
            CargarRuta();
            this.Text = "Seleccione unidad, carpetas y archivo pulsando las primeras letras del combo y ESPACIO toma la ruta";
        }

        Stack<Elemento> lista = new Stack<Elemento>();
        bool UltimoDirectorio = false;
        bool ArchivoSeleccionado = false;
        bool OrdenarArchivosPorFecha = false;

        private void CargarRuta()
        {
            if ( lista.Count == 0 )
            {
                CargarUnidadesCombo();
            }
            else
            {
                if (!UltimoDirectorio )
                {
                    CargarDirectoriosCombo(txtRutaCompleta.Text.Replace(@"\\", @"\"));
                    CargarArchivosCombo(txtRutaCompleta.Text.Replace(@"\\", @"\"));
                }
            }

        }



        private void CargarUnidadesCombo()
        {
            cmbRutas.Items.Clear();
            foreach (DriveInfo un in DriveInfo.GetDrives())
            {
                if (!un.Name.Contains("A"))
                {
                    Elemento el = new Elemento(un.Name.Replace("\\", ""), Elemento.tipo.unidad);
                    cmbRutas.Items.Add(el);
                }
            }
            
        }

        private void CargarDirectoriosCombo(string ruta)
        {
            cmbRutas.Items.Clear();
            
            try
            {
                DirectoryInfo dire = new DirectoryInfo(ruta);
                if (dire.GetDirectories().Length > 0)
                {
                    foreach (DirectoryInfo di in dire.GetDirectories())
                    {
                        Elemento el = new Elemento(di.Name , Elemento.tipo.carpeta );
                        cmbRutas.Items.Add(el);
                    }
   
                }
                else 
                {
                    cmbRutas.Items.Add("NO HAY MÁS DIRECTORIOS");
                }
            }
            catch (Exception ex)
            {
                
            }
        }
        private void CargarArchivosCombo(string ruta)
        {
            try
            {
                DirectoryInfo dire = new DirectoryInfo(ruta);
                if (dire.GetFiles().Length > 0)
                {
                    if (OrdenarArchivosPorFecha)
                    {
                        foreach (FileInfo fi in dire.GetFiles().Select(fn => fn).OrderByDescending(f => f.LastWriteTime ))
                        {
                            Elemento el = new Elemento(fi.Name, Elemento.tipo.archivo);
                            cmbRutas.Items.Add(el);
                        }
                    }
                    else
                    {
                        foreach (FileInfo fi in dire.GetFiles())
                        {
                            Elemento el = new Elemento(fi.Name, Elemento.tipo.archivo);
                            cmbRutas.Items.Add(el);
                        }

                    }
                }
            }
            catch (Exception e) 
            {
                
            }
        }

        private void cmbRutas_Enter(object sender, EventArgs e)
        {
            cmbRutas.DroppedDown = true;
        }

        private void cmbRutas_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {

                case Keys.Delete:
                    if (lista.Count > -1)
                    {

                        lista.Pop();
                        CargarRutaTotalActual();
                        CargarRuta();
                        ArchivoSeleccionado = false;
                        this.Text = "Seleccione unidad, carpetas y archivo pulsando las primeras letras del combo y ESPACIO toma la ruta";
                    }
                    break;
                case Keys.Space :
                    if (!ArchivoSeleccionado)
                    {
                        if (cmbRutas.SelectedItem != null)
                        {
                            Elemento el = (Elemento)cmbRutas.SelectedItem;
                            lista.Push(el);
                            if (el.es == Elemento.tipo.archivo)
                            {
                                ArchivoSeleccionado = true;
                                this.Text = "Archivo seleccionado";
                            }
                            else
                            {
                                ArchivoSeleccionado = false;
                                this.Text = "Seleccione unidad, carpetas y archivo pulsando las primeras letras del combo y ESPACIO toma la ruta";
                            }
                            CargarRutaTotalActual();

                            if (EsRutaValida(txtRutaCompleta.Text))
                            {

                                CargarRuta();

                            }

                        }
                    }
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
                case Keys.Enter:
                    string NombreArchivoSeleccionado = txtRutaCompleta.Text.Substring(txtRutaCompleta.Text.LastIndexOf("\\") + 1);
                    ((frmArchivos)Owner).AsignarRutaYNombreArchivo(txtRutaCompleta.Text, NombreArchivoSeleccionado);
                    this.Close();

                    break;

            }
            if (e.Control == true && e.KeyCode == Keys.D1)
            {
                OrdenarArchivosPorFecha = true;
                CargarRuta();
                ArchivoSeleccionado = false;
                this.Text = "Seleccione unidad, carpetas y archivo pulsando las primeras letras del combo y ESPACIO toma la ruta";
            }
                

        }

        private bool EsRutaValida(string ruta)
        {
            bool resultado = false;
            try
            {
                DirectoryInfo di = new DirectoryInfo(ruta);
                if (di.Exists)
                    resultado = true;
            }
            catch (Exception e) { }
            return resultado;
        }
        private void CargarRutaTotalActual()
        {
            txtRutaCompleta.Text = "";

            string separador = @"\";
            foreach (Elemento e in lista.Reverse())
            {
                if (e.es == Elemento.tipo.archivo)
                    separador = "";
                txtRutaCompleta.Text += e.nombre  + separador;
            }
            

        }

        private void txtRutaCompleta_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter :
                    string NombreArchivoSeleccionado = txtRutaCompleta.Text.Substring(txtRutaCompleta.Text.LastIndexOf("\\") + 1);
                    ((frmArchivos)Owner).AsignarRutaYNombreArchivo(txtRutaCompleta.Text, NombreArchivoSeleccionado);
                    this.Close();
                    break;
            }
        }



     



    }
}
