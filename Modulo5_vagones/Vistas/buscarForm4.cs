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
    public partial class buscarForm4 : Form
    {
        public buscarForm4()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

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

        private void button2_Click(object sender, EventArgs e) // Este es el botón de Buscar
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
    }
}
