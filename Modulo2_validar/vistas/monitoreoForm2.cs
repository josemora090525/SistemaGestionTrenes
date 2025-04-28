using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoEstructuras.Modulo2_validar.vistas
{
    public partial class monitoreoForm2 : Form
    {
        public monitoreoForm2()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            iniciarSesion2Form1 iniciarSesion = new iniciarSesion2Form1();
            iniciarSesion.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            verificarboletosForm3 verificarBoletos = new verificarboletosForm3();
            verificarBoletos.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            controlequipajeForm5 controlEquipaje = new controlequipajeForm5();
            controlEquipaje.Show();
            this.Hide();
        }
    }
}
