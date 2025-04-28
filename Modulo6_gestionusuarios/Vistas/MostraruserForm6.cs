using ProyectoEstructuras.Códigos.Actores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoEstructuras.Modulo6_gestionusuarios.Vistas
{
    public partial class MostraruserForm6 : Form
    {
        public MostraruserForm6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            menuForm2 menuForm2 = new menuForm2();
            menuForm2.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Limpiar el área de visualización en richTextBox1
                richTextBox1.Clear();

                Console.WriteLine("\n--- Mostrando todos los usuarios en el sistema ---"); // Depuración

                // --- 1. Verificar si la tabla hash de usuarios está inicializada ---
                // Asegúrate de que 'Datos.tablaUsuarios' sea tu instancia estática de TablaHash<string, Usuario>
                // y que esté inicializada en otro lugar de tu aplicación.
                if (Datos.tablaUsuarios == null)
                {
                    richTextBox1.Text = "Error: La tabla hash de usuarios no está inicializada.";
                    Console.WriteLine("Error: Datos.tablaUsuarios es null."); // Depuración
                    return;
                }

                // --- 2. Obtener todos los usuarios de la tabla hash ---
                // ESTA LÍNEA REQUIERE QUE HAYAS AÑADIDO EL MÉTODO PUBLIC List<V> GetAllValues() A TU CLASE TablaHash<K, V>
                List<Usuario> listaUsuarios = Datos.tablaUsuarios.GetAllValues();


                // --- 3. Verificar si se encontraron usuarios y mostrarlos ---
                if (listaUsuarios == null || listaUsuarios.Count == 0)
                {
                    richTextBox1.Text = "No hay usuarios agregados en el sistema.";
                    Console.WriteLine("La tabla hash no contiene usuarios."); // Depuración
                    return;
                }

                // Si se encontraron usuarios, construir el texto para mostrar
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("--- LISTADO DE USUARIOS EN EL SISTEMA ---");
                sb.AppendLine();

                int userCount = 0; // Contador para el número de usuarios mostrados

                // Iterar sobre la lista de usuarios obtenida de la tabla hash
                foreach (Usuario usuario in listaUsuarios)
                {
                    // GetAllValues() debería devolver solo los elementos válidos, pero verificamos por seguridad
                    if (usuario != null)
                    {
                        userCount++;
                        sb.AppendLine($"Usuario #{userCount}:");

                        // Mostrar información común de la clase base Usuario
                        // **¡¡¡ASEGÚRATE DE QUE ESTAS PROPIEDADES EXISTEN Y SON PÚBLICAS EN TU CLASE Usuario O SUS HEREDERAS!!!**
                        // Ajusta los nombres de las propiedades (.Nombre, .Apellido, etc.) si son diferentes en tus clases.
                        sb.AppendLine($"  Nombre: {usuario.Nombre}");
                        sb.AppendLine($"  Apellido: {usuario.Apellidos}"); // O usuario.Apellidos? Verifica tu clase.
                        sb.AppendLine($"  Correo: {usuario.Correo}");
                        sb.AppendLine($"  Teléfono: {usuario.Telefono}");
                        sb.AppendLine($"  Tipo Identificación: {usuario.Identificacion}"); // O usuario.Identificacion? Verifica tu clase.
                        sb.AppendLine($"  Número Identificación: {usuario.NumeroIdentificacion}");

                        // Determinar y mostrar el tipo específico de usuario (Pasajero o Empleado)
                        string tipoUsuario = "Usuario Genérico";
                        if (usuario is Pasajero) tipoUsuario = "Pasajero";
                        else if (usuario is Empleado) tipoUsuario = "Empleado";
                        sb.AppendLine($"  Rol: {tipoUsuario}");


                        // Opcional: Mostrar información específica si es Pasajero o Empleado
                        // **¡¡¡ASEGÚRATE DE QUE ESTAS PROPIEDADES ESPECÍFICAS EXISTEN EN LAS CLASES HIJAS Y SON PÚBLICAS!!!**
                        if (usuario is Pasajero pasajero)
                        {
                            sb.AppendLine("    --- Detalles Específicos de Pasajero ---");
                            // sb.AppendLine($"    Alguna propiedad específica: {pasajero.AlgunaPropiedadPasajero}"); // Ejemplo
                        }

                        sb.AppendLine("  --------------------"); // Separador entre usuarios
                        Console.WriteLine($"  - Añadido usuario '{usuario.Correo}' a la salida."); // Depuración
                    }
                }

                // Si la lista estaba vacía o no se encontraron usuarios no nulos después de la iteración
                if (userCount == 0)
                {
                    // Esto podría pasar si GetAllValues devuelve una lista vacía o llena de nulos inesperadamente
                    richTextBox1.Text = "No se encontraron usuarios válidos en la tabla hash para mostrar.";
                    Console.WriteLine("No se encontraron usuarios válidos para mostrar."); // Depuración
                }
                else
                {
                    // Establecer el texto final en el richTextBox1
                    richTextBox1.Text = sb.ToString();
                    Console.WriteLine($"Listado de {userCount} usuarios mostrado en richTextBox1."); // Depuración
                }

                Console.WriteLine("--- Fin de la muestra de usuarios ---"); // Depuración

            }
            catch (Exception ex)
            {
                // Capturar cualquier otro error inesperado (ej: Datos.tablaUsuarios es null antes de la verificación, error en GetAllValues, etc.)
                MessageBox.Show("Ocurrió un error al mostrar los usuarios: " + ex.Message + "\nDetalles en Consola.");
                Console.WriteLine("ERROR general en MostraruserForm6.button3_Click: " + ex.ToString()); // Imprimir detalles del error
            }
        }
    }
}
