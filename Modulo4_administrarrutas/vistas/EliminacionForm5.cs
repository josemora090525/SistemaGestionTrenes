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

namespace ProyectoEstructuras.Modulo4_administrarrutas.vistas
{
    public partial class EliminacionForm5 : Form
    {
        public EliminacionForm5()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuForm2 menuForm2 = new MenuForm2();
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
                    // Mostrar detalles de la ruta en el RichTextBox.
                    richTextBox1.Text = "Ruta encontrada:\n";
                    richTextBox1.Text += $"Nombre: {rutaEncontrada.Nombre}\n";
                    richTextBox1.Text += $"ID: {rutaEncontrada.IdRuta}\n";
                    richTextBox1.Text += $"Origen: {rutaEncontrada.Origen}\n";
                    richTextBox1.Text += $"Destino: {rutaEncontrada.Destino}\n";
                    // Como las fechas son cadenas, se muestran directamente.
                    richTextBox1.Text += $"Fecha de Salida: {rutaEncontrada.FechaSalida}\n";
                    richTextBox1.Text += $"Fecha de Llegada: {rutaEncontrada.FechaLlegada}\n";
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

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string nombreBusqueda = textBox1.Text.Trim();
            string idBusqueda = textBox2.Text.Trim();

            // Validar que los campos de búsqueda tengan información.
            if (string.IsNullOrEmpty(nombreBusqueda) || string.IsNullOrEmpty(idBusqueda))
            {
                MessageBox.Show("Por favor, ingrese nombre y ID para eliminar la ruta.");
                return;
            }

            // Buscar la ruta para confirmar su existencia.
            Ruta rutaEncontrada = Datos.tablaRutas.BuscarValores(idBusqueda);
            if (rutaEncontrada != null)
            {
                // Validar que el nombre coincida.
                if (string.Equals(rutaEncontrada.Nombre, nombreBusqueda, StringComparison.OrdinalIgnoreCase))
                {
                    Datos.tablaRutas.EliminarValores(idBusqueda);
                    MessageBox.Show("Ruta eliminada exitosamente.");

                    // Limpiar controles y el área de resultados.
                    textBox1.Clear();
                    textBox2.Clear();
                    richTextBox1.Clear();
                }
                else
                {
                    MessageBox.Show("No se encontró una ruta que coincida con el ID y el nombre ingresados.");
                }
            }
            else
            {
                MessageBox.Show("No se encontró la ruta con el ID proporcionado.");
            }
        }


    }
}
