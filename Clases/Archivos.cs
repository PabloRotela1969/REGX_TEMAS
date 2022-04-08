using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using AccesoADatos;

namespace Clases
{
    public class Archivos
    {
        int _idarch;
        public int IdArch
        {
            get { return _idarch; }
            set { _idarch = value; }
        }
        int _idtipo;
        public int IdTipo
        {
            get { return _idtipo; }
            set { _idtipo = value; }
        }


        string _ruta;
        public string Ruta
        {
            get { return _ruta; }
            set { _ruta = value; }

        }

        string _nombre;
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }


        string _descripcion;
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        string _fechaCambio;
        public string FechaCambio
        {
            get { return _fechaCambio; }
            set { _fechaCambio = value; }

        }


        public Archivos()
        { }

        Datas da;

        public int  GuardaArchivo()
        {
            da = new Datas();
            da.CargarParametros("@nombre", Nombre );
            da.CargarParametros("@ruta", Ruta);
            da.CargarParametros("@idtipo", IdTipo .ToString() );
            da.CargarParametros("@descripcion", Descripcion );
            return da.EjecutarDevolviendoEntero("ArchivosAlta");

        }

        public int GuardarArchivoDevolviendoSuIndice()
        {
            da = new Datas();
            da.CargarParametros("@nombre", Nombre);
            da.CargarParametros("@ruta", Ruta);
            da.CargarParametros("@idtipo", IdTipo.ToString());
            da.CargarParametros("@descripcion", Descripcion);
            return da.EjecutarDevolviendoEntero("ArchivosAlta");
        }

        public void BorrarArchivo()
        {

            da = new Datas();
            da.CargarParametros("@idarch", IdArch.ToString());
            da.EjecutarSinDevolver("ArchivosBorrado");

        }
        public void ModificarArchivo()
        {
            da = new Datas();
            da.CargarParametros("@idarch", IdArch.ToString());
            da.CargarParametros("@nombre", Nombre);
            da.CargarParametros("@ruta", Ruta);
            da.CargarParametros("@idtipo", IdTipo.ToString());
            da.CargarParametros("@descripcion", Descripcion);
            da.CargarParametros("@fecha_cambio", FechaCambio);
            da.EjecutarSinDevolver("ArchivosModifica");
        }

        public DataTable TraerRegistros()
        {
            da = new Datas();
            da.CargarParametros("@idarch", IdArch.ToString());
            da.CargarParametros("@nombre", Nombre);
            da.CargarParametros("@ruta", Ruta);
            da.CargarParametros("@idtipo", IdTipo.ToString());
            da.CargarParametros("@descripcion", Descripcion);
            da.CargarParametros("@fecha_cambio", FechaCambio);
            return da.EjecutarDevolviendoDatatable("ArchivosConsulta");
        }

    }
}
