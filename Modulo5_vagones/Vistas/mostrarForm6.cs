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
    public partial class mostrarForm6 : Form
    {
        public mostrarForm6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            menuForm2 form = new menuForm2();
            form.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Limpiar el área de visualización antes de mostrar nuevos resultados
                richTextBox1.Clear();

                Console.WriteLine("\n--- Mostrando todos los vagones del sistema ---");

                // Verificar si la lista de trenes está vacía
                if (Datos.listaTrenes == null || Datos.listaTrenes.Tamanio == 0)
                {
                    richTextBox1.Text = "No hay trenes en el sistema. No hay vagones para mostrar.";
                    Console.WriteLine("La lista de trenes está vacía."); // Depuración
                    return; // Salir del método si no hay trenes
                }

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("--- LISTADO DE VAGONES EN EL SISTEMA ---");
                sb.AppendLine();

                bool foundAnyWagons = false; // Bandera para saber si encontramos al menos un vagón

                // Iterar a través de cada tren en la ListaCircular (usando el GetEnumerator corregido)
                foreach (Tren tren in Datos.listaTrenes)
                {
                    Console.WriteLine($"Revisando tren con ID: {tren.Id} (Tipo: {tren.GetType().Name})"); // Depuración

                    // Verificar si el tren actual tiene vagones en su pila
                    if (tren.PilaVagones == null || tren.PilaVagones.Tamanio == 0)
                    {
                        sb.AppendLine($"Tren ID: {tren.Id} (Este tren no tiene vagones)");
                        sb.AppendLine("  --------------------"); // Separador
                        Console.WriteLine($"  Tren '{tren.Id}' no tiene vagones."); // Depuración
                        continue; // Pasar al siguiente tren en la lista principal
                    }

                    // Si el tren tiene vagones, iterar manualmente a través de la pila
                    sb.AppendLine($"Tren ID: {tren.Id}"); // Mostrar el ID del tren antes de listar sus vagones
                    Console.WriteLine($"  Iterando sobre {tren.PilaVagones.Tamanio} vagones en tren '{tren.Id}':"); // Depuración

                    Nodo<Vagon> currentVagonNode = tren.PilaVagones.Tope; // Empezar desde el tope de la pila
                    int vagonIndex = 0; // Contador opcional para depuración/visualización

                    // Recorrer los nodos de la pila manualmente
                    while (currentVagonNode != null)
                    {
                        foundAnyWagons = true; // Marcamos que hemos encontrado al menos un vagón
                        Vagon vagon = currentVagonNode.Elemento; // Obtener el objeto Vagon del nodo

                        // Construir la cadena de texto para este vagón
                        sb.AppendLine($"  Vagón {vagonIndex + 1}:"); // Mostrar índice del vagón (opcional)
                        sb.AppendLine($"    ID: {vagon.GetId()}");
                        // Determinar el tipo de vagón usando 'is'
                        string tipoVagon = "Desconocido";
                        if (vagon is VagonCarga) tipoVagon = "Carga";
                        else if (vagon is VagonPasajeros) tipoVagon = "Pasajeros";
                        sb.AppendLine($"    Tipo: {tipoVagon}");
                        sb.AppendLine($"    Capacidad: {vagon.Capacidad}"); // Capacidad del vagón (ej: asientos o peso)

                        // Opcional: Añadir información específica si es VagónCarga o VagónPasajeros
                        if (vagon is VagonCarga vagonCarga)
                        {
                            // sb.AppendLine($"    Peso Actual: {vagonCarga.PesoActual}"); // Si tienes esta propiedad
                            // sb.AppendLine($"    Capacidad Máx. Equipaje: {vagonCarga.CapacidadMaximaEquipaje}"); // Si tienes esta propiedad
                        }
                        else if (vagon is VagonPasajeros vagonPasajeros)
                        {
                            // sb.AppendLine($"    Número de Pasajeros: {vagonPasajeros.NumeroPasajeros}"); // Si tienes esta propiedad
                        }

                        sb.AppendLine("    ------------"); // Separador para vagones dentro del mismo tren
                        Console.WriteLine($"    - Añadido vagón '{vagon.GetId()}' del tren '{tren.Id}' a la salida."); // Depuración


                        currentVagonNode = currentVagonNode.Siguiente; // Mover al siguiente nodo en la pila
                        vagonIndex++; // Incrementar contador
                    }
                    sb.AppendLine("  --------------------"); // Separador después de listar los vagones de un tren
                }

                // Si después de revisar todos los trenes no encontramos NINGÚN vagón
                if (!foundAnyWagons)
                {
                    // Este caso ocurriría si hay trenes, pero ninguno tiene vagones.
                    // La lista de trenes vacía se maneja al principio.
                    richTextBox1.Text = "Hay trenes en el sistema, pero no se encontraron vagones en ninguno de ellos.";
                    Console.WriteLine("No se encontraron vagones en ningún tren."); // Depuración
                }
                else
                {
                    // Mostrar todo el texto recolectado en el richTextBox
                    richTextBox1.Text = sb.ToString();
                    Console.WriteLine("Listado de vagones mostrado exitosamente en richTextBox1."); // Depuración
                }
                Console.WriteLine("--- Fin de la muestra de vagones ---"); // Depuración


            }
            catch (Exception ex)
            {
                // Capturar cualquier error inesperado durante la iteración o visualización
                MessageBox.Show("Error al mostrar los vagones: " + ex.Message);
                Console.WriteLine("ERROR en mostrarForm6.button3_Click: " + ex.ToString()); // Imprimir detalles del error
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
