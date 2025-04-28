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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProyectoEstructuras.Modulo4_administrarrutas.vistas
{
    public partial class busquedaForm4 : Form
    {
        public busquedaForm4()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuForm2 menuForm = new MenuForm2();
            menuForm.Show();
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
            string nombreBusqueda = textBox1.Text.Trim();
            string idBusqueda = textBox2.Text.Trim();

            // Validar que ambos campos contengan datos.
            if (string.IsNullOrEmpty(nombreBusqueda) || string.IsNullOrEmpty(idBusqueda))
            {
                MessageBox.Show("Por favor, ingrese nombre y ID de la ruta para la búsqueda.");
                return;
            }

            // Buscar la ruta en la tabla hash empleando el ID.
            Ruta rutaEncontrada = Datos.tablaRutas.BuscarValores(idBusqueda);
            if (rutaEncontrada != null)
            {
                // Validar que el nombre coincida (ignorando mayúsculas/minúsculas).
                if (string.Equals(rutaEncontrada.Nombre, nombreBusqueda, StringComparison.OrdinalIgnoreCase))
                {
                    // Mostrar detalles de la ruta sin intentar formatear las fechas, ya que son strings.
                    richTextBox1.Text = "Ruta encontrada:\n";
                    richTextBox1.Text += $"Nombre: {rutaEncontrada.Nombre}\n";
                    richTextBox1.Text += $"ID: {rutaEncontrada.IdRuta}\n";
                    richTextBox1.Text += $"Origen: {rutaEncontrada.Origen}\n";
                    richTextBox1.Text += $"Destino: {rutaEncontrada.Destino}\n";
                    richTextBox1.Text += $"Fecha de Salida: {rutaEncontrada.FechaSalida}\n";
                    richTextBox1.Text += $"Fecha de Llegada: {rutaEncontrada.FechaLlegada}\n";

                    // Limpiar controles de búsqueda.
                    textBox1.Clear();
                    textBox2.Clear();
                }
                else
                {
                    richTextBox1.Text = "No se encontró una ruta que coincida con el ID y el nombre ingresados.";
                }
            }
            else
            {
                richTextBox1.Text = "No se encontró la ruta con el ID proporcionado.";
            }

        }
    }
}
