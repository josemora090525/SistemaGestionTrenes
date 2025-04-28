using ProyectoEstructuras.Códigos.Servicio;
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

namespace ProyectoEstructuras.Modulo1_CompraBoleto.Vistas
{
    public partial class MenúViajesForm2 : Form
    {

        private void CargarRutas()
        {
            
            
        }


        public MenúViajesForm2()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("\n--- Buscando viaje ---");

                string origenId = txtLugarOrigen.Text.Trim();
                string destinoId = txtLugarDestino.Text.Trim();

                Console.WriteLine($"Datos de búsqueda capturados: Origen='{origenId}', Destino='{destinoId}'");

                if (string.IsNullOrEmpty(origenId) || string.IsNullOrEmpty(destinoId))
                {
                    MessageBox.Show("Por favor, ingrese el Lugar de Origen y el Lugar de Destino.", "Validación de Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Console.WriteLine("Validación fallida: Campos de origen o destino vacíos.");
                    return;
                }

                Estacion origenEstacion = null;
                Estacion destinoEstacion = null;

                if (Datos.grafoEstaciones?.Nodos != null)
                {
                    foreach (Estacion estacion in Datos.grafoEstaciones.Nodos.ObtenerClaves())
                    {
                        if (estacion?.IdEstacion != null)
                        {
                            if (estacion.IdEstacion.Equals(origenId, StringComparison.OrdinalIgnoreCase)) origenEstacion = estacion;
                            if (estacion.IdEstacion.Equals(destinoId, StringComparison.OrdinalIgnoreCase)) destinoEstacion = estacion;
                        }
                        if (origenEstacion != null && destinoEstacion != null) break;
                    }
                }

                if (origenEstacion == null)
                {
                    MessageBox.Show($"El Lugar de Origen con Identificación '{origenId}' no fue encontrado en nuestras estaciones.", "Estación No Encontrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine($"Búsqueda fallida: Estación de origen '{origenId}' no encontrada en el grafo.");
                    return;
                }

                if (destinoEstacion == null)
                {
                    MessageBox.Show($"El Lugar de Destino con Identificación '{destinoId}' no fue encontrado en nuestras estaciones.", "Estación No Encontrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine($"Búsqueda fallida: Estación de destino '{destinoId}' no encontrada en el grafo.");
                    return;
                }

                Console.WriteLine($"Estaciones encontradas en el grafo: Origen='{origenEstacion.NombreEstacion}', Destino='{destinoEstacion.NombreEstacion}'");

                int distancia = Datos.grafoEstaciones.CalcularDistanciaEntre(origenEstacion, destinoEstacion);

                Console.WriteLine($"Distancia calculada entre '{origenEstacion.NombreEstacion}' y '{destinoEstacion.NombreEstacion}': {distancia} Km");

                if (distancia >= 0 && distancia != int.MaxValue)
                {
                    Console.WriteLine($"Distancia estimada: {distancia} Km.");

                    MessageBox.Show($"Ruta encontrada.\nDistancia estimada: {distancia} Km.", "Resultados de Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else if (distancia == int.MaxValue)
                {
                    MessageBox.Show("No se encontró un camino disponible entre el origen y el destino seleccionados.", "Ruta No Disponible", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Console.WriteLine("Destino no alcanzable desde origen.");
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al buscar la ruta. Asegúrese de que las estaciones existen y las rutas están cargadas correctamente.", "Error de Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("Error en el cálculo de distancia (retorno -1).");
                }

                Console.WriteLine("--- Proceso de búsqueda finalizado ---");
                ListaviajesForm3 listaviajesForm3 = new ListaviajesForm3(origenEstacion, destinoEstacion, distancia);
                listaviajesForm3.Show();
                this.Hide(); 

            }
            catch (Exception ex)
            {
                string errorMsg = "Ocurrió un error inesperado durante la búsqueda: " + ex.Message + "\nDetalles técnicos en la Consola.";
                MessageBox.Show(errorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("ERROR general en MenúViajesForm2.button1_Click (Buscar): " + ex.ToString());
            }
        }

        private void panel1_Paint_2(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            IniciarsesionForm1 loginForm = new IniciarsesionForm1();
            loginForm.Show();
            this.Hide(); 
        }
    }
}
