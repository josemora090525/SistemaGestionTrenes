using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoEstructuras.Modulo5_vagones.Vistas
{
    public partial class menuForm2 : Form
    {
        public menuForm2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            iniciarsesion5Form1 form = new iniciarsesion5Form1();
            form.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            agregarForm3 form = new agregarForm3();
            form.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            buscarForm4 form = new buscarForm4();
            form.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            eliminarForm5 form = new eliminarForm5();
            form.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            mostrarForm6 form = new mostrarForm6();
            form.Show();
            this.Hide();
        }
    }
}
