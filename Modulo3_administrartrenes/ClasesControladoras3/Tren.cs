using ProyectoEstructuras.Códigos.TareasEmpleado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEstructuras.Códigos.Servicio
{
    public abstract class Tren : InterfazID
    {
        private string nombre;
        private string id;
        private int capacidadVagones;
        private int kilometraje;
        private Pila<Vagon> pilaVagones;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Id { get => id; set => id = value; }
        public int Kilometraje { get => kilometraje; set => kilometraje = value; }
        public Pila<Vagon> PilaVagones { get => pilaVagones; set => pilaVagones = value; }
        public int CapacidadVagones { get => capacidadVagones; set => capacidadVagones = value; }

        public Tren(string nombre, string id, int maximoVagones, int kilometraje)
        {
            this.nombre = nombre;
            this.id = id;
            this.capacidadVagones = maximoVagones;
            this.kilometraje = kilometraje;
            this.pilaVagones = new Pila<Vagon>();
        }

        public string GetId()
        {
            return Id;
        }

        public void AgregarVagon(Vagon vagon)
        {
            if (pilaVagones.Tamanio >= pilaVagones.Capacidad)
            {
                Console.WriteLine("La pila de vagones está llena.");
            }
            else
            {
                pilaVagones.Push(vagon);
                Console.WriteLine($"Vagón {vagon.GetId()} agregado al tren {id}.");
            }
        }

        public void EliminarVagon()
        {
            Vagon vagonEliminado = pilaVagones.Pop();
            if (vagonEliminado != null)
            {
                Console.WriteLine($"Vagón {vagonEliminado.GetId()} eliminado del tren {id}.");
            }
            else
            {
                Console.WriteLine($"No hay vagones para eliminar en el tren {id}.");
            }
        }

        public Vagon ObtenerPrimerVagon()
        {
            return pilaVagones.Peek();
        }

        public void MostrarVagones()
        {
            Console.WriteLine($"Vagones del tren {id}:");
            pilaVagones.MostrarElementos();
        }

        public abstract void VerificarNumeroVagones();
    }
}
