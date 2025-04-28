using ProyectoEstructuras.Códigos.Servicio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoEstructuras.Modulo5_vagones.Vistas
{
    public partial class agregarForm3 : Form
    {
        public agregarForm3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            menuForm2 menuForm = new menuForm2();
            menuForm.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e) // Este es el botón de Agregar
        {
            try
            {
                // 1. Capturar datos desde los controles.
                string tipoVagon = comboBox1.SelectedItem?.ToString();
                string idVagon = textBox2.Text.Trim();
                string idTren = textBox3.Text.Trim();

                if (!int.TryParse(textBox4.Text.Trim(), out int capacidad))
                {
                    MessageBox.Show("Ingrese una capacidad válida.");
                    return;
                }

                if (string.IsNullOrEmpty(tipoVagon) || string.IsNullOrEmpty(idVagon) || string.IsNullOrEmpty(idTren))
                {
                    MessageBox.Show("Complete todos los campos requeridos: tipo de vagón, ID del vagón y ID del tren.");
                    return;
                }

                // 2. Buscar si ya existe un tren con el ID ingresado.
                // FirstOrDefault usa la iteración (GetEnumerator), así que con la corrección, esto también debería funcionar bien.
                Tren trenExistente = Datos.listaTrenes.FirstOrDefault(t => t.Id.Equals(idTren, StringComparison.OrdinalIgnoreCase));

                TrenArnold trenParaAgregarVagon;

                // 3. Si el tren existe, usarlo; de lo contrario, crear un nuevo TrenArnold.
                if (trenExistente != null)
                {
                    trenParaAgregarVagon = (TrenArnold)trenExistente; // Casteamos al tipo específico
                    Console.WriteLine($"Se encontró el tren con ID: {idTren}");
                }
                else
                {
                    // Crear un nuevo TrenArnold con el ID proporcionado por el usuario.
                    // Asegúrate de que TrenArnold herede de Tren e implemente InterfazID
                    // Asegúrate de que el constructor reciba los parámetros correctos para tu TrenArnold
                    trenParaAgregarVagon = new TrenArnold("Nuevo Tren Arnold", idTren, 32, 0); // Ajusta los parámetros si es necesario
                    Datos.listaTrenes.Agregar(trenParaAgregarVagon);
                    Console.WriteLine($"Se creó el tren con ID: {idTren} y se agregó a la lista.");
                }

                // --- LÍNEA DE DEPURACIÓN (ID del tren al que se agregará el vagón) ---
                Console.WriteLine($"Se va a agregar el vagón al tren con ID: {trenParaAgregarVagon.Id}");

                // 4. Crear la instancia de Vagon según el tipo seleccionado.
                Vagon nuevoVagon; // Asegúrate de que Vagon implemente InterfazID
                if (tipoVagon.Equals("Vagón de Carga", StringComparison.OrdinalIgnoreCase))
                {
                    // Asegúrate de que VagonCarga herede de Vagon y el constructor sea correcto
                    nuevoVagon = new VagonCarga(idVagon, capacidad);
                }
                else if (tipoVagon.Equals("Vagón de Pasajeros", StringComparison.OrdinalIgnoreCase))
                {
                    // Asegúrate de que VagonPasajeros herede de Vagon y el constructor sea correcto
                    nuevoVagon = new VagonPasajeros(idVagon, capacidad);
                }
                else
                {
                    MessageBox.Show("Seleccione un tipo de vagón válido.");
                    return;
                }

                // --- LÍNEA DE DEPURACIÓN (ID del vagón creado) ---
                Console.WriteLine($"Se creó el vagón con ID: {nuevoVagon.GetId()} (Tipo: {tipoVagon}, Capacidad: {capacidad})");

                // 5. Agregar el vagón al tren encontrado o creado.
                // Asegúrate de que TrenArnold tenga un método AgregarVagon
                // que internamente llame a PilaVagones.Push()
                trenParaAgregarVagon.AgregarVagon(nuevoVagon);

                // --- LÍNEA DE DEPURACIÓN (Cantidad de vagones en la pila del tren) ---
                // Asegúrate de que TrenArnold tenga una propiedad PilaVagones accesible
                Console.WriteLine($"Cantidad de vagones en la pila del tren '{trenParaAgregarVagon.Id}': {trenParaAgregarVagon.PilaVagones.Tamanio}");


                // --- NUEVAS LÍNEAS DE DEPURACIÓN: Verificar la lista de trenes *después* de agregar ---
                Console.WriteLine($"--- Estado de Datos.listaTrenes DESPUÉS de agregar vagón/tren ---");
                Console.WriteLine($"Tamaño de la lista de trenes: {Datos.listaTrenes.Tamanio}");
                int index = 0;
                // Este foreach ahora debería usar el GetEnumerator corregido
                foreach (Tren t in Datos.listaTrenes)
                {
                    Console.WriteLine($"Tren {index}: ID='{t.Id}' (Tipo: {t.GetType().Name})"); // Muestra el tipo real del objeto
                    index++;
                    // Opcional: Imprimir vagones en este tren para verificar que están ahí
                    /*
                    Console.WriteLine($"  Vagones en tren '{t.Id}': {t.PilaVagones.Tamanio}");
                    Nodo<Vagon> tempVagon = t.PilaVagones.Tope;
                    while(tempVagon != null)
                    {
                        Console.WriteLine($"    - Vagon ID: {tempVagon.Elemento.GetId()}, Capacidad: {tempVagon.Elemento.Capacidad}");
                        tempVagon = tempVagon.Siguiente;
                    }
                    */
                }
                Console.WriteLine("--- Fin estado de Datos.listaTrenes DESPUÉS ---");
                // --- FIN NUEVAS LÍNEAS DE DEPURACIÓN ---


                MessageBox.Show($"Vagón con ID '{idVagon}' agregado al tren con ID '{idTren}' exitosamente.");

                // 6. Limpiar los controles para futuras entradas.
                comboBox1.SelectedIndex = -1;
                textBox2.Clear(); // Ojo: este es el ID del vagón, se limpia al agregar, pero el de buscar lo usa.
                textBox3.Clear();
                textBox4.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el vagón: " + ex.Message);
                Console.WriteLine("ERROR: " + ex.ToString()); // Imprimir detalles del error en consola
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void agregarForm3_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear(); // Limpiar elementos previos, si los hubiera
            comboBox1.Items.Add("Vagón de Carga");
            comboBox1.Items.Add("Vagón de Pasajeros");
        }
    }
}
