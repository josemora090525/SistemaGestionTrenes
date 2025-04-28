using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoEstructuras.Modulo6_gestionusuarios.Vistas
{
    public partial class menuForm2 : Form
    {
        public menuForm2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            iniciarsesion6Form1 form = new iniciarsesion6Form1();
            form.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            agregarUsuarioForm3 form = new agregarUsuarioForm3();
            form.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            buscarusersForm4 form = new buscarusersForm4();
            form.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            eliminaruserForm5 form = new eliminaruserForm5();
            form.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MostraruserForm6 form = new MostraruserForm6();
            form.Show();
            this.Hide();
        }
    }
}
