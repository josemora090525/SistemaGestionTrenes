using ProyectoEstructuras.Modulo1_CompraBoleto.Vistas;
using ProyectoEstructuras.Modulo2_validar.vistas;
using ProyectoEstructuras.Modulo3_administrartrenes.vistas;
using ProyectoEstructuras.Modulo4_administrarrutas.vistas;
using ProyectoEstructuras.Modulo5_vagones.Vistas;
using ProyectoEstructuras.Modulo6_gestionusuarios.Vistas;
using ProyectoEstructuras.Modulo7_calculoestaciones.vistas;
using ProyectoEstructuras.Modulo8_vagonpasajerosyabordaje.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoEstructuras
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            Application.Run(new Iniciarsesion3Form1());
        }
    }
}
