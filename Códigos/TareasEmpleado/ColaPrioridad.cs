using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEstructuras.Códigos.TareasEmpleado
{
    public class ColaPrioridad<T> where T : IComparable<T>, InterfazID
    {
        private T[] elementos;
        private int capacidadMaxima;
        private int cantidadElementos;

        public int CapacidadMaxima { get => capacidadMaxima; set => capacidadMaxima = value; }
        public int CantidadElementos { get => cantidadElementos; set => cantidadElementos = value; }

        public ColaPrioridad(int capacidadMaxima)
        {
            this.capacidadMaxima = capacidadMaxima;
            this.elementos = new T[capacidadMaxima];
            this.cantidadElementos = 0;
        }

        public void Encolar(T elemento)
        {
            if (cantidadElementos >= capacidadMaxima)
            {
                Console.WriteLine("La cola está llena. No se puede agregar más elementos.");
                return;
            }

            int index = cantidadElementos;
            while (index > 0 && elementos[index - 1] != null && elemento.CompareTo(elementos[index - 1]) > 0)
            {
                elementos[index] = elementos[index - 1];
                index--;
            }
            elementos[index] = elemento;
            cantidadElementos++;
        }

        public T Desencolar()
        {
            if (cantidadElementos == 0)
            {
                Console.WriteLine("La cola está vacía.");
                return default;
            }

            T elemento = elementos[0];

            for (int ii = 0; ii < cantidadElementos - 1; ii++)
            {
                elementos[ii] = elementos[ii + 1];
            }

            elementos[cantidadElementos - 1] = default;
            cantidadElementos--;
            return elemento;
        }

        public T BuscarPorId(string id)
        {
            for (int ii = 0; ii < cantidadElementos; ii++)
            {
                if (elementos[ii].GetId().Equals(id))
                {
                    return elementos[ii];
                }
            }

            Console.WriteLine($"Elemento con ID {id} no encontrado.");
            return default;
        }

        public bool EliminarPorId(string id)
        {
            for (int ii = 0; ii < cantidadElementos; ii++)
            {
                if (elementos[ii].GetId().Equals(id))
                {
                    for (int jj = ii; jj < cantidadElementos - 1; jj++)
                    {
                        elementos[jj] = elementos[jj + 1];
                    }

                    cantidadElementos--;
                    Console.WriteLine($"Elemento con ID {id} eliminado.");
                    return true;
                }
            }

            Console.WriteLine($"Elemento con ID {id} no encontrado.");
            return false;
        }

        public void MostrarCola()
        {
            if (cantidadElementos == 0)
            {
                Console.WriteLine("La cola está vacía.");
                return;
            }

            Console.WriteLine("Elementos en la cola:");
            for (int ii = 0; ii < cantidadElementos; ii++)
            {
                Console.WriteLine(elementos[ii]);
            }
        }

    }
}
