using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using AccesoADatos;


namespace Clases
{
    public class AplicacionesRoles
    {
        int _idapp;
        public int IdApp
        {
            get { return _idapp; }
            set { _idapp = value; }
        }

        string _usr;
        public string Usr
        {
            get { return _usr; }
            set { _usr = value; }
        }

        string _pass;
        public string Pass
        {
            get { return _pass; }
            set { _pass = value; }
        }

        string _perfil;
        public string Perfil
        {
            get { return _perfil; }
            set { _perfil = value; }
        }

        string _fechaCambio;
        public string FechaCambio
        {
            get { return _fechaCambio; }
            set { _fechaCambio = value; }

        }

        public AplicacionesRoles()
        { }


        Datas da;

        public int GuardaAplicacionRoles()
        {
            da = new Datas();
            da.CargarParametros("@id", IdApp.ToString());
            da.CargarParametros("@usr", Usr);
            da.CargarParametros("@perfil",Perfil);
            da.CargarParametros("@pass", Pass );

            return da.EjecutarDevolviendoEntero("Aplicaciones_rolesAlta");

        }
        public void BorrarAplicacionRoles()
        {

            da = new Datas();
            da.CargarParametros("@id", IdApp.ToString());
            da.CargarParametros("@usr", Usr);
            
            da.EjecutarSinDevolver("Aplicaciones_rolesBorrado");

        }
        public void ModificarAplicacionRoles()
        {
            da = new Datas();
            da.CargarParametros("@id", IdApp.ToString());
            da.CargarParametros("@usr", Usr);
            da.CargarParametros("@pass", Pass);
            da.CargarParametros("@perfil",Perfil);
            da.EjecutarSinDevolver("Aplicaciones_rolesModifica");
        }

        public DataTable TraerRegistros()
        {
            da = new Datas();
            da.CargarParametros("@id", IdApp.ToString());
            da.CargarParametros("@usr", Usr);
            da.CargarParametros("@pass", Pass);
            da.CargarParametros("@perfil",Perfil);
            da.CargarParametros("@fecha_cambio", FechaCambio);
            return da.EjecutarDevolviendoDatatable("Aplicaciones_rolesConsulta");
        }



    }
}
