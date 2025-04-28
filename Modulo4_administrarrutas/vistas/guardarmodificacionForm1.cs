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
    public partial class guardarmodificacionForm1 : Form
    {
        public guardarmodificacionForm1()
        {
            InitializeComponent();

        }

        private void guardarmodificacionForm1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ModificarForm1 modificarForm1 = new ModificarForm1();
            modificarForm1.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }        

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Capturar los datos ingresados por el usuario.
                string nuevoId = textBox2.Text.Trim(); // Nuevo identificador de la ruta.
                string nuevoNombre = textBox1.Text.Trim(); // Nuevo nombre de la ruta.
                string nuevoOrigen = textBox3.Text.Trim(); // Origen de la ruta.
                string nuevoDestino = textBox4.Text.Trim(); // Destino de la ruta.
                string fechaSalida = textBox5.Text.Trim(); // Fecha de salida (como cadena).
                string fechaLlegada = textBox6.Text.Trim(); // Fecha de llegada (como cadena).

                // Validar que ninguno de los campos esté vacío.
                if (string.IsNullOrEmpty(nuevoId))
                {
                    MessageBox.Show("Por favor, ingrese un nuevo ID para la ruta.");
                    return;
                }
                if (string.IsNullOrEmpty(nuevoNombre))
                {
                    MessageBox.Show("Por favor, ingrese un nuevo nombre para la ruta.");
                    return;
                }
                if (string.IsNullOrEmpty(nuevoOrigen))
                {
                    MessageBox.Show("Por favor, ingrese el origen para la ruta.");
                    return;
                }
                if (string.IsNullOrEmpty(nuevoDestino))
                {
                    MessageBox.Show("Por favor, ingrese el destino para la ruta.");
                    return;
                }
                if (string.IsNullOrEmpty(fechaSalida))
                {
                    MessageBox.Show("Por favor, ingrese la fecha de salida para la ruta.");
                    return;
                }
                if (string.IsNullOrEmpty(fechaLlegada))
                {
                    MessageBox.Show("Por favor, ingrese la fecha de llegada para la ruta.");
                    return;
                }

                // (Opcional) Verificar que las fechas no sean iguales.
                if (fechaSalida.Equals(fechaLlegada, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("La fecha de salida y la de llegada no pueden ser iguales.");
                    return;
                }

                // Crear la nueva instancia de Ruta.
                // Se asume que el constructor de Ruta es similar a:
                // public Ruta(string nombre, string idRuta, string origen, string destino, string fechaSalida, string fechaLlegada)
                Ruta rutaModificada = new Ruta(nuevoNombre, nuevoId, nuevoOrigen, nuevoDestino, fechaSalida, fechaLlegada);

                // Insertar la nueva ruta en la tabla hash utilizando el nuevo ID como clave.
                Datos.tablaRutas.InsertarValores(nuevoId, rutaModificada);

                MessageBox.Show("La ruta se ha modificado con el nuevo ID correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}");
            }

        }
    }
}
