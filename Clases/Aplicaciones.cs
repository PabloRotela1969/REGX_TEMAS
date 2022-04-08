using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using AccesoADatos;

namespace Clases
{
    public class Aplicaciones
    {

        int _idapp;
        public int IdApp
        {
            get { return _idapp; }
            set { _idapp = value; }
        }
        string _lenguaje;
        public string Lenguaje
        {
            get { return _lenguaje; }
            set { _lenguaje = value; }
        }

        string _sqlVersion;
        public string SQLversion
        {
            get { return _sqlVersion; }
            set { _sqlVersion = value; }
        }


        string _nombre;
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }

        }


        string _fechaCambio;
        public string FechaCambio
        {
            get { return _fechaCambio; }
            set { _fechaCambio = value; }

        }



        public Aplicaciones()
        { }

        Datas da;

        public int GuardaAplicacion()
        {
            da = new Datas();
            da.CargarParametros("@nombre", Nombre);
            da.CargarParametros("@lenguaje", Lenguaje  );
            da.CargarParametros("@sqlVersion", SQLversion);
            return da.EjecutarDevolviendoEntero("AplicacionesAlta");

        }
        public void BorrarAplicacion()
        {

            da = new Datas();
            da.CargarParametros("@id", IdApp.ToString());
            da.EjecutarSinDevolver("AplicacionesBorrado");

        }
        public void ModificarAplicacion()
        {
            da = new Datas();
            da.CargarParametros("@id", IdApp.ToString());
            da.CargarParametros("@nombre", Nombre);
            da.CargarParametros("@lenguaje", Lenguaje);
            da.CargarParametros("@sqlVersion", SQLversion);
            da.EjecutarSinDevolver("AplicacionesModifica");
        }

        public DataTable TraerRegistros()
        {
            da = new Datas();
            da.CargarParametros("@id", IdApp.ToString());
            da.CargarParametros("@nombre", Nombre);
            da.CargarParametros("@lenguaje", Lenguaje);
            da.CargarParametros("@sqlVersion", SQLversion);
            da.CargarParametros("@fecha_cambio", FechaCambio);
            return da.EjecutarDevolviendoDatatable("AplicacionesConsulta");
        }

    }
}
