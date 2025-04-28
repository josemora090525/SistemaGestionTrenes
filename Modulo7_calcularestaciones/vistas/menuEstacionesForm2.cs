using ProyectoEstructuras.Modulo10_calculoestaciones.vistas;
using ProyectoEstructuras.Modulo7_calculoestaciones.vistas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoEstructuras.Modulo7_calcularestaciones.vistas
{
    public partial class menuEstacionesForm2 : Form
    {
        public menuEstacionesForm2()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            iniciarSesion7Form1 iniciarSesion = new iniciarSesion7Form1();
            iniciarSesion.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            calculopasajeForm7 calculoPasaje = new calculopasajeForm7();
            calculoPasaje.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            crearestacionesForm13 crearEstaciones = new crearestacionesForm13();
            crearEstaciones.Show();
            this.Hide();
        }
    }
}
