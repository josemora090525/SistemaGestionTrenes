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
        public class PriorityQueue<T, P> where P : IComparable<P>
        {
            private List<(T Elemento, P Prioridad)> elementos;

            public PriorityQueue()
            {
                elementos = new List<(T, P)>();
            }

            public void Enqueue(T elemento, P prioridad)
            {
                elementos.Add((elemento, prioridad));
                elementos.Sort((x, y) => x.Prioridad.CompareTo(y.Prioridad));
            }

            public T Dequeue()
            {
                if (elementos.Count == 0)
                {
                    throw new InvalidOperationException("La cola de prioridad está vacía.");
                }
                var elemento = elementos[0].Elemento;
                elementos.RemoveAt(0);
                return elemento;
            }

            public int Count => elementos.Count;
        }
    }
}
