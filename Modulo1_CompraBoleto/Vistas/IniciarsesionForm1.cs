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
    public partial class IniciarsesionForm1 : Form
    {
        public IniciarsesionForm1()
        {
            InitializeComponent();
        }

        private void IniciarsesionForm1_Load(object sender, EventArgs e)
        {

        }

        private void button_Click(object sender, EventArgs e)
        {
            string correo = textBox1.Text;
            string contrasenia = textBox2.Text;

            InicioSesion inicioSesion = new InicioSesion();
            bool inicioExitoso = inicioSesion.IniciarSesion(correo, contrasenia);

            if (inicioExitoso)
            {
                Usuario usuarioActual = inicioSesion.ObtenerUsuarioActual();
                MessageBox.Show($"Inicio de sesión exitoso como {usuarioActual.Rol}.");

                MenúViajesForm2 menuViajesForm = new MenúViajesForm2();
                menuViajesForm.Show();

                this.Hide();
            }
            else
            {
                MessageBox.Show("Correo o contraseña incorrectos. Intente nuevamente.");
            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
