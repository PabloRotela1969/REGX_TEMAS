namespace RegistrosNet
{
    partial class frmRegistros
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistros));
            this.dgRegs = new System.Windows.Forms.DataGridView();
            this.cmbDia = new System.Windows.Forms.ComboBox();
            this.cmbHora = new System.Windows.Forms.ComboBox();
            this.cmbMinuto = new System.Windows.Forms.ComboBox();
            this.cmbSegundo = new System.Windows.Forms.ComboBox();
            this.cmbTema = new System.Windows.Forms.ComboBox();
            this.cmbPersona = new System.Windows.Forms.ComboBox();
            this.cmbModo = new System.Windows.Forms.ComboBox();
            this.cmbNexo = new System.Windows.Forms.ComboBox();
            this.cmbVerbo = new System.Windows.Forms.ComboBox();
            this.cmbObjeto = new System.Windows.Forms.ComboBox();
            this.cmbAplicacion = new System.Windows.Forms.ComboBox();
            this.cmbFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.cmbBloques = new System.Windows.Forms.ComboBox();
            this.ttCarteles = new System.Windows.Forms.ToolTip(this.components);
            this.process1 = new System.Diagnostics.Process();
            this.txtTemas = new System.Windows.Forms.TextBox();
            this.txtNombres = new System.Windows.Forms.TextBox();
            this.txtVerbos = new System.Windows.Forms.TextBox();
            this.txtNexos = new System.Windows.Forms.TextBox();
            this.txtModos = new System.Windows.Forms.TextBox();
            this.txtObjetos = new System.Windows.Forms.TextBox();
            this.txtArchivos = new System.Windows.Forms.TextBox();
            this.txtAplicaciones = new System.Windows.Forms.TextBox();
            this.cmbArchivo = new System.Windows.Forms.TextBox();
            this.btnBackup = new System.Windows.Forms.Button();
            this.cmbFrase = new System.Windows.Forms.ComboBox();
            this.cmbFraseConsulta = new System.Windows.Forms.ComboBox();
            this.lblclip = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.txtPendiente = new System.Windows.Forms.RichTextBox();
            this.lblNotasDeArchivo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgRegs)).BeginInit();
            this.SuspendLayout();
            // 
            // dgRegs
            // 
            this.dgRegs.AllowUserToAddRows = false;
            this.dgRegs.AllowUserToDeleteRows = false;
            this.dgRegs.AllowUserToOrderColumns = true;
            this.dgRegs.AllowUserToResizeRows = false;
            this.dgRegs.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgRegs.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgRegs.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dgRegs.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgRegs.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgRegs.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgRegs.GridColor = System.Drawing.SystemColors.Highlight;
            this.dgRegs.Location = new System.Drawing.Point(2, 243);
            this.dgRegs.Name = "dgRegs";
            this.dgRegs.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgRegs.RowHeadersVisible = false;
            this.dgRegs.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgRegs.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgRegs.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgRegs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgRegs.ShowEditingIcon = false;
            this.dgRegs.ShowRowErrors = false;
            this.dgRegs.Size = new System.Drawing.Size(1306, 224);
            this.dgRegs.TabIndex = 27;
            this.dgRegs.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgRegs_CellEnter);
            this.dgRegs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgRegs_KeyDown);
            // 
            // cmbDia
            // 
            this.cmbDia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbDia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDia.FormattingEnabled = true;
            this.cmbDia.Location = new System.Drawing.Point(72, 216);
            this.cmbDia.Name = "cmbDia";
            this.cmbDia.Size = new System.Drawing.Size(32, 21);
            this.cmbDia.TabIndex = 11;
            this.cmbDia.Enter += new System.EventHandler(this.cmbDia_Enter);
            this.cmbDia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbDia_KeyDown);
            // 
            // cmbHora
            // 
            this.cmbHora.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbHora.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbHora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbHora.FormattingEnabled = true;
            this.cmbHora.Location = new System.Drawing.Point(107, 216);
            this.cmbHora.Name = "cmbHora";
            this.cmbHora.Size = new System.Drawing.Size(34, 21);
            this.cmbHora.TabIndex = 12;
            this.cmbHora.Enter += new System.EventHandler(this.cmbHora_Enter);
            this.cmbHora.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbHora_KeyDown);
            // 
            // cmbMinuto
            // 
            this.cmbMinuto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbMinuto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMinuto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMinuto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMinuto.FormattingEnabled = true;
            this.cmbMinuto.Location = new System.Drawing.Point(145, 216);
            this.cmbMinuto.Name = "cmbMinuto";
            this.cmbMinuto.Size = new System.Drawing.Size(37, 21);
            this.cmbMinuto.TabIndex = 13;
            this.cmbMinuto.Enter += new System.EventHandler(this.cmbMinuto_Enter);
            this.cmbMinuto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbMinuto_KeyDown);
            // 
            // cmbSegundo
            // 
            this.cmbSegundo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbSegundo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSegundo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSegundo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSegundo.FormattingEnabled = true;
            this.cmbSegundo.Location = new System.Drawing.Point(185, 216);
            this.cmbSegundo.Name = "cmbSegundo";
            this.cmbSegundo.Size = new System.Drawing.Size(41, 21);
            this.cmbSegundo.TabIndex = 14;
            this.cmbSegundo.Enter += new System.EventHandler(this.cmbSegundo_Enter);
            this.cmbSegundo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbSegundo_KeyDown);
            // 
            // cmbTema
            // 
            this.cmbTema.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTema.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTema.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTema.DropDownWidth = 800;
            this.cmbTema.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTema.FormattingEnabled = true;
            this.cmbTema.Location = new System.Drawing.Point(229, 216);
            this.cmbTema.MaxDropDownItems = 20;
            this.cmbTema.Name = "cmbTema";
            this.cmbTema.Size = new System.Drawing.Size(231, 21);
            this.cmbTema.TabIndex = 1;
            this.cmbTema.Enter += new System.EventHandler(this.cmbTema_Enter);
            this.cmbTema.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbTema_KeyDown);
            this.cmbTema.MouseHover += new System.EventHandler(this.cmbTema_MouseHover);
            // 
            // cmbPersona
            // 
            this.cmbPersona.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbPersona.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPersona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPersona.DropDownWidth = 400;
            this.cmbPersona.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPersona.FormattingEnabled = true;
            this.cmbPersona.Location = new System.Drawing.Point(463, 217);
            this.cmbPersona.MaxDropDownItems = 20;
            this.cmbPersona.Name = "cmbPersona";
            this.cmbPersona.Size = new System.Drawing.Size(93, 21);
            this.cmbPersona.Sorted = true;
            this.cmbPersona.TabIndex = 2;
            this.cmbPersona.SelectedIndexChanged += new System.EventHandler(this.cmbPersona_SelectedIndexChanged);
            this.cmbPersona.Enter += new System.EventHandler(this.cmbPersona_Enter);
            this.cmbPersona.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbPersona_KeyDown);
            this.cmbPersona.MouseHover += new System.EventHandler(this.cmbPersona_MouseHover);
            // 
            // cmbModo
            // 
            this.cmbModo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbModo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbModo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModo.DropDownWidth = 400;
            this.cmbModo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbModo.FormattingEnabled = true;
            this.cmbModo.Location = new System.Drawing.Point(733, 216);
            this.cmbModo.MaxDropDownItems = 20;
            this.cmbModo.Name = "cmbModo";
            this.cmbModo.Size = new System.Drawing.Size(101, 21);
            this.cmbModo.Sorted = true;
            this.cmbModo.TabIndex = 5;
            this.cmbModo.SelectedIndexChanged += new System.EventHandler(this.cmbModo_SelectedIndexChanged);
            this.cmbModo.Enter += new System.EventHandler(this.cmbModo_Enter);
            this.cmbModo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbModo_KeyDown);
            // 
            // cmbNexo
            // 
            this.cmbNexo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbNexo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbNexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNexo.DropDownWidth = 100;
            this.cmbNexo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNexo.FormattingEnabled = true;
            this.cmbNexo.Location = new System.Drawing.Point(650, 217);
            this.cmbNexo.MaxDropDownItems = 20;
            this.cmbNexo.Name = "cmbNexo";
            this.cmbNexo.Size = new System.Drawing.Size(78, 21);
            this.cmbNexo.Sorted = true;
            this.cmbNexo.TabIndex = 4;
            this.cmbNexo.SelectedIndexChanged += new System.EventHandler(this.cmbNexo_SelectedIndexChanged);
            this.cmbNexo.Enter += new System.EventHandler(this.cmbNexo_Enter);
            this.cmbNexo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbNexo_KeyDown);
            // 
            // cmbVerbo
            // 
            this.cmbVerbo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbVerbo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbVerbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVerbo.DropDownWidth = 200;
            this.cmbVerbo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVerbo.FormattingEnabled = true;
            this.cmbVerbo.Location = new System.Drawing.Point(560, 217);
            this.cmbVerbo.MaxDropDownItems = 20;
            this.cmbVerbo.Name = "cmbVerbo";
            this.cmbVerbo.Size = new System.Drawing.Size(86, 21);
            this.cmbVerbo.Sorted = true;
            this.cmbVerbo.TabIndex = 3;
            this.cmbVerbo.SelectedIndexChanged += new System.EventHandler(this.cmbVerbo_SelectedIndexChanged);
            this.cmbVerbo.Enter += new System.EventHandler(this.cmbVerbo_Enter);
            this.cmbVerbo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbVerbo_KeyDown);
            // 
            // cmbObjeto
            // 
            this.cmbObjeto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbObjeto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbObjeto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbObjeto.DropDownWidth = 400;
            this.cmbObjeto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbObjeto.FormattingEnabled = true;
            this.cmbObjeto.Location = new System.Drawing.Point(839, 216);
            this.cmbObjeto.MaxDropDownItems = 20;
            this.cmbObjeto.Name = "cmbObjeto";
            this.cmbObjeto.Size = new System.Drawing.Size(103, 21);
            this.cmbObjeto.Sorted = true;
            this.cmbObjeto.TabIndex = 6;
            this.cmbObjeto.SelectedIndexChanged += new System.EventHandler(this.cmbObjeto_SelectedIndexChanged);
            this.cmbObjeto.TextChanged += new System.EventHandler(this.cmbObjeto_TextChanged);
            this.cmbObjeto.Enter += new System.EventHandler(this.cmbObjeto_Enter);
            this.cmbObjeto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbObjeto_KeyDown);
            // 
            // cmbAplicacion
            // 
            this.cmbAplicacion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbAplicacion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbAplicacion.DropDownHeight = 200;
            this.cmbAplicacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAplicacion.DropDownWidth = 300;
            this.cmbAplicacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAplicacion.FormattingEnabled = true;
            this.cmbAplicacion.IntegralHeight = false;
            this.cmbAplicacion.Location = new System.Drawing.Point(1161, 215);
            this.cmbAplicacion.MaxDropDownItems = 20;
            this.cmbAplicacion.Name = "cmbAplicacion";
            this.cmbAplicacion.Size = new System.Drawing.Size(107, 21);
            this.cmbAplicacion.Sorted = true;
            this.cmbAplicacion.TabIndex = 8;
            this.cmbAplicacion.SelectedIndexChanged += new System.EventHandler(this.cmbAplicacion_SelectedIndexChanged);
            this.cmbAplicacion.Enter += new System.EventHandler(this.cmbAplicacion_Enter);
            this.cmbAplicacion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbAplicacion_KeyDown);
            // 
            // cmbFechaHasta
            // 
            this.cmbFechaHasta.AllowDrop = true;
            this.cmbFechaHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.cmbFechaHasta.Location = new System.Drawing.Point(1, 217);
            this.cmbFechaHasta.Name = "cmbFechaHasta";
            this.cmbFechaHasta.Size = new System.Drawing.Size(68, 20);
            this.cmbFechaHasta.TabIndex = 10;
            this.cmbFechaHasta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbFechaHasta_KeyDown);
            // 
            // cmbBloques
            // 
            this.cmbBloques.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbBloques.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbBloques.DropDownHeight = 150;
            this.cmbBloques.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBloques.DropDownWidth = 100;
            this.cmbBloques.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbBloques.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBloques.FormattingEnabled = true;
            this.cmbBloques.IntegralHeight = false;
            this.cmbBloques.Location = new System.Drawing.Point(12, 192);
            this.cmbBloques.Name = "cmbBloques";
            this.cmbBloques.Size = new System.Drawing.Size(127, 21);
            this.cmbBloques.TabIndex = 0;
            this.cmbBloques.Enter += new System.EventHandler(this.cmbBloques_Enter);
            this.cmbBloques.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbBloques_KeyDown);
            this.cmbBloques.MouseHover += new System.EventHandler(this.cmbBloques_MouseHover);
            // 
            // process1
            // 
            this.process1.StartInfo.Domain = "";
            this.process1.StartInfo.LoadUserProfile = false;
            this.process1.StartInfo.Password = null;
            this.process1.StartInfo.StandardErrorEncoding = null;
            this.process1.StartInfo.StandardOutputEncoding = null;
            this.process1.StartInfo.UserName = "";
            this.process1.SynchronizingObject = this;
            // 
            // txtTemas
            // 
            this.txtTemas.Location = new System.Drawing.Point(229, 193);
            this.txtTemas.Name = "txtTemas";
            this.txtTemas.Size = new System.Drawing.Size(231, 20);
            this.txtTemas.TabIndex = 17;
            this.txtTemas.Enter += new System.EventHandler(this.txtTemas_Enter);
            this.txtTemas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTemas_KeyDown);
            this.txtTemas.Leave += new System.EventHandler(this.txtTemas_Leave);
            // 
            // txtNombres
            // 
            this.txtNombres.Location = new System.Drawing.Point(463, 193);
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Size = new System.Drawing.Size(93, 20);
            this.txtNombres.TabIndex = 18;
            this.txtNombres.TextChanged += new System.EventHandler(this.txtNombres_TextChanged);
            this.txtNombres.Enter += new System.EventHandler(this.txtNombres_Enter);
            this.txtNombres.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNombres_KeyDown);
            this.txtNombres.Leave += new System.EventHandler(this.txtNombres_Leave);
            // 
            // txtVerbos
            // 
            this.txtVerbos.Location = new System.Drawing.Point(560, 193);
            this.txtVerbos.Name = "txtVerbos";
            this.txtVerbos.Size = new System.Drawing.Size(86, 20);
            this.txtVerbos.TabIndex = 19;
            this.txtVerbos.TextChanged += new System.EventHandler(this.txtVerbos_TextChanged);
            this.txtVerbos.Enter += new System.EventHandler(this.txtVerbos_Enter);
            this.txtVerbos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVerbos_KeyDown);
            this.txtVerbos.Leave += new System.EventHandler(this.txtVerbos_Leave);
            // 
            // txtNexos
            // 
            this.txtNexos.Location = new System.Drawing.Point(650, 193);
            this.txtNexos.Name = "txtNexos";
            this.txtNexos.Size = new System.Drawing.Size(78, 20);
            this.txtNexos.TabIndex = 20;
            this.txtNexos.TextChanged += new System.EventHandler(this.txtNexos_TextChanged);
            this.txtNexos.Enter += new System.EventHandler(this.txtNexos_Enter);
            this.txtNexos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNexos_KeyDown);
            this.txtNexos.Leave += new System.EventHandler(this.txtNexos_Leave);
            // 
            // txtModos
            // 
            this.txtModos.Location = new System.Drawing.Point(733, 192);
            this.txtModos.Name = "txtModos";
            this.txtModos.Size = new System.Drawing.Size(101, 20);
            this.txtModos.TabIndex = 21;
            this.txtModos.TextChanged += new System.EventHandler(this.txtModos_TextChanged);
            this.txtModos.Enter += new System.EventHandler(this.txtModos_Enter);
            this.txtModos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtModos_KeyDown);
            this.txtModos.Leave += new System.EventHandler(this.txtModos_Leave);
            // 
            // txtObjetos
            // 
            this.txtObjetos.Location = new System.Drawing.Point(839, 192);
            this.txtObjetos.Name = "txtObjetos";
            this.txtObjetos.Size = new System.Drawing.Size(103, 20);
            this.txtObjetos.TabIndex = 22;
            this.txtObjetos.TextChanged += new System.EventHandler(this.txtObjetos_TextChanged);
            this.txtObjetos.Enter += new System.EventHandler(this.txtObjetos_Enter);
            this.txtObjetos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtObjetos_KeyDown);
            this.txtObjetos.Leave += new System.EventHandler(this.txtObjetos_Leave);
            // 
            // txtArchivos
            // 
            this.txtArchivos.Location = new System.Drawing.Point(946, 192);
            this.txtArchivos.Name = "txtArchivos";
            this.txtArchivos.Size = new System.Drawing.Size(209, 20);
            this.txtArchivos.TabIndex = 23;
            this.txtArchivos.TextChanged += new System.EventHandler(this.txtArchivos_TextChanged);
            this.txtArchivos.Enter += new System.EventHandler(this.txtArchivos_Enter);
            this.txtArchivos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtArchivos_KeyDown);
            this.txtArchivos.Leave += new System.EventHandler(this.txtArchivos_Leave);
            // 
            // txtAplicaciones
            // 
            this.txtAplicaciones.Location = new System.Drawing.Point(1161, 193);
            this.txtAplicaciones.Name = "txtAplicaciones";
            this.txtAplicaciones.Size = new System.Drawing.Size(107, 20);
            this.txtAplicaciones.TabIndex = 24;
            this.txtAplicaciones.TextChanged += new System.EventHandler(this.txtAplicaciones_TextChanged);
            this.txtAplicaciones.Enter += new System.EventHandler(this.txtAplicaciones_Enter);
            this.txtAplicaciones.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAplicaciones_KeyDown);
            this.txtAplicaciones.Leave += new System.EventHandler(this.txtAplicaciones_Leave);
            this.txtAplicaciones.MouseHover += new System.EventHandler(this.txtAplicaciones_MouseHover);
            // 
            // cmbArchivo
            // 
            this.cmbArchivo.Location = new System.Drawing.Point(946, 216);
            this.cmbArchivo.Name = "cmbArchivo";
            this.cmbArchivo.Size = new System.Drawing.Size(209, 20);
            this.cmbArchivo.TabIndex = 7;
            this.cmbArchivo.TextChanged += new System.EventHandler(this.cmbArchivo_TextChanged);
            this.cmbArchivo.Enter += new System.EventHandler(this.cmbArchivo_Enter);
            this.cmbArchivo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbArchivo_KeyDown);
            // 
            // btnBackup
            // 
            this.btnBackup.Location = new System.Drawing.Point(0, 194);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(10, 17);
            this.btnBackup.TabIndex = 26;
            this.btnBackup.Text = "button1";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // cmbFrase
            // 
            this.cmbFrase.FormattingEnabled = true;
            this.cmbFrase.Location = new System.Drawing.Point(1273, 216);
            this.cmbFrase.Name = "cmbFrase";
            this.cmbFrase.Size = new System.Drawing.Size(36, 21);
            this.cmbFrase.TabIndex = 9;
            this.cmbFrase.Enter += new System.EventHandler(this.cmbFrase_Enter);
            this.cmbFrase.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbFrase_KeyDown);
            // 
            // cmbFraseConsulta
            // 
            this.cmbFraseConsulta.FormattingEnabled = true;
            this.cmbFraseConsulta.Location = new System.Drawing.Point(1273, 193);
            this.cmbFraseConsulta.Name = "cmbFraseConsulta";
            this.cmbFraseConsulta.Size = new System.Drawing.Size(36, 21);
            this.cmbFraseConsulta.TabIndex = 25;
            this.cmbFraseConsulta.Enter += new System.EventHandler(this.cmbFraseConsulta_Enter);
            this.cmbFraseConsulta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbFraseConsulta_KeyDown);
            this.cmbFraseConsulta.Leave += new System.EventHandler(this.cmbFraseConsulta_Leave);
            // 
            // lblclip
            // 
            this.lblclip.AutoSize = true;
            this.lblclip.Location = new System.Drawing.Point(12, 470);
            this.lblclip.Name = "lblclip";
            this.lblclip.Size = new System.Drawing.Size(0, 13);
            this.lblclip.TabIndex = 28;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(149, 194);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(73, 20);
            this.dtpFecha.TabIndex = 16;
            this.dtpFecha.Visible = false;
            this.dtpFecha.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpFecha_KeyDown);
            // 
            // txtFecha
            // 
            this.txtFecha.Location = new System.Drawing.Point(144, 192);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(80, 20);
            this.txtFecha.TabIndex = 15;
            this.txtFecha.Enter += new System.EventHandler(this.txtFecha_Enter);
            this.txtFecha.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFecha_KeyDown);
            this.txtFecha.Leave += new System.EventHandler(this.txtFecha_Leave);
            // 
            // txtPendiente
            // 
            this.txtPendiente.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPendiente.Location = new System.Drawing.Point(0, 4);
            this.txtPendiente.Name = "txtPendiente";
            this.txtPendiente.Size = new System.Drawing.Size(1307, 181);
            this.txtPendiente.TabIndex = 29;
            this.txtPendiente.Text = "";
            this.txtPendiente.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.txtPendiente_LinkClicked);
            this.txtPendiente.TextChanged += new System.EventHandler(this.txtPendiente_TextChanged_1);
            this.txtPendiente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPendiente_KeyDown);
            // 
            // lblNotasDeArchivo
            // 
            this.lblNotasDeArchivo.AutoSize = true;
            this.lblNotasDeArchivo.Location = new System.Drawing.Point(12, 489);
            this.lblNotasDeArchivo.Name = "lblNotasDeArchivo";
            this.lblNotasDeArchivo.Size = new System.Drawing.Size(0, 13);
            this.lblNotasDeArchivo.TabIndex = 30;
            // 
            // frmRegistros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1304, 511);
            this.Controls.Add(this.lblNotasDeArchivo);
            this.Controls.Add(this.txtPendiente);
            this.Controls.Add(this.txtFecha);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.lblclip);
            this.Controls.Add(this.cmbFraseConsulta);
            this.Controls.Add(this.cmbFrase);
            this.Controls.Add(this.btnBackup);
            this.Controls.Add(this.cmbArchivo);
            this.Controls.Add(this.txtAplicaciones);
            this.Controls.Add(this.txtArchivos);
            this.Controls.Add(this.txtObjetos);
            this.Controls.Add(this.txtModos);
            this.Controls.Add(this.txtNexos);
            this.Controls.Add(this.txtVerbos);
            this.Controls.Add(this.txtNombres);
            this.Controls.Add(this.txtTemas);
            this.Controls.Add(this.cmbBloques);
            this.Controls.Add(this.cmbFechaHasta);
            this.Controls.Add(this.cmbAplicacion);
            this.Controls.Add(this.cmbObjeto);
            this.Controls.Add(this.cmbVerbo);
            this.Controls.Add(this.cmbNexo);
            this.Controls.Add(this.cmbModo);
            this.Controls.Add(this.cmbPersona);
            this.Controls.Add(this.cmbTema);
            this.Controls.Add(this.cmbSegundo);
            this.Controls.Add(this.cmbMinuto);
            this.Controls.Add(this.cmbHora);
            this.Controls.Add(this.cmbDia);
            this.Controls.Add(this.dgRegs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1320, 540);
            this.MinimumSize = new System.Drawing.Size(1278, 540);
            this.Name = "frmRegistros";
            this.Text = "REGISTRO DE EVENTOS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRegistros_FormClosing);
            this.Load += new System.EventHandler(this.frmRegistros_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgRegs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgRegs;
        private System.Windows.Forms.ComboBox cmbDia;
        private System.Windows.Forms.ComboBox cmbHora;
        private System.Windows.Forms.ComboBox cmbMinuto;
        private System.Windows.Forms.ComboBox cmbSegundo;
        private System.Windows.Forms.ComboBox cmbTema;
        private System.Windows.Forms.ComboBox cmbPersona;
        private System.Windows.Forms.ComboBox cmbModo;
        private System.Windows.Forms.ComboBox cmbNexo;
        private System.Windows.Forms.ComboBox cmbVerbo;
        private System.Windows.Forms.ComboBox cmbObjeto;
        private System.Windows.Forms.ComboBox cmbAplicacion;
        private System.Windows.Forms.DateTimePicker cmbFechaHasta;
        private System.Windows.Forms.ComboBox cmbBloques;
        private System.Windows.Forms.ToolTip ttCarteles;
        private System.Diagnostics.Process process1;
        private System.Windows.Forms.TextBox txtAplicaciones;
        private System.Windows.Forms.TextBox txtArchivos;
        private System.Windows.Forms.TextBox txtObjetos;
        private System.Windows.Forms.TextBox txtModos;
        private System.Windows.Forms.TextBox txtNexos;
        private System.Windows.Forms.TextBox txtVerbos;
        private System.Windows.Forms.TextBox txtNombres;
        private System.Windows.Forms.TextBox txtTemas;
        private System.Windows.Forms.TextBox cmbArchivo;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.ComboBox cmbFraseConsulta;
        private System.Windows.Forms.ComboBox cmbFrase;
        private System.Windows.Forms.Label lblclip;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.RichTextBox txtPendiente;
        private System.Windows.Forms.Label lblNotasDeArchivo;

    }
}