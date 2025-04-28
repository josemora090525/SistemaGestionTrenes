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
    public partial class AgregarForm3 : Form
    {
        public AgregarForm3()
        {
            InitializeComponent();
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

        private void button2_Click(object sender, EventArgs e)
        {
            string nombre = textBox1.Text.Trim();
            string idRuta = textBox2.Text.Trim();
            string origen = textBox3.Text.Trim();
            string destino = textBox4.Text.Trim();

            // En lugar de DateTime, obtener las fechas como string fijo
            string fechaSalida = textBox5.Text.Trim();
            string fechaLlegada = textBox6.Text.Trim();

            // Validar que todos los campos estén completos.
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(idRuta) ||
                string.IsNullOrEmpty(origen) || string.IsNullOrEmpty(destino) ||
                string.IsNullOrEmpty(fechaSalida) || string.IsNullOrEmpty(fechaLlegada))
            {
                MessageBox.Show("Debe completar todos los campos.");
                return;
            }

            // (Opcional) Verificar que las fechas no sean iguales.
            if (fechaSalida.Equals(fechaLlegada, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("La fecha de salida y la de llegada no pueden ser iguales. Ingrese valores distintos.");
                return;
            }

            // Verificar si ya existe una ruta con el mismo ID en la tabla hash.
            Ruta rutaExistente = Datos.tablaRutas.BuscarValores(idRuta);
            if (rutaExistente != null)
            {
                MessageBox.Show("Ya existe una ruta con el mismo ID.");
                return;
            }

            // Crear la nueva instancia de Ruta utilizando las cadenas fijas.
            Ruta nuevaRuta = new Ruta(nombre, idRuta, origen, destino, fechaSalida, fechaLlegada);

            // Insertar la nueva ruta en la tabla hash utilizando el ID como clave.
            Datos.tablaRutas.InsertarValores(idRuta, nuevaRuta);

            MessageBox.Show("Ruta agregada exitosamente.");

            // (Opcional) Limpiar los controles para agregar otra ruta.
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
