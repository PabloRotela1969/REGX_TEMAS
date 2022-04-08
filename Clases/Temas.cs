using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using AccesoADatos;

namespace Clases
{
    public class Temas
    {


        int _idtem;
        public int IdTem
        {
            get { return _idtem; }
            set { _idtem = value; }
        }
        string _estado;
        public string Estado
        {
            get { return _estado; }
            set { _estado = value; }
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


        public Temas()
        { }

        Datas da;

        public void GuardarTemas()
        {
            da = new Datas();
            da.CargarParametros("@tema", Nombre );
            da.CargarParametros("@estado", Estado );
            da.EjecutarSinDevolver("TemasAlta");

        }
        public void BorrarTemas()
        {

            da = new Datas();
            da.CargarParametros("@idtem", IdTem.ToString());
            da.EjecutarSinDevolver("TemasBorrado");

        }
        public void ModificarTemas()
        {
            da = new Datas();
            da.CargarParametros("@idtem", IdTem.ToString());
            da.CargarParametros("@tema",Nombre  );
            da.CargarParametros("@estado", Estado);
            da.EjecutarSinDevolver("TemasModifica");
        }

        public DataTable TraerRegistrosAlfabeticamente()
        {
            da = new Datas();
            da.CargarParametros("@idtem", IdTem.ToString());
            da.CargarParametros("@tema", Nombre);
            da.CargarParametros("@estado", Estado);
            da.CargarParametros("@fecha_cambio", FechaCambio);
            return da.EjecutarDevolviendoDatatable("TemasConsultaAlfabetica");
        }
        public DataTable TraerRegistrosUltimo()
        {
            da = new Datas();
            da.CargarParametros("@idtem", IdTem.ToString());
            da.CargarParametros("@tema", Nombre);
            da.CargarParametros("@estado", Estado);
            da.CargarParametros("@fecha_cambio", FechaCambio);
            return da.EjecutarDevolviendoDatatable("TemasConsultaFrecuencia");
        }
    }
}
