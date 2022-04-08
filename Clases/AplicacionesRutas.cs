using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using AccesoADatos;

namespace Clases
{
    public class AplicacionesRutas
    {
        int _idapp;
        public int IdApp
        {
            get { return _idapp; }
            set { _idapp = value; }
        }

        int _rut;
        public int Rut
        {
            get { return _rut; }
            set { _rut = value; }
        }

        string _repositorio;
        public string Repositorio
        {
            get { return _repositorio; }
            set { _repositorio = value; }
        }

        string _rigido;
        public string Rigido
        {
            get { return _rigido; }
            set { _rigido = value; }
        }

        string _desarrollo;
        public string Desarrollo
        {
            get { return _desarrollo; }
            set { _desarrollo = value; }
        }

        string _test;
        public string Test
        {
            get { return _test; }
            set { _test = value; }
        }

        string _produccion;
        public string Produccion
        {
            get { return _produccion; }
            set { _produccion = value; }
        }

        string _fechaCambio;
        public string FechaCambio
        {
            get { return _fechaCambio; }
            set { _fechaCambio = value; }

        }

        public AplicacionesRutas()
        { }


        Datas da;

        public int GuardaAplicacionRutas()
        {
            da = new Datas();
            da.CargarParametros("@idapp", IdApp.ToString());
            da.CargarParametros("@idrut", Rut.ToString());
            da.CargarParametros("@repositorio", Repositorio );
            da.CargarParametros("@rigido", Rigido);
            da.CargarParametros("@desarrollo", Desarrollo);
            da.CargarParametros("@test", Test);
            da.CargarParametros("@produccion", Produccion);
            return da.EjecutarDevolviendoEntero("Aplicaciones_rutasAlta");

        }
        public void BorrarAplicacionRutas()
        {

            da = new Datas();
            da.CargarParametros("@idapp", IdApp.ToString());
            da.CargarParametros("@idrut", Rut.ToString());
            da.EjecutarSinDevolver("Aplicaciones_rutasBorrado");

        }
        public void ModificarAplicacionRutas()
        {
            da = new Datas();
            da.CargarParametros("@idapp", IdApp.ToString());
            da.CargarParametros("@idrut", Rut.ToString());
            da.CargarParametros("@repositorio", Repositorio);
            da.CargarParametros("@rigido", Rigido);
            da.CargarParametros("@desarrollo", Desarrollo);
            da.CargarParametros("@test", Test);
            da.CargarParametros("@produccion", Produccion);
            da.EjecutarSinDevolver("Aplicaciones_rutasModifica");
        }

        public DataTable TraerRegistros()
        {
            da = new Datas();
            da.CargarParametros("@idapp", IdApp.ToString());
            da.CargarParametros("@idrut", Rut.ToString());
            da.CargarParametros("@repositorio", Repositorio);
            da.CargarParametros("@rigido", Rigido);
            da.CargarParametros("@desarrollo", Desarrollo);
            da.CargarParametros("@test", Test);
            da.CargarParametros("@produccion", Produccion);
            da.CargarParametros("@fecha_cambio", FechaCambio);
            return da.EjecutarDevolviendoDatatable("Aplicaciones_rutasConsulta");
        }


    }
}
