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
    public partial class frmArchivosDesvinculados : Form
    {
        public frmArchivosDesvinculados()
        {
            InitializeComponent();
            VerficarDesdeTablasExistenArchivos();
        }

        #region METODOS_OPERATIVOS
        private void VerficarDesdeTablasExistenArchivos()
        {
            Clases.Archivos arch = new Clases.Archivos();
            DataTable tabla = arch.TraerRegistros();
            foreach (DataRow archivo in tabla.Rows)
            {
                //DirectoryInfo dir = new DirectoryInfo(archivo["ruta"].ToString());
                try
                {
                    
                    FileInfo file = new FileInfo(archivo["__________________________________________________________RUTA__________________________________________________________________"].ToString());
                    if (!file.Exists)
                    {
                        lstResultados.Items.Add(archivo["__________________________________________________________RUTA__________________________________________________________________"].ToString());
                    }
                }
                catch (PathTooLongException muylargo)
                {
                }
                catch (NotSupportedException nosoportado)
                {
                }
                catch (ArgumentException argu)
                {
                }


            }
            

        }

        private void IrAlSubDirectorio(string ruta)
        {
            string rutasola = ruta.Substring(0, ruta.LastIndexOf(@"\"));
            try
            {
                System.Diagnostics.Process.Start(rutasola);
            }
            catch (Exception exc)
            {
                MessageBox.Show("No existe la ruta : " + rutasola);
            }
        }

        #endregion


        private void lstResultados_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyData )
            {
                case Keys.F11:
                    VerficarDesdeTablasExistenArchivos();
                    break;
                case Keys.Enter :
                    IrAlSubDirectorio(lstResultados.SelectedItem.ToString());
                break;
                case Keys.Right :
                Clipboard.SetData(DataFormats.Text, (Object) lstResultados.SelectedItem.ToString());

                break;
                case Keys.Escape :
                this.Close();
                break;
            }

        }
    }
}
