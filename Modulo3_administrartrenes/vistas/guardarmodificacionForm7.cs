using ProyectoEstructuras.Códigos.Servicio;
using ProyectoEstructuras.Modulo3_administrartrenes.ClasesControladoras3;
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
    public partial class guardarmodificacionForm7 : Form
    {
        public guardarmodificacionForm7()
        {
            InitializeComponent();
        }

        private void guardarmodificacionForm7_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear(); // Limpia cualquier valor previo en el ComboBox
            comboBox1.Items.Add("Arnold");
            comboBox1.Items.Add("MercedesBenz");

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            modificartrenForm1 formM = new modificartrenForm1();

            // Muestra el formulario anterior.
            formM.Show();

            // Cierra o esconde el formulario actual.
            this.Close(); // O this.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Capturar los datos ingresados por el usuario
                string nuevoId = textBox2.Text.Trim(); // Nuevo identificador
                string nuevoNombre = textBox1.Text.Trim(); // Nuevo nombre del tren
                int nuevaCapacidad = int.Parse(textBox3.Text); // Nueva capacidad
                int nuevoKilometraje = int.Parse(textBox4.Text); // Nuevo kilometraje

                // Validar entradas
                if (string.IsNullOrEmpty(nuevoId))
                {
                    MessageBox.Show("Por favor, ingrese un nuevo ID para el tren.");
                    return;
                }

                if (string.IsNullOrEmpty(nuevoNombre))
                {
                    MessageBox.Show("Por favor, ingrese un nuevo nombre para el tren.");
                    return;
                }

                // Crear una instancia del tren según el tipo seleccionado
                string tipoTren = comboBox1.SelectedItem?.ToString(); // Tipo de tren desde el ComboBox
                Tren trenModificado;

                if (tipoTren == "Arnold")
                {
                    trenModificado = new TrenArnold(
                        nuevoNombre,
                        nuevoId,
                        nuevaCapacidad,
                        nuevoKilometraje
                    );
                }
                else if (tipoTren == "MercedesBenz")
                {
                    trenModificado = new TrenMercedesBenz(
                        nuevoNombre,
                        nuevoId,
                        nuevaCapacidad,
                        nuevoKilometraje
                    );
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione un tipo de tren válido.");
                    return;
                }

                // Intentar agregar el tren modificado a la lista circular
                Datos.listaTrenes.Agregar(trenModificado);
                MessageBox.Show("El tren ha sido modificado y agregado con el nuevo ID correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}");
            }
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.SelectedIndex = -1;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
