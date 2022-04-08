using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using AccesoADatos;

namespace Clases
{
    public class Tipos
    {
        int _IdTipo;
        public int IdTipo
        {
            get { return _IdTipo; }
            set { _IdTipo = value; }
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


        public Tipos()
        { }

        Datas da;

        public int GuardaTipos()
        {
            da = new Datas();
            da.CargarParametros("@nombre", Nombre );
            return da.EjecutarDevolviendoEntero("TiposAlta");

        }


        public void BorrarTipos()
        {

            da = new Datas();
            da.CargarParametros("@IdTipo", IdTipo.ToString());
            da.EjecutarSinDevolver("TiposBorrado");

        }
        public void ModificarTipos()
        {
            da = new Datas();
            da.CargarParametros("@IdTipo", IdTipo.ToString());
            da.CargarParametros("@nombre", Nombre);
            da.EjecutarSinDevolver("TiposModifica");
        }

        public DataTable TraerRegistros()
        {
            da = new Datas();
            da.CargarParametros("@IdTipo", IdTipo.ToString());
            da.CargarParametros("@nombre", Nombre);
            da.CargarParametros("@fecha_cambio", FechaCambio);
            return da.EjecutarDevolviendoDatatable("TiposConsulta");
        }

    }
}
