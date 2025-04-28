using ProyectoEstructuras.Códigos.Actores;
using ProyectoEstructuras.Códigos.TareasAdministrador;
using ProyectoEstructuras.Modulo3_administrartrenes.vistas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoEstructuras.Modulo4_administrarrutas.vistas
{
    public partial class MenuForm2 : Form
    {
        public MenuForm2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Crea una instancia del sistema de autenticación.
            // Aquí puedes usar la misma instancia que manejaste para iniciar sesión.
            SistemaAutenticacion<string, Empleado> sistema = new SistemaAutenticacion<string, Empleado>(
                new TablaHash<string, Empleado>(10) // Tabla hash temporal (ajusta según implementación)
            );

            // Llama al método CerrarSesion.
            sistema.CerrarSesion();

            // Muestra el formulario anterior (Iniciarsesion3Form1).
            Iniciarsesion3Form1 formInicioSesion = new Iniciarsesion3Form1();
            formInicioSesion.Show();

            // Oculta el formulario actual (menuForm2).
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AgregarForm3 agregarForm3 = new AgregarForm3();
            agregarForm3.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            busquedaForm4 formBuscar = new busquedaForm4();
            formBuscar.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EliminacionForm5 formEliminar = new EliminacionForm5();
            formEliminar.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ModificarForm1 formModificar = new ModificarForm1();
            formModificar.Show();
            this.Hide();
        }
    }
}
