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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProyectoEstructuras.Modulo7_calcularestaciones.vistas
{
    public partial class crearestacionesForm13 : Form
    {
        public crearestacionesForm13()
        {
            InitializeComponent();
        }

        private void crearestacionesForm13_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            menuEstacionesForm2 menuEstaciones = new menuEstacionesForm2();
            menuEstaciones.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("\n--- Intentando agregar estación ---");

                string nombreEstacion = textBox3.Text.Trim();
                string identificacionEstacion = textBox4.Text.Trim();

                Console.WriteLine($"Datos capturados: Nombre='{nombreEstacion}', Identificación='{identificacionEstacion}'");

                if (string.IsNullOrEmpty(nombreEstacion) || string.IsNullOrEmpty(identificacionEstacion))
                {
                    MessageBox.Show("Por favor, complete el Nombre y la Identificación de la estación.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Console.WriteLine("Validación fallida: Campos Nombre o Identificación vacíos.");
                    return;
                }

                Estacion nuevaEstacion = new Estacion(identificacionEstacion, nombreEstacion);

                Console.WriteLine($"Instancia de Estacion creada en memoria: ID='{nuevaEstacion.IdEstacion}', Nombre='{nuevaEstacion.NombreEstacion}'");

                Datos.grafoEstaciones.AgregarNodo(nuevaEstacion);

                MessageBox.Show($"Estación '{nombreEstacion}' (ID: {identificacionEstacion}) agregada exitosamente.", "Estación Agregada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Console.WriteLine($"Llamada a Datos.grafoEstaciones.AgregarNodo() completada con la estación: ID='{nuevaEstacion.IdEstacion}'.");

                if (textBox3 != null) textBox3.Clear();
                if (textBox4 != null) textBox4.Clear();
            }
            catch (Exception ex)
            {
                string errorMsg = "Ocurrió un error al intentar agregar la estación: " + ex.Message + "\nDetalles técnicos en la Consola.";
                MessageBox.Show(errorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("ERROR general en crearestacionesForm13.button2_Click (Crear): " + ex.ToString());
            }
        }
    }
}
