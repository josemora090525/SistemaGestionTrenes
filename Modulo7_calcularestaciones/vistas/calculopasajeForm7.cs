using ProyectoEstructuras.Códigos.Servicio;
using ProyectoEstructuras.Modulo7_calcularestaciones.vistas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoEstructuras.Modulo10_calculoestaciones.vistas
{
    public partial class calculopasajeForm7 : Form
    {
        public calculopasajeForm7()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            menuEstacionesForm2 menuEstacionesForm2 = new menuEstacionesForm2();
            menuEstacionesForm2.Show();
            this.Hide();
        }

        public int AddMatrixEdgesToGraph() // Ahora devuelve un entero (la cantidad de aristas agregadas)
        {
            var connections = new List<(string, string, int)>
            {
                ("A", "B", 30), ("A", "C", 40), ("A", "D", 50), ("A", "F", 50),
                ("D", "E", 20),
                ("E", "F", 65),
                ("F", "G", 80),
                ("G", "H", 30), ("G", "I", 145),
                ("C", "I", 80), ("C", "J", 120), ("C", "K", 110)
            };

            Console.WriteLine("\n--- Intentando agregar aristas desde la matriz ---");

            int addedEdgesCount = 0; // Contador para las aristas agregadas exitosamente

            foreach (var connection in connections)
            {
                string origenId = connection.Item1;
                string destinoId = connection.Item2;
                int peso = connection.Item3;

                Estacion origenEstacion = FindEstacionById(origenId);
                Estacion destinoEstacion = FindEstacionById(destinoId);

                if (origenEstacion != null && destinoEstacion != null)
                {
                    // Si ambas estaciones existen en el grafo, agrega la arista.
                    Datos.grafoEstaciones.AgregarAristaNoDirigida(origenEstacion, destinoEstacion, peso);
                    Console.WriteLine($"DEBUG: Arista no dirigida agregada entre '{origenId}' y '{destinoId}' con peso {peso}.");
                    addedEdgesCount++; // Incrementa el contador
                }
                else
                {
                    Console.WriteLine($"ADVERTENCIA: No se pudo agregar arista entre '{origenId}' y '{destinoId}'. Asegúrese de que ambas estaciones existan en el grafo ANTES de cargar las aristas.");
                }
            }

            Console.WriteLine("--- Proceso de agregar aristas finalizado ---");
            return addedEdgesCount; // Devuelve la cantidad de aristas que se lograron agregar
        }

        private Estacion FindEstacionById(string estacionId) // Puede ser public si se usa fuera
        {
            if (string.IsNullOrEmpty(estacionId) || Datos.grafoEstaciones?.Nodos == null)
            {
                Console.WriteLine($"DEBUG FindEstacionById: ID nulo/vacío o grafo no inicializado para buscar '{estacionId}'.");
                return null;
            }

            Console.WriteLine($"DEBUG FindEstacionById: Buscando estación con ID '{estacionId}' en la TablaHash.");

            foreach (Estacion estacion in Datos.grafoEstaciones.Nodos.ObtenerClaves())
            {
                if (estacion?.IdEstacion != null && estacion.IdEstacion.Equals(estacionId, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"DEBUG FindEstacionById: Estación con ID '{estacionId}' encontrada: {estacion}.");
                    return estacion;
                }
            }

            Console.WriteLine($"DEBUG FindEstacionById: Estación con ID '{estacionId}' NO encontrada en la TablaHash.");
            return null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("\n--- Intentando calcular pasaje ---");
                string origenId = textBox1.Text.Trim(); // ID Estación origen
                string destinoId = textBox2.Text.Trim(); // ID Estación llegada
                string tipoBoletoSeleccionado = comboBox1.SelectedItem?.ToString(); // Tipo boleto


                Console.WriteLine($"Datos de entrada capturados: Origen='{origenId}', Destino='{destinoId}', Tipo Boleto='{tipoBoletoSeleccionado}'");
                if (txtDistanciaOutput != null) txtDistanciaOutput.Clear(); // Limpia el campo de distancia de salida
                if (txtValorCalculadoOutput != null) txtValorCalculadoOutput.Clear(); // Limpia el campo de valor calculado de salida


        // Validación de campos de entrada
                if (string.IsNullOrEmpty(origenId) || string.IsNullOrEmpty(destinoId))
                {
                    MessageBox.Show("Por favor, ingrese la Estación de Origen y la Estación de Llegada.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Console.WriteLine("Validación fallida: Campos de origen o llegada vacíos.");
                    return;
                }

                if (string.IsNullOrEmpty(tipoBoletoSeleccionado))
                {
                    MessageBox.Show("Por favor, seleccione un Tipo de Boleto.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Console.WriteLine("Validación fallida: No se seleccionó tipo de boleto.");
                    return;
                }

        
                Estacion origenEstacionKey = new Estacion(origenId, "");
                Estacion destinoEstacionKey = new Estacion(destinoId, "");

                Console.WriteLine($"Objetos Estacion 'clave' creados: Origen ID='{origenEstacionKey.IdEstacion}', Destino ID='{destinoEstacionKey.IdEstacion}'");

        
                if (!Datos.grafoEstaciones.Nodos.ContieneClave(origenEstacionKey))
                {
                    MessageBox.Show($"La estación de origen con Identificación '{origenId}' no fue encontrada en el grafo.\n\nAsegúrese de haber agregado esta estación previamente usando el formulario 'Crear Estación'.", "Estación No Encontrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine($"Búsqueda fallida: Estación de origen '{origenId}' no encontrada en la TablaHash.");
                    return;
                }

                if (!Datos.grafoEstaciones.Nodos.ContieneClave(destinoEstacionKey))
                {           
            
                    MessageBox.Show($"La estación de llegada con Identificación '{destinoId}' no fue encontrada en el grafo.\n\nAsegúrese de haber agregado esta estación previamente usando el formulario 'Crear Estación'.", "Estación No Encontrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine($"Búsqueda fallida: Estación de llegada '{destinoId}' no encontrada en la TablaHash.");
                    return;
                }

         
                Estacion origenEstacionCompleta = null;
                Estacion destinoEstacionCompleta = null;

                foreach (Estacion estacion in Datos.grafoEstaciones.Nodos.ObtenerClaves())
                {
                    if (estacion?.IdEstacion != null)
                    {
                        if (estacion.IdEstacion.Equals(origenId, StringComparison.OrdinalIgnoreCase)) origenEstacionCompleta = estacion;
                        if (estacion.IdEstacion.Equals(destinoId, StringComparison.OrdinalIgnoreCase)) destinoEstacionCompleta = estacion;
                    }
                if (origenEstacionCompleta != null && destinoEstacionCompleta != null) break;
                }

                if (origenEstacionCompleta == null || destinoEstacionCompleta == null)
                {
                    string errorInternoMsg = "Error interno al recuperar los detalles completos de las estaciones después de la verificación.";
                    MessageBox.Show(errorInternoMsg, "Error Interno", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine($"Error interno: No se pudieron recuperar objetos Estacion completos para origen '{origenId}' o destino '{destinoId}'.");
                    return;
                }

                Console.WriteLine($"Estaciones encontradas en el grafo: Origen='{origenEstacionCompleta.NombreEstacion}', Destino='{destinoEstacionCompleta.NombreEstacion}'");

                int distancia = Datos.grafoEstaciones.CalcularDistanciaEntre(origenEstacionCompleta, destinoEstacionCompleta);

                Console.WriteLine($"Distancia calculada entre '{origenEstacionCompleta.NombreEstacion}' y '{destinoEstacionCompleta.NombreEstacion}': {distancia} Km");

                if (txtDistanciaOutput != null)
                {
                    if (distancia >= 0 && distancia != int.MaxValue) // Si la distancia es un valor válido y alcanzable
                    {
                        txtDistanciaOutput.Text = distancia.ToString(); // Muestra la distancia en el TextBox de salida de Distancia
                        Console.WriteLine($"Distancia mostrada en campo txtDistanciaOutput: {distancia} Km.");
                        MaquinaVenta maquina = new MaquinaVenta(); // Crear una instancia de MaquinaVenta

                        double precioPasaje = maquina.CalcularPrecio(tipoBoletoSeleccionado, distancia); // Calcular el precio

                        Console.WriteLine($"Precio calculado para boleto '{tipoBoletoSeleccionado}' y distancia {distancia} Km: {precioPasaje:C}"); 
                        if (txtValorCalculadoOutput != null)
                        {
                            txtValorCalculadoOutput.Text = precioPasaje.ToString("C"); // Muestra el precio en el TextBox de salida de Valor Calculado (formateado como moneda)
                            Console.WriteLine($"Precio mostrado en campo txtValorCalculadoOutput: {precioPasaje:C}");
                        }
                        else
                        {
                            Console.WriteLine("ADVERTENCIA: Control txtValorCalculadoOutput es null.");
                        }

                    }
                    else if (distancia == int.MaxValue) // Si la distancia es int.MaxValue (inaccesible)
                    {
                        string unreachableMsg = "No hay un camino disponible entre las estaciones seleccionadas.";
                        txtDistanciaOutput.Text = "Inalcanzable"; // Muestra "Inalcanzable" en el campo de distancia de salida
                        if (txtValorCalculadoOutput != null) txtValorCalculadoOutput.Clear(); // Limpia el campo de precio de salida
                        MessageBox.Show(unreachableMsg, "Resultado de Cálculo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Console.WriteLine(unreachableMsg);
                    }
                    else // Si la distancia es -1 (error de cálculo en CalcularDistanciaEntre)
                    {
                        string distanceErrorMsg = "No se pudo calcular la distancia entre las estaciones.\n\nAsegúrese de haber agregado las aristas (rutas) usando el botón 'Cargar Rutas' en este formulario."; // Mensaje más claro sobre posible falta de aristas
                        txtDistanciaOutput.Text = "Error"; // Muestra "Error" en el campo de distancia de salida
                        if (txtValorCalculadoOutput != null) txtValorCalculadoOutput.Clear(); // Limpia el campo de precio de salida
                        MessageBox.Show(distanceErrorMsg, "Error de Cálculo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Console.WriteLine(distanceErrorMsg);
                    }
                }
                else
                {
                    Console.WriteLine("ADVERTENCIA: Control txtDistanciaOutput es null."); // Depuración si el control de distancia de salida no existe
                }

                Console.WriteLine("--- Proceso de cálculo de pasaje finalizado ---");

            }
            catch (Exception ex)
            {
                string errorMsg = "Ocurrió un error inesperado al calcular el pasaje: " + ex.Message + "\nDetalles técnicos en la Consola.";
                MessageBox.Show(errorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("ERROR general en calculopasajeForm7.button1_Click (Calcular): " + ex.ToString());
         
                if (txtDistanciaOutput != null) txtDistanciaOutput.Clear();
                if (txtValorCalculadoOutput != null) txtValorCalculadoOutput.Clear();
            }
        }

        private void calculopasajeForm7_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Premium");
            comboBox1.Items.Add("Ejecutivo");
            comboBox1.Items.Add("Estandar");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int edgesLoaded = AddMatrixEdgesToGraph();
            MessageBox.Show($"Intento de cargar aristas del grafo desde la matriz.\nSe agregaron {edgesLoaded} arista(s).\nVerifique la consola para detalles o advertencias si faltan estaciones.", "Carga de Rutas Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
