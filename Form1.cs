using ProyectoEstructuras.Modulo1_CompraBoleto.Vistas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoEstructuras
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IniciarsesionForm1 iniciarSesion = new IniciarsesionForm1();
            iniciarSesion.Show();
            this.Hide();
        }
    }
}
