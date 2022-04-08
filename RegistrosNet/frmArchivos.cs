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
    public delegate void ActualizarArchivo(string nombre);
    public partial class frmArchivos : Form
    {

        private int _idArchivo;
        public int IDarchivo
        {
            get { return _idArchivo; }
            set { _idArchivo = value; }
        }
        private string _nombreArchivo;
        public string NOMBREarchivo
        {
            get { return _nombreArchivo; }
            set { _nombreArchivo = value; }
        }

        private string _rutaArchivo;
        public string RUTAarchivo
        {
            get { return _rutaArchivo; }
            set { _rutaArchivo = value; }
        }


        public frmArchivos()
        {
            InitializeComponent();
        }

        string objetoSeleccionado = "";
        int fila;
        int columna;

        Clases.Archivos ar = new Clases.Archivos();
        frmDirectorio dir = null;


        private void frmArchivos_Load(object sender, EventArgs e)
        {
            
            try
            {
                if (this.Owner.Name == "frmRegistros")
                {

                    this._idArchivo = ((frmRegistros)this.Owner).idTextoArchivos;
                    this.txtRuta.Text = ((frmRegistros)this.Owner).TextoRuta;
                    this.txtNombre.Text = ((frmRegistros)this.Owner).TextoArchivos;
                    ObjetoSeleccionadoReconocible();
                    /// Si tengo un idArchivo es que tengo un registro para mostrar en la grilla
                    /// si por el contrario , si no tengo ningùn archivo voy a buscar todo archivo reciente en la ruta del catálogo 
                    /// del objeto registrado con ruta, para acelerar la búsqueda, en caso de no estar catalogado, busca en todo el àrbol
                    /// de carpetas
                    if (_idArchivo > 0)
                        CargarGrilla();
                    else
                    {
                        //if ( objetoSeleccionado != @"C:\REGX\")
                        //{
                        //    dir = new frmDirectorio(objetoSeleccionado);
                        //    dir.Show(this);
                        //    dir.Focus();
                        //}
                        //else
                        //{
                            if ( ((frmRegistros)this.Owner).ArchivosRecientes.Count > 0 )
                                CargarGrillaConArchivosDeUltimaHora();
                        //}
                    }
                       
                }
            }
            catch(Exception excep)
            {
                // viene desde directorio
            }


        }

        private void CargarGrillaConArchivosDeUltimaHora()
        {
            

            //List<FileInfo> listaArchivos = BuscarUltimosArchivos(@"c:\REGX", false);
           
            int indice = 0;
           
            dgResultado.Columns.Add("Nombre", "Nombre");
            dgResultado.Columns.Add("Ruta", "Ruta");
            dgResultado.Columns.Add("Fecha Modifica", "Fecha Modifica");
            dgResultado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgResultado.Columns[0].Width = 240;
            dgResultado.Columns[1].Width = 440;
            dgResultado.Columns[2].Width = 120;
            foreach (FileInfo archivo in ((frmRegistros)Owner).ArchivosRecientes)
            {

                dgResultado.Rows.Insert(indice, archivo.Name, archivo.FullName, archivo.LastAccessTime);
                
                indice++;


            }
            //((frmRegistros)this.Owner).ArchivosRecientes.Clear();
        }

        private void CargarGrilla()
        {

            CargarEntidad();
            DataTable tabla = ar.TraerRegistros();
            dgResultado.DataSource = tabla;
            if (tabla.Rows.Count == 1)
            {
                CargarCamposDesdeGrillaFila(0);
                CargarCamposDesdeEntidad();
            }
        }




        private void CargarEntidad()
        {
            ar.Nombre = txtNombre.Text;
            ar.IdTipo = (0);
            ar.Ruta = txtRuta.Text;
            ar.Descripcion = txtDescrip.Text;

        }

        private void CargarCamposDesdeEntidad()
        {
            txtNombre.Text = ar.Nombre;
            txtRuta.Text = ar.Ruta;
            txtDescrip.Text = ar.Descripcion;
            txtNombre.Focus();
        }

        private void LimpiarCampos()
        {
            ar.IdArch = 0;
            ar.IdTipo = 0;
            ar.FechaCambio = "";
            txtNombre.Text = "";
             txtRuta.Text = "";
            txtDescrip.Text = "";
        }


        private void EventosKeyDown(KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 13:
                    CargarEntidad();
                    int nuevoIndice = ar.GuardaArchivo();
                    ((frmRegistros)this.Owner).TextoArchivos = ar.Nombre;
                    ((frmRegistros)this.Owner).idTextoArchivos = nuevoIndice;
                    this.Close();
                    break;
                case 27:
                    this.Close();
                    break;
                case 36:
                    txtNombre.Focus();
                    break;
                case 40:
                    dgResultado.Focus();
                    break;

                case 112:
                    CargarEntidad();
                    ((frmRegistros)this.Owner).idTextoArchivos = ar.GuardaArchivo();
                    ((frmRegistros)this.Owner).TextoArchivos = ar.Nombre;
                    LimpiarCampos();
                    CargarGrilla();
                    break;
                case 113:
                    CargarEntidad();
                    if ( ar.IdArch == 0 )
                    {
                        MessageBox.Show("No hay indice para modificar el archivo");
                    }
                    else
                    {
                        ar.ModificarArchivo();
                        ((frmRegistros)this.Owner).idTextoArchivos = ar.IdArch;
                        ((frmRegistros)this.Owner).TextoArchivos = ar.Nombre;
                        LimpiarCampos();
                        CargarGrilla();
                    }

                    break;
                case 114:
                    CargarEntidad();
                    if ( ar.IdArch == 0 )
                    {
                        MessageBox.Show("No hay indice para borrar el archivo ");

                    }
                    else
                    {

                        ar.BorrarArchivo();
                        DialogResult resultado = MessageBox.Show("Borra Archivo asociado?", "VERIFICAR", MessageBoxButtons.YesNo);
                        if ( resultado == DialogResult.Yes)
                        {
                            try
                            {
                                System.IO.File.Delete(ar.Ruta);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("el archivo " + ar.Ruta + " no se encuentra");
                            }
                        }

                        LimpiarCampos();
                        CargarGrilla();
                    }

                    break;
                case 115:
                    LimpiarCampos();
                    ((frmRegistros)this.Owner).ArchivosRecientes.Clear();
                    break;
                case 116:
                    CargarGrilla();
                    break;

                case 118:
                    // F7 = EDITAR TIPOS
                    frmTipos ti = new frmTipos();
                    ti.Show(this);
                    break;

            }
        }

        private void CargarCamposDesdeGrillaFila(int f)
        {
            if (dgResultado.Rows[f].Cells[0].Value != null)
            {
                ar.IdArch = Utilidades.IntDeColumna(dgResultado, f, 5);
                ar.Nombre = Utilidades.StringDeColumna(dgResultado, f, 0);
                ar.Ruta = Utilidades.StringDeColumna(dgResultado, f, 1);
                ar.Descripcion = Utilidades.StringDeColumna(dgResultado, f, 2);
                ar.FechaCambio = Utilidades.StringDeColumna(dgResultado, f, 3);
            }
        }

        private void CargarCamposDesdeGrillaAFilaEnUltimos(int fila)
        {
            if (dgResultado.Rows[fila].Cells[0].Value != null)
            {
                ar.Nombre = Utilidades.StringDeColumna(dgResultado, fila, 0);
                ar.Ruta = Utilidades.StringDeColumna(dgResultado, fila, 1);
                ar.FechaCambio = Utilidades.StringDeColumna(dgResultado, fila, 2);
            }
        }

        private void dgResultado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space )
            {
                int f = fila;
                if (_idArchivo > 0)
                    CargarCamposDesdeGrillaFila(f);
                else
                    CargarCamposDesdeGrillaAFilaEnUltimos(f);

                CargarCamposDesdeEntidad();

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

            switch (e.KeyValue)
            {
                case 36:
                    txtNombre.Focus();
                    break;

            }
        }



        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            EventosKeyDown(e);
        }



        private void cmbtipo_KeyDown(object sender, KeyEventArgs e)
        {
            EventosKeyDown(e);
        }



        private void txtRuta_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.F9)
            {
                string carpetaDelArchivo = DevolverRutaDelArchivo(txtRuta.Text);

                System.Diagnostics.Process.Start(carpetaDelArchivo);
            }
            if (e.KeyCode == Keys.F8)
            {

                SeleccionarArchivosPorDialogo();
                txtNombre.Text = NOMBREarchivo;

            }
            EventosKeyDown(e);


            
        }

        private string DevolverRutaDelArchivo(string archivo)
        {
            string ruta = "";
            int ultimaAparicionDeBarraDerecha = archivo.LastIndexOf('/');
            int ultimaAparicionDeBarraIzquierda = archivo.LastIndexOf('\\');
            if (ultimaAparicionDeBarraDerecha > 0)
                ruta = archivo.Substring(0, ultimaAparicionDeBarraDerecha);
            else
                ruta = archivo.Substring(0, ultimaAparicionDeBarraIzquierda);

            return ruta;

        }

        private void ObjetoSeleccionadoReconocible()
        {
           
            try
            {
                objetoSeleccionado = Utilidades.ConsultarRutasRelativas(((frmRegistros)this.Owner).TextoTemas);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problemas en SeleccionarArchivosPorDialogo en frmArchivos , error :" + ex.Message);
            }
            
        }

        private void SeleccionarArchivosPorDialogo()
        {

            //frmDirectorio dir = new frmDirectorio(objetoSeleccionado);
            //frmDirectorioCombos dir = new frmDirectorioCombos(objetoSeleccionado);
            //dir.ShowDialog(this);            
            //dir.Focus();
            frmDirSeleccionarUnArchivo dir = new frmDirSeleccionarUnArchivo();
            dir.ShowDialog(this);
            dir.Focus();

        }

        public void AsignarRutaYNombreArchivo(string ruta, string nombre)
        {
            this.txtRuta.Text = ruta;
            this.txtNombre.Text = nombre;
            NOMBREarchivo = nombre;
        }

        private void txtDescrip_KeyDown(object sender, KeyEventArgs e)
        {

            EventosKeyDown(e);
        }



        private void txtNombre_MouseHover(object sender, EventArgs e)
        {
           
            ttCarteles.Show("F6 o ENTER para insertar en Registros, F7 = editar Tipos ", this, 3000);
        }





         private void txtRuta_MouseHover(object sender, EventArgs e)
        {
            ttCarteles.Show("F8 = dialogo mostrando filesistem , F9 = CARPETA DE LA RUTA",txtRuta ,3000);
        }

         private void CargarTreeViewCarpetas(string dir , TreeNode nodo)
         {
             DirectoryInfo directorio = new DirectoryInfo(dir);
             foreach (DirectoryInfo info in directorio.GetDirectories())
             {
                 TreeNode n = new TreeNode(info.Name);
                 CargarTreeViewCarpetas(info.FullName , n);
                 nodo.Nodes.Add(n);
             }
         }

         private void txtRuta_Enter(object sender, EventArgs e)
         {
             ttCarteles.Show("F8 = dialogo mostrando filesistem , F9 = CARPETA DE LA RUTA", txtRuta, 3000);
             txtRuta.BackColor = Color.Black;
             txtRuta.ForeColor = Color.White;
            if (dir != null)
                dir.Focus();
             
         }

         private void txtRuta_Leave(object sender, EventArgs e)
         {
             txtRuta.BackColor = Color.White;
             txtRuta.ForeColor = Color.Black;
            if (dir != null)
                dir.Focus();
        }

         private void txtDescrip_Enter(object sender, EventArgs e)
         {
             ttCarteles.Show("F1 = nuevo Archivo , F2 = modifica archivo , F3 = Borra archivo", txtDescrip, 3000);
             txtDescrip.BackColor = Color.Black;
             txtDescrip.ForeColor = Color.White;
            if (dir != null)
                dir.Focus();
        }

         private void txtDescrip_Leave(object sender, EventArgs e)
         {
             txtDescrip.BackColor = Color.White;
             txtDescrip.ForeColor = Color.Black;
            if (dir != null)
                dir.Focus();
        }

         private void txtNombre_Enter(object sender, EventArgs e)
         {
             ttCarteles.Show("F1 = nuevo Archivo , F2 = modifica archivo , F3 = Borra archivo", txtNombre, 3000);
             txtNombre.BackColor = Color.Black;
             txtNombre.ForeColor = Color.White;
            if (dir != null)
                dir.Focus();
        }

         private void txtNombre_Leave(object sender, EventArgs e)
         {

             txtNombre.BackColor = Color.White;
             txtNombre.ForeColor = Color.Black;
            if (dir != null)
                dir.Focus();
        }



 
        public List<FileInfo> BuscarUltimosArchivos(string root, bool EsDeCreacion)
        {
            List<FileInfo> rutas = new List<FileInfo>();
            DateTime ahora = DateTime.Now;

            // Data structure to hold names of subfolders to be
            // examined for files.
            Stack<string> dirs = new Stack<string>(20);

            if (!System.IO.Directory.Exists(root))
            {
                throw new ArgumentException();
            }
            dirs.Push(root);

            while (dirs.Count > 0)
            {
                string currentDir = dirs.Pop();
                string[] subDirs;
                try
                {
                    subDirs = System.IO.Directory.GetDirectories(currentDir);
                }
                // An UnauthorizedAccessException exception will be thrown if we do not have
                // discovery permission on a folder or file. It may or may not be acceptable 
                // to ignore the exception and continue enumerating the remaining files and 
                // folders. It is also possible (but unlikely) that a DirectoryNotFound exception 
                // will be raised. This will happen if currentDir has been deleted by
                // another application or thread after our call to Directory.Exists. The 
                // choice of which exceptions to catch depends entirely on the specific task 
                // you are intending to perform and also on how much you know with certainty 
                // about the systems on which this code will run.
                catch (UnauthorizedAccessException e)
                {
                    //Console.WriteLine(e.Message);
                    continue;
                }
                catch (System.IO.DirectoryNotFoundException e)
                {
                    //Console.WriteLine(e.Message);
                    continue;
                }

                string[] files = null;
                try
                {
                    files = System.IO.Directory.GetFiles(currentDir);
                }

                catch (UnauthorizedAccessException e)
                {

                    //Console.WriteLine(e.Message);
                    continue;
                }

                catch (System.IO.DirectoryNotFoundException e)
                {
                    //Console.WriteLine(e.Message);
                    continue;
                }
                // Perform the required action on each file here.
                // Modify this block to perform your required task.
                foreach (string file in files)
                {
                    try
                    {
                        // Perform whatever action is required in your scenario.
                        System.IO.FileInfo fi = new System.IO.FileInfo(file);
                        //Console.WriteLine("{0}: {1}, {2}", fi.Name, fi.Length, fi.CreationTime);
                        if (EsDeCreacion)
                        {
                            if (fi.CreationTime.Year.Equals(ahora.Year) && fi.CreationTime.Month.Equals(ahora.Month) && fi.CreationTime.Day.Equals(ahora.Day) && fi.CreationTime.Hour.Equals(ahora.Hour))
                                rutas.Add(fi);
                        }
                        else
                        {
                            if (fi.LastWriteTime.Year.Equals(ahora.Year) && fi.LastWriteTime.Month.Equals(ahora.Month) && fi.LastWriteTime.Day.Equals(ahora.Day) && fi.LastWriteTime.Hour.Equals(ahora.Hour))
                                rutas.Add(fi);
                        }

                    }
                    catch( System.IO.PathTooLongException r)
                    {
                        continue;
                    }
                    catch (System.IO.FileNotFoundException e)
                    {
                        // If file was deleted by a separate application
                        //  or thread since the call to TraverseTree()
                        // then just continue.
                       // Console.WriteLine(e.Message);
                        continue;
                    }
                }

                // Push the subdirectories onto the stack for traversal.
                // This could also be done before handing the files.
                foreach (string str in subDirs)
                    dirs.Push(str);
            }
            return rutas;
        }

    }
}
