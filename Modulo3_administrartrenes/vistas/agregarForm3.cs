using ProyectoEstructuras.Códigos.Servicio;
using ProyectoEstructuras.Códigos.TareasEmpleado;
using ProyectoEstructuras.Modulo3_administrartrenes.ClasesControladoras3;
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
    public partial class agregarForm3 : Form
    {
        public agregarForm3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Crea una nueva instancia del formulario anterior (por ejemplo, menuForm2).
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        public static ListaCircular<Tren> listaTrenes = new ListaCircular<Tren>();

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Capturar valores desde los controles del formulario.
                string nombre = textBox1.Text; // Nombre del tren
                string id = textBox2.Text; // Identificador del tren
                string tipoTren = comboBox1.SelectedItem?.ToString(); // Tipo de tren desde el comboBox
                int capacidadCarga = int.Parse(textBox3.Text); // Capacidad de carga
                int kilometraje = int.Parse(textBox4.Text); // Kilometraje

                // Verificar que se haya seleccionado un tipo de tren.
                if (string.IsNullOrEmpty(tipoTren))
                {
                    MessageBox.Show("Por favor, seleccione un tipo de tren.");
                    return;
                }

                // Crear instancia de tren según el tipo seleccionado.
                Tren tren;
                if (tipoTren == "Arnold")
                {
                    tren = new TrenArnold(nombre, id, capacidadCarga, kilometraje);
                }
                else if (tipoTren == "MercedesBenz")
                {
                    tren = new TrenMercedesBenz(nombre, id, capacidadCarga, kilometraje);
                }
                else
                {
                    MessageBox.Show("Seleccione un tipo de tren válido.");
                    return;
                }

                // Agregar el tren a la lista central de Datos.
                Datos.listaTrenes.Agregar(tren);

                // Mostrar un mensaje de confirmación con los datos del tren creado.
                MessageBox.Show($"Tren creado y agregado al sistema:\nNombre: {tren.Nombre}\nID: {tren.Id}\nTipo: {tipoTren}\nCapacidad: {tren.CapacidadVagones}\nKilometraje: {tren.Kilometraje}");

                // Opcional: Actualizar alguna lista visual o tabla en el formulario si corresponde.
            }
            catch (Exception ex)
            {
                // Manejo de errores (por ejemplo, formato inválido en los TextBoxes).
                MessageBox.Show($"Error al crear el tren: {ex.Message}");
            }
        }


        private void agregarForm3_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear(); // Limpia cualquier valor previo en el ComboBox.
            comboBox1.Items.Add("Arnold");
            comboBox1.Items.Add("MercedesBenz");

        }
    }
}
