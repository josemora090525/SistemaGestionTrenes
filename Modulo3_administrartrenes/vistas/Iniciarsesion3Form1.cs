using ProyectoEstructuras.Códigos.Actores;
using ProyectoEstructuras.Códigos.TareasAdministrador;
using ProyectoEstructuras.Modulo4_administrarrutas.vistas;
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
    public partial class Iniciarsesion3Form1 : Form
    {
        public Iniciarsesion3Form1()
        {
            InitializeComponent();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_Click(object sender, EventArgs e)
        {
            string correo = textBox1.Text;
            string password = textBox2.Text;

            // Creamos una tabla hash para empleados con un tamaño predefinido.
            TablaHash<string, Empleado> tablaEmpleados = new TablaHash<string, Empleado>(10);

            // Pre-cargamos la tabla con un empleado de ejemplo.
            // El constructor de Empleado recibe: nombre, apellidos, teléfono, identificación, correo, contraseña y rol.
            Empleado empleadoEjemplo = new Empleado("Juan", "Pérez", "3001234567", "cedula ciudadania", "102393", "empleado@example.com", "pass123", "Empleado");
            // Insertamos el empleado usando el correo como clave, ya que de ahí se realizará la búsqueda.
            tablaEmpleados.InsertarValores(empleadoEjemplo.Correo, empleadoEjemplo);

            // Creamos una instancia del sistema de autenticación genérico para empleados.
            SistemaAutenticacion<string, Empleado> sistema = new SistemaAutenticacion<string, Empleado>(tablaEmpleados);

            // Se intenta iniciar sesión validando que tanto el correo como la contraseña coincidan.
            Empleado empleadoLogueado = sistema.IniciarSesion(correo, emp => emp.Correo.Equals(correo) && emp.Contrasenia.Equals(password));

            if (empleadoLogueado != null)
            {
                MessageBox.Show("Inicio de sesión exitoso. Bienvenido, " + empleadoLogueado.Correo);
                // Abrimos el formulario MenuForm2 y ocultamos el formulario de inicio de sesión.
                menuForm2 menuForm = new menuForm2();
                menuForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Error en el inicio de sesión. Verifica tus credenciales.");
            }

        }

        private void Iniciarsesion3Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            iniciarSesion4Form1 iniciarSesion = new iniciarSesion4Form1();
            iniciarSesion.Show();
            this.Hide();
        }
    }
}
