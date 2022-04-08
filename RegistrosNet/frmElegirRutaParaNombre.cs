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
    public partial class frmElegirRutaParaNombre : Form
    {
        public frmElegirRutaParaNombre()
        {
            InitializeComponent();
            CargarRuta();
        }

        private string ArchivoNombre;

        public frmElegirRutaParaNombre(string nombreArchivo)
        {
            InitializeComponent();

            CargarRutaPorDefecto(nombreArchivo);
            CargarRuta();
            CargarRutaTotalActual();
        }

        Stack<Elemento> lista = new Stack<Elemento>();
        int tope = 0;
        int contador = 0;
        private void CargarRutaPorDefecto(string cadena)
        {
            if (cadena != null)
            {
                if (cadena.Contains(":"))
                {
                    char separador = '\\';
                    string[] arrai = cadena.Split(separador);
                    tope = arrai.Length - 1;
                    foreach (string parte in arrai)
                    {
                        Elemento nuevo;
                        if (parte.Contains(":"))
                            nuevo = new Elemento(parte, Elemento.tipo.unidad);
                        else
                            nuevo = new Elemento(parte, Elemento.tipo.carpeta);

                        if (contador < tope )
                            lista.Push(nuevo);

                        contador++;
                    }
                    ArchivoNombre = arrai[arrai.Length - 1];
                }
            }
        }

        private void CargarRuta()
        {
            if (lista.Count == 0)
            {
                CargarUnidadesCombo();
            }
            else
            {

                    CargarRutaTotalActual();
                    CargarDirectoriosCombo(CargarRutaTotalActual());
                    

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
                        Elemento el = new Elemento(di.Name, Elemento.tipo.carpeta);
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




        private string CargarRutaTotalActual()
        {
            txtRutaCompleta.Text = "";
            string rutaSolamente = "";
            string separador = @"\";
            foreach (Elemento e in lista.Reverse())
            {
                rutaSolamente += e.nombre + separador;
                txtRutaCompleta.Text += e.nombre + separador;
            }
            txtRutaCompleta.Text += ArchivoNombre;
            return rutaSolamente;

        }

        private void cmbRutas_Enter(object sender, EventArgs e)
        {
            cmbRutas.DroppedDown = true;
        }

        private void cmbRutas_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape :
                    this.Close();
                    break;
                case Keys.Space:
                    if (cmbRutas.SelectedItem != null)
                    {
                        lista.Push((Elemento)cmbRutas.SelectedItem);
                        CargarRuta();
                        
                    }
                    break;
                case Keys.Enter:
                     switch (this.Owner.Name)
                    {
                        case "frmNotas":
                            ((frmNotas)Owner).NombreArchivoASalvar = txtRutaCompleta.Text;
                            break;
                        case "frmClipGraf":
                            ((frmClipGraf)Owner).NombreArchivoASalvar = txtRutaCompleta.Text;
                            break;
                    }
                    this.Close();
                    break;
                case Keys.Delete:
                    lista.Pop();
                    CargarRuta();
                    break;
            }

        }

        private void txtRutaCompleta_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode )
            {
                case Keys.Enter:
                    
                    switch (this.Owner.Name)
                    {
                        case "frmNotas":
                            ((frmNotas)Owner).NombreArchivoASalvar = txtRutaCompleta.Text;
                            break;
                        case "frmClipGraf":
                            ((frmClipGraf)Owner).NombreArchivoASalvar = txtRutaCompleta.Text;
                            break;
                    }
                    this.Close();
                    break;
                case Keys.Insert:
                    string nombre = txtRutaCompleta.Text.Substring(txtRutaCompleta.Text.LastIndexOf(@"\") + 1) + "*";
                    BuscarArchivosSimilares(CargarRutaTotalActual(), nombre);
                    cmbRutas.DroppedDown = true;
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
 
             
            }
        }


        private void txtRutaCompleta_Enter(object sender, EventArgs e)
        {
            txtRutaCompleta.SelectionStart = txtRutaCompleta.Text.Length;
        }


        private void BuscarArchivosSimilares(string ruta,string archivo)
        {
            try
            {
                cmbRutas.Items.Clear();
                DirectoryInfo dire = new DirectoryInfo(ruta);
                if (dire.GetFiles().Length > 0)
                {
                    
                    foreach (FileInfo fi in dire.GetFiles(archivo ).Select(fn => fn).OrderByDescending(f => f.LastWriteTime))
                    {
                        Elemento el = new Elemento(fi.Name, Elemento.tipo.archivo);
                        cmbRutas.Items.Add(el);
                    }

                }
            }
            catch (Exception e)
            {

            }
        }

        private void txtRutaCompleta_TextChanged(object sender, EventArgs e)
        {
                
        }


    }
}
