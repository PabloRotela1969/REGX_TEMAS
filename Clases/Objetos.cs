using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using AccesoADatos;

namespace Clases
{
    public class Objetos
    {
        int _idobj;
        public int IdObj
        {
            get { return _idobj; }
            set { _idobj = value; }
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


        public Objetos()
        { }

        Datas da;

        public int GuardaObjetos()
        {
            da = new Datas();
            da.CargarParametros("@Nombre", Nombre );
            return da.EjecutarDevolviendoEntero("ObjetosAlta");

        }


        public void BorrarObjetos()
        {

            da = new Datas();
            da.CargarParametros("@IdObj", IdObj.ToString());
            da.EjecutarSinDevolver("ObjetosBorrado");

        }
        public void ModificarObjetos()
        {
            da = new Datas();
            da.CargarParametros("@IdObj", IdObj.ToString());
            da.CargarParametros("@Nombre", Nombre);
            da.CargarParametros("@fecha_cambio", FechaCambio);
            da.EjecutarSinDevolver("ObjetosModifica");
        }

        public DataTable TraerRegistros()
        {
            da = new Datas();
            da.CargarParametros("@IdObj", IdObj.ToString());
            da.CargarParametros("@Nombre", Nombre);
            da.CargarParametros("@fecha_cambio", FechaCambio);
            return da.EjecutarDevolviendoDatatable("ObjetosConsulta");
        }

    }
}
