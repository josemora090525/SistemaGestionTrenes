using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEstructuras.Códigos.TareasEmpleado
{
    public class ListaCircular<T> : IEnumerable<T> where T : InterfazID
    {
        private Nodo<T> cabeza;
        private Nodo<T> cola;
        private int tamanio;

        public Nodo<T> Cabeza { get => cabeza; set => cabeza = value; }
        public Nodo<T> Cola { get => cola; set => cola = value; }
        public int Tamanio { get => tamanio; set => tamanio = value; }

        public ListaCircular()
        {
            this.cabeza = null;
            this.cola = null;
            this.tamanio = 0;
        }

        public void Agregar(T nuevo)
        {
            Nodo<T> nuevoNodo = new Nodo<T>(nuevo);

            if (cabeza == null)
            {
                cabeza = nuevoNodo;
                cola = nuevoNodo;
                nuevoNodo.Siguiente = cabeza;
            }
            else
            {
                cola.Siguiente = nuevoNodo;
                nuevoNodo.Siguiente = cabeza;
                cola = nuevoNodo;
            }

            tamanio++;
        }

        public T Buscar(string id)
        {
            if (cabeza == null)
            {
                return default;
            }

            Nodo<T> actual = cabeza;

            do
            {
                if (actual.Elemento.GetId().Trim().Equals(id.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    return actual.Elemento;
                }
                actual = actual.Siguiente;
            } while (actual != cabeza);

            return default;
        }

        public bool Eliminar(string id)
        {
            if (cabeza == null)
            {
                return false;
            }

            Nodo<T> actual = cabeza;
            Nodo<T> anterior = cola;

            do
            {
                if (actual.Elemento.GetId().Equals(id))
                {
                    if (actual == cabeza)
                    {
                        cabeza = cabeza.Siguiente;
                        cola.Siguiente = cabeza;
                    }
                    else if (actual == cola)
                    {
                        cola = anterior;
                        cola.Siguiente = cabeza;
                    }
                    else
                    {
                        anterior.Siguiente = actual.Siguiente;
                    }

                    tamanio--;
                    return true;
                }

                anterior = actual;
                actual = actual.Siguiente;
            } while (actual != cabeza);

            return false;
        }

        public bool Modificar(string id, T nuevoElemento)
        {
            if (cabeza == null)
            {
                return false;
            }

            Nodo<T> actual = cabeza;

            do
            {
                if (actual.Elemento.GetId().Equals(id))
                {
                    actual.Elemento = nuevoElemento;
                    return true;
                }
                actual = actual.Siguiente;
            } while (actual != cabeza);

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (cabeza == null)
            {
                yield break; // Devolver un iterador vacío si la lista está vacía
            }

            Nodo<T> actual = cabeza;
            int elementosCedidos = 0; // Contador para saber cuántos elementos hemos "devuelto"

            // El bucle debe ejecutarse exactamente Tamanio veces para visitar cada nodo una vez
            while (elementosCedidos < tamanio)
            {
                yield return actual.Elemento;
                actual = actual.Siguiente;
                elementosCedidos++;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
