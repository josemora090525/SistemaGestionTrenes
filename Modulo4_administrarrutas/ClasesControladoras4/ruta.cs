using ProyectoEstructuras.Códigos.TareasEmpleado;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEstructuras.Modulo1_CompraBoleto.ClasesControladoras
{
    public class Ruta 
    {
        private string nombre;
        private string idRuta;
        private string origen;
        private string destino;
        private string fechaSalida;
        private string fechaLlegada;

        public string IdRuta { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public string FechaSalida { get; set; }
        public string FechaLlegada { get; set; }
        public string Nombre { get => nombre; set => nombre = value; }

        public Ruta(string nombre, string idRuta, string origen, string destino, string fechaSalida, string fechaLlegada)
        {
            Nombre = nombre;
            IdRuta = idRuta;
            Origen = origen;
            Destino = destino;
            FechaSalida = fechaSalida;
            FechaLlegada = fechaLlegada;
        }
    }

}
