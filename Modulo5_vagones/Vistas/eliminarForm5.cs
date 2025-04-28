using ProyectoEstructuras.Códigos.Servicio;
using ProyectoEstructuras.Códigos.TareasEmpleado;
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
    public partial class eliminarForm5 : Form
    {
        public eliminarForm5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            menuForm2 menuForm2 = new menuForm2();
            menuForm2.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Capturar el ID del vagón a buscar.
                // Ojo: Este textbox2 es donde se captura el ID a buscar.
                // En el método de Agregar, limpias textBox2 después de agregar.
                // Si agregas, y luego sin cerrar el programa, usas el mismo formulario para buscar,
                // textBox2 estará vacío si no vuelves a escribir el ID del vagón.
                string idVagonBuscado = textBox2.Text.Trim();
                if (string.IsNullOrEmpty(idVagonBuscado))
                {
                    MessageBox.Show("Ingrese el ID del vagón a buscar.");
                    return;
                }

                Console.WriteLine($"\n--- Buscando vagón con ID: '{idVagonBuscado}' ---");

                // --- NUEVAS LÍNEAS DE DEPURACIÓN: Verificar la lista de trenes *antes* de la búsqueda ---
                Console.WriteLine("--- Estado de Datos.listaTrenes ANTES de iniciar la búsqueda ---");
                Console.WriteLine($"Tamaño de la lista de trenes: {Datos.listaTrenes.Tamanio}"); // <-- Agrega esta línea
                int index = 0; // <-- Agrega esta variable
                bool listaVacia = true; // <-- Variable para verificar si el foreach realmente itera

                // Este foreach ahora debería usar el GetEnumerator corregido y visitar todos los trenes
                foreach (Tren tren in Datos.listaTrenes)
                {
                    listaVacia = false; // Si entra al menos una vez, la lista no estaba "vacía" para el iterador
                    Console.WriteLine($"Tren {index}: ID en la lista: {tren.Id} (Tipo: {tren.GetType().Name})"); // <-- Modifica esta línea
                    index++;
                }

                if (listaVacia && Datos.listaTrenes.Tamanio > 0)
                {
                    // Este mensaje indicaría que el GetEnumerator no está funcionando correctamente A PESAR de la corrección,
                    // o que la lista se modificó inesperadamente justo antes del foreach.
                    Console.WriteLine("\nADVERTENCIA SERIA: Datos.listaTrenes tiene tamaño > 0, pero el foreach no iteró. Problema con el enumerador o estado de la lista.");
                }
                else if (Datos.listaTrenes.Tamanio == 0)
                {
                    Console.WriteLine("\nLa lista de trenes está vacía. No hay trenes para buscar vagones.");
                }
                Console.WriteLine("--- Fin estado de Datos.listaTrenes ANTES ---");
                // --- FIN NUEVAS LÍNEAS DE DEPURACIÓN ---


                Vagon vagonEncontrado = null;
                string trenAsociadoId = "";
                // La variable trenEncontradoEnLista ya no es tan necesaria con la depuración anterior,
                // pero la mantenemos si quieres. El problema principal era la iteración de la lista.
                // bool trenEncontradoEnLista = false;


                // Iterar a través de la ListaCircular de Trenes (ahora con GetEnumerator corregido)
                foreach (Tren tren in Datos.listaTrenes)
                {
                    // trenEncontradoEnLista = true; // Esto ahora solo confirma que el foreach se ejecutó al menos una vez

                    Console.WriteLine($"\nRevisando tren con ID: '{tren.Id}' para encontrar vagón '{idVagonBuscado}'");

                    // --- LÍNEA DE DEPURACIÓN (Vagones en el tren actual) ---
                    Console.WriteLine($"Vagones en la pila del tren '{tren.Id}': (Tamaño: {tren.PilaVagones.Tamanio})"); // Agregado tamaño
                    Nodo<Vagon> actualVagonNodo = tren.PilaVagones.Tope;
                    int vagonIndex = 0; // <-- Agregado contador para vagones
                    while (actualVagonNodo != null)
                    {
                        Console.WriteLine($"- Vagón {vagonIndex}: ID: '{actualVagonNodo.Elemento.GetId()}', Capacidad: {actualVagonNodo.Elemento.Capacidad}");
                        if (actualVagonNodo.Elemento.GetId().Trim().Equals(idVagonBuscado.Trim(), StringComparison.OrdinalIgnoreCase))
                        {
                            vagonEncontrado = actualVagonNodo.Elemento;
                            trenAsociadoId = tren.Id;
                            Console.WriteLine($"\n¡Vagón encontrado en el tren '{trenAsociadoId}' durante la iteración de la pila!");
                            break; // Salir del bucle de la pila de este tren
                        }
                        actualVagonNodo = actualVagonNodo.Siguiente;
                        vagonIndex++; // Incrementar contador de vagones
                    }
                    //Console.WriteLine($"Fin revisión de vagones en tren '{tren.Id}'."); // Depuración


                    if (vagonEncontrado != null)
                    {
                        // Si encontramos el vagón en el tren actual, salimos del bucle principal de trenes
                        //Console.WriteLine($"Vagón encontrado, saliendo del bucle de trenes."); // Depuración
                        break;
                    }
                }

                // Las advertencias sobre lista vacía o no iterada ahora se manejan mejor antes del foreach.
                // if (!trenEncontradoEnLista && Datos.listaTrenes.Tamanio> 0) { ... }
                // else if (Datos.listaTrenes.Tamanio == 0) { ... }


                if (vagonEncontrado == null)
                {
                    MessageBox.Show("No se encontró el vagón con el ID especificado en ningún tren.");
                    richTextBox1.Clear();
                }
                else
                {
                    richTextBox1.Text = $"Vagón encontrado:\n" +
                                         $"ID: {vagonEncontrado.GetId()}\n" +
                                         $"Capacidad: {vagonEncontrado.Capacidad}\n" +
                                         $"Tren asociado: {trenAsociadoId}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar el vagón: " + ex.Message);
                Console.WriteLine("ERROR: " + ex.ToString()); // Imprimir detalles del error en consola
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Capturar los IDs desde los controles.
                string idTrenABuscar = textBox1.Text.Trim(); // Asumo textBox1 para ID Tren
                string idVagonAEliminar = textBox2.Text.Trim(); // Asumo textBox2 para ID Vagón

                // 2. Validar la entrada.
                if (string.IsNullOrEmpty(idTrenABuscar))
                {
                    MessageBox.Show("Ingrese el ID del tren.");
                    return;
                }
                 if (string.IsNullOrEmpty(idVagonAEliminar))
                {
                    MessageBox.Show("Ingrese el ID del vagón a eliminar.");
                    return;
                }

                Console.WriteLine($"\n--- Intentando eliminar vagón '{idVagonAEliminar}' del tren '{idTrenABuscar}' ---");


                // 3. Buscar el tren por su ID en la ListaCircular.
                // Usamos el método Buscar que ya tienes implementado en ListaCircular
                // Este método usa el GetEnumerator corregido, por lo que debería encontrar el tren si existe.
                Tren trenEncontrado = Datos.listaTrenes.Buscar(idTrenABuscar);


                // 4. Si no se encuentra el tren...
                if (trenEncontrado == null)
                {
                    MessageBox.Show($"No se encontró ningún tren con el ID '{idTrenABuscar}'.");
                     Console.WriteLine($"Tren con ID '{idTrenABuscar}' no encontrado en la lista."); 
                    return; // Salir del método, no se puede eliminar
                }

                // 5. Si se encuentra el tren, intentar eliminar el vagón de su pila.
                 Console.WriteLine($"Tren con ID '{idTrenABuscar}' encontrado. Intentando eliminar vagón '{idVagonAEliminar}' de su pila."); 

                // Llama al método EliminarPorId de la pila del tren.
                // Este método devuelve true si eliminó, false si el vagón no estaba en la pila.
                bool vagonEliminado = trenEncontrado.PilaVagones.EliminarPorId(idVagonAEliminar);


                // 6. Dar feedback al usuario.
                if (vagonEliminado)
                {
                    MessageBox.Show($"Vagón con ID '{idVagonAEliminar}' eliminado exitosamente del tren con ID '{idTrenABuscar}'.");
                     Console.WriteLine($"Vagón con ID '{idVagonAEliminar}' eliminado exitosamente."); // Depuración
                    // Limpiar los campos después de una eliminación exitosa
                    textBox1.Clear();
                    textBox2.Clear();
                    richTextBox1.Clear(); // Limpiar el área de visualización si se usó
                }
                else
                {
                    // Esto ocurre si el vagón con idVagonAEliminar no se encontró en la pila de ESE tren
                    MessageBox.Show($"No se encontró el vagón con el ID '{idVagonAEliminar}' en el tren con ID '{idTrenABuscar}'.");
                     Console.WriteLine($"Vagón con ID '{idVagonAEliminar}' no encontrado en la pila del tren '{idTrenABuscar}'."); 
                } 

            }
            catch (Exception ex)
            {
                // Captura cualquier otro error que pueda ocurrir (ej: PilaVagones es null si el tren no está bien inicializado, aunque Buscar debería evitarlo)
                MessageBox.Show("Ocurrió un error al intentar eliminar el vagón: " + ex.Message);
                 Console.WriteLine("ERROR en eliminarForm5.button3_Click (Eliminar): " + ex.ToString()); // Imprimir detalles del error
            }
        }
    }
}
