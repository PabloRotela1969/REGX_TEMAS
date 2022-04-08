using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RegistrosNet
{
    public partial class frmErroresBackup : Form
    {
        public frmErroresBackup()
        {
            InitializeComponent();
        }


        private void frmErroresBackup_Load(object sender, EventArgs e)
        {
            this.txtErrores.Text = this.Tag.ToString();
            string [] separadores = { "\r\n"};
            string[] listado = this.Tag.ToString().Split(separadores, StringSplitOptions.None);

            this.lstErrores.DataSource = listado;
        }
    }
}
