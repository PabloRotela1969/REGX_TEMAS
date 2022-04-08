using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using AccesoADatos;

namespace Clases
{
    public class AplicacionesMenues
    {
        int _idapp;
        public int IdApp
        {
            get { return _idapp; }
            set { _idapp = value; }
        }

        string _menu;
        public string Menu
        {
            get { return _menu; }
            set { _menu = value; }
        }

        string _descrip;
        public string Descripcion
        {
            get { return _descrip; }
            set { _descrip = value; }
        }

        string _fechaCambio;
        public string FechaCambio
        {
            get { return _fechaCambio; }
            set { _fechaCambio = value; }

        }

        public AplicacionesMenues()
        { }


        Datas da;

        public int GuardaAplicacionMenues()
        {
            da = new Datas();
            da.CargarParametros("@idapp", IdApp.ToString());
            da.CargarParametros("@menu", Menu.ToString());
            da.CargarParametros("@descripcion", Descripcion );

            return da.EjecutarDevolviendoEntero("Aplicaciones_menuesAlta");

        }
        public void BorrarAplicacionMenues()
        {

            da = new Datas();
            da.CargarParametros("@idapp", IdApp.ToString());
            da.CargarParametros("@menu", Menu.ToString());
            da.EjecutarSinDevolver("Aplicaciones_menuesBorrado");

        }
        public void ModificarAplicacionMenues()
        {
            da = new Datas();
            da.CargarParametros("@idapp", IdApp.ToString());
            da.CargarParametros("@menu", Menu.ToString());
            da.CargarParametros("@descripcion", Descripcion);
            da.EjecutarSinDevolver("Aplicaciones_menuesModifica");
        }

        public DataTable TraerRegistros()
        {
            da = new Datas();
            da.CargarParametros("@idapp", IdApp.ToString());
            da.CargarParametros("@menu", Menu.ToString());
            da.CargarParametros("@descripcion", Descripcion);
            da.CargarParametros("@fecha_cambio", FechaCambio);
            return da.EjecutarDevolviendoDatatable("Aplicaciones_menuesConsulta");
        }


    }
}
