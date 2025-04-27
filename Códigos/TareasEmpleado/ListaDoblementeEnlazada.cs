using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEstructuras.Códigos.TareasEmpleado
{
    public class ListaDoblementeEnlazada<T> : IEnumerable<T> where T : InterfazID
    {
        private Nodo<T> cabeza;
        private Nodo<T> cola;
        private int tamanio;

        public Nodo<T> Cabeza { get => cabeza; set => cabeza = value; }
        public Nodo<T> Cola { get => cola; set => cola = value; }
        public int Tamanio { get => tamanio; set => tamanio = value; }

        public ListaDoblementeEnlazada()
        {
            this.cabeza = null;
            this.cola = null;
            this.tamanio = 0;
        }
        public void AgregarAlFinal(T elemento)
        {
            Nodo<T> nuevoNodo = new Nodo<T>(elemento);

            if (cabeza == null)
            {
                cabeza = nuevoNodo;
                cola = nuevoNodo;
            }
            else
            {
                cola.Siguiente = nuevoNodo;
                nuevoNodo.Anterior = cola;
                cola = nuevoNodo;
            }

            tamanio++;
        }

        public void AgregarAlInicio(T elemento)
        {
            Nodo<T> nuevoNodo = new Nodo<T>(elemento);

            if (cabeza == null)
            {
                cabeza = nuevoNodo;
                cola = nuevoNodo;
            }
            else
            {
                nuevoNodo.Siguiente = cabeza;
                cabeza.Anterior = nuevoNodo;
                cabeza = nuevoNodo;
            }

            tamanio++;
        }

        public bool Eliminar(string id)
        {
            if (cabeza == null)
            {
                return false;
            }

            Nodo<T> actual = cabeza;

            while (actual != null)
            {
                if (actual.Elemento.GetId().Equals(id))
                {
                    if (actual == cabeza)
                    {
                        cabeza = cabeza.Siguiente;
                        if (cabeza != null)
                        {
                            cabeza.Anterior = null;
                        }
                        else
                        {
                            cola = null;
                        }
                    }
                    else if (actual == cola)
                    {
                        cola = cola.Anterior;
                        if (cola != null)
                        {
                            cola.Siguiente = null;
                        }
                    }
                    else
                    {
                        actual.Anterior.Siguiente = actual.Siguiente;
                        actual.Siguiente.Anterior = actual.Anterior;
                    }

                    tamanio--;
                    return true;
                }

                actual = actual.Siguiente;
            }

            return false;
        }

        public T Buscar(string id)
        {
            Nodo<T> actual = cabeza;

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

        public void MostrarElementos()
        {
            foreach (T elemento in this)
            {
                Console.WriteLine(elemento);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Nodo<T> actual = cabeza;

            while (actual != null)
            {
                yield return actual.Elemento;
                actual = actual.Siguiente;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
