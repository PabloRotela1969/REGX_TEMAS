using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using AccesoADatos;

namespace Clases
{
    public class Modos
    {
        int _idmod;
        public int IdMod
        {
            get { return _idmod; }
            set { _idmod = value; }
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


        public Modos()
        { }

        Datas da;



        public int GuardaModo()
        {
            da = new Datas();
            da.CargarParametros("@nombre", Nombre);
            return da.EjecutarDevolviendoEntero("ModosAlta");
        }

        public void BorrarModo()
        {

            da = new Datas();
            da.CargarParametros("@idmod", IdMod.ToString());
            da.EjecutarSinDevolver("ModosBorrado");

        }
        public void ModificarModo()
        {
            da = new Datas();
            da.CargarParametros("@idmod", IdMod.ToString());
            da.CargarParametros("@nombre", Nombre);
            da.CargarParametros("@fecha_cambio", FechaCambio);
            da.EjecutarSinDevolver("ModosModifica");
        }

        public DataTable TraerRegistros()
        {
            da = new Datas();
            da.CargarParametros("@idmod", IdMod.ToString());
            da.CargarParametros("@nombre", Nombre);
            da.CargarParametros("@fecha_cambio", FechaCambio);
            return da.EjecutarDevolviendoDatatable("ModosConsulta");
        }

    }
}
