using ProyectoEstructuras.Códigos.Actores;
using ProyectoEstructuras.Modulo1_CompraBoleto.ClasesControladoras;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Usuario = ProyectoEstructuras.Códigos.Actores.Usuario;

namespace ProyectoEstructuras.Modulo1_CompraBoleto.Vistas
{
    public partial class IniciarsesionForm1 : Form
    {
        public IniciarsesionForm1()
        {
            InitializeComponent();
        }

        private void IniciarsesionForm1_Load(object sender, EventArgs e)
        {

        }

        private void button_Click(object sender, EventArgs e)
        {
            try
            {
                string correoIngresado = textBox1.Text.Trim(); 
                string contraseniaIngresada = textBox2.Text.Trim(); 

                Console.WriteLine($"\n--- Intentando iniciar sesión con correo: '{correoIngresado}' ---"); 

                // --- 2. Validar datos ingresados ---
                if (string.IsNullOrEmpty(correoIngresado) || string.IsNullOrEmpty(contraseniaIngresada))
                {
                    MessageBox.Show("Por favor, ingrese su correo electrónico y contraseña.");
                    Console.WriteLine("Validación fallida: Campos de correo o contraseña vacíos."); 
                    return; // Salir del método si la validación falla
                }

                Console.WriteLine($"DEBUG Login: Tamaño actual de la tabla hash: {Datos.tablaUsuarios.Tamanio}"); // Asegúrate de que Tamanio es público en TablaHash
                Console.WriteLine($"DEBUG Login: ¿Contiene la clave '{correoIngresado}' antes de buscar? {Datos.tablaUsuarios.ContieneClave(correoIngresado)}");

                // Opcional: Muestra todas las claves para ver qué hay realmente en la tabla antes de buscar
                Console.WriteLine("DEBUG Login: Claves actuales en la tabla hash ANTES de buscar:");
                List<string> clavesLogin = Datos.tablaUsuarios.ObtenerClaves(); // Requiere ObtenerClaves() público
                foreach (string clave in clavesLogin)
                {
                    Console.WriteLine($" - {clave}");
                }

                // --- 3. Buscar el usuario en la Tabla Hash usando el correo como clave ---
                Usuario usuarioEncontrado = Datos.tablaUsuarios.BuscarValores(correoIngresado);

                // --- 4. Verificar si el usuario fue encontrado y si la contraseña coincide ---
                if (usuarioEncontrado == null)
                {
                    // Si BuscarValores devuelve null, no se encontró ningún usuario con ese correo en la tabla hash.
                    MessageBox.Show("Usuario no encontrado. Verifique su correo electrónico.");
                    Console.WriteLine($"Intento de inicio de sesión fallido: Usuario con correo '{correoIngresado}' no encontrado en la tabla hash."); 
                }
                else
                {
                    // Usuario encontrado en la tabla hash. Ahora verificar la contraseña.
                    Console.WriteLine($"Usuario con correo '{correoIngresado}' encontrado. Verificando contraseña.");

                   
                    if (usuarioEncontrado.Contrasenia == contraseniaIngresada) // Comparar contraseñas 
                    {
                        // *** Inicio de sesión exitoso ***
                        Console.WriteLine($"Inicio de sesión exitoso para usuario '{correoIngresado}'."); 

                        // --- 5. Determinar el Rol del usuario logueado ---
                        // Esto es útil para mostrar el menú correcto o habilitar/deshabilitar funcionalidades.
                        string rolUsuario = "Usuario Genérico"; // Valor por defecto si no es Pasajero ni Empleado
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
                        // --- 6. Navegar al menú principal o al formulario correspondiente ---
                        // si menuForm2 necesita saber quién inició sesión.
                        // Ejemplo pasando el usuario logueado al constructor de menuForm2:
                        // menuForm2 menuForm2 = new menuForm2(usuarioEncontrado); // Si menuForm2 tiene un constructor que acepta Usuario
                        // O simplemente si menuForm2 no necesita detalles del usuario logueado (menos común):

                        MessageBox.Show($"Bienvenido, {usuarioEncontrado.Nombre} ({rolUsuario}).");
                        MenúViajesForm2 menuForm2 = new MenúViajesForm2();

                        menuForm2.Show(); // Mostrar el formulario del menú
                        this.Hide(); // Oculta el formulario de login (para volver a él si el usuario cierra el meniu
                    }
                    else
                    {
                        // Contraseña ingresada es incorrecta para el usuario encontrado
                        MessageBox.Show("Contraseña incorrecta.");
                        Console.WriteLine($"Intento de inicio de sesión fallido: Contraseña incorrecta para usuario '{correoIngresado}'.");
                    }
                }

                Console.WriteLine("--- Fin intento de inicio de sesión ---"); 

            }
            catch (Exception ex)
            {
                // Capturar cualquier otro error inesperado durante el proceso de login
                // (ej: si Datos.tablaUsuarios no está inicializada, un error en BuscarValores, etc.)
                MessageBox.Show("Ocurrió un error al iniciar sesión: " + ex.Message + "\nDetalles en Consola.");
                Console.WriteLine("ERROR general en LoginForm.buttonIniciarSesion_Click: " + ex.ToString()); // Imprimir detalles completos del error
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
