using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEstructuras.Códigos.TareasEmpleado
{
    public class Arista 

    {
        private int destino;
        private int distancia;
        private int peso;

        public int Destino { get => destino; set => destino = value; }
        public int Distancia { get => distancia; set => distancia = value; }
        public int Peso { get => peso; set => peso = value; }

        public Arista(int destino, int distancia, int peso)
        {
            this.destino = destino;
            this.distancia = distancia;
            this.peso = peso;
        }

        public override string ToString()
        {
            return $"Arista [Destino: {Destino}, Distancia: {Distancia} km]";
        }

        public int CompareTo(Arista otra)
        {
            return this.Distancia.CompareTo(otra.Distancia);
        }
    }
}
