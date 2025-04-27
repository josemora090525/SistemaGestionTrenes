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

namespace ProyectoEstructuras.Modulo3_administrartrenes.vistas
{
    public partial class eliminarForm5 : Form
    {
        public eliminarForm5()
        {
            InitializeComponent();
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

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Capturar el ID ingresado en el campo de texto
                string idEliminar = textBox2.Text.Trim();

                // Validar entrada
                if (string.IsNullOrEmpty(idEliminar))
                {
                    MessageBox.Show("Por favor, ingrese el ID del tren para eliminar.");
                    return;
                }

                // Intentar eliminar el tren de la lista circular por ID
                bool eliminado = Datos.listaTrenes.Eliminar(idEliminar);

                if (eliminado)
                {
                    // Mostrar mensaje de éxito y limpiar el RichTextBox
                    MessageBox.Show($"El tren con ID: {idEliminar} ha sido eliminado correctamente.");
                    richTextBox1.Text = "";
                }
                else
                {
                    // Mostrar mensaje de error si no se encontró el tren
                    MessageBox.Show($"No se encontró ningún tren con ID: {idEliminar} para eliminar.");
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                MessageBox.Show($"Error al intentar eliminar el tren: {ex.Message}");
            }
        }

        private void eliminarForm5_Load(object sender, EventArgs e)
        {
            
        }
    }
}
