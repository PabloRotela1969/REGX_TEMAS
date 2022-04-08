using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RegistrosNet
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmAcceso());// esto servía cuando estaba residente en máquina física host, fuera de la virtual
            Application.Run(new frmRegistros());
            //Application.Run(frmRegistros.Instanciar());
  
        }
    }
}
