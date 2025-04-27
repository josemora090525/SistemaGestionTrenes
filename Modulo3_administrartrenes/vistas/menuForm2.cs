using ProyectoEstructuras.Códigos.Actores;
using ProyectoEstructuras.Códigos.TareasAdministrador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoEstructuras.Modulo3_administrartrenes.vistas
{
    public partial class menuForm2 : Form
    {
        public menuForm2()
        {
            InitializeComponent();
        }

        private void menuForm2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Crea una nueva instancia del formulario agregarForm3
            agregarForm3 formAgregar = new agregarForm3();

            // Muestra el formulario para agregar tren
            formAgregar.Show();

            // Opcional: oculta el formulario actual (menuForm2)
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            buscarForm4 formBuscar = new buscarForm4();
            formBuscar.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            eliminarForm5 formEliminar = new eliminarForm5();
            formEliminar.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            modificartrenForm1 formModificar = new modificartrenForm1();
            formModificar.Show();
            this.Hide();
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
    }
}
