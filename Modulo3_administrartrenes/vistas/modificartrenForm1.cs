using ProyectoEstructuras.Códigos.Servicio;
using ProyectoEstructuras.Modulo4_administrarrutas.vistas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoEstructuras.Modulo3_administrartrenes.vistas
{
    public partial class modificartrenForm1 : Form
    {
        public modificartrenForm1()
        {
            InitializeComponent();
        }

        private void modificartrenForm1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            menuForm2 formMenu = new menuForm2();

            // Muestra el formulario anterior.
            formMenu.Show();

            // Cierra o esconde el formulario actual.
            this.Close(); // O this.Hide();
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
                // Capturar el ID ingresado en el campo de texto
                string idBuscado = textBox2.Text.Trim();

                // Validar entrada
                if (string.IsNullOrEmpty(idBuscado))
                {
                    MessageBox.Show("Por favor, ingrese el ID del tren para buscar.");
                    return;
                }

                // Buscar el tren en la lista circular por ID
                Tren trenEncontrado = Datos.listaTrenes.Buscar(idBuscado);

                if (trenEncontrado != null)
                {
                    // Mostrar los detalles del tren en el RichTextBox
                    richTextBox1.Text = $"Tren encontrado:\n" +
                                        $"Nombre: {trenEncontrado.Nombre}\n" +
                                        $"ID: {trenEncontrado.Id}\n" +
                                        $"Capacidad de vagones: {trenEncontrado.CapacidadVagones}\n" +
                                        $"Kilometraje: {trenEncontrado.Kilometraje}\n";

                }
                else
                {
                    // Si no se encuentra el tren, mostrar un mensaje en el RichTextBox
                    richTextBox1.Text = $"No se encontró ningún tren con ID: {idBuscado}.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar tren: {ex.Message}");
            }
            textBox1.Clear();
            textBox2.Clear();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            guardarmodificacionForm7 formGuardar = new guardarmodificacionForm7();

            // Mostrar el formulario guardarmodificacionForm1
            formGuardar.Show();

            // Cerrar el formulario actual (modificarForm6)
            this.Close();

        }
    }
}
