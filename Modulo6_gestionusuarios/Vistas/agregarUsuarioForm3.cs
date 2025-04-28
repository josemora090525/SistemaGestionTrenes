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
    public partial class agregarUsuarioForm3 : Form
    {
        public agregarUsuarioForm3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            menuForm2 menu = new menuForm2();
            menu.Show();
            this.Hide(); 
        }

        private void agregarUsuarioForm3_Load_1(object sender, EventArgs e)
        {
            comboBox1.Items.Clear(); // Limpiar por si acaso ya tiene ítems
            comboBox1.Items.Add("Empleado");
            comboBox1.Items.Add("Pasajero");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                // --- 1. Capturar datos desde los controles ---
                // ¡¡¡VERIFICA ESTOS NOMBRES CON TU DISEÑO REAL!!!
                string nombre = textBox1.Text.Trim(); // ¿Es textBox1 el nombre?
                string apellido = textBox2.Text.Trim(); // ¿Es textBox2 el apellido?
                string contrasenia = textBox3.Text.Trim(); // ¿Es textBox3 la contraseña?
                string telefono = textBox4.Text.Trim(); // ¿Es textBox4 el teléfono?
                string correo = textBox5.Text.Trim(); // ¿Es textBox5 el correo? (¡Esta será la clave!)
                string tipoIdentificacion = textBox6.Text.Trim(); // ¿Es textBox6 el tipo Identificación?
                string numeroIdentificacion = textBox7.Text.Trim(); // ¿Es textBox7 el número Identificación?

                // Obtener el rol seleccionado del ComboBox (ahora usando el nombre correcto 'comboBoxRol')
                string rol = comboBox1.SelectedItem?.ToString(); // <--- OBTENIENDO EL ROL DEL ComboBox

                Console.WriteLine($"\n--- Intentando agregar usuario: {correo} ({rol}) ---"); // Depuración
                Console.WriteLine($"Datos capturados: Nombre={nombre}, Apellido={apellido}, Contraseña={contrasenia.Length} chars, Teléfono={telefono}, Correo={correo}, TipoID={tipoIdentificacion}, NumID={numeroIdentificacion}, Rol={rol}"); 


                // --- 2. Validar datos ---
                // rol ya no necesita validación de String.IsNullOrEmpty si el ComboBox siempre tiene un valor seleccionado por defecto
                if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) || string.IsNullOrEmpty(contrasenia) ||
                    string.IsNullOrEmpty(telefono) || string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(tipoIdentificacion) ||
                    string.IsNullOrEmpty(numeroIdentificacion) || string.IsNullOrEmpty(rol)) // rol podría ser null si no se seleccionó nada
                {
                    MessageBox.Show("Por favor, complete todos los campos requeridos.");
                    Console.WriteLine("Validación fallida: Campos vacíos."); // Depuración
                    return;
                }

                // Validar formato de correo (básico)
                if (!correo.Contains("@") || !correo.Contains("."))
                {
                    MessageBox.Show("Por favor, ingrese un formato de correo electrónico válido.");
                    Console.WriteLine("Validación fallida: Formato de correo incorrecto."); // Depuración
                    return;
                }

                // La validación del Rol ya está implícita porque el ComboBox solo permite seleccionar "Empleado" o "Pasajero"
                // Pero aún validamos si la variable 'rol' terminó siendo null por alguna razón (aunque es poco probable con SelectedIndex = 0)
                if (string.IsNullOrEmpty(rol))
                {
                    MessageBox.Show("No se pudo determinar el Rol del usuario. Por favor, seleccione uno.");
                    Console.WriteLine("Validación fallida: Variable 'rol' es null o vacía inesperadamente."); // Depuración
                    return;
                }


                // --- 3. Verificar si el usuario ya existe en la Tabla Hash (usando el correo como clave) ---
                // Asegúrate de que Datos.tablaUsuarios esté inicializada en alguna parte del proyecto
                // K en TablaHash es string, V es Usuario
                if (Datos.tablaUsuarios.ContieneClave(correo))
                {
                    MessageBox.Show($"Ya existe un usuario registrado con el correo electrónico: {correo}");
                    Console.WriteLine($"Error: Usuario con correo '{correo}' ya existe en la tabla hash."); // Depuración
                    // Opcional: Limpiar solo el campo de correo
                    textBox5.Clear();
                    // Opcional: Poner el foco en el campo de correo
                    textBox5.Focus();
                    return;
                }


                // --- 4. Crear la instancia del usuario (Pasajero o Empleado) ---
                // Asegúrate de que Usuario es la clase base y Pasajero/Empleado heredan de ella
                Usuario nuevoUsuario = null;

                // Asegúrate de que tus constructores de Pasajero y Empleado reciban los parámetros en el orden y tipo correctos
                // Ejemplo asumido del constructor: Pasajero(nombre, apellido, telefono, numIdentificacion, correo, contrasenia, tipoIdentificacion)
                if (rol.Equals("Pasajero", StringComparison.OrdinalIgnoreCase))
                {
                    try // Bloque try/catch interno para depurar errores en el constructor de Pasajero/Empleado
                    {
                        nuevoUsuario = new Pasajero(nombre, apellido, telefono, tipoIdentificacion, numeroIdentificacion, correo, contrasenia, rol);
                        Console.WriteLine("Usuario creado: Pasajero."); // Depuración
                    }
                    catch (Exception createEx)
                    {
                        MessageBox.Show($"Error al crear objeto Pasajero: {createEx.Message}");
                        Console.WriteLine($"ERROR al crear Pasajero: {createEx.ToString()}"); // Depuración
                        return; // Salir si falla la creación del objeto
                    }
                }
                else if (rol.Equals("Empleado", StringComparison.OrdinalIgnoreCase))
                {
                    try // Bloque try/catch interno para depurar errores en el constructor de Pasajero/Empleado
                    {
                        nuevoUsuario = new Empleado(nombre, apellido, telefono, tipoIdentificacion, numeroIdentificacion, correo, contrasenia, rol);
                        Console.WriteLine("Usuario creado: Empleado."); // Depuración
                    }
                    catch (Exception createEx)
                    {
                        MessageBox.Show($"Error al crear objeto Empleado: {createEx.Message}");
                        Console.WriteLine($"ERROR al crear Empleado: {createEx.ToString()}"); // Depuración
                        return; // Salir si falla la creación del objeto
                    }
                }

                // Si por alguna razón no se pudo crear el usuario (no debería pasar si la validación y constructores son buenos)
                if (nuevoUsuario == null)
                {
                    MessageBox.Show("Error interno al crear el objeto de usuario.");
                    Console.WriteLine("Error: nuevoUsuario es null después de intentar crear (lógica de creación)."); // Depuración
                    return;
                }


                // --- 5. Insertar el usuario en la Tabla Hash ---
                // Usamos el correo como clave y el objeto Usuario como valor
                // Asegúrate de que Datos.tablaUsuarios esté bien inicializada y sea del tipo TablaHash<string, Usuario>
                Datos.tablaUsuarios.InsertarValores(correo, nuevoUsuario);

                Console.WriteLine($"DEBUG AgregarUsuario: Tamaño actual de la tabla hash: {Datos.tablaUsuarios.Tamanio}"); // Asegúrate de que Tamanio es público en TablaHash
                Console.WriteLine($"DEBUG AgregarUsuario: ¿Contiene la clave '{correo}' después de insertar? {Datos.tablaUsuarios.ContieneClave(correo)}");

                // Opcional: Muestra todas las claves para ver qué hay realmente en la tabla
                Console.WriteLine("DEBUG AgregarUsuario: Claves actuales en la tabla hash:");
                List<string> clavesActuales = Datos.tablaUsuarios.ObtenerClaves(); // Requiere ObtenerClaves() público
                foreach (string clave in clavesActuales)
                {
                    Console.WriteLine($" - {clave}");
                }

                // --- 6. Dar feedback al usuario y limpiar campos ---
                MessageBox.Show($"Usuario {nombre} {apellido} ({rol}) agregado exitosamente.");

                // Limpiar los campos después de agregar
                textBox1.Clear(); // Nombre
                textBox2.Clear(); // Apellido
                textBox3.Clear(); // Contraseña
                textBox4.Clear(); // Teléfono
                textBox5.Clear(); // Correo
                textBox6.Clear(); // Tipo Identificación
                textBox7.Clear(); // Número Identificación
                // El ComboBoxRol ya tiene un valor por defecto (Empleado/Pasajero), no es necesario limpiarlo a vacío

            }
            catch (Exception ex)
            {
                // Capturar cualquier otro error inesperado (ej: problema con Datos.tablaUsuarios)
                MessageBox.Show("Ocurrió un error al agregar el usuario: " + ex.Message);
                Console.WriteLine("ERROR general en agregarusuariosForm1.button2_Click: " + ex.ToString()); // Imprimir detalles del error en consola
            }
        }
    }
}
