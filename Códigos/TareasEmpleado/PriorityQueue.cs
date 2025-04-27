using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEstructuras.Códigos.TareasEmpleado
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace ProyectoEstructuras.Códigos.TareasEmpleado
    {
        public class PriorityQueue<T>
        {
            private List<(T Elemento, int Prioridad)> elementos;

            public PriorityQueue()
            {
                elementos = new List<(T, int)>();
            }

            public void Enqueue(T elemento, int prioridad)
            {
                elementos.Add((elemento, prioridad));
                elementos.Sort((x, y) => x.Prioridad.CompareTo(y.Prioridad));
            }

            public T Dequeue()
            {
                if (elementos.Count == 0) throw new InvalidOperationException("La cola está vacía.");
                var elemento = elementos[0].Elemento;
                elementos.RemoveAt(0);
                return elemento;
            }

            public int Count => elementos.Count;
        }
    }

}
