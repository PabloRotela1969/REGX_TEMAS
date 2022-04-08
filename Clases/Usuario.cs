using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using AccesoADatos;

namespace Clases
{
    public class Usuario
    {
        Datas da;
        public Usuario()
        {
        }


        int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        string _nombre;
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }



        public int GuardaUsuario()
        {
            da = new Datas();
            da.CargarParametros("@usr", Nombre );
            da.CargarParametros("@pass", Password );
            return da.EjecutarDevolviendoEntero("UsuarioAlta");

        }


        public void BorrarUsuario()
        {

            da = new Datas();
            da.CargarParametros("@id", Id.ToString());
            da.EjecutarSinDevolver("UsuarioBorrado");

        }
        public void ModificarUsuario()
        {
            da = new Datas();
            da.CargarParametros("@id", Id.ToString());
            da.CargarParametros("@usr", Nombre);
            da.CargarParametros("@pass", Password);
            da.EjecutarSinDevolver("UsuarioModifica");
        }

        public DataTable TraerRegistros()
        {
            da = new Datas();
            da.CargarParametros("@id", Id.ToString());
            da.CargarParametros("@usr", Nombre);
            da.CargarParametros("@pass", Password);
            return da.EjecutarDevolviendoDatatable("UsuarioConsulta");
        }

    }
}
