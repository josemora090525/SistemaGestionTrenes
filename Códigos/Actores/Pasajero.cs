using ProyectoEstructuras.Códigos.TareasEmpleado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProyectoEstructuras.Códigos.Actores
{
    public class Pasajero: Usuario, IComparable<Pasajero>, InterfazPrioridad, InterfazID

    {
        private string prioridad;
        private int numeroAsiento;

        public string Prioridad { get => prioridad; set => prioridad = value; }
        public int NumeroAsiento { get => numeroAsiento; set => numeroAsiento = value; }

        public string GetPrioridad() { return Prioridad; }
        public string GetId() { return Identificacion; }

        public Pasajero(string nombre, string apellidos, string telefono, string identificacion, string correo, string contrasenia, string rol, string prioridad, int numeroAsiento)
            : base(nombre, apellidos, telefono, identificacion, correo, contrasenia, rol)
        {
            this.Prioridad = prioridad;
            this.NumeroAsiento = numeroAsiento;
        }


        public int CompareTo(Pasajero otro)
        {
            List<string> ordenPrioridades = new List<string> { "premium", "ejecutivo", "estándar" };

            int thisIndex = ordenPrioridades.IndexOf(this.Prioridad.ToLower());
            int otroIndex = ordenPrioridades.IndexOf(otro.Prioridad.ToLower());

            return thisIndex.CompareTo(otroIndex);
        }

        public override string ToString()
        {
            return $"Pasajero{{prioridad={Prioridad}, numeroAsiento={NumeroAsiento}}}";
        }

    }
}
