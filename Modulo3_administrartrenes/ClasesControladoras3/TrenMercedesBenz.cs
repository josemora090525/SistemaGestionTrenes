using ProyectoEstructuras.Códigos.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEstructuras.Modulo3_administrartrenes.ClasesControladoras3
{
    public class TrenMercedesBenz : Tren
    {
        public TrenMercedesBenz(string nombre, string id, int capacidadCarga, int kilometraje)
            : base(nombre, id, 28, kilometraje) 
        {
        }

        public override void VerificarNumeroVagones()
        {
            if (PilaVagones.Tamanio > 28) 
            {
                Console.WriteLine($"Error: El número de vagones excede el límite permitido (28) para TrenMercedesBenz.");
            }
            else
            {
                Console.WriteLine($"Número de vagones correcto: {PilaVagones.Tamanio} vagones en el tren.");
            }
        }
    }

}
