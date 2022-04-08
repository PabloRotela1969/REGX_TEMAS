using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clases;

namespace RegistrosNet
{
    public partial class Acciones : Form
    {

        public Acciones()
        {
            InitializeComponent();
        }
        Clases.Acciones acc = new Clases.Acciones();
        private void Acciones_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            acc.Nombre = this.txtNombreAccion.Text;
            this.dgResultado.DataSource = acc.TraerRegistros();
            
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            acc.Nombre = txtNombreAccion.Text;
            acc.GuardarAccion();
            CargarGrilla();
        }

        private void btnModifica_Click(object sender, EventArgs e)
        {
            acc.Nombre = txtNombreAccion.Text;
            acc.ModificarAccion();
            CargarGrilla();
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            acc.BorrarAccion();
            acc.idAcc = 0;
            acc.Nombre = "";
            this.txtNombreAccion.Text = "";
            CargarGrilla();

        }

        private void dgResultado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                acc.idAcc = Convert.ToInt32(dgResultado.Rows[e.RowIndex].Cells[0].Value);
                DataTable tabla = acc.TraerRegistros();
                this.txtNombreAccion.Text = tabla.Rows[0]["nombre"].ToString();
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            this.txtNombreAccion.Text = "";
            acc.idAcc = 0;
            CargarGrilla();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            acc.idAcc = 0;
            CargarGrilla();
        }
    }
}
