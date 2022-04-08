using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using AccesoADatos;

namespace Clases
{
    public class Registros
    {

        int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        string  _fecha;
        public string Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        string _fechaDesde;
        public string FechaDesde
        {
            get { return _fechaDesde; }
            set { _fechaDesde = value; }
        }

        string _fechaHasta;
        public string FechaHasta
        {
            get { return _fechaHasta; }
            set { _fechaHasta = value; }
        }

        int _hora;
        public int Hora
        {
            get { return _hora; }
            set { _hora = value; }
        }

        int _min;
        public int Min
        {
            get { return _min; }
            set { _min = value; }
        }

        int _seg;
        public int Seg
        {
            get { return _seg; }
            set { _seg = value; }
        }

        string _dia;
        public string Dia
        {
            get { return _dia; }
            set { _dia = value; }

        }

        string _tema;
        public string Tema
        {
            get { return _tema; }
            set { _tema = value; }
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

        string _estado;
        public string Estado
        {
            get { return _estado ; }
            set { _estado = value; }
        }

        public Registros()
        { }

        Datas da;

        public void GuardaRegistro()
        {
            da = new Datas();
            da.CargarParametros("@Fecha", FechaHasta.ToString());
            da.CargarParametros("@dia", Dia.ToString());
            da.CargarParametros("@hora", Hora.ToString());
            da.CargarParametros("@minuto", Min.ToString());
            da.CargarParametros("@segundo", Seg.ToString());
            da.CargarParametros("@tema", Tema);
            da.CargarParametros("@persona", Persona);
            da.CargarParametros("@Verbo", Verbo);
            da.CargarParametros("@Nexo", Nexo);
            da.CargarParametros("@Modo", Modo);
            da.CargarParametros("@Objeto", Objeto);
            da.CargarParametros("@archivo", Archivo);
            da.CargarParametros("@aplicacion",  Aplicacion );
            da.CargarParametros("@estado", Estado);
            da.EjecutarSinDevolver("RegistrosAlta");

        }

        public void BorrarRegistro()
        {

            da = new Datas();
            da.CargarParametros("@id", Id.ToString());
            da.EjecutarSinDevolver("RegistrosBorrado");

        }

        public void ModificarRegistro()
        {
            da = new Datas();
            da.CargarParametros("@id", Id.ToString());
            da.CargarParametros("@fecha", FechaHasta.ToString());
            da.CargarParametros("@dia", Dia.ToString());
            da.CargarParametros("@hora", Hora.ToString());
            da.CargarParametros("@minuto", Min.ToString());
            da.CargarParametros("@segundo", Seg.ToString());
            da.CargarParametros("@tema", Tema);
            da.CargarParametros("@persona", Persona);
            da.CargarParametros("@Verbo", Verbo);
            da.CargarParametros("@Nexo", Nexo);
            da.CargarParametros("@Modo", Modo);
            da.CargarParametros("@Objeto", Objeto);
            da.CargarParametros("@archivo", Archivo);
            da.CargarParametros("@aplicacion", Aplicacion);
            da.CargarParametros("@estado", Estado);
            da.EjecutarSinDevolver("RegistrosModifica");
        }

        public DataTable TraerRegistros()
        {
            da = new Datas();
            da.CargarParametros("@id", Id.ToString());
            da.CargarParametros("@fechaDesde", FechaDesde);
            da.CargarParametros("@fechaHasta", FechaHasta);
            da.CargarParametros("@dia", Dia);
            da.CargarParametros("@hora", Hora.ToString());
            da.CargarParametros("@minuto", Min.ToString());
            da.CargarParametros("@segundo", Seg.ToString());
            da.CargarParametros("@tema", Tema);
            da.CargarParametros("@persona", Persona);
            da.CargarParametros("@Verbo", Verbo);
            da.CargarParametros("@Nexo", Nexo);
            da.CargarParametros("@Modo", Modo);
            da.CargarParametros("@Objeto", Objeto);
            da.CargarParametros("@archivo", Archivo);
            da.CargarParametros("@aplicacion", Aplicacion);
            return da.EjecutarDevolviendoDatatable("RegistrosConsulta");
        }

        public DataTable TraerTodasLasRutasDeHoy()
        {
            da = new Datas();
            da.CargarParametros("@fecha", "");
            return da.EjecutarDevolviendoDatatable("BackupRutas");
        }

        public DataTable TraerLosInsertsDeRegistros()
        {
            da = new Datas();
            da.CargarParametros("@fecha", "");
            return da.EjecutarDevolviendoDatatable("InsertsRegistros");
        }

        public DataSet TraerTodosLosInserts()
        {
            da = new Datas();
            da.CargarParametros("@fecha", "");
            return da.EjecutarDevolviendoDataset("TodosInserts");
        }

        public DataTable Traer30UltimosTemas()
        {
            da = new Datas();
            return da.EjecutarDevolviendoDatatable("TemasUltimos");
        }

        public DataTable FiltradoPorAproximacion()
        {
            da = new Datas();
            da.CargarParametros("@id", Id.ToString());
            da.CargarParametros("@fechaDesde", FechaDesde.ToString());
            da.CargarParametros("@fechaHasta", FechaHasta.ToString());
            da.CargarParametros("@dia", Dia.ToString());
            da.CargarParametros("@hora", Hora.ToString());
            da.CargarParametros("@minuto", Min.ToString());
            da.CargarParametros("@segundo", Seg.ToString());
            da.CargarParametros("@tema", Tema);
            da.CargarParametros("@persona", Persona);
            da.CargarParametros("@Verbo", Verbo);
            da.CargarParametros("@Nexo", Nexo);
            da.CargarParametros("@Modo", Modo);
            da.CargarParametros("@Objeto", Objeto);
            da.CargarParametros("@archivo", Archivo);
            da.CargarParametros("@aplicacion", Aplicacion);
            return da.EjecutarDevolviendoDatatable("RegistrosConsultaTextual");
        }

    }
}
