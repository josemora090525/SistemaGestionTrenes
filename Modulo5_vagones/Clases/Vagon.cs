using ProyectoEstructuras.Códigos.TareasEmpleado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEstructuras.Códigos.Servicio
{
    public class Vagon : InterfazID
    {
        private string idVagon;
        private int capacidad;

        public string IdVagon { get => idVagon; set => idVagon = value; }
        public int Capacidad { get => capacidad; set => capacidad = value; }

        public Vagon(string idVagon, int capacidad)
        {
            this.idVagon = idVagon;
            this.capacidad = capacidad;
        }

        public string GetId()
        {
            return IdVagon;
        }
    }
}
