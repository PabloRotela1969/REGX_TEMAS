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

    public partial class frmDirectorio : Form
    {
        public frmDirectorio()
        {
            InitializeComponent();
            string rutaPorDefecto = @"C:\REGX";
            CargarListaCarpetas(rutaPorDefecto);
            CargarListaArchivos(rutaPorDefecto);
            dgCarpetas.Focus();
        }

        public frmDirectorio(string rutaInicial)
        {
            InitializeComponent();
            CargarListaCarpetas(rutaInicial);
            rutaInicial = rutaInicial + @"\" +  TomarLaPrimerCarpeta();
            CargarListaArchivos(rutaInicial);
            dgArchivos.Focus();
        }

        private void frmDirectorio_Load(object sender, EventArgs e)
        {
     

        }
        static int filaCarpeta;
        static int columnaCarpeta;
        string PorDefecto = @"C:\REGX";

        static int filaArchivo;
        static int columnaArchivo;

        private string _nombreArchivoSeleccionado;
        public string NombreArchivoSeleccionado
        {
            get { return _nombreArchivoSeleccionado; }
            set { _nombreArchivoSeleccionado = value; }
        }

        private string _rutaArchivoSeleccionado;
        public string RutaArchivoSeleccionado
        {
            get { return _rutaArchivoSeleccionado; }
            set { _rutaArchivoSeleccionado = value; }
        }

        List<FileInfo> ListaArchivos = new List<FileInfo>();
        List<DirectoryInfo> columnaNombre = new List<DirectoryInfo>();

        /// <summary>
        /// Si no le paso una ruta existente , asume la del principal
        /// </summary>
        /// <param name="directorioInicial"></param>
        /// <returns>siempre emite una ruta</returns>
        private DirectoryInfo ExisteLaRuta(string directorioInicial)
        {
            DirectoryInfo dire = new DirectoryInfo(directorioInicial);
            if (dire.Exists)
            {
                return dire;
            }
            else
            {
                DirectoryInfo dire1 = new DirectoryInfo(PorDefecto);
                return dire1;
            }
        }

        private void CargarListaCarpetas(string directorioInicial)
        {
            DirectoryInfo dir = ExisteLaRuta(directorioInicial);
            try
            {
                if (dir.GetDirectories().Length == 0)
                    dir = dir.Parent;

                columnaNombre.Clear();
                columnaNombre.AddRange(dir.GetDirectories().OrderByDescending(f => f.LastWriteTime));
                dgCarpetas.DataSource = null;
                dgCarpetas.DataSource = columnaNombre;
                

            }
            catch (UnauthorizedAccessException acceso)
            {
                MessageBox.Show("Hay problemas de autorización para esta carpeta " + directorioInicial + " excep : " + acceso.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        
        }

        private string TomarLaPrimerCarpeta()
        {
            string valor = "";
            if (this.dgCarpetas.Rows[0].Cells[0].Value.ToString() != "")
            {
                valor = this.dgCarpetas.Rows[0].Cells[0].Value.ToString();
                this.dgCarpetas.Rows[0].Cells[0].Selected = true;
            }
            return valor;
        }

        private void CargarListaArchivos(string ruta)
        {
            int cantidadTope = 60;
            DirectoryInfo dir = new DirectoryInfo(ruta);
            
            try
            {
                ListaArchivos.Clear();

                ListaArchivos.AddRange(dir.GetFiles().OrderByDescending(f => f.CreationTime ));
                dgArchivos.Rows.Clear();
                dgArchivos.ColumnCount = 4;
                dgArchivos.Columns[0].Name = "Nombre";
                dgArchivos.Columns[1].Name = "Ultima escritura";
                dgArchivos.Columns[2].Name = "Creación";
                dgArchivos.Columns[3].Name = "Ruta completa";
                foreach (FileInfo fi in ListaArchivos)
                {
                    dgArchivos.Rows.Add(fi.Name,fi.LastWriteTime,fi.CreationTime,fi.FullName );
                    if (cantidadTope == 0) 
                        break;
                    else
                        cantidadTope -= 1;
                }

            }
            catch (Exception ex)
            {

            }
        }



 

        private void dgCarpetas_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            filaCarpeta = e.RowIndex;
            columnaCarpeta = e.ColumnIndex;

        }

        private void dgCarpetas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string ruta = dgCarpetas.Rows[filaCarpeta].Cells["fullname"].Value.ToString();
            DirectoryInfo dir = new DirectoryInfo(ruta);
            if (columnaCarpeta == 1)
            {
                ruta = ruta.Substring(0, ruta.LastIndexOf(@"\"));
                CargarListaCarpetas(ruta);
                CargarListaArchivos(ruta);
            }
            else
            {
                if (dir.GetDirectories().Length > 0)
                {

                        CargarListaCarpetas(ruta);
                        CargarListaArchivos(ruta);

                }
                else
                {
                    CargarListaArchivos(ruta);
                }
            }

        }


        private string cadena;
        private void dgCarpetas_KeyDown(object sender, KeyEventArgs e)
        {
            
            switch (e.KeyData )
            {
                case Keys.Home:
                    dgCarpetas.CurrentCell = dgCarpetas.Rows[0].Cells[0];
                    break;
                case Keys.Delete :
                    cadena = "";
                    dgCarpetas.CurrentCell = null;
                    break;
                case Keys.End:
                    dgCarpetas.CurrentCell = dgCarpetas.Rows[dgCarpetas.Rows.Count - 1].Cells[0];
                    dgCarpetas.CurrentCell = dgCarpetas.Rows[dgCarpetas.Rows.Count - 1].Cells[0];
                    break;
                case Keys.Escape :
                    this.Close();
                    break;
                case Keys.Enter:
                    cadena = "";
                    string ruta = dgCarpetas.Rows[filaCarpeta].Cells["fullname"].Value.ToString();
                    DirectoryInfo dir = new DirectoryInfo(ruta);
                    if (columnaCarpeta == 1)
                    {
                        ruta = ruta.Substring(0, ruta.LastIndexOf(@"\"));
                        CargarListaCarpetas(ruta);
                        CargarListaArchivos(ruta);
                    }
                    else
                    {
                        if (dir.GetDirectories().Length > 0)
                        {

                            CargarListaCarpetas(ruta);
                            CargarListaArchivos(ruta);

                        }
                        else
                        {
                            CargarListaArchivos(ruta);
                        }
                    }
                    break;
                case Keys.Tab :
                    cadena = "";
                    dgArchivos.Focus();
                    dgCarpetas.ClearSelection();
                    dgCarpetas.Refresh();
                    
                    break;
                case Keys.F5:
                    
                    CargarListaCarpetas(PorDefecto);
  
                    break;
                default :
                    if (e.KeyValue >= 65)
                    {
                       
                        cadena += Convert.ToChar(e.KeyValue).ToString();
                        PosicionarEnDirectorio(cadena);
                    }
                    break;
            }

        }



        private void PosicionarEnDirectorio(string nombre)
        {
            int contador = 0;
            int largoNombreLista = 0;
            int largoNombreParametro = nombre.Length;;
            string nombreLista = "";

            foreach (DirectoryInfo di in columnaNombre)
            {
                largoNombreLista = di.Name.Length;

                if (largoNombreLista >= largoNombreParametro)
                    nombreLista = di.Name.Substring(0, nombre.Length);
                else
                    nombreLista = di.Name;

                if (nombreLista == nombre)
                {
                    if (contador < 0)
                        contador = 0;

                    if (contador >= dgCarpetas.Rows.Count)
                        contador = dgCarpetas.Rows.Count - 1;

                    dgCarpetas.CurrentCell = dgCarpetas.Rows[contador].Cells[0];
                    dgCarpetas.Refresh();
                }
                contador++;
            }
        }

        private void dgArchivos_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Enter:
                    RutaArchivoSeleccionado = dgArchivos.Rows[filaArchivo].Cells[3].Value.ToString();
                    NombreArchivoSeleccionado = dgArchivos.Rows[filaArchivo].Cells[0].Value.ToString();
              
                    ((frmArchivos)Owner).AsignarRutaYNombreArchivo(RutaArchivoSeleccionado, NombreArchivoSeleccionado);

                    this.Close();
                    break;
                
                case Keys.Tab:
                    this.dgCarpetas.Focus();
                    dgArchivos.CurrentCell = null;
                    
                    break;
                case Keys.F12:
                    RutaArchivoSeleccionado = dgArchivos.Rows[filaArchivo].Cells[3].Value.ToString();
                    NombreArchivoSeleccionado = dgArchivos.Rows[filaArchivo].Cells[0].Value.ToString();
                    System.Diagnostics.Process.Start(RutaArchivoSeleccionado);
                    break;
                case Keys.Escape :
                    this.Close();
                    break;
                case Keys.Insert :
                    if (dgArchivos.GetCellCount(DataGridViewElementStates.Selected) > 0)
                    {
                        Clipboard.SetDataObject(this.dgArchivos.GetClipboardContent());
                    }
                    break;
            }

        }

        private void dgCarpetas_Enter(object sender, EventArgs e)
        {
            cadena = "";
            dgCarpetas.DefaultCellStyle.BackColor = Color.LightYellow;
            dgArchivos.DefaultCellStyle.BackColor = Color.White;
        }

        private void dgArchivos_Enter(object sender, EventArgs e)
        {
            dgCarpetas.DefaultCellStyle.BackColor = Color.White;
            dgArchivos.DefaultCellStyle.BackColor = Color.LightYellow;
        }

        private void dgArchivos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            filaArchivo = e.RowIndex;
            columnaArchivo = e.ColumnIndex;
        }



    }
}
