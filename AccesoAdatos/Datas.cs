using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Reflection;


namespace AccesoADatos
{
    public struct UnidadParametro
    {
        public string nombre;
        public string valor;
    }
    public class Datas
    {
        private static string strRutaDLL;
        private static string cadenaConexion;
        
        public  Datas()
        {
            CargaCadenaConexion();
        }
        // cuando levanta la aplicacion, se ejecuta este constructor que trae la ruta de la 
        // dll donde esta el archivo con la configuración
        public Datas(string ruta)
        {
            strRutaDLL = ruta;
            CargaCadenaConexion();
        }


        private string RutaDeLaDLL()
        {
            int hasta = Assembly.GetExecutingAssembly().Location.LastIndexOf(@"\") + 1;
            string ruta = Assembly.GetExecutingAssembly().Location.Substring(0, hasta);
            return ruta;
        }
  
        private void CargaCadenaConexion()
        {
            string respuesta = "";
            string cadena = "";
            StreamReader lector = new StreamReader(RutaDeLaDLL () + "cadena.txt");
            try
            {
                while ( !lector.EndOfStream  )
                {
                    cadena = lector.ReadLine();
                    if (!cadena.Contains("//"))
                        respuesta = cadena;
                }
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
            }
            
            cadenaConexion = respuesta;
        }


        
        List<UnidadParametro> lista = new List<UnidadParametro>();

        public void CargarParametros(string nombre, string valor)
        {
            UnidadParametro u = new UnidadParametro();
            u.nombre = nombre;
            u.valor = valor;
            lista.Add(u);
        }
        private void AgregarParametrosAlComando(ref SqlCommand comando, ref List<UnidadParametro> lista)
        {
            object valor;
            SqlParameter parametro;
            foreach (UnidadParametro u in lista)
            {
                if (u.valor == "" | u.valor == "0")
                    valor = null;
                else
                    valor = u.valor;

                parametro = new SqlParameter(u.nombre, valor);
                comando.Parameters.Add(parametro);
            }

        }


        public void EjecutarSinDevolver(string comando)
        {
            SqlConnection con = new SqlConnection(cadenaConexion);
            SqlCommand com = new SqlCommand(comando , con);
            com.CommandType = CommandType.StoredProcedure;
            AgregarParametrosAlComando(ref com, ref lista);
            try
            {
                con.Open();
                com.ExecuteNonQuery();

            }
            catch( Exception ex)
            {
                throw  new ApplicationException("Excepcion en " + com.CommandText + " " + ex.Message );
            }
            finally 
            {
                con.Close();
            }
        }
        public DataTable EjecutarDevolviendoDatatable(string comando)
        {
            DataTable tabla = new DataTable();
            SqlConnection con = new SqlConnection(cadenaConexion);
            SqlCommand com = new SqlCommand(comando , con);
            com.CommandType = CommandType.StoredProcedure;
            AgregarParametrosAlComando(ref com, ref lista);
            SqlDataAdapter adp = new SqlDataAdapter(com);
            try
            {
                con.Open();
                adp.Fill(tabla);

            }
            catch( Exception ex)
            {
                throw new ApplicationException("Excepcion en " + com.CommandText + " " + ex.Message);
            }
            finally 
            {
                con.Close();
            }
            return tabla;
        }

        public DataSet  EjecutarDevolviendoDataset(string comando)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(cadenaConexion);
            SqlCommand com = new SqlCommand(comando, con);
            com.CommandType = CommandType.StoredProcedure;
            AgregarParametrosAlComando(ref com, ref lista);
            SqlDataAdapter adp = new SqlDataAdapter(com);
            try
            {
                con.Open();
                adp.Fill(ds);

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Excepcion en " + com.CommandText + " " + ex.Message);
            }
            finally
            {
                con.Close();
            }
            return ds;
        }

        public int EjecutarDevolviendoEntero(string comando )
        {
            int respuesta = 0;
            SqlConnection con = new SqlConnection(cadenaConexion);
            SqlCommand com = new SqlCommand(comando, con);
            com.CommandType = CommandType.StoredProcedure;
            AgregarParametrosAlComando(ref com, ref lista);
            SqlDataReader lector = null;
            try
            {
                con.Open();
                lector = com.ExecuteReader();
                while (lector.Read())
                {
                    respuesta = lector.GetInt32(0);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Excepcion en " + com.CommandText + " " + ex.Message);
            }
            finally
            {
                lector.Close();
                con.Close();
                
                
            }
            return respuesta;

        }

        public string EjecutarDevolviendoString(string comando)
        {
            string respuesta = "";
            SqlConnection con = new SqlConnection(cadenaConexion);
            SqlCommand com = new SqlCommand(comando, con);
            com.CommandType = CommandType.StoredProcedure;
            AgregarParametrosAlComando(ref com, ref lista);
            SqlDataReader lector = null;
            try
            {
                con.Open();
                lector = com.ExecuteReader();
                respuesta = lector.GetString(0);

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Excepcion en " + com.CommandText + " " + ex.Message);
            }
            finally
            {
                lector.Close();
                con.Close();


            }
            return respuesta;

        }

    }
}
