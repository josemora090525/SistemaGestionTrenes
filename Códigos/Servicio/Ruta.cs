using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEstructuras.Códigos.Servicio
{
    public class Ruta
    {
        private string idRuta;
        private string origen;
        private string destino;

        public string IdRuta { get => idRuta; set => idRuta = value; }
        public string Origen { get => origen; set => origen = value; }
        public string Destino { get => destino; set => destino = value; }

        public Ruta(string idRuta, string origen, string destino)
        {
            this.idRuta = idRuta;
            this.origen = origen;
            this.destino = destino;
        }
    }
}
