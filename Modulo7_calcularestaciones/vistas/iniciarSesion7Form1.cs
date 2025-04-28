using ProyectoEstructuras.Códigos.Actores;
using ProyectoEstructuras.Códigos.TareasAdministrador;
using ProyectoEstructuras.Modulo1_CompraBoleto.Vistas;
using ProyectoEstructuras.Modulo10_calculoestaciones.vistas;
using ProyectoEstructuras.Modulo7_calcularestaciones.vistas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoEstructuras.Modulo7_calculoestaciones.vistas
{
    public partial class iniciarSesion7Form1 : Form
    {
        public iniciarSesion7Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IniciarsesionForm1 iniciarsesionForm1 = new IniciarsesionForm1();
            iniciarsesionForm1.Show();
            this.Hide();
        }

        private void button_Click(object sender, EventArgs e)
        {
            string correo = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            // Creamos una tabla hash para administradores, con un tamaño predefinido.
            TablaHash<string, Administrador> tablaAdministradores = new TablaHash<string, Administrador>(10);

            // Pre-cargamos la tabla con un administrador de ejemplo.
            // Se asume que el constructor de la clase Administrador es:
            // public Administrador(string nombre, string apellidos, string telefono, string identificacion, string correo, string contrasenia)
            Administrador adminEjemplo = new Administrador("Diego", "Ramirez", "3005554444", "cedula ciudadania", "12345", "admin@empresa.com", "adminpass123");
            // Insertamos el administrador usando su correo como clave (el que se usará para la búsqueda).
            tablaAdministradores.InsertarValores(adminEjemplo.Correo, adminEjemplo);

            // Creamos una instancia del sistema de autenticación para administradores.
            SistemaAutenticacion<string, Administrador> sistema =
                new SistemaAutenticacion<string, Administrador>(tablaAdministradores);

            // Intentamos iniciar sesión validando que el correo y la contraseña ingresados coincidan.
            Administrador adminLogueado = sistema.IniciarSesion(
                correo,
                adm => adm.Correo.Equals(correo) && adm.Contrasenia.Equals(password)
            );

            if (adminLogueado != null)
            {
                MessageBox.Show("Inicio de sesión exitoso. Bienvenido, " + adminLogueado.Correo);
                // Abrir el formulario principal (por ejemplo, MenuForm2) y ocultar el formulario actual.
                menuEstacionesForm2 menuForm = new menuEstacionesForm2();
                menuForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Error en el inicio de sesión. Verifica tus credenciales.");
            }
        }
    }
}
