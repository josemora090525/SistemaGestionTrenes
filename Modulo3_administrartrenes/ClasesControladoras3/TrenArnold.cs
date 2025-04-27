using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEstructuras.Códigos.Servicio
{
    public class TrenArnold : Tren
    {
        public TrenArnold(string nombre, string id, int capacidadCarga, int kilometraje)
        : base(nombre, id, 32, kilometraje) 
        {
        }

        public override void VerificarNumeroVagones()
        {
            if (PilaVagones.Tamanio > 32)
            {
                Console.WriteLine($"Error: El número de vagones excede el límite permitido (32) para TrenArnold.");
            }
            else
            {
                Console.WriteLine($"Número de vagones correcto: {PilaVagones.Tamanio} vagones en el tren.");
            }
        }


    }

}
