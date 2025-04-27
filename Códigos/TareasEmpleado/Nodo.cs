using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEstructuras.Códigos.TareasEmpleado
{
    public class Nodo<T>
    {
        private T elemento;
        private Nodo<T> siguiente;
        private Nodo<T> anterior;

        public T Elemento { get => elemento; set => elemento = value; }
        public Nodo<T> Siguiente { get => siguiente; set => siguiente = value; }
        public Nodo<T> Anterior { get => anterior; set => anterior = value; }

        public Nodo(T elemento)
        {
            this.Elemento = elemento;
            this.Siguiente = null;
            this.Anterior = null;
        }
    }
}
