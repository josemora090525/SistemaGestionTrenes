using ProyectoEstructuras.Códigos.TareasEmpleado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEstructuras.Códigos.Servicio
{
    public class VagonCarga : Vagon
    {
        private Pila<Equipaje> pilaEquipaje;
        private double pesoActual;
        private int capacidadMaximaEquipaje;

        public Pila<Equipaje> PilaEquipaje { get => pilaEquipaje; set => pilaEquipaje = value; }
        public double PesoActual { get => pesoActual; set => pesoActual = value; }
        public int CapacidadMaximaEquipaje { get => capacidadMaximaEquipaje; set => capacidadMaximaEquipaje = value; }

        public VagonCarga(string idVagon, int capacidad) : base(idVagon, capacidad)
        {
            this.pilaEquipaje = new Pila<Equipaje>();
            this.pesoActual = 0.0;
            this.capacidadMaximaEquipaje = 2;
        }

        public void AgregarEquipaje(Equipaje equipaje)
        {
            if (PilaEquipaje.Tamanio < CapacidadMaximaEquipaje &&
                (PesoActual + equipaje.Peso <= CapacidadMaximaEquipaje * 80.0))
            {
                PilaEquipaje.Push(equipaje);
                PesoActual += equipaje.Peso;
                Console.WriteLine($"Equipaje agregado al vagón: {equipaje.IdEquipaje}");
            }
            else
            {
                Console.WriteLine("No se puede agregar más equipaje. Capacidad o peso excedido.");
            }
        }

        public Equipaje RetirarEquipaje()
        {
            Equipaje equipaje = PilaEquipaje.Pop();
            if (equipaje != null)
            {
                PesoActual -= equipaje.Peso;
                Console.WriteLine($"Equipaje retirado: {equipaje.IdEquipaje}");
            }
            return equipaje;
        }

        public Equipaje ObtenerEquipaje()
        {
            return PilaEquipaje.Peek();
        }
    }

}
