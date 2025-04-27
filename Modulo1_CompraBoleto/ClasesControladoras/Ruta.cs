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
        private string idRuta;
        private string origen;
        private string destino;
        private DateTime fechasalida;
        private DateTime fechallegada;

        public string IdRuta { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public DateTime FechaSalida { get; set; }
        public DateTime FechaLlegada { get; set; }

        public Ruta(string idRuta, string origen, string destino, DateTime fechaSalida, DateTime fechaLlegada)
        {
            IdRuta = idRuta;
            Origen = origen;
            Destino = destino;
            FechaSalida = fechaSalida;
            FechaLlegada = fechaLlegada;
        }

    }
}
