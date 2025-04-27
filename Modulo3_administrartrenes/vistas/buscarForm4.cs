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

namespace ProyectoEstructuras.Modulo3_administrartrenes.vistas
{
    public partial class buscarForm4 : Form
    {
        public buscarForm4()
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
                // Capturar los valores ingresados en los campos de texto.
                string nombreBuscado = textBox1.Text.Trim();
                string idBuscado = textBox2.Text.Trim();

                // Validar entrada
                if (string.IsNullOrEmpty(nombreBuscado) && string.IsNullOrEmpty(idBuscado))
                {
                    MessageBox.Show("Por favor, ingrese un nombre o ID del tren para buscar.");
                    return;
                }

                // Buscar tren en la lista estática
                Tren trenEncontrado = Datos.listaTrenes.Buscar(idBuscado);

                if (trenEncontrado != null)
                {
                    // Mostrar detalles del tren en el RichTextBox
                    richTextBox1.Text = $"Tren encontrado:\n" +
                                        $"Nombre: {trenEncontrado.Nombre}\n" +
                                        $"ID: {trenEncontrado.Id}\n" +
                                        $"Capacidad de vagones: {trenEncontrado.CapacidadVagones}\n" +
                                        $"Kilometraje: {trenEncontrado.Kilometraje}\n" 
                                        ;
                }
                else
                {
                    // Mostrar mensaje si no se encuentra el tren
                    richTextBox1.Text = $"No se encontró ningún tren con ID: {idBuscado}.";
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                MessageBox.Show($"Error al buscar tren: {ex.Message}");
            }


        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void buscarForm4_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
