using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Reflection;

namespace RegistrosNet
{


    public static class Utilidades
    {
        public static void SeleccionarPorIndice(ComboBox combo, int indice)
        {
            if (combo.Items.Count > 0)
            {
                if (indice > 0)
                {
                    combo.SelectedIndex = -1;
                    try
                    {
                        combo.SelectedValue = indice;
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("El combo " + combo.Name + " arrojó la excepcion  " + ex.Message + " tratando de buscar el indice SeleccionarPorIndice " + indice.ToString());
                    }

                }
                else
                {
                    MessageBox.Show("Falta un indice mayor a 0 , SeleccionarPorIndice");
                }

            }
            else
            {
                MessageBox.Show("El combo " + combo.Name + " está descargado, SeleccionarPorIndice");

            }
        }


        public static void SeleccionarPorValor(ComboBox combo, string valor)
        {
            if ( combo.Items.Count > 0 )
            {
                combo.SelectedIndex = IndiceDelValor(combo, valor);
                //combo.SelectedText = valor;
            }
        }

        public static int IndiceDelValor(ComboBox combo, string valor)
        {

            int i = 0;
            foreach (DataRowView item in combo.Items)
            {
                if (item[1].ToString().Equals(valor))
                    break;
                i++;
            }

            return i;
        }

        public static string RutaDeLaDLL()
        {
            int hasta = Assembly.GetExecutingAssembly().Location.LastIndexOf(@"\") + 1;
            string ruta = Assembly.GetExecutingAssembly().Location.Substring(0, hasta);
            return ruta;
        }

        public static string Obtener_Unidad_y_REGX_de_dll()
        {
            return RutaDeLaDLL().Substring(0, 7);
        }


        public static string ConsultarRutasRelativas(string texto)
        {
            string objetoSeleccionado = "";
            DataSet ds = new DataSet();
            string ruta = RutaDeLaDLL();
            string unidad = ruta.Substring(0, 2);
            try
            {
                ds.ReadXml(ruta + @"RutasRelativas.xml");
                foreach (DataRow fila in ds.Tables[0].Rows)
                {
                    if (fila["Objeto"].ToString() == texto)
                        objetoSeleccionado = fila["Ruta"].ToString();
                }
            }
            catch (Exception es)
            {
                MessageBox.Show("Error en ConsultarRutasRelativas por " + es.Message );
            }
            return unidad + @"\REGX\" + objetoSeleccionado;
        }


        public static void SalvarRTF(RichTextBox rtfb, string NombreArchivo)
        {
            
            string rutaArchivo = RutaDeLaDLL() + NombreArchivo;
            try
            {
                rtfb.SaveFile(rutaArchivo);
            }
            catch (Exception exec)
            {
                MessageBox.Show("Problemas para escribir a " + rutaArchivo + " el contenido " + rtfb.Text  + " : " + exec.Message);
            }
        }

        public static RichTextBox CargarRTF(RichTextBox rtbf, string NombreArchivo)
        {
            string rutaArchivo = RutaDeLaDLL() + NombreArchivo;
            try
            {
                rtbf.LoadFile(NombreArchivo);
            }
            catch(Exception ex )
            {
                MessageBox.Show("Problemas para leer desde " + rutaArchivo + " : , LeerArchivo " + ex.Message);
            }
            return rtbf;
        }


        public static void EscribirAArchivo(string NombreArchivo, string contenido)
        {
            StreamWriter escritor = null;
            string rutaArchivo = RutaDeLaDLL() + NombreArchivo;
            try
            {
                escritor = new StreamWriter(rutaArchivo);
                escritor.Write(contenido);
                
                escritor.Flush();
            }
            catch (Exception es)
            {
                MessageBox.Show("Problemas para escribir a " + rutaArchivo + " el contenido " + contenido + " : " + es.Message );
            }
            finally
            {
                escritor.Close();
            }
        }


        public static string LeerArchivo(string NombreArchivo)
        {
            string contenido = "";
            StreamReader lector = null;
            string rutaArchivo = RutaDeLaDLL() + NombreArchivo;
            try
            {
                lector = new StreamReader(rutaArchivo, true);
                contenido = lector.ReadToEnd();
            }
            catch (Exception es)
            {
                MessageBox.Show("Problemas para leer desde " + rutaArchivo + " : , LeerArchivo " + es.Message);
            }
            finally
            {
                lector.Close();
            }
            return contenido;
        }




        public static DataTable AgregarFilaVaciaInicial(DataTable d)
        {
            DataTable tabla = new DataTable();

            tabla = d.Clone();
            DataRow fila = tabla.NewRow();
            for (int i = 0; i <= d.Columns.Count - 1; i++)
            {
                try
                {
                    fila[i] = "";
                   
                }
                catch (ArgumentException e)
                {
                    try
                    {
                        fila[i] = 0;
                    }
                    catch (Exception ex)
                    {
                        fila[i] = "01/01/1900";
                    }
                }

            }
 
            tabla.Rows.Add(fila);
            foreach (DataRow filax in d.Rows)
            {
                tabla.ImportRow(filax);

            }
            return tabla;
        }

        public static int IntDeColumna(DataGridView gv, int columna, int fila)
        {
            int valor = 0;
            try
            {
                if (gv.Rows[columna].Cells[fila].Value != null && !(gv.Rows[columna].Cells[fila].Value is System.DBNull ))
                    valor = (int)gv.Rows[columna].Cells[fila].Value;
            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show("Error por casteo en IntDeColumna en grilla " + gv.Name + " columna :" + fila + " fila :" + columna.ToString() + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en IntDeColumna en grilla " + gv.Name + " columna :" + fila + " fila :" + columna.ToString() + ex.Message);
            }
            return valor;

        }

        public static int IntDeColFilaNombre(DataGridView gv, int fila, string columna)
        {
            int valor = 0;
            try
            {
                if (gv.Rows[fila].Cells[columna].Value != null)
                    valor = (int)gv.Rows[fila].Cells[columna ].Value;
            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show("Error de casteo en IntDeColFilaNombre en seleccion en grilla " + gv.Name + " columna :" + fila + " fila :" + columna.ToString() + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en seleccion en IntDeColFilaNombre en grilla " + gv.Name + " columna :" + fila + " fila :" + columna.ToString() + ex.Message);
            }
            return valor;

        }


        public static string StringDeColumna(DataGridView gv,int columna, int fila)
        {
            string valor = "";
            try
            {
                if (gv.Rows[columna].Cells[fila].Value != null)
                    valor = gv.Rows[columna].Cells[fila].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en seleccion en StringDeColumna en grilla " + gv.Name + " columna :" + fila.ToString() + " fila :" + columna.ToString() + ex.Message);
            }
            return valor;

        }

        public static string StringDeColNombre(DataGridView gv, int columna, string fila)
        {
            string valor = "";
            try
            {
                if (gv.Rows[columna].Cells[fila].Value != null)
                    valor = gv.Rows[columna].Cells[fila].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en seleccion en StringDeColNombre en grilla " + gv.Name + " columna :" + fila + " fila :" + columna.ToString() + ex.Message);
            }
            return valor;

        }


        public static string ElegirNombreInexistente(string nombreOriginal)
        {
            string respuesta = nombreOriginal;
            string cadenaIndice = "";
            string posible = "";
            int indiceFinal = -1;
            FileInfo archivoPosible;

            try
            {
                FileInfo archivo = new FileInfo(nombreOriginal);

                string ruta = archivo.DirectoryName;
                while (archivo.Exists)
                {
                    indiceFinal++;
                    cadenaIndice = (indiceFinal < 10 ? "0" + indiceFinal.ToString() : indiceFinal.ToString());
                    posible = ruta + @"\" + archivo.Name.Substring(0, (archivo.Name.Length - archivo.Extension.Length)) + " " + cadenaIndice + archivo.Extension;
                    try
                    {
                        archivoPosible = new FileInfo(posible);
                        if (!archivoPosible.Exists)
                        {
                            respuesta = posible;
                            break;
                        }
                    }
                    catch (Exception excepRuta)
                    {
                        MessageBox.Show("Archivo armado en ElegirNombreInexistente : " + posible + " tira este error " + excepRuta.Message  );
                    }


                }
            }
            catch (Exception excep)
            {
                MessageBox.Show("Problemas  en Utilidades ElegirNombreInexistente , error : " + excep.Message + " por " + nombreOriginal);
            }
            return respuesta;
        }

        public static string strRuta;
        public static string strNombre;
        public static string strIntercambio;
        public static int intIntercambio;




    }
}
