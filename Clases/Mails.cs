using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using AccesoADatos;

namespace Clases
{
    public class Mails
    {
        int _idper;
        public int IdPer
        {
            get { return _idper; }
            set { _idper = value; }
        }
        int _idmail;
        public int IdMail
        {
            get { return _idmail; }
            set { _idmail = value; }
        }

        string _direccion;
        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }

        string _fechaCambio;
        public string FechaCambio
        {
            get { return _fechaCambio; }
            set { _fechaCambio = value; }

        }


        public Mails()
        { }

        Datas da;

        public int GuardaMails()
        {
            da = new Datas();
            da.CargarParametros("@idPer", IdPer.ToString());
            da.CargarParametros("@direccion", Direccion );
            return da.EjecutarDevolviendoEntero ("MailsAlta");

        }


        public void BorrarMails()
        {

            da = new Datas();
            da.CargarParametros("@idMail", IdMail.ToString());
            da.CargarParametros("@idPer", IdPer.ToString());
            da.EjecutarSinDevolver("MailsBorrado");

        }
        public void ModificarMails()
        {
            da = new Datas();
            da.CargarParametros("@idMail", IdMail.ToString());
            da.CargarParametros("@idPer", IdPer.ToString());
            da.CargarParametros("@direccion", Direccion);
            da.CargarParametros("@fecha_cambio", FechaCambio);
            da.EjecutarSinDevolver("MailsModifica");
        }

        public DataTable TraerRegistros()
        {
            da = new Datas();
            da.CargarParametros("@idMail", IdMail.ToString());
            da.CargarParametros("@idPer", IdPer.ToString());
            da.CargarParametros("@direccion", Direccion);
            da.CargarParametros("@fecha_cambio", FechaCambio);
            return da.EjecutarDevolviendoDatatable("MailsConsulta");
        }

    }
}
