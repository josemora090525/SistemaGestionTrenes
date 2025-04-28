using ProyectoEstructuras.Códigos.Servicio;
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
    public partial class ListaviajesForm3 : Form
    {
        private Estacion _origenViaje;
        private Estacion _destinoViaje;
        private int _distanciaViaje;

        public ListaviajesForm3(Estacion origen, Estacion destino, int distancia)
        {
            InitializeComponent();
            _origenViaje = origen;
            _destinoViaje = destino;
            _distanciaViaje = distancia;

            MaquinaVenta maquina = new MaquinaVenta();
            double precioEstandar = maquina.CalcularPrecio("Estandar", _distanciaViaje);
            double precioEjecutivo = maquina.CalcularPrecio("Ejecutivo", _distanciaViaje);
            double precioPremium = maquina.CalcularPrecio("Premium", _distanciaViaje);
        }

        private void ListaviajesForm3_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MenúViajesForm2 menúViajesForm2 = new MenúViajesForm2();
            menúViajesForm2.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
