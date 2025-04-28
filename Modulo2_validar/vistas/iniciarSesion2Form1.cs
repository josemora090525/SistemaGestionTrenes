using ProyectoEstructuras.Códigos.Actores;
using ProyectoEstructuras.Códigos.TareasAdministrador;
using ProyectoEstructuras.Modulo1_CompraBoleto.Vistas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoEstructuras.Modulo2_validar.vistas
{
    public partial class iniciarSesion2Form1 : Form
    {
        public iniciarSesion2Form1()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            try
            { 
                TablaHash<string, Usuario> tablaUsuariosLocal = new TablaHash<string, Usuario>(101); // Crea una instancia LOCAL aquí

                string correoPasajeroEj = "pasajero@example.com";
                Pasajero pasajeroInicial = new Pasajero("Viajero", "Frecuente", "12333", "DNI", "ID123456", correoPasajeroEj, "password123", "Pasajero");
                tablaUsuariosLocal.InsertarValores(correoPasajeroEj, pasajeroInicial); // Inserta en la tabla LOCAL

                string correoIngresado = textBox1.Text.Trim(); // Obtiene correo del TextBox
                string contraseniaIngresada = textBox2.Text.Trim(); // Obtiene contraseña del TextBox

                Console.WriteLine($"\n--- Intentando iniciar sesión con correo: '{correoIngresado}' ---");

                // --- 2. Validar datos ingresados ---
                if (string.IsNullOrEmpty(correoIngresado) || string.IsNullOrEmpty(contraseniaIngresada))
                {
                    MessageBox.Show("Por favor, ingrese su correo electrónico y contraseña.");
                    Console.WriteLine("Validación fallida: Campos de correo o contraseña vacíos.");
                    // textBox1.Focus(); // Opcional: poner foco en el primer campo vacío
                    return; // Salir si la validación falla
                }


                // --- 3. Buscar el usuario en la Tabla Hash LOCAL usando el correo como clave ---
                // *** Usa la instancia LOCAL que acabas de crear: tablaUsuariosLocal ***
                Usuario usuarioEncontrado = tablaUsuariosLocal.BuscarValores(correoIngresado);


                // --- 4. Verificar si el usuario fue encontrado y si la contraseña coincide ---
                if (usuarioEncontrado == null)
                {
                    // Usuario no encontrado en esta instancia LOCAL de la tabla hash.
                    MessageBox.Show("Usuario no encontrado. Verifique su correo electrónico.");
                    Console.WriteLine($"Intento de inicio de sesión fallido: Usuario con correo '{correoIngresado}' no encontrado en la tabla hash LOCAL.");
                    // textBox1.Clear(); // Opcional: Limpiar campos o poner foco
                    // textBox2.Clear();
                    // textBox1.Focus();
                }
                else
                {
                    // Usuario encontrado en la tabla hash LOCAL. Ahora verificar la contraseña.
                    Console.WriteLine($"Usuario con correo '{correoIngresado}' encontrado en la tabla LOCAL. Verificando contraseña.");

                    // **¡¡¡ASEGÚRATE DE QUE TU CLASE Usuario TIENE UNA PROPIEDAD PÚBLICA LLAMADA Contrasenia!!!**
                    if (usuarioEncontrado.Contrasenia == contraseniaIngresada) // Comparar contraseñas
                    {
                        // *** Inicio de sesión exitoso ***
                        Console.WriteLine($"Inicio de sesión exitoso para usuario '{correoIngresado}'.");

                        // --- 5. Determinar el Rol del usuario logueado ---
                        string rolUsuario = "Usuario Genérico";
                        if (usuarioEncontrado is Pasajero)
                        {
                            rolUsuario = "Pasajero";
                            Console.WriteLine($"Rol detectado: Pasajero.");
                        }
                        else if (usuarioEncontrado is Empleado)
                        {
                            rolUsuario = "Empleado";
                            Console.WriteLine($"Rol detectado: Empleado.");
                        }
                        // Si tienes otros tipos de usuarios, añade más 'else if'

                        // --- 6. Navegar al menú principal o al formulario correspondiente ---
                        // *** IMPORTANTE: Este nuevo formulario MenúViajesForm2 NO tendrá los usuarios que creaste en esta tablaUsuariosLocal. ***
                        MenúViajesForm2 menuForm2 = new MenúViajesForm2();

                        menuForm2.Show(); // Mostrar el formulario del menú
                        this.Hide(); // Oculta el formulario de login

                        MessageBox.Show($"Bienvenido, {usuarioEncontrado.Nombre} ({rolUsuario}).");

                        // Puedes pasar el usuario logueado al siguiente formulario si este lo necesita:
                        // MenúViajesForm2 menuForm2 = new MenúViajesForm2(usuarioEncontrado);
                        // (Requiere un constructor en MenúViajesForm2 que acepte un Usuario)

                    }
                    else
                    {
                        // Contraseña ingresada es incorrecta
                        MessageBox.Show("Contraseña incorrecta.");
                        Console.WriteLine($"Intento de inicio de sesión fallido: Contraseña incorrecta para usuario '{correoIngresado}'.");
                        textBox2.Clear(); // Limpiar solo el campo de contraseña
                        textBox2.Focus(); // Poner el foco en el campo de contraseña
                    }
                }

                Console.WriteLine("--- Fin intento de inicio de sesión ---");

            }
            catch (Exception ex)
            {
                // Capturar cualquier otro error inesperado
                MessageBox.Show("Ocurrió un error al iniciar sesión: " + ex.Message + "\nDetalles en Consola.");
                Console.WriteLine("ERROR general en LoginForm.button_Click: " + ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
