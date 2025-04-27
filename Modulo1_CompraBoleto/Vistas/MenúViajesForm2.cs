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

namespace ProyectoEstructuras.Modulo1_CompraBoleto.Vistas
{
    public partial class MenúViajesForm2 : Form
    {
        private List<Ruta> rutasDisponibles;

        private void CargarRutas()
        {
            
            rutasDisponibles = new List<Ruta>
            {
                new Ruta("R001", "A", "B", new DateTime(2025, 4, 27), new DateTime(2025, 4, 27)),
                new Ruta("R002", "A", "C", new DateTime(2025, 4, 28), new DateTime(2025, 4, 28)),
                new Ruta("R003", "B", "F", new DateTime(2025, 4, 29), new DateTime(2025, 4, 29))
            };
        }


        public MenúViajesForm2()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
