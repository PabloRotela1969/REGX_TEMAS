using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using AccesoADatos;

namespace Clases
{
    public class Verbos
    {
        int _idver;
        public int idVer
        {
            get { return _idver; }
            set { _idver = value; }
        }
        string _nombre;
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        string _fecha_cambio;
        public string FechaCambio
        {
            get { return _fecha_cambio; }
            set { _fecha_cambio = value; }
        }


    
        public Verbos()
        {
           
        }
        Datas da;
        

        public int GuardarAccion()
        {
            da = new Datas();
            da.CargarParametros("@nombre", Nombre);
            return da.EjecutarDevolviendoEntero("VerbosAlta");

        }
        public void BorrarAccion()
        {

            da = new Datas();
            da.CargarParametros("@idver", idVer.ToString());
            da.EjecutarSinDevolver("VerbosBorrado");

        }
        public void ModificarAccion()
        {
            da = new Datas();
            da.CargarParametros("@idver", idVer.ToString());
            da.CargarParametros("@nombre", Nombre);
            da.EjecutarSinDevolver("VerbosModifica");            
        }

        public DataTable TraerRegistros()
        {
            da = new Datas();
            da.CargarParametros("@idver", idVer.ToString());
            da.CargarParametros("@nombre", Nombre);
            return da.EjecutarDevolviendoDatatable("VerbosConsulta");
        }
    }
}
