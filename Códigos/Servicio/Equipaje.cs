using ProyectoEstructuras.Códigos.TareasEmpleado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEstructuras.Códigos.Servicio
{
    public class Equipaje : InterfazID
    { 
        private string idEquipaje;
        private string idPasajero;
        private double peso;
        private string idVagonCarga;
        private const double MAXIMO_PESO = 80.0;

        public string IdEquipaje { get => idEquipaje; set => idEquipaje = value; }
        public string IdPasajero { get => idPasajero; set => idPasajero = value; }
        public double Peso { get => peso; set => peso = ValidarPeso(value); }
        public string IdVagonCarga { get => idVagonCarga; set => idVagonCarga = value; }

        public Equipaje(string idEquipaje, string idPasajero, double peso, string idVagonCarga)
        {
            this.idEquipaje = idEquipaje;
            this.idPasajero = idPasajero;
            this.peso = ValidarPeso(peso);
            this.idVagonCarga = idVagonCarga;
        }

        private static double ValidarPeso(double peso)
        {
            if (peso > MAXIMO_PESO)
            {
                Console.WriteLine($"El peso excede el máximo permitido ({MAXIMO_PESO} kg). Ajustando al máximo permitido.");
                return MAXIMO_PESO;
            }
            return peso;
        }

        public string GetId()
        {
            return IdEquipaje;
        }
    }

}
