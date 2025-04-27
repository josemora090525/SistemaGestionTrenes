using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEstructuras.Códigos.TareasEmpleado
{
    public class Pila<T> where T : InterfazID
    {
        private Nodo<T> tope;
        private int tamanio;
        private int capacidad;

        public Nodo<T> Tope { get => tope; set => tope = value; }
        public int Tamanio { get => tamanio; set => tamanio = value; }
        public int Capacidad { get => capacidad; set => capacidad = value; }

        public Pila()
        {
            this.tope = null;
            this.tamanio = 0;
        }

        public void Push(T elemento)
        {
            Nodo<T> nuevoNodo = new Nodo<T>(elemento);
            nuevoNodo.Siguiente = tope;
            tope = nuevoNodo;
            tamanio++;
        }

        public T Pop()
        {
            if (tope == null)
            {
                Console.WriteLine("La pila está vacía.");
                return default;
            }

            T eliminado = tope.Elemento;
            tope = tope.Siguiente;
            tamanio--;
            return eliminado;
        }

        public T Peek()
        {
            if (tope == null)
            {
                Console.WriteLine("La pila está vacía.");
                return default;
            }

            return tope.Elemento;
        }

        public T BuscarPorId(string id)
        {
            Nodo<T> actual = tope;

            while (actual != null)
            {
                if (actual.Elemento.GetId().Equals(id))
                {
                    return actual.Elemento;
                }

                actual = actual.Siguiente;
            }

            return default;
        }

        public bool EliminarPorId(string id)
        {
            if (tope == null)
            {
                Console.WriteLine("La pila está vacía.");
                return false;
            }

            Nodo<T> actual = tope;
            Nodo<T> previo = null;

            while (actual != null)
            {
                if (actual.Elemento.GetId().Equals(id))
                {
                    if (previo == null)
                    {
                        tope = actual.Siguiente;
                    }
                    else
                    {
                        previo.Siguiente = actual.Siguiente;
                    }

                    tamanio--;
                    return true;
                }

                previo = actual;
                actual = actual.Siguiente;
            }

            return false;
        }

        public void MostrarElementos()
        {
            if (tope == null)
            {
                Console.WriteLine("La pila está vacía.");
                return;
            }

            Console.WriteLine("Elementos en la pila:");
            Nodo<T> actual = tope;

            while (actual != null)
            {
                Console.WriteLine("- " + actual.Elemento.GetId());
                actual = actual.Siguiente;
            }
        }

    }
}
