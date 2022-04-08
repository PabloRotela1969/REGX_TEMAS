using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using AccesoADatos;

namespace Clases
{
    public class Nexos
    {
        int _idnex;
        public int IdNex
        {
            get { return _idnex; }
            set { _idnex = value; }
        }

        string _nexo;
        public string Nexo
        {
            get { return _nexo; }
            set { _nexo = value; }
        }

        string _fechaCambio;
        public string FechaCambio
        {
            get { return _fechaCambio; }
            set { _fechaCambio = value; }

        }


        public Nexos()
        { }

        Datas da;

        public int GuardaNexos()
        {
            da = new Datas();
            da.CargarParametros("@Nexo", Nexo );
            da.CargarParametros("@fecha_cambio", FechaCambio );
            return da.EjecutarDevolviendoEntero ("NexosAlta");

        }


        public void BorrarNexos()
        {

            da = new Datas();
            da.CargarParametros("@idnex", IdNex.ToString());
            da.EjecutarSinDevolver("NexosBorrado");

        }
        public void ModificarNexos()
        {
            da = new Datas();
            da.CargarParametros("@idnex", IdNex.ToString());
            da.CargarParametros("@Nexo", Nexo);
            da.CargarParametros("@fecha_cambio", FechaCambio);
            da.EjecutarSinDevolver("NexosModifica");
        }

        public DataTable TraerRegistros()
        {
            da = new Datas();
            da.CargarParametros("@idnex", IdNex.ToString());
            da.CargarParametros("@Nexo", Nexo);
            da.CargarParametros("@fecha_cambio", FechaCambio);
            return da.EjecutarDevolviendoDatatable("NexosConsulta");
        }

    }
 
}
