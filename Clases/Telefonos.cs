using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using AccesoADatos;

namespace Clases
{
    public class Telefonos
    {
        int _idTel;
        public int IdTel
        {
            get { return _idTel; }
            set { _idTel = value; }
        }

        int _idPer;
        public int IdPer
        {
            get { return _idPer; }
            set { _idPer = value; }
        }

        string _telefono;
        public string Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        string _fechaCambio;
        public string FechaCambio
        {
            get { return _fechaCambio; }
            set { _fechaCambio = value; }

        }

        public Telefonos()
        { }

        Datas da;


        public void GuardarTelefonos()
        {
            da = new Datas();
            da.CargarParametros("@idPer", IdPer.ToString() );
            da.CargarParametros("@telefono", Telefono);
            da.EjecutarSinDevolver("TelefonosAlta");

        }
        public void BorrarTelefonos()
        {

            da = new Datas();
            da.CargarParametros("@IdTel", IdTel.ToString());
            da.EjecutarSinDevolver("TelefonosBorrado");

        }
        public void ModificarTelefonos()
        {
            da = new Datas();
            da.CargarParametros("@IdTel", IdTel.ToString());
            da.CargarParametros("@IdPer", IdPer.ToString());
            da.CargarParametros("@telefono", Telefono);
            da.CargarParametros("@fecha_cambio", FechaCambio);
            da.EjecutarSinDevolver("TelefonosModifica");
        }

        public DataTable TraerRegistros()
        {
            da = new Datas();
            da.CargarParametros("@IdTel", IdTel.ToString());
            da.CargarParametros("@IdPer", IdPer.ToString());
            da.CargarParametros("@telefono", Telefono);
            da.CargarParametros("@fecha_cambio", FechaCambio);
            return da.EjecutarDevolviendoDatatable("TelefonosConsulta");
        }

    }
}
