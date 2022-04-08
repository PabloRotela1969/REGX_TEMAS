using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Permissions;
using System.Reflection;
using System.Runtime.InteropServices;

namespace RegistrosNet
{
    
    public partial class frmRegistros : Form
    {


        public frmRegistros()
        {
            InitializeComponent();
        }

        #region CONSTANTES_DE_NOMBRES_DE_COLUMNAS_STOREDS

        const string ArchivosNombre = "___NOMBRE___";
        const string ArchivosRuta = "__________________________________________________________RUTA__________________________________________________________________";
        const string TemasTema = "__________________________________________TEMA_____________________________________________________";
        const string ModosNombre = "________________________NOMBRE___________________________";
        const string ObjetosNombre = "_______________________________Nombre__________________________________";
        const string RegistrosSegundos = "S";
        const string BloquesNombre = "BLOQUE";
        const string RegistrosTema = "TEMA";
        const string RegistrosApellido = "APELLIDO";
        const string RegistrosVerbo = "VERBO";
        const string RegistrosNexos = "NEXOS";
        const string RegistrosModo = "MODO";
        const string RegistrosObjeto = "OBJETO";
        const string RegistrosAplicacion = "APLICACION";

        #endregion

        #region PROPIEDADES_Y_ENUMERADORES
        private string _name;
        private string ultimoCampoFiltrado = "";
        public string TextoName
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _ruta;
        public string TextoRuta
        {
            get { return _ruta; }
            set { _ruta = value; }
        }

        public string TextoArchivos
        {
            get { return cmbArchivo.Text; }
            set { cmbArchivo.Text = value; }
        }

        public int idTextoArchivos
        {
            get { return Convert.ToInt32(cmbArchivo.Tag); }
            set { cmbArchivo.Tag = value; }
        }

        public int idAplicaciones
        {
            get { return Convert.ToInt32(cmbAplicacion.SelectedValue); }
            set { cmbAplicacion.SelectedText = value.ToString(); }
        }

        public string TextoTemas
        {
            get { return cmbTema.Text; }
            set { cmbTema.Text = value; }
        }

        public string TextoPersonas
        {
            get { return cmbPersona.Text; }
            set { cmbPersona.Text = value; }
        }

        public string TextoVerbos
        {
            get { return cmbVerbo.Text; }
            set { cmbVerbo.Text = value; }
        }

        public string TextoNexos
        {
            get { return cmbNexo.Text; }
            set { cmbNexo.Text = value; }
        }

        public string TextoModos
        {
            get { return cmbModo.Text; }
            set { cmbModo.Text = value; }
        }

        public string TextoObjetos
        {
            get { return cmbObjeto.Text; }
            set { cmbObjeto.Text = value; }
        }

        public string TextoAplicaciones
        {
            get { return cmbAplicacion.Text; }
            set { cmbAplicacion.Text = value; }
        }

        public string TextoBloques
        {
            get { return cmbBloques.Text; }
            set { cmbBloques.Text = value; }
        }

        string _mensajes;
        public string TextoErrores
        {
            get { return _mensajes; }
            set { _mensajes = value; }
        }

        enum Funcion
        {
            grabar
            , filtrar
        }

        enum Ordenado
        {
            Alfabéticamente,
            PorUltimaAparicion
        }

        int fila;
        int columna;

        #endregion

        /// <summary>
        /// Este objeto se usará tanto para busqueda como para ABMs
        /// </summary>
        Clases.Registros reg = new Clases.Registros();
        frmElegirRutaParaNombre rutasPnombre = new frmElegirRutaParaNombre();
        
        private string UltimoTema(DataTable tabla)
        {
            int maximo = 0;
            int actual = 0;
            string ultimo = "";
            foreach (DataRow fila in tabla.Rows)
            {
                if (fila["id"] != null)
                {
                    actual = int.Parse(fila["id"].ToString());
                    if (actual >= maximo)
                    {
                        maximo = int.Parse(fila["id"].ToString());
                        ultimo = fila[RegistrosTema].ToString();
                    }
                }
            }
            return ultimo;
            
        }

        #region CARGA_DE_COMBOS

        private void CargarCombos()
        {
            CargarCombosTiempoDeRegistro();
            CargarComboBloques();
            //CargarComboTemaUltimo();
            CargarComboTemaAlfabeticamente();
            CargaComboPersonas();
            CargaComboVerbos();
            CargaComboNexos();
            CargarComboModos();
            CargarComboObjetos();
            CargarCombosAplicaciones();
            CargaDelimitadorFrases();

        }

        private void CargarHoras()
        {
            for (int i = 0; i <= 23; i++)
            {
                cmbHora.Items.Add(i.ToString());
            }
            cmbHora.Items.Insert(0, "");
        }
        private void CargarMinutosYSegundos()
        {
            for (int i = 0; i <= 59; i++)
            {
                cmbMinuto.Items.Add(i.ToString());
                cmbSegundo.Items.Add(i.ToString());
            }
            cmbMinuto.Items.Insert(0, "");
            cmbSegundo.Items.Insert(0, "");
        }
        private void CargarDiasSemana()
        {
            cmbDia.Items.Add("LU");
            cmbDia.Items.Add("MA");
            cmbDia.Items.Add("MI");
            cmbDia.Items.Add("JU");
            cmbDia.Items.Add("VI");
            cmbDia.Items.Add("SA");
            cmbDia.Items.Add("DO");
            cmbDia.Items.Add("");

        }

        private void CargaDelimitadorFrases()
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("id", typeof(String));
            tabla.Columns.Add("descripcion", typeof(String));
            DataRow fila0 = tabla.NewRow();
            fila0[0] = "";
            fila0[1] = "";
            tabla.Rows.Add(fila0);
            DataRow fila1 = tabla.NewRow();
            fila1[0] = "1";
            fila1[1] = "(";
            tabla.Rows.Add(fila1);
            DataRow fila2 = tabla.NewRow();
            fila2[0] = "2";
            fila2[1] = "+";
            tabla.Rows.Add(fila2);
            DataRow fila3 = tabla.NewRow();
            fila3[0] = "3";
            fila3[1] = ")";
            tabla.Rows.Add(fila3);

            cmbFrase.DataSource = tabla;
            cmbFrase.DisplayMember = "descripcion";
            cmbFrase.ValueMember = "id";
            cmbFraseConsulta.DataSource = tabla;
            cmbFraseConsulta.DisplayMember = "descripcion";
            cmbFraseConsulta.ValueMember = "id";

        }

        private void CargarCombosTiempoDeRegistro()
        {
 
            CargarDiasSemana();
            CargarHoras();
            CargarMinutosYSegundos();

        }

        public void CargarComboTemaAlfabeticamente()
        {
            this.cmbTema.Capture = false;
            if ((new Clases.Temas()).TraerRegistrosAlfabeticamente().Rows.Count > 0)
            {
                cmbTema.DataSource = Utilidades.AgregarFilaVaciaInicial((new Clases.Temas()).TraerRegistrosAlfabeticamente());
                cmbTema.DisplayMember = TemasTema;
                cmbTema.ValueMember = "idTem";
                //cmbTema.Text = ((System.Data.DataRowView)(cmbTema.Items[1])).Row.ItemArray[1].ToString();
                cmbTema.Text = (new Clases.Temas()).TraerRegistrosAlfabeticamente().Rows[0].ToString();
                
            }
            else
            {
                MessageBox.Show("no hay temas para cargar el combo");
            }
        }


        public void CargarCombo30UltimosTemas()
        {
            if ((new Clases.Registros()).Traer30UltimosTemas().Rows.Count > 0 )
            {
                cmbTema.DataSource = Utilidades.AgregarFilaVaciaInicial((new Clases.Registros()).Traer30UltimosTemas());
                cmbTema.DisplayMember = TemasTema;
                cmbTema.ValueMember = "idTem";
 
            }
            else
            {
                MessageBox.Show("no hay temas para cargar el combo");
            }
        }

        public void CargarComboTemaUltimo()
        {
            this.cmbTema.Capture = false;
            if ((new Clases.Temas()).TraerRegistrosUltimo().Rows.Count > 0)
            {
                try
                {
                    cmbTema.DataSource = Utilidades.AgregarFilaVaciaInicial((new Clases.Temas()).TraerRegistrosUltimo());
                    cmbTema.DisplayMember = TemasTema;
                    cmbTema.ValueMember = "idTem";
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Problema con la columna temas" + ex.Message );
                }
            }
            else
            {
                MessageBox.Show("no hay temas para cargar el combo");
            }
        }

        public void CargaComboPersonas()
        {
            if ((new Clases.Personas()).TraerRegistros().Rows.Count > 0)
            {
                cmbPersona.DataSource = Utilidades.AgregarFilaVaciaInicial((new Clases.Personas()).TraerRegistros());
                cmbPersona.DisplayMember = "apellido";
                cmbPersona.ValueMember = "idPer";
            }
            else
            {
                MessageBox.Show("no hay Personas para cargar el combo");
            }
        }

        public void CargaComboVerbos()
        {
            if ((new Clases.Verbos()).TraerRegistros().Rows.Count > 0)
            {
                cmbVerbo.DataSource = Utilidades.AgregarFilaVaciaInicial((new Clases.Verbos()).TraerRegistros());
                cmbVerbo.DisplayMember = "nombre";
                cmbVerbo.ValueMember = "idVer";
            }
            else
            {
                MessageBox.Show("no hay Verbos para cargar el combo");
            }
        }

        public void CargaComboNexos()
        {
            if ((new Clases.Nexos()).TraerRegistros().Rows.Count > 0)
            {
                cmbNexo.DataSource = Utilidades.AgregarFilaVaciaInicial((new Clases.Nexos()).TraerRegistros());
                cmbNexo.DisplayMember = "nexo";
                cmbNexo.ValueMember = "idnex";
            }
            else
            {
                MessageBox.Show("no hay Nexos para cargar el combo");
            }
        }

        public void CargarComboModos()
        {
            if ((new Clases.Modos()).TraerRegistros().Rows.Count > 0)
            {
                cmbModo.DataSource = Utilidades.AgregarFilaVaciaInicial((new Clases.Modos()).TraerRegistros());
                cmbModo.DisplayMember = ModosNombre;
                cmbModo.ValueMember = "idmod";
            }
            else
            {
                MessageBox.Show("no hay Modos para cargar el combo");
            }
        }

        public void CargarComboObjetos()
        {
            if ( (new Clases.Objetos ()).TraerRegistros().Rows.Count > 0 )
            {
                cmbObjeto.DataSource = Utilidades.AgregarFilaVaciaInicial((new Clases.Objetos ()).TraerRegistros());
                cmbObjeto.DisplayMember = ObjetosNombre;
                cmbObjeto.ValueMember = "idobj";
            }
            else
            {
                MessageBox.Show("no hay Objetos para cargar el combo");
            }

        }


        public void CargarCombosAplicaciones()
        {
            if ((new Clases.Aplicaciones()).TraerRegistros().Rows.Count > 0)
            {
                cmbAplicacion.DataSource = Utilidades.AgregarFilaVaciaInicial((new Clases.Aplicaciones()).TraerRegistros());
                cmbAplicacion.DisplayMember = "nombre";
                cmbAplicacion.ValueMember = "idapp";
            }
            else
            {
                MessageBox.Show("no hay Aplicaciones para cargar el combo");
            }
        }

        public void CargarComboBloques()
        {
            if ((new Clases.Bloques()).TraerBloques().Rows.Count > 0)
            {
                cmbBloques.DataSource = Utilidades.AgregarFilaVaciaInicial((new Clases.Bloques()).TraerBloques());
                cmbBloques.DisplayMember = BloquesNombre;
                cmbBloques.ValueMember = "idBloque";
            }
            else
            {
                MessageBox.Show("no hay Bloques para cargar el combo");
            }
        }

        #endregion


        frmTemas objte;
        frmPersona objPe;
        frmVerbos objVe;
        frmNexos objNe;
        frmModos objMo;
        frmObjetos objOb;
        frmAplicaciones objAp;
        frmBloques objBL;
        frmMails objMa;
        frmTelefonos objTl;
        frmAplicacionesMenues objAm;
        frmAplicacionesRoles objRo;
        frmAplicacionesRutas objRu;
        frmNotas objNo;

        private void frmRegistros_Load(object sender, EventArgs e)
        {

            LeerPendientes();
            CargarGrilla(Funcion.filtrar );
            FormarAnchoColumnasPorAnchoCampos(dgRegs);
            CargarCombos();
            BuscarArchivosRecientes();
        }

        private void dgRegs_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex;
            columna = e.ColumnIndex;
            string contenido = dgRegs.Rows[fila].Cells[columna].Value.ToString();
            this.lblclip.Text = contenido;
            this.lblNotasDeArchivo.Text = dgRegs.Rows[fila].Cells[dgRegs.ColumnCount -1].Value.ToString();
         }


        private void CargarGrilla(Funcion f)
        {
            int maximafila = 0;
            CargarEntidad(f);
            DataTable tabla = reg.TraerRegistros();
    
            tabla.Rows.InsertAt(tabla.NewRow(), tabla.Rows.Count);
            dgRegs.DataSource = tabla;
            
            maximafila = dgRegs.Rows.Count - 1;
            dgRegs.CurrentCell = dgRegs.Rows[maximafila].Cells[0];

            

        }

        private void FormarAnchoColumnasPorAnchoCampos(DataGridView d)
        {
            int compensacion = 3;
            
            d.Columns[0].Width = cmbFechaHasta.Size.Width + compensacion;
            d.Columns[1].Width = cmbDia.Size.Width + compensacion;
            d.Columns[2].Width = cmbHora.Size.Width + compensacion;
            d.Columns[3].Width = cmbMinuto.Size.Width + compensacion;
            d.Columns[4].Width = cmbSegundo.Size.Width + compensacion;
            d.Columns[5].Width = cmbTema.Size.Width + compensacion;
            d.Columns[6].Width = cmbPersona.Size.Width + compensacion;
            d.Columns[7].Width = cmbVerbo.Size.Width + compensacion;
            d.Columns[8].Width = cmbNexo.Size.Width + compensacion;
            d.Columns[9].Width = cmbModo.Size.Width + compensacion;
            d.Columns[10].Width = cmbObjeto.Size.Width + compensacion;
            d.Columns[11].Width = cmbArchivo.Size.Width + compensacion;
            d.Columns[12].Width = cmbAplicacion.Size.Width + compensacion;
        }

        private void CargarGrillaConsultaAproximacion(Funcion f)
        {
            int maximafila = 0;
            Clases.Registros regis = new Clases.Registros();

            CargarEntidadParaBusquedaAproximada(regis , f);
            DataTable tabla = regis.FiltradoPorAproximacion();
            tabla.Rows.InsertAt(tabla.NewRow(), tabla.Rows.Count);
            dgRegs.DataSource = tabla;
            maximafila = dgRegs.Rows.Count - 1;
            dgRegs.CurrentCell = dgRegs.Rows[maximafila].Cells[0];
        }



        private void CargarEntidad(Funcion f)
        {
            
            reg.FechaDesde = "";
            if ( f == Funcion.grabar )
                reg.FechaHasta = cmbFechaHasta.Text;
            else
                reg.FechaHasta = "";

            reg.Dia = cmbDia.Text;
            reg.Hora = ( cmbHora.Text  != ""? Convert.ToInt32(cmbHora.Text) : 0);
            reg.Min = ( cmbMinuto.Text != "" ? Convert.ToInt32(cmbMinuto.Text) : 0 );
            reg.Seg  = ( cmbSegundo.Text != ""? Convert.ToInt32(cmbSegundo.Text) : 0);
            
            reg.Tema = ( cmbTema.Text != ""?  cmbTema.SelectedValue.ToString() : "");
            reg.Persona = (cmbPersona.Text != "" ? cmbPersona.SelectedValue.ToString() : "");
            reg.Verbo = (cmbVerbo.Text != ""?  cmbVerbo.SelectedValue.ToString() : "");
            reg.Modo = (cmbModo.Text != "" ? cmbModo.SelectedValue.ToString() : "");
            reg.Nexo = (cmbNexo.Text != "" ? cmbNexo.SelectedValue.ToString() : "");
            reg.Objeto = (cmbObjeto.Text != "" ? cmbObjeto.SelectedValue.ToString() : "");
            reg.Archivo = idTextoArchivos.ToString();
            this.idTextoArchivos = 0;
            reg.Aplicacion = (cmbAplicacion.Text != "" ? cmbAplicacion.SelectedValue.ToString() : "");
            Utilidades.SeleccionarPorValor(cmbFrase, cmbFrase.Text);
            reg.Estado = (cmbFrase.Text != "" ? cmbFrase.SelectedValue.ToString() : ""); 
        }

        private void CargarEntidadParaBusquedaAproximada(Clases.Registros re, Funcion f)
        {
            re.FechaDesde = txtFecha.Text;
            re.FechaHasta = txtFecha.Text;


            re.Dia = "";
            re.Hora = 0;
            re.Min = 0;
            re.Seg = 0;

            re.Tema = txtTemas.Text ;
            re.Persona = txtNombres.Text;
            re.Modo = txtModos.Text;
            re.Verbo = txtVerbos.Text;
            re.Nexo = txtNexos.Text;
            re.Objeto = txtObjetos.Text;
            re.Archivo = txtArchivos.Text;
            re.Aplicacion = txtAplicaciones.Text;
            Utilidades.SeleccionarPorValor(cmbFrase, cmbFrase.Text);
            re.Estado = (cmbFraseConsulta.Text != "" ? cmbFraseConsulta.SelectedValue.ToString() : ""); 
        }

        private void CargarCamposDesdeGrilla()
        {
            int f = fila;
            if (f < 0)
                f = 0;
            try
            {
                reg.Id = Convert.ToInt32(dgRegs.Rows[f].Cells["id"].Value);

                cmbFechaHasta.Text = Utilidades.StringDeColNombre(dgRegs, f, "FECHA");
                cmbDia.Text = Utilidades.StringDeColNombre(dgRegs, f, "D");
                cmbHora.Text = Utilidades.StringDeColNombre(dgRegs, f, "H");
                cmbMinuto.Text = Utilidades.StringDeColNombre(dgRegs, f, "M");
                cmbSegundo.Text = Utilidades.StringDeColNombre(dgRegs, f, RegistrosSegundos);
                cmbTema.Text = Utilidades.StringDeColNombre(dgRegs, f, RegistrosTema );
                cmbPersona.Text = Utilidades.StringDeColNombre(dgRegs, f, RegistrosApellido );
                cmbVerbo.Text = Utilidades.StringDeColNombre(dgRegs, f, RegistrosVerbo );
                cmbNexo.Text = Utilidades.StringDeColNombre(dgRegs, f, RegistrosNexos );
                cmbModo.Text = Utilidades.StringDeColNombre(dgRegs, f, RegistrosModo );
                cmbObjeto.Text = Utilidades.StringDeColNombre(dgRegs, f, RegistrosObjeto );
                //cmbArchivo.Text = Utilidades.StringDeColNombre(dgRegs, f, "                       ARCHIVO                     ");
                cmbAplicacion.Text = Utilidades.StringDeColNombre(dgRegs, f, RegistrosAplicacion );
                /// Ahora cargo el nombre del archivo directamente desde su indice ( en las columnas de indices agregado )
                /// de modo que si hay un valor, creo el objeto Archivo, consulto por su indice y cargo la variable de aplicacion
                /// idTextoArchivo y la TextoArchivos si tiene nombre, recién desde ésta cargo el campo 
                string columnaDeIndice = Utilidades.StringDeColNombre(dgRegs, f, "idArch");
                if (columnaDeIndice != "")
                {
                    Clases.Archivos ar = new Clases.Archivos();
                    ar.IdArch = Convert.ToInt32(columnaDeIndice);
                    DataRow filaTabla = ar.TraerRegistros().Rows[0];
                    idTextoArchivos = Convert.ToInt32(filaTabla["idarch"]);
                    TextoArchivos = (filaTabla[ArchivosNombre] != null ? filaTabla[ArchivosNombre].ToString() : "");
                    cmbArchivo.Text = TextoArchivos;
                }
                
            }
            catch (Exception excep)
            {
                MessageBox.Show("Hay problemas en la carga de los campos desde la grilla, excepción : " + excep.Message );
            }
            cmbArchivo.Focus();
        }

 

        private void LimpiarCampos()
        {
   
            cmbFechaHasta.Text = "";
            cmbDia.Text = "";
            cmbHora.Text = "";
            cmbMinuto.Text = "";
            cmbSegundo.Text = "";
            cmbTema.Text = "";
            cmbPersona.Text = "";
            cmbVerbo.Text = "";
            cmbNexo.Text = "";
            cmbModo.Text = "";
            cmbObjeto.Text = "";
            cmbArchivo.Text = "";
            cmbAplicacion.Text = "";
            
            reg.Id = 0;
            reg.Fecha = "";
            reg.FechaHasta = "";
            reg.FechaDesde = "";
            reg.Dia = "";
            reg.Hora = 0;
            reg.Min = 0;
            reg.Seg = 0;
            reg.Tema = "";
            reg.Persona = "";
            reg.Nexo = "";
            reg.Verbo = "";
            reg.Objeto = "";
            reg.Archivo = "";
            reg.Aplicacion = "";

            this.idTextoArchivos = 0;
            this.TextoArchivos = "";
        }

        private void LimpiarCamposFiltradoAproximacion()
        {
            txtFecha.Text = "";
            txtTemas.Text = "";
            txtNombres.Text = "";
            txtVerbos.Text = "";
            txtModos.Text = "";
            txtNexos.Text = "";
            txtObjetos.Text = "";
            txtArchivos.Text = "";
            txtAplicaciones.Text = "";


            reg.Id = 0;
            reg.Fecha = "";
            reg.FechaHasta = "";
            reg.FechaDesde = "";
            reg.Dia = "";
            reg.Hora = 0;
            reg.Min = 0;
            reg.Seg = 0;
            reg.Tema = "";
            reg.Persona = "";
            reg.Nexo = "";
            reg.Verbo = "";
            reg.Objeto = "";
            reg.Archivo = "";
            reg.Aplicacion = "";
        }


        private void EjecutarRuta(int idarchivo)
        {

            if (idarchivo != 0)
            {
                Clases.Archivos arch = new Clases.Archivos();
                arch.IdArch = idarchivo;
                string unidad = "";
                DataTable archivos = arch.TraerRegistros();
                string ruta = "";
                if (archivos.Rows.Count > 0)
                {
                    ruta = archivos.Rows[0][ArchivosRuta].ToString();
                    if ( !ruta.Contains("http") || !ruta.Contains("www"))
                    {
                        unidad = Utilidades.RutaDeLaDLL().Substring(0, 3);
                        int largo = ruta.Length - 3;
                        ruta = unidad + ruta.Substring(3, largo);

                    }
                    try
                    {
                        System.Diagnostics.Process.Start(ruta);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("NO SE PUEDE ABRIR EL ARCHIVO CUYO ID ES :" + idarchivo + " ERROR " + ex.Message );
                    }
                }
            }

        }

        private void EscribirPendientes()
        {
            //Utilidades.EscribirAArchivo(@"pendientes.txt", txtPendiente.Text );
            Utilidades.SalvarRTF(txtPendiente, @"pendientes.rtf");
            
        }
        public void LeerPendientes()
        {
            // txtPendiente.Text = Utilidades.LeerArchivo(@"pendientes.txt");
            txtPendiente = Utilidades.CargarRTF(txtPendiente, @"pendientes.rtf");
        }

        private string ActualizarUltimos30TemasAPendiente()
        {
            string Concatenacion = "";
            foreach( DataRow fila in (new Clases.Registros()).Traer30UltimosTemas().Rows)
            {
                Concatenacion += fila[TemasTema] + "\n";

            }
            return Concatenacion;
        }

        private void txtPendiente_KeyDown(object sender, KeyEventArgs e)
        {
            
            switch (e.KeyCode)
            {
                case Keys.F1:
                    EscribirPendientes();
                    break;
                case Keys.Insert :
                    Clipboard.SetDataObject(txtPendiente.SelectedText );
                    lblclip.Text = txtPendiente.SelectedText;
                    break;
                case Keys.F9:
                    frmTextoRecordatorio t = new frmTextoRecordatorio();
                    t.Show(this);
                    break;
                case Keys.Home:
                    txtPendiente.SelectionBackColor = Color.Yellow;
                    break;
                case Keys.End:
                    txtPendiente.SelectionBackColor = Color.White;
                    break;
                 case Keys.F11:
                    this.txtPendiente.Text = "_______________________________________________________________ULTIMOS TEMAS_________________________________________________________________________________\n" + ActualizarUltimos30TemasAPendiente() + txtPendiente.Text;
                    break;
                case Keys.F5:
                    //int linea = txtPendiente.Find(txtPendiente.SelectedText,2,txtPendiente.TextLength,RichTextBoxFinds.WholeWord);
                    ResaltarTexto(txtPendiente, txtPendiente.SelectedText, Color.Blue, false);

                    break;
                case Keys.F6:
                    //RestablecerColor(txtPendiente);
                    LeerPendientes();
                    break;
                case Keys.F10:

                    txtArchivos.Text = txtPendiente.SelectedText;
                    txtArchivos.Focus();
                                      
                    break;
                

            }


    
            if (e.Shift && e.KeyCode == Keys.Down)
            {
                switch (ultimoCampoFiltrado)
                {
                    case "bloques":
                        cmbBloques.Focus();
                        break;
                    case "temas":
                        txtTemas.Focus();
                        break;
                    case "nombres":
                        txtNombres.Focus();
                        break;
                    case "verbos":
                        txtVerbos.Focus();
                        break;
                    case "nexos":
                        txtNexos.Focus();
                        break;
                    case "modos":
                        txtModos.Focus();
                        break;
                    case "objetos":
                        txtObjetos.Focus();
                        break;
                    case "archivos":
                        txtArchivos.Focus();
                        break;
                    case "aplicaciones":
                        txtAplicaciones.Focus();
                        break;
                }
            }
        }

        private void  RestablecerColor( RichTextBox rich)
        {
            rich.SelectAll();
            rich.SelectionColor = Color.Black;
            rich.SelectionBackColor = Color.White;
            rich.SelectionLength = 0;
           
        }

        private void ResaltarTexto(RichTextBox rich, string cadena, System.Drawing.Color colores, bool cadena_completa)
        {
            int posicion_caracter = 0;
            int longitud_cadena = 0;
            int posSelInicio = 0;
            RichTextBoxFinds tipoBusqueda1 = RichTextBoxFinds.WholeWord;

            int posSelLen = 0;
            int n = 0;
            if (cadena_completa)
                tipoBusqueda1 = RichTextBoxFinds.MatchCase;


            rich.HideSelection = false;
            posicion_caracter = rich.Find(cadena, rich.SelectionStart + rich.SelectionLength, tipoBusqueda1);
            RestablecerColor(rich);
            posSelInicio = rich.SelectionStart;
            posSelLen = rich.SelectionLength;
            longitud_cadena = cadena.Length;

            //posicion_caracter = rich.Find(cadena, 0,, tipoBusqueda1);
            //posicion_caracter = rich.Find(cadena, 0, rich.Text.Length, tipoBusqueda1);
            while (posicion_caracter > 0)
            {
                n++;
                rich.SelectionStart = posicion_caracter;
                rich.SelectionLength = longitud_cadena;
                rich.SelectionColor = Color.Yellow;
                rich.SelectionBackColor = colores;
                posicion_caracter = rich.Find(cadena, (posicion_caracter + longitud_cadena), rich.Text.Length, tipoBusqueda1);


            }
            rich.SelectionStart = posSelInicio;
            rich.SelectionLength = posSelLen;
        }

        #region EVENTOS_KEY


        private void EventosKeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode )
            {

                case Keys.Home :
                    // tecla INICIO 
                    this.Text = "REGISTRO DE EVENTOS" + " (Home)";
                    cmbBloques.Focus();
                        
                    break;

                case Keys.F1 :
                    //f1
                    this.Text = "REGISTRO DE EVENTOS" + " (F1)";
                    CargarEntidad(Funcion.grabar );
                    reg.GuardaRegistro();
                    LimpiarCampos();
                    CargarGrilla(Funcion.filtrar );
                    cmbTema.Text = UltimoTema((new Clases.Registros().TraerRegistros()));
                    SendKeys.Send("{ESC}");
                    break;


                case Keys.F2:
                    //f2
                    this.Text = "REGISTRO DE EVENTOS" + " (F2)";
                    CargarEntidad(Funcion.grabar );
                    try
                    {
                        reg.ModificarRegistro();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("no preexistía el registro");
                    }
                    LimpiarCampos();
                    CargarGrilla(Funcion.filtrar );
                    cmbTema.Text = UltimoTema((new Clases.Registros().TraerRegistros()));
                    SendKeys.Send("{ESC}");
                    break;
                case Keys.F3:
                    //f3
                    this.Text = "REGISTRO DE EVENTOS" + " (F3)";
                    CargarEntidad(Funcion.grabar );
                    reg.BorrarRegistro();
                    LimpiarCampos();
                    CargarGrilla(Funcion.filtrar );
                    cmbTema.Text = UltimoTema((new Clases.Registros().TraerRegistros()));
                    break;
                case Keys.F4:
                    //f4
                    this.Text = "REGISTRO DE EVENTOS" + " (F4)";
                    LimpiarCampos();
                    break;
                case Keys.F5:
                    this.Text = "REGISTRO DE EVENTOS" + " (F5)";
                    CargarGrilla(Funcion.filtrar );
                    break;
                

                case Keys.F6:
                    //frmDirectorioCombos dis = new frmDirectorioCombos( @"c:\regx\mails\");
                    frmDirSeleccionarUnArchivo dis = new frmDirSeleccionarUnArchivo();
                    
                    rutasPnombre.Show(this);
                    break;
                case Keys.F11:
                    //f11
                    this.Text = "REGISTRO DE EVENTOS" + " (F11)";
                    objBL = new frmBloques();
                    objBL.Show(this);

                    break;
                case Keys.CapsLock :
                    this.Text = "REGISTRO DE EVENTOS" + " (Bloq Mayus)";
                    objNo  = new frmNotas();
                    objNo.Show(this);
                    break;
                case Keys.Divide:
                    this.Text = "REGISTRO DE EVENTOS" + " (Barra División)";
                    frmArchivosDesvinculados ards = new frmArchivosDesvinculados();
                    ards.Show();

                    break;
            }
        }

  



        private void dgRegs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                this.Text = "REGISTRO DE EVENTOS" + " (Carga de registro para editarlo)";
                CargarCamposDesdeGrilla();
            }
            if (e.Shift && e.KeyCode == Keys.Up)
            {

                this.Text = "REGISTRO DE EVENTOS" + " (Home)";
                switch (columna)
                {
                    case 0:
                        this.cmbFechaHasta.Focus();
                        break;
                    case 1:
                        this.cmbDia.Focus();
                        break;
                    case 2:
                        this.cmbHora.Focus();
                        break;
                    case 3:
                        this.cmbMinuto.Focus();
                        break;
                    case 4:
                        this.cmbSegundo.Focus();
                        break;
                    case 5:
                        this.cmbTema.Focus();
                        break;
                    case 6:
                        this.cmbPersona.Focus();
                        break;
                    case 7:
                        this.cmbVerbo.Focus();
                        break;
                    case 8:
                        this.cmbNexo.Focus();
                        break;
                    case 9:
                        this.cmbModo.Focus();
                        break;
                    case 10:
                        this.cmbObjeto.Focus();
                        break;
                    case 11:
                        this.cmbArchivo.Focus();
                        break;
                    case 12:
                        this.cmbAplicacion.Focus();
                        break;

                }
            }


            if (e.KeyCode == Keys.F12 || e.KeyCode == Keys.Enter)
            {
                if (columna == 11)
                    this.Text = "REGISTRO DE EVENTOS" + " (F12 Carga de archivo a S.O.)";
                    EjecutarRuta(Utilidades.IntDeColFilaNombre(dgRegs,fila,"idArch"));
            }

            if (e.KeyCode == Keys.F10)
            {
                this.Text = "REGISTRO DE EVENTOS" + " (F10)";
                switch (columna)
                {
                    case 5:
                        //this.cmbTema.Text = Utilidades.StringDeColumna(dgRegs, fila, columna);
                        Utilidades.SeleccionarPorIndice(this.cmbTema, Utilidades.IntDeColFilaNombre(dgRegs, fila, "idTem"));
                        this.cmbTema.Focus();
                        break;
                    case 6:
                        this.cmbPersona.Text = Utilidades.StringDeColumna(dgRegs, fila, columna);
                        this.cmbPersona.Focus();
                        break;
                    case 7:
                        this.cmbVerbo.Text = Utilidades.StringDeColumna(dgRegs, fila, columna);
                        this.cmbVerbo.Focus();
                        break;
                    case 8:
                        this.cmbNexo.Text = Utilidades.StringDeColumna(dgRegs, fila, columna);
                        this.cmbNexo.Focus();
                        break;
                    case 9:
                        this.cmbModo.Text = Utilidades.StringDeColumna(dgRegs, fila, columna);
                        this.cmbModo.Focus();
                        break;
                    case 10:
                        cmbObjeto.Text = Utilidades.StringDeColumna(dgRegs, fila, columna);
                        this.cmbObjeto.Focus();
                        break;
                    case 11:
                        cmbArchivo.Text = Utilidades.StringDeColumna(dgRegs, fila, columna);
                        this.idTextoArchivos = Utilidades.IntDeColFilaNombre(dgRegs, fila, "idArch");
                        this.cmbArchivo.Focus();                        
                        break;
                    case 12:
                        this.cmbAplicacion.Text = Utilidades.StringDeColumna(dgRegs, fila, columna);
                        this.idAplicaciones = Utilidades.IntDeColFilaNombre(dgRegs, fila, "idApp");
                        this.cmbAplicacion.Focus();
                        break;

                }
            }

            if (e.KeyValue == 37 && columna == 0)
            {
                this.Text = "REGISTRO DE EVENTOS" + " (Abajo)";
                columna = dgRegs.Columns.Count - 2;
                dgRegs.CurrentCell = dgRegs.Rows[fila].Cells[columna];
            }
            if (e.KeyValue == 39 && columna == dgRegs.Columns.Count - 3)
            {
                columna = 0;
                dgRegs.CurrentCell = dgRegs.Rows[fila].Cells[columna];
            }


            if (e.KeyCode == Keys.F7)
            {
                if (columna == 6)
                {
                    this.Text = "REGISTRO DE EVENTOS" + " (F7)";
                    this.TextoPersonas = dgRegs.Rows[fila].Cells[columna].Value.ToString();
                    objTl = new frmTelefonos();
                    objTl.Show(this);

                }
            }
            if (e.KeyCode == Keys.F8)
            {
                this.Text = "REGISTRO DE EVENTOS" + " (F8)";
                if (columna == 6)
                {
                    
                    this.TextoPersonas  = dgRegs.Rows[fila].Cells[columna].Value.ToString();
                    objMa = new frmMails();
                    objMa.Show(this);

                }
            }
            if (e.KeyCode == Keys.F9 )
            {
                this.Text = "REGISTRO DE EVENTOS" + " (F9)";
                if (columna == 6)
                {
                    
                    this.TextoPersonas = dgRegs.Rows[fila].Cells[columna].Value.ToString();
                    objMa = new frmMails();
                    objMa.Show(this);

                }
                if (columna == 12)
                {
                    int idapp = Convert.ToInt32(dgRegs.Rows[fila].Cells["idApp"].Value);
                    frmAplicacionesMenues apm = new frmAplicacionesMenues(idapp);
                    apm.Show(this);
                }
            }
            if (e.KeyCode == Keys.Insert)
            {
                if ( dgRegs.GetCellCount(DataGridViewElementStates.Selected) > 0 )
                {
                    this.Text = "REGISTRO DE EVENTOS" + " (Insert)";
                    this.dgRegs.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
                    Clipboard.SetDataObject(this.dgRegs.GetClipboardContent());
                    
                    string mensaje = "";
                    foreach (DataGridViewCell celda in dgRegs.SelectedCells)
                    {
                        mensaje += celda.Value.ToString() + ";";
                    }
                    this.lblclip.Text = mensaje;
                }
            }

        }

 

        private void cmbTema_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Insert :
                    this.Text = "REGISTRO DE EVENTOS" + " (Insert)";
                    objte = new frmTemas();
                    //objte.Tag = datos;
                    objte.Show(this);

                    break;
                case ( Keys.Alt | Keys.D1):
                    this.Text = "REGISTRO DE EVENTOS" + " (Alt y 1 ordena Temas alfabéticamente)";
                    CargarComboTemaAlfabeticamente();
                    cmbTema.SelectedIndex = 1;
                    break;

                case (Keys.Alt | Keys.D2):
                    this.Text = "REGISTRO DE EVENTOS" + " (Alt y 2 ordena Temas por fecha)";
                    CargarComboTemaUltimo();
                    cmbTema.SelectedIndex = 1;
                    break;

                case (Keys.Alt | Keys.D3):
                    this.Text = "REGISTRO DE EVENTOS" + " (Alt y 2 ordena Temas últimos 30 registros modificados)";
                    CargarCombo30UltimosTemas();
                    break;
                case  ( Keys.Up):
                    txtTemas.Focus();
                    break;
                case  Keys.F10:
                    this.Text = "REGISTRO DE EVENTOS" + " (F10)";
                    txtTemas.Focus();
                    txtTemas.Text = cmbTema.Text;
                    txtTemas.Focus();
                    break;
                case ( Keys.Down):
                    this.Text = "REGISTRO DE EVENTOS" + " (Abajo)";
                    dgRegs.CurrentCell = dgRegs.Rows[fila].Cells[5];
                    
                    dgRegs.BeginEdit(true);
                    break;

            }
            EventosKeyDown(e);
        }


        private void cmbPersona_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Insert :
                    this.Text = "REGISTRO DE EVENTOS" + " (Insert)";
                    objPe = new frmPersona();
                    objPe.Show(this);
                    break;
                case  Keys.F7:
                    this.Text = "REGISTRO DE EVENTOS" + " (F7)";
                    objTl = new frmTelefonos();
                    TextoPersonas = this.cmbPersona.Text;
                    objTl.Show(this);
                    break;
                case Keys.F8:
                    this.Text = "REGISTRO DE EVENTOS" + " (F8)";
                    objMa = new frmMails();
                    TextoPersonas = this.cmbPersona.Text;
                    objMa.Show(this);
                    break;
                case ( Keys.Up):
                    this.Text = "REGISTRO DE EVENTOS" + " (Arriba)";
                    txtNombres.Focus();
                    break;
                case ( Keys.Down):
                    this.Text = "REGISTRO DE EVENTOS" + " (Abajo)";
                    dgRegs.CurrentCell = dgRegs.Rows[fila].Cells[6];
                    dgRegs.BeginEdit(true);
                    break;
                case Keys.F10:
                    this.Text = "REGISTRO DE EVENTOS" + " (F10)";
                    txtNombres.Focus();
                    txtNombres.Text = cmbPersona.Text;
                    txtNombres.DeselectAll();
                    break;


            }
            EventosKeyDown(e);
        }

        private void cmbVerbo_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Insert :
                    this.Text = "REGISTRO DE EVENTOS" + " (Insert)";
                    objVe = new frmVerbos();
                    objVe.Show(this);
                    break;

                case ( Keys.Up):
                    this.Text = "REGISTRO DE EVENTOS" + " (Arriba)";
                    txtVerbos.Focus();
                    break;
                case ( Keys.Down):
                    this.Text = "REGISTRO DE EVENTOS" + " (Abajo)";
                    dgRegs.CurrentCell = dgRegs.Rows[fila].Cells[7];
                    dgRegs.BeginEdit(true);
                    break;
                case Keys.F10:
                    this.Text = "REGISTRO DE EVENTOS" + " (F10)";
                    txtVerbos.Focus();
                    txtVerbos.Text = cmbVerbo.Text;
                    txtVerbos.DeselectAll();
                    break;

            }
            EventosKeyDown(e);
        }

        private void cmbNexo_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Insert :
                    this.Text = "REGISTRO DE EVENTOS" + " (Insert)";
                    objNe = new frmNexos();
                    objNe.Show(this);
                    break;
                 case ( Keys.Up):
                    this.Text = "REGISTRO DE EVENTOS" + " (Arriba)";
                    txtNexos.Focus();
                    break;
                case ( Keys.Down):
                    this.Text = "REGISTRO DE EVENTOS" + " (Abajo)";
                    dgRegs.CurrentCell = dgRegs.Rows[fila].Cells[8];
                    dgRegs.BeginEdit(true);
                    break;
                case Keys.F10:
                    this.Text = "REGISTRO DE EVENTOS" + " (F10)";
                    txtNexos.Focus();
                    txtNexos.Text = cmbNexo.Text;
                    txtNexos.DeselectAll();
                    break;

            }
            EventosKeyDown(e);
        }

        private void cmbModo_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Insert :
                    this.Text = "REGISTRO DE EVENTOS" + " (Insert)";
                    objMo = new frmModos();
                    objMo.Show(this);
                    break;

                case ( Keys.Up):
                    this.Text = "REGISTRO DE EVENTOS" + " (Arriba)";
                    txtModos.Focus();
                    break;
                case ( Keys.Down):
                    this.Text = "REGISTRO DE EVENTOS" + " (Abajo)";
                    dgRegs.CurrentCell = dgRegs.Rows[fila].Cells[9];
                    dgRegs.BeginEdit(true);
                    break;
                case Keys.F10:
                    this.Text = "REGISTRO DE EVENTOS" + " (F10)";
                    txtModos.Focus();
                    txtModos.Text = cmbModo.Text;
                    txtModos.DeselectAll();
                    break;

            }
            EventosKeyDown(e);
        }

        private void cmbObjeto_TextChanged(object sender, EventArgs e)
        {
            this.TextoObjetos = this.cmbObjeto.Text;
        }

        private void cmbObjeto_KeyDown(object sender, KeyEventArgs e)
        {
            
            switch (e.KeyData)
            {
                case Keys.Insert:
                    this.Text = "REGISTRO DE EVENTOS" + " (Insert)";
                    objOb = new frmObjetos();
                    objOb.Show(this);
                    break;
                case ( Keys.Up):
                    this.Text = "REGISTRO DE EVENTOS" + " (Arriba)";
                    txtObjetos.Focus();
                    break;
                case ( Keys.Down):
                    this.Text = "REGISTRO DE EVENTOS" + " (Abajo)";
                    dgRegs.CurrentCell = dgRegs.Rows[fila].Cells[10];
                    dgRegs.BeginEdit(true);
                    break;
                case Keys.F10:
                    this.Text = "REGISTRO DE EVENTOS" + " (F10)";
                    txtObjetos.Focus();
                    txtObjetos.Text = cmbObjeto.Text;
                    txtObjetos.DeselectAll();
                    break;

            }
            EventosKeyDown(e);
        }

        /// <summary>
        /// solo este método es publico para poder invocarlo desde el formulario 
        /// de Clipboard, este salva sus datos como archivo y pasa sus datos a Registros
        /// desde Clipboard se llama a éste método para levantar el formulario de Archivos, registrarlo
        /// en DB y agregar otros datos como el id y finalmente devolver a registros el id, nombre y ruta
        /// del archivo
        /// </summary>
        public void AbrirFormularioArchivos()
        {
            
            frmArchivos ar = new frmArchivos();
            ar.Show(this);
           
            
        }
        //public List<FileInfo> ArchivosRecientes = new List<FileInfo>();
        public Stack<FileInfo> ArchivosRecientes = new Stack<FileInfo>();

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        private void BuscarArchivosRecientes()
        {
            string ruta = Utilidades.ConsultarRutasRelativas("");
            FileSystemWatcher Examinador = new FileSystemWatcher(ruta);
            Examinador.IncludeSubdirectories = true;
            Examinador.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName;
            Examinador.Created += new FileSystemEventHandler(Examinador_Created);
            Examinador.Renamed += new RenamedEventHandler(Examinador_Changed);

            Examinador.EnableRaisingEvents = true;

        }

        void Examinador_Created(object sender, FileSystemEventArgs e)
        {
            FileInfo carga = new FileInfo(e.FullPath);
            bool unico = true;
            foreach (FileInfo contenido in ArchivosRecientes)
            {
                if (contenido.FullName.Equals(e.FullPath))
                    unico = false;
            }
            if (unico)
                if (carga.Extension != "")
                    ArchivosRecientes.Push(carga);
        }

        void Examinador_Changed(object sender, FileSystemEventArgs e)
        {
            FileInfo cambiado = new FileInfo(e.FullPath);

            if (cambiado.Extension != "")
                ArchivosRecientes.Push(cambiado);
        }


        private void cmbArchivo_KeyDown(object sender, KeyEventArgs e)
        {

            
            switch ((e.KeyData))
            {
                case Keys.Insert :
                    this.Text = "REGISTRO DE EVENTOS" + " (Insert)";
                    //this.idTextoArchivos = Utilidades.IntDeColumna(dgRegs, this.idTextoArchivos , 15);
                    AbrirFormularioArchivos();
                    break;

                case  Keys.F7:
                    this.Text = "REGISTRO DE EVENTOS" + " (F7)";
                    //frmClipBoard clip = new frmClipBoard();
                     string rutaRel = Utilidades.ConsultarRutasRelativas(cmbTema.Text );
                     frmClipGraf clip = new frmClipGraf(rutaRel);
                    clip.Show(this);

                    break;

                case Keys.F12:
                    
                    this.ArchivosRecientes.Clear();
                    break;
                case ( Keys.Up):
                    this.Text = "REGISTRO DE EVENTOS" + " (Arriba)";
                    txtArchivos.Focus();
                    break;
                case ( Keys.Down):
                    this.Text = "REGISTRO DE EVENTOS" + " (Abajo)";
                    dgRegs.CurrentCell = dgRegs.Rows[fila].Cells[11];
                    dgRegs.BeginEdit(true);
                    break;
                case Keys.F10:
                    this.Text = "REGISTRO DE EVENTOS" + " (F10)";
                    txtArchivos.Focus();
                    txtArchivos.Text = cmbArchivo.Text;                    
                    txtArchivos.DeselectAll();
                    break;
                case Keys.F6:
                    this.Text = "REGISTRO DE EVENTOS" + " (Del)";
                    Clipboard.SetData(DataFormats.Text ,(object) cmbArchivo.Text );
                    lblclip.Text = cmbArchivo.Text;
                    break;
                case Keys.Delete:
                    this.cmbArchivo.Text = "";
                    this.idTextoArchivos = 0;
                    break;

            }
            EventosKeyDown(e);
        }

        private void cmbAplicacion_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Insert :
                    this.Text = "REGISTRO DE EVENTOS" + " (Insert)";
                    objAp = new frmAplicaciones();
                    objAp.Show(this);
                    break;


                case  Keys.F7:
                    this.Text = "REGISTRO DE EVENTOS" + " (F8)";
                    objRo = new frmAplicacionesRoles();
                     objRo.Show(this);
                    break;
                case  Keys.F8:
                    this.Text = "REGISTRO DE EVENTOS" + " (F9)";
                    objRu = new frmAplicacionesRutas();
                    objRu.Show(this);
                    break;
                case  Keys.F9:
                    //int idapp = Convert.ToInt32(dgRegs.Rows[fila].Cells["idApp"].Value);
                    
                    frmAplicacionesMenues apm = new frmAplicacionesMenues(this.idAplicaciones );
                    apm.Show(this);
                    break;
                case ( Keys.Up):
                    this.Text = "REGISTRO DE EVENTOS" + " (Arriba)";
                    txtAplicaciones.Focus();
                    break;
                case ( Keys.Down):
                    this.Text = "REGISTRO DE EVENTOS" + " (Abajo)";
                    dgRegs.CurrentCell = dgRegs.Rows[dgRegs.Rows.Count - 2].Cells[12];
                    dgRegs.BeginEdit(true);
                    break;
                case Keys.F10:
                    this.Text = "REGISTRO DE EVENTOS" + " (F10)";
                    txtAplicaciones.Focus();
                    txtAplicaciones.Text = cmbAplicacion.Text;
                    txtAplicaciones.DeselectAll();
                    break;

            }
            EventosKeyDown(e);
        }

        private void cmbFechaHasta_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {

                case ( Keys.Down):
                    this.Text = "REGISTRO DE EVENTOS" + " (Abajo)";
                    dgRegs.CurrentCell = dgRegs.Rows[dgRegs.Rows.Count - 2].Cells[0];
                    dgRegs.BeginEdit(true);
                    break;
                case Keys.F:
                    this.Text = "REGISTRO DE EVENTOS" + " (Letra F)";
                    cmbFechaHasta.Focus();
                    SendKeys.Send("{F4}");
                    break;
            }

            //EventosKeyDown(e); esto está comentado para que el F4 de la letra "f" no me limpie campos
        }

        private void cmbBloques_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case  Keys.Enter:
                    this.Text = "REGISTRO DE EVENTOS" + " (Enter)";
                    Clases.Bloques bl = new Clases.Bloques();
                    bl.Bloque = cmbBloques.Text;
                    DataTable tabla = bl.TraerBloques();
                    if (tabla.Rows.Count == 1)
                    {
                        string DescripArchivo = tabla.Rows[0]["ARCHIVO"].ToString();
                        Clases.Archivos ar = new Clases.Archivos();
                        ar.Nombre  = DescripArchivo;
                        DataTable tablaArchivos = ar.TraerRegistros();
                        if (tablaArchivos.Rows.Count > 0)
                        {
                            this.idTextoArchivos = Convert.ToInt32( tablaArchivos.Rows[0]["idArch"]);
                        }
                        

                        if (tabla.Rows[0]["TEMA"].ToString() != "")
                            cmbTema.Text = tabla.Rows[0]["TEMA"].ToString();
                        if (tabla.Rows[0]["PERSONA"].ToString() != "")
                            cmbPersona.Text = tabla.Rows[0]["PERSONA"].ToString();
                        if (tabla.Rows[0]["VERBO"].ToString() != "")
                            cmbVerbo.Text = tabla.Rows[0]["VERBO"].ToString();
                        if (tabla.Rows[0]["N"].ToString() != "")
                            cmbNexo.Text = tabla.Rows[0]["N"].ToString();
                        if (tabla.Rows[0]["MODO"].ToString() != "")
                            cmbModo.Text = tabla.Rows[0]["MODO"].ToString();
                        if (tabla.Rows[0]["OBJETO"].ToString() != "")
                            cmbObjeto.Text = tabla.Rows[0]["OBJETO"].ToString();
                        if (tabla.Rows[0]["ARCHIVO"].ToString() != "")
                            cmbArchivo.Text = DescripArchivo;
                        if (tabla.Rows[0]["APLICACIONES"].ToString() != "")
                            cmbAplicacion.Text = tabla.Rows[0]["APLICACIONES"].ToString();
                    }
                    break;
                case Keys.Insert:
                    this.Text = "REGISTRO DE EVENTOS" + " (Insert)";
                        objBL = new frmBloques();
                         objBL.Show(this);
                   
                    break;
                case  Keys.End:
                    this.Text = "REGISTRO DE EVENTOS" + " (End)";
                    cmbArchivo.Focus();
                    
                    break;
                case ( Keys.Down):
                    this.Text = "REGISTRO DE EVENTOS" + " (Abajo)";
                    dgRegs.CurrentCell = dgRegs.Rows[dgRegs.Rows.Count - 2].Cells[0];
                    dgRegs.BeginEdit(true);
                    break;
  

            }


            if (e.Shift && e.KeyCode == Keys.Up)
            {
                this.ultimoCampoFiltrado = "bloques";
                txtPendiente.Focus();
            }
                


            EventosKeyDown(e);
        }

        private void cmbDia_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {

                case ( Keys.Down):
                    this.Text = "REGISTRO DE EVENTOS" + " (Abajo)";
                    dgRegs.CurrentCell = dgRegs.Rows[dgRegs.Rows.Count - 2].Cells[1];
                    dgRegs.BeginEdit(true);
                    break;
                case ( Keys.Up):
                    txtPendiente.Focus();
                    break;

            }
            EventosKeyDown(e);
        }

        private void cmbHora_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {

                case ( Keys.Down):
                    this.Text = "REGISTRO DE EVENTOS" + " (Abajo)";
                    dgRegs.CurrentCell = dgRegs.Rows[dgRegs.Rows.Count - 2].Cells[2];
                    dgRegs.BeginEdit(true);
                    break;
                case ( Keys.Up):
                    txtPendiente.Focus();
                    break;
            }
            EventosKeyDown(e);
        }

        private void cmbMinuto_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {

                case ( Keys.Down):
                    this.Text = "REGISTRO DE EVENTOS" + " (Abajo)";
                    dgRegs.CurrentCell = dgRegs.Rows[dgRegs.Rows.Count - 2].Cells[3];
                    dgRegs.BeginEdit(true);
                    break;
                case ( Keys.Up):
                    txtPendiente.Focus();
                    break;
            }
            EventosKeyDown(e);
        }

        private void cmbSegundo_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {

                case ( Keys.Down):
                    this.Text = "REGISTRO DE EVENTOS" + " (Abajo)";
                    dgRegs.CurrentCell = dgRegs.Rows[dgRegs.Rows.Count - 2].Cells[4];
                    dgRegs.BeginEdit(true);
                    break;
                case ( Keys.Up):
                    txtPendiente.Focus();
                    break;
            }
            EventosKeyDown(e);
        }

        private void cmbFrase_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {

                case Keys.Down:
                    this.Text = "REGISTRO DE EVENTOS" + " (Abajo)";
                    dgRegs.CurrentCell = dgRegs.Rows[dgRegs.Rows.Count - 2].Cells[14];
                    dgRegs.BeginEdit(true);
                    break;
            }
            EventosKeyDown(e);
        }



        private void cmbFraseConsulta_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {

                case Keys.Down:
                    this.Text = "REGISTRO DE EVENTOS" + " (Abajo)";
                    dgRegs.CurrentCell = dgRegs.Rows[dgRegs.Rows.Count - 2].Cells[14];
                    dgRegs.BeginEdit(true);
                    break;
            }
            EventosKeyDown(e);
        }

        private void txtFecha_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyValue  )
            {
                case (int) Keys.F:
                    this.Text = "REGISTRO DE EVENTOS" + " (Letra F)";
                    txtFecha.Visible = false;
                    dtpFecha.Visible = true;
                    dtpFecha.Focus();
                    SendKeys.Send("{F4}");
                    break;
                case (int) Keys.Down :
                    this.Text = "REGISTRO DE EVENTOS" + " (Abajo)";
                    cmbTema.Focus();
                    break;

            }


            EventosKeyDownTEXTOS(sender,e);
            
        }

        private void dtpFecha_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {

                case (int)Keys.Enter:
                    this.Text = "REGISTRO DE EVENTOS" + " (Enter)";
                    dtpFecha.Visible = false;
                    txtFecha.Visible = true;
                    txtFecha.Text = dtpFecha.Text;
                    txtFecha.Focus();
                    break;
            }

        }



        #endregion

        #region COMBOS_ENTER
        private void cmbBloques_Enter(object sender, EventArgs e)
        {
            
            cmbBloques.DroppedDown = true;

        }

     

        private void cmbPersona_Enter(object sender, EventArgs e)
        {

            cmbPersona.DroppedDown = true;

        }

        private void cmbTema_Enter(object sender, EventArgs e)
        {

            cmbTema.DroppedDown = true;
        }

        private void cmbNexo_Enter(object sender, EventArgs e)
        {

            cmbNexo.DroppedDown = true;
        }

        private void cmbModo_Enter(object sender, EventArgs e)
        {

            cmbModo.DroppedDown = true;
        }


        private void cmbVerbo_Enter(object sender, EventArgs e)
        {

            cmbVerbo.DroppedDown = true;
        }


        private void cmbObjeto_Enter(object sender, EventArgs e)
        {
  
            cmbObjeto.DroppedDown = true;
        }

        private void cmbArchivo_Enter(object sender, EventArgs e)
        {
           
        }

        private void cmbAplicacion_Enter(object sender, EventArgs e)
        {
   
            cmbAplicacion.DroppedDown = true;
            
        }

        private void cmbDia_Enter(object sender, EventArgs e)
        {

            cmbDia.DroppedDown = true;
        }

        private void cmbHora_Enter(object sender, EventArgs e)
        {

            cmbHora.DroppedDown = true;
        }

        private void cmbMinuto_Enter(object sender, EventArgs e)
        {
     
            cmbMinuto.DroppedDown = true;
        }

        private void cmbSegundo_Enter(object sender, EventArgs e)
        {
           
            cmbSegundo.DroppedDown = true;
        }

        private void cmbFrase_Enter(object sender, EventArgs e)
        {
           
            cmbFrase.DroppedDown = true;
        }

        private void cmbFraseConsulta_Enter(object sender, EventArgs e)
        {
         
            cmbFraseConsulta.DroppedDown = true;
        }



        #endregion

        private void cmbAplicacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.idAplicaciones = (cmbAplicacion.Text != "" ? Convert.ToInt32(cmbAplicacion.SelectedValue) : 0);
        }
        
        #region MOUSE

        private void cmbTema_MouseHover(object sender, EventArgs e)
        {
            ttCarteles.UseAnimation = true;
            ttCarteles.IsBalloon = true;
            ttCarteles.Show("CTRL= para definir bloque ,INSERT = para agregar parametros,F1=alta,F2=modifica,F3=baja", cmbTema, 1000);
        }

        private void txtPendiente_MouseHover(object sender, EventArgs e)
        {
            ttCarteles.UseAnimation = true;
            ttCarteles.IsBalloon = true;
            ttCarteles.Show("CTRL= para definir bloque ,F1 para grabar", txtPendiente, 1000);
        }

        private void cmbArchivo_MouseHover(object sender, EventArgs e)
        {
            ttCarteles.UseAnimation = true;
            ttCarteles.IsBalloon = true;
            ttCarteles.Show("F12 = ir a ruta,INSERT = agregar parametros, CTRL= para definir bloque ,F6 = cargar Word, F7 = CLIPBOARD,F1=alta,F2=modifica,F3=baja", cmbArchivo, 1000);
        }

        private void txtAplicaciones_MouseHover(object sender, EventArgs e)
        {
            ttCarteles.UseAnimation = true;
            ttCarteles.IsBalloon = true;
            ttCarteles.Show("INSERT = agregar parametros, CTRL= para definir bloque ,F1=alta,F2=modifica,F3=baja", cmbArchivo, 1000);
        }
        private void cmbBloques_MouseHover(object sender, EventArgs e)
        {
            ttCarteles.UseAnimation = true;
            ttCarteles.IsBalloon = true;
            ttCarteles.Show("INSERT = agregar parametros, F6 = cargar Word, END = pasa a Archivos,F1=alta,F2=modifica,F3=baja", cmbArchivo, 1000);
        }

        private void cmbPersona_MouseHover(object sender, EventArgs e)
        {
            ttCarteles.UseAnimation = true;
            ttCarteles.IsBalloon = true;
            ttCarteles.Show("CTRL= para definir bloque ,INSERT = agregar parametros, F6 = cargar Word, F7 = TELEFONOS,F2=modifica,F3=baja", cmbArchivo, 1000);

        }

        #endregion

        #region FILTRADO_POR_APROXIMACION_TEXTUAL

        private void EventosKeyDownTEXTOS(object  q, KeyEventArgs e)
        {
        switch (e.KeyCode )
            {
                case Keys.Enter :
                    this.Text = "REGISTRO DE EVENTOS" + " (Enter)";
                    CargarGrillaConsultaAproximacion(Funcion.filtrar);

                    break;
                case Keys.Tab :
                    this.Text = "REGISTRO DE EVENTOS" + " (Tab)";
                    cmbBloques.Focus();
                    break;
                case Keys.F4:
                    this.Text = "REGISTRO DE EVENTOS" + " (F4)";
                    LimpiarCamposFiltradoAproximacion();
                    break;
            }
        if (e.Control && e.KeyCode == Keys.Delete)
            if (q.GetType().Name == "TextBox")
                ((TextBox)q).Text = "";
            
        }

        private void txtTemas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                cmbTema.Focus();

            if (e.Shift && e.KeyCode == Keys.Up)
            {
                ultimoCampoFiltrado = "temas";
                txtPendiente.Focus();
            }

            if (e.Shift && e.KeyCode == Keys.Delete)
                this.txtTemas.Text = "";
           
            EventosKeyDownTEXTOS(sender , e);
        }

        private void txtNombres_KeyDown(object sender, KeyEventArgs e)
        {
            if ( e.KeyCode == Keys.Down)                
                cmbPersona.Focus();
            if (e.Shift && e.KeyCode == Keys.Delete)
                this.txtNombres.Text = "";
            if (e.Shift && e.KeyCode == Keys.Up)
            {
                ultimoCampoFiltrado = "nombres";
                txtPendiente.Focus();
            }

            EventosKeyDownTEXTOS(sender, e);

        }

        private void txtVerbos_KeyDown(object sender, KeyEventArgs e)
        {
            if ( e.KeyCode == Keys.Down)
               
                cmbVerbo.Focus();
            if (e.Shift && e.KeyCode == Keys.Delete)
                this.txtVerbos.Text = "";
            if (e.Shift && e.KeyCode == Keys.Up)
            {
                ultimoCampoFiltrado = "verbos";
                txtPendiente.Focus();
            }

            EventosKeyDownTEXTOS(sender, e);
        }

        private void txtNexos_KeyDown(object sender, KeyEventArgs e)
        {
            if ( e.KeyCode == Keys.Down)
                
                cmbNexo.Focus();
            if (e.Shift && e.KeyCode == Keys.Delete)
                this.txtNexos.Text = "";
            if (e.Shift && e.KeyCode == Keys.Up)
            {
                ultimoCampoFiltrado = "nexos";
                txtPendiente.Focus();
            }

            EventosKeyDownTEXTOS(sender, e);
        }

        private void txtModos_KeyDown(object sender, KeyEventArgs e)
        {
            if ( e.KeyCode == Keys.Down)
               
                cmbModo.Focus();

            if (e.Shift && e.KeyCode == Keys.Delete)
                this.txtModos.Text = "";
            if (e.Shift && e.KeyCode == Keys.Up)
            {
                ultimoCampoFiltrado = "modos";
                txtPendiente.Focus();
            }

            EventosKeyDownTEXTOS(sender, e);
        }

        private void txtObjetos_KeyDown(object sender, KeyEventArgs e)
        {
            if ( e.KeyCode == Keys.Down)
               
                cmbObjeto.Focus();
            if (e.Shift && e.KeyCode == Keys.Delete)
                this.txtObjetos.Text = "";
            if (e.Shift && e.KeyCode == Keys.Up)
            {
                ultimoCampoFiltrado = "objetos";
                txtPendiente.Focus();
            }

            EventosKeyDownTEXTOS(sender, e);
        }

        private void txtArchivos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                
                cmbArchivo.Focus();
            //if (e.Control  && e.KeyCode == Keys.Delete)
            //    this.txtArchivos.Text = "";
            if (e.Shift && e.KeyCode ==  Keys.Up)
            {
                ultimoCampoFiltrado = "archivos";
                txtPendiente.Focus();
            }

            EventosKeyDownTEXTOS(sender, e);
        }

        private void txtAplicaciones_KeyDown(object sender, KeyEventArgs e)
        {
            if ( e.KeyCode == Keys.Down)
               
                cmbAplicacion.Focus();
            if (e.Shift && e.KeyCode == Keys.Delete)
                this.txtAplicaciones.Text = "";
            if (e.Shift && e.KeyCode == Keys.Up)
            {
                ultimoCampoFiltrado = "aplicaciones";
                txtPendiente.Focus();
            }

            EventosKeyDownTEXTOS(sender, e);
        }


        #endregion

        #region BACKUPEO_AUTOMATICO

        private void Backupeo()
        {
            DataTable tablaRutasDeHoy = reg.TraerTodasLasRutasDeHoy();
            string origen = "";
            string origenBackupTablas = "";
            string destino = "";
            string directorio = "";
            string error = "";
            int largo = 0;
            string subruta = "";
            //***************** traigo la ruta del archivo RutasBackUp.txt *************************

            //int hasta = Assembly.GetExecutingAssembly().Location.LastIndexOf(@"\") + 1;
            //string rutaDeLaDLL = Assembly.GetExecutingAssembly().Location.Substring(0, hasta);

            string rutaDeLaDLL = Utilidades.RutaDeLaDLL();

            List<string> rutas = new List<string>();

            //MessageBox.Show("ruta del archivo RutasBackup.txt :" + rutaDeLaDLL);

            //********* traigo las rutas que no estén comentadas desde el archivo RutasBackUp.txt ***
            string cadena = "";
            StreamReader lector = new StreamReader(rutaDeLaDLL + "RutasBackUp.txt");
            try
            {
                while (!lector.EndOfStream)
                {
                    cadena = lector.ReadLine();
                    if (!cadena.Contains("//"))
                        rutas.Add(cadena);
                 }


            }
            catch (Exception ex)
            {
                error = "problemas para leer el archivo de destinos backups";
            }
            finally
            {
                lector.Close();
            }

            //*** genero el archivo de backup de tablas y lo guardo en su posición por fecha *******

            DataSet ds = reg.TraerTodosLosInserts();
            string fecha = System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString("00") + System.DateTime.Now.Day.ToString("00");
            origenBackupTablas = rutaDeLaDLL.Substring(0,2) + @"\REGX\BACKUP\TABLAS\" + fecha + ".sql";
            StreamWriter escritor = new StreamWriter(origenBackupTablas);



            foreach (DataTable tabla in ds.Tables)
            {
                foreach (DataRow fila in tabla.Rows)
                {
                    escritor.WriteLine(fila["linea"]);
                    escritor.Flush();
                }
            }
            escritor.Close();

            // ** copio todos los archivos de registros de la fecha a los destinos del archivo RutasBackUp.txt ****

            FileIOPermission f = new FileIOPermission(PermissionState.Unrestricted);
            f.AllFiles = FileIOPermissionAccess.AllAccess;
            try
            {
                f.Demand();
            }
            catch (Exception ex)
            {
                error += "No se obtuvieron todos los permisos";
            }

            foreach (string rutaDestino in rutas)
            {

                foreach (DataRow rutaDeHoy in tablaRutasDeHoy.Rows)
                {
                    origen = rutaDeHoy[0].ToString();
                    try
                    {

                            largo = origen.IndexOf("REGX", 1) + 4;
                            subruta = origen.Substring(largo, (origen.Length - largo));

                            destino = rutaDestino + subruta;

                            directorio = destino.Substring(0, destino.LastIndexOf("\\"));

                        if ((destino.IndexOf(@"/") < 0) && (origen.IndexOf(@"/") < 0))
                        {
                            Directory.CreateDirectory(directorio);
                            System.IO.File.Copy(origen, destino, true);
                        }
                    }
                    catch (Exception er)
                    {

                        error += "no se encontró la ruta " + destino + " o " + er.Message + "\r\n";
                    }

                }
                try
                {
                    destino = rutaDestino + @"\BACKUP\TABLAS\" + fecha + ".sql";
                    directorio = destino.Substring(0, destino.LastIndexOf("\\"));
                    Directory.CreateDirectory(directorio);
                    System.IO.File.Copy(origenBackupTablas, destino, true);
                }
                catch (Exception ex)
                {
                    error += " problemas con la copia del backup de tablas";
                }

            }

            if (error == "")
                MessageBox.Show("Backup Exitoso");
            else
            {
                frmErroresBackup errs = new frmErroresBackup();
                errs.Tag = error;
                errs.Show();
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            Backupeo();
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    frmArchivosDesvinculados desvin = new frmArchivosDesvinculados();
        //    desvin.Show();
        //}


        #endregion

        #region COLOREADO_CAMPOS

        private void txtTemas_Enter(object sender, EventArgs e)
        {
            
            txtTemas.BackColor = Color.Black;
            txtTemas.ForeColor = Color.White;
            txtTemas.Font = new Font(this.Font, FontStyle.Bold);
           
        }

        private void txtTemas_Leave(object sender, EventArgs e)
        {
            txtTemas.BackColor = Color.White;
            txtTemas.ForeColor = Color.Black;
            txtTemas.Font = new Font(this.Font, FontStyle.Regular );
        }

        private void txtNombres_Enter(object sender, EventArgs e)
        {
            txtNombres.BackColor = Color.Black;
            txtNombres.ForeColor = Color.White;
            txtNombres.Font = new Font(this.Font, FontStyle.Bold);
        }

        private void txtNombres_Leave(object sender, EventArgs e)
        {
            txtNombres.BackColor = Color.White;
            txtNombres.ForeColor = Color.Black;
            txtNombres.Font = new Font(this.Font, FontStyle.Regular );
        }

        private void txtVerbos_Enter(object sender, EventArgs e)
        {
            txtVerbos.BackColor = Color.Black;
            txtVerbos.ForeColor = Color.White;
            txtVerbos.Font = new Font(this.Font, FontStyle.Bold);
        }

        private void txtVerbos_Leave(object sender, EventArgs e)
        {
            txtVerbos.BackColor = Color.White;
            txtVerbos.ForeColor = Color.Black;
            txtVerbos.Font = new Font(this.Font, FontStyle.Regular );
        }

        private void txtNexos_Enter(object sender, EventArgs e)
        {
            txtNexos.BackColor = Color.Black;
            txtNexos.ForeColor = Color.White;
            txtNexos.Font = new Font(this.Font, FontStyle.Bold);
        }

        private void txtNexos_Leave(object sender, EventArgs e)
        {
            txtNexos.BackColor = Color.White;
            txtNexos.ForeColor = Color.Black;
            txtNexos.Font = new Font(this.Font, FontStyle.Regular);
        }


        private void txtModos_Enter(object sender, EventArgs e)
        {
            txtModos.BackColor = Color.Black;
            txtModos.ForeColor = Color.White;
            txtModos.Font = new Font(this.Font, FontStyle.Bold);
        }

        private void txtModos_Leave(object sender, EventArgs e)
        {
            txtModos.BackColor = Color.White;
            txtModos.ForeColor = Color.Black;
            txtModos.Font = new Font(this.Font, FontStyle.Regular );
        }

        private void txtObjetos_Enter(object sender, EventArgs e)
        {
            txtObjetos.BackColor = Color.Black;
            txtObjetos.ForeColor = Color.White;
            txtObjetos.Font = new Font(this.Font, FontStyle.Bold);
        }

        private void txtObjetos_Leave(object sender, EventArgs e)
        {
            txtObjetos.BackColor = Color.White;
            txtObjetos.ForeColor = Color.Black;
            txtObjetos.Font = new Font(this.Font, FontStyle.Regular);
        }

        private void txtArchivos_Enter(object sender, EventArgs e)
        {
            txtArchivos.BackColor = Color.Black;
            txtArchivos.ForeColor = Color.White;
            txtArchivos.Font = new Font(this.Font, FontStyle.Bold);
        }

        private void txtArchivos_Leave(object sender, EventArgs e)
        {
            txtArchivos.BackColor = Color.White;
            txtArchivos.ForeColor = Color.Black;
            txtArchivos.Font = new Font(this.Font, FontStyle.Regular );
        }

        private void txtAplicaciones_Enter(object sender, EventArgs e)
        {
            txtAplicaciones.BackColor = Color.Black;
            txtAplicaciones.ForeColor = Color.White;
            txtAplicaciones.Font = new Font(this.Font, FontStyle.Bold);
        }

        private void txtAplicaciones_Leave(object sender, EventArgs e)
        {
            txtAplicaciones.BackColor = Color.White;
            txtAplicaciones.ForeColor = Color.Black;
            txtAplicaciones.Font = new Font(this.Font, FontStyle.Regular );
        }

        private void cmbFraseConsulta_Leave(object sender, EventArgs e)
        {
            cmbFraseConsulta.BackColor = Color.White;
            cmbFraseConsulta.ForeColor = Color.Black;
            cmbFraseConsulta.Font = new Font(this.Font, FontStyle.Bold);
        }

        private void txtFecha_Enter(object sender, EventArgs e)
        {
            txtFecha.BackColor = Color.Black;
            txtFecha.ForeColor = Color.White;
            txtFecha.Font = new Font(this.Font, FontStyle.Bold );
        }

        private void txtFecha_Leave(object sender, EventArgs e)
        {
            txtFecha.BackColor = Color.White;
            txtFecha.ForeColor = Color.Black;
            txtFecha.Font = new Font(this.Font, FontStyle.Regular);
        }


        #endregion

        private void frmRegistros_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
            GC.Collect();
        }

        private void txtPendiente_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtVerbos_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAplicaciones_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtArchivos_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtObjetos_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtModos_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNexos_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbArchivo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombres_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbObjeto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbVerbo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbNexo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbModo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbPersona_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtPendiente_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        private void txtPendiente_TextChanged_1(object sender, EventArgs e)
        {

        }



    }
}
