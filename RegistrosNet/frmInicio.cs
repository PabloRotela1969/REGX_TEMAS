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
    public partial class frmInicio : Form
    {
        public frmInicio()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            (new frmAplicaciones()).Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            (new frmArchivos()).Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            (new frmTipos()).Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            (new frmPersona()).Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            (new frmMails()).Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            (new frmModos()).Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            (new frmNexos()).Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            (new frmObjetos()).Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            (new frmVerbos()).Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            (new frmTemas()).Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            (new frmTelefonos()).Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //(new frmRegistros()).Show();

        }
    }
}
