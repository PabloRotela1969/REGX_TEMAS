using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using AccesoADatos;

namespace Clases
{
    public class Personas
    {
        int _IdPer;
        public int IdPer
        {
            get { return _IdPer; }
            set { _IdPer = value; }
        }


        string _nombre;
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }

        }

        string _apellido;
        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }

        }

        string _empresa;
        public string Empresa
        {
            get { return _empresa; }
            set { _empresa = value; }

        }

        string _fecha_cambio;
        public string Fecha_Cambio
        {
            get { return _fecha_cambio; }
            set { _fecha_cambio = value; }

        }



        public Personas()
        { }

        Datas da;


        public int GuardarPersonas()
        {
            da = new Datas();
            da.CargarParametros("@nombre", Nombre);
            da.CargarParametros("@Apellido", Apellido);
            da.CargarParametros("@Empresa", Empresa);
            return da.EjecutarDevolviendoEntero("PersonasAlta");

        }
        public void BorrarPersonas()
        {

            da = new Datas();
            da.CargarParametros("@IdPer", IdPer.ToString());
            da.EjecutarSinDevolver("PersonasBorrado");

        }
        public void ModificarPersonas()
        {
            da = new Datas();
            da.CargarParametros("@IdPer", IdPer.ToString());
            da.CargarParametros("@nombre", Nombre);
            da.CargarParametros("@Apellido", Apellido);
            da.CargarParametros("@Empresa", Empresa);
            da.EjecutarSinDevolver("PersonasModifica");
        }

        public DataTable TraerRegistros()
        {
            da = new Datas();
            da.CargarParametros("@IdPer", IdPer.ToString());
            da.CargarParametros("@nombre", Nombre);
            da.CargarParametros("@Apellido", Apellido);
            da.CargarParametros("@Empresa", Empresa);
            da.CargarParametros("@Fecha_Cambio", Fecha_Cambio);
            return da.EjecutarDevolviendoDatatable("PersonasConsulta");
        }



    }
}
