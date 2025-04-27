using ProyectoEstructuras.Códigos.Actores;
using ProyectoEstructuras.Códigos.TareasEmpleado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEstructuras.Códigos.Servicio
{
    public class VagonPasajeros : Vagon
    { 
        private int premium;
        private int ejecutivo;
        private int estandar;
        private int pilotos;
        private int personal;
        private ColaPrioridad<Pasajero> colaAbordaje = new ColaPrioridad<Pasajero>(40);
        private int asientos;

        public int Premium { get => premium; set => premium = value; }
        public int Ejecutivo { get => ejecutivo; set => ejecutivo = value; }
        public int Estandar { get => estandar; set => estandar = value; }
        public int Pilotos { get => pilotos; set => pilotos = value; }
        public int Personal { get => personal; set => personal = value; }
        public ColaPrioridad<Pasajero> ColaAbordaje { get => colaAbordaje; set => colaAbordaje = value; }
        public int Asientos { get => asientos; set => asientos = value; }

        public VagonPasajeros(string idVagon, int capacidad) : base(idVagon, capacidad)
        {
            this.premium = 4;
            this.ejecutivo = 8;
            this.estandar = 22;
            this.pilotos = 2;
            this.personal = 4;
        }

        public void AbordarPasajeros(Pasajero pasajero)
        {
            if (ColaAbordaje.CantidadElementos >= Capacidad)
            {
                Console.WriteLine("El vagón está lleno. No se puede agregar más pasajeros.");
                return;
            }
            ColaAbordaje.Encolar(pasajero);
        }

        public void AsignarAsientos()
        {
            int asientoActual = 1;
            Pasajero pasajero;

            while ((pasajero = ColaAbordaje.Desencolar()) != null)
            {
                pasajero.NumeroAsiento = asientoActual++;
                Console.WriteLine($"Pasajero {pasajero.Nombre} asignado al asiento {pasajero.NumeroAsiento}");
            }
        }

        public void DesencolarPasajero()
        {
            Pasajero pasajero = ColaAbordaje.Desencolar();
            if (pasajero != null)
            {
                Console.WriteLine($"Pasajero desencolado: {pasajero.Nombre}");
            }
        }

        public void MostrarPasajeros()
        {
            Console.WriteLine("Lista de pasajeros en la cola de abordaje:");
            ColaAbordaje.MostrarCola();
        }

        public void MostrarOrdenAbordaje()
        {
            Console.WriteLine("Orden de abordaje para el vagón:");
            while (ColaAbordaje.CantidadElementos > 0)
            {
                Pasajero pasajero = ColaAbordaje.Desencolar();
                Console.WriteLine($"    {pasajero.Nombre} - Prioridad: {pasajero.Prioridad}");
            }
        }
    }

}
