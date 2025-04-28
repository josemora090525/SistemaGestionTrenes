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
    public partial class buscarusersForm4 : Form
    {
        public buscarusersForm4()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            menuForm2 form = new menuForm2();
            form.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Limpiar el área de resultados anterior en richTextBox1
                richTextBox1.Clear();

                Console.WriteLine("\n--- Intentando buscar usuario ---"); // Depuración

                // --- 1. Capturar datos desde los controles ---
                // **¡¡¡VERIFICA ESTOS NOMBRES CON TU DISEÑO REAL DEL FORMULARIO!!!**
                // Asumo que tienes textboxes para estos campos. Ajusta 'txtCorreoBusqueda' al nombre correcto del TextBox del correo.
                // string tipoIdentificacionBusqueda = txtTipoIdentificacion.Text.Trim(); // Si quieres capturarlos, ajusta el nombre del textbox
                // string numeroIdentificacionBusqueda = txtNumeroIdentificacion.Text.Trim(); // Si quieres capturarlos, ajusta el nombre del textbox
                string correoBusqueda = textBox1.Text.Trim(); // <--- Nombre del textbox para el CORREO a buscar. ¡AJUSTA ESTE NOMBRE!


                Console.WriteLine($"Intentando buscar usuario con correo: '{correoBusqueda}'"); // Depuración


                // --- 2. Validar datos ---
                // Requerimos el correo para hacer la búsqueda eficiente en la Tabla Hash.
                if (string.IsNullOrEmpty(correoBusqueda))
                {
                    MessageBox.Show("Por favor, ingrese el correo electrónico del usuario a buscar.");
                    Console.WriteLine("Validación fallida: Campo de correo vacío."); // Depuración
                    return;
                }

                // Opcional: Validar formato básico de correo si lo deseas aquí
                // if (!correoBusqueda.Contains("@") || !correoBusqueda.Contains(".")) { ... }


                // --- 3. Buscar el usuario en la Tabla Hash (usando el correo como clave) ---
                // Asegúrate de que 'Datos.tablaUsuarios' sea tu instancia estática de TablaHash<string, Usuario>
                // y que esté inicializada en otro lugar de tu aplicación.
                Usuario usuarioEncontrado = Datos.tablaUsuarios.BuscarValores(correoBusqueda);


                // --- 4. Mostrar resultados o indicar que no se encontró ---
                if (usuarioEncontrado == null)
                {
                    // Si BuscarValores devuelve null, el usuario no fue encontrado con esa clave (correo)
                    richTextBox1.Text = $"No se encontró ningún usuario con el correo electrónico '{correoBusqueda}'.";
                    Console.WriteLine($"Usuario con correo '{correoBusqueda}' no encontrado en la tabla hash."); // Depuración

                    // Opcional: Aquí podrías añadir lógica para buscar por identificación si el correo falló,
                    // pero recuerda que sería iterando toda la tabla hash y no usando su eficiencia directa.
                    /*
                    if (!string.IsNullOrEmpty(numeroIdentificacionBusqueda) && !string.IsNullOrEmpty(tipoIdentificacionBusqueda))
                    {
                         // Lógica para buscar iterando todos los usuarios si el correo no funcionó
                         // Esto requiere una forma de obtener todos los valores de la TablaHash (ej: un método GetAllValues() o iterarla)
                         // Y verificar el tipo y número de identificación en cada Usuario.
                         // Si lo encuentras, actualiza richTextBox1.Text y vagonEncontrado = user;
                    }
                    */
                }
                else
                {
                    // ¡Usuario encontrado! Ahora preparamos la información para mostrar
                    Console.WriteLine($"Usuario con correo '{correoBusqueda}' encontrado."); // Depuración

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("--- Información del Usuario Encontrado ---");
                    sb.AppendLine();

                    // Mostrar información común de la clase base Usuario
                    // **¡¡¡ASEGÚRATE DE QUE ESTAS PROPIEDADES EXISTEN EN TU CLASE Usuario (O BASE)!!!**
                    // Ajusta los nombres de las propiedades (.Nombre, .Apellido, etc.) si son diferentes en tus clases.
                    sb.AppendLine($"Nombre: {usuarioEncontrado.Nombre}");
                    sb.AppendLine($"Apellido: {usuarioEncontrado.Apellidos}");
                    sb.AppendLine($"Correo: {usuarioEncontrado.Correo}");
                    sb.AppendLine($"Teléfono: {usuarioEncontrado.Telefono}");
                    sb.AppendLine($"Tipo Identificación: {usuarioEncontrado.Identificacion}");
                    sb.AppendLine($"Número Identificación: {usuarioEncontrado.NumeroIdentificacion}");

                    // Determinar y mostrar el tipo específico de usuario (Pasajero o Empleado)
                    string tipoUsuario = "Usuario Genérico (clase base)";
                    if (usuarioEncontrado is Pasajero) tipoUsuario = "Pasajero";
                    else if (usuarioEncontrado is Empleado) tipoUsuario = "Empleado";
                    sb.AppendLine($"Rol: {tipoUsuario}");


                    // Opcional: Mostrar información específica si es Pasajero o Empleado
                    // **¡¡¡ASEGÚRATE DE QUE ESTAS PROPIEDADES ESPECÍFICAS EXISTEN EN LAS CLASES HIJAS!!!**
                    if (usuarioEncontrado is Pasajero pasajero)
                    {
                        sb.AppendLine("  --- Detalles Específicos de Pasajero ---");
                        // sb.AppendLine($"  Alguna propiedad específica de Pasajero: {pasajero.AlgunaPropiedadPasajero}"); // Ejemplo: Número de Viajes, etc.
                    }

                    // Establecer el texto final en el richTextBox1
                    richTextBox1.Text = sb.ToString();
                    Console.WriteLine($"Información completa del usuario '{correoBusqueda}' mostrada en richTextBox1."); // Depuración
                }

                Console.WriteLine("--- Fin de la búsqueda de usuario ---"); // Depuración

                // Opcional: Limpiar el campo de correo después de buscar (siempre o solo si se encontró)
                // txtCorreoBusqueda.Clear();

            }
            catch (Exception ex)
            {
                // Capturar cualquier otro error inesperado durante la búsqueda
                MessageBox.Show("Ocurrió un error al buscar el usuario: " + ex.Message + "\nDetalles en Consola.");
                Console.WriteLine("ERROR general en buscarusersForm4.button2_Click: " + ex.ToString()); // Imprimir detalles del error
            }
        }
    }
}
