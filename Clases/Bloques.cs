using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccesoADatos;
using System.Data;

namespace Clases
{
    public class Bloques
    {
        int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }


        string _tema;
        public string Tema
        {
            get { return _tema; }
            set { _tema = value; }
        }

        string _bloque;
        public string Bloque
        {
            get { return _bloque; }
            set { _bloque = value; }
        }

        string _persona;
        public string Persona
        {
            get { return _persona; }
            set { _persona = value; }
        }

        string _verbo;
        public string Verbo
        {
            get { return _verbo; }
            set { _verbo = value; }
        }

        string _nexo;
        public string Nexo
        {
            get { return _nexo; }
            set { _nexo = value; }
        }

        string _modo;
        public string Modo
        {
            get { return _modo; }
            set { _modo = value; }
        }


        string _objeto;
        public string Objeto
        {
            get { return _objeto; }
            set { _objeto = value; }
        }

        string _archivo;
        public string Archivo
        {
            get { return _archivo; }
            set { _archivo = value; }
        }


        string _aplicacion;
        public string Aplicacion
        {
            get { return _aplicacion; }
            set { _aplicacion = value; }
        }

        string _tipo;
        public string Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }


        string _telefono;
        public string Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }



        public Bloques()
        { }

        Datas da;

        public void GuardaBloques()
        {
            da = new Datas();
            da.CargarParametros("@bloque", Bloque);
            da.CargarParametros("@tema", Tema);
            da.CargarParametros("@persona", Persona);
            da.CargarParametros("@Verbo", Verbo);
            da.CargarParametros("@Nexo", Nexo);
            da.CargarParametros("@Modo", Modo);
            da.CargarParametros("@Objeto", Objeto);
            da.CargarParametros("@archivo", Archivo);
            da.CargarParametros("@aplicacion",  Aplicacion);
            da.EjecutarSinDevolver("BloquesAlta");

        }

        public void BorrarBloques()
        {

            da = new Datas();
            da.CargarParametros("@idBloque", Id.ToString());
            da.EjecutarSinDevolver("BloquesBorrado");

        }

        public void ModificarBloques()
        {
            da = new Datas();
            da.CargarParametros("@idBloque", Id.ToString());
            da.CargarParametros("@bloque", Bloque );
            da.CargarParametros("@tema", Tema);
            da.CargarParametros("@persona", Persona);
            da.CargarParametros("@Verbo", Verbo);
            da.CargarParametros("@Nexo", Nexo);
            da.CargarParametros("@Modo", Modo);
            da.CargarParametros("@Objeto", Objeto);
            da.CargarParametros("@archivo", Archivo);
            da.CargarParametros("@aplicacion", Aplicacion);
            da.EjecutarSinDevolver("BloquesModifica");
        }

        public DataTable TraerBloques()
        {
            da = new Datas();
            da.CargarParametros("@idBloque", Id.ToString());
            da.CargarParametros("@bloque", Bloque);
            da.CargarParametros("@tema", Tema);
            da.CargarParametros("@persona", Persona);
            da.CargarParametros("@Verbo", Verbo);
            da.CargarParametros("@Nexo", Nexo);
            da.CargarParametros("@Modo", Modo);
            da.CargarParametros("@Objeto", Objeto);
            da.CargarParametros("@archivo", Archivo);
            da.CargarParametros("@aplicacion", Aplicacion);
            return da.EjecutarDevolviendoDatatable("BloquesConsulta");
        }




    }
}
