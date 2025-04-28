using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEstructuras.Códigos.TareasAdministrador
{
    public class TablaHash<K, V>
    {
        private int tamanio;
        private K[] claves;
        private V[] valores;

        public int Tamanio { get => tamanio; set => tamanio = value; }

        public TablaHash(int tamanio)
        {
            this.tamanio = tamanio;
            claves = new K[tamanio];
            valores = new V[tamanio];
        }

        private int HashFunction(K clave)
        {
            int hashCode = clave.GetHashCode();
            return Math.Abs(hashCode % tamanio);
        }

        public bool ContieneClave(K clave)
        {
            int indice = HashFunction(clave);

            while (claves[indice] != null)
            {
                if (claves[indice].Equals(clave))
                {
                    return true;
                }
                indice = (indice + 1) % tamanio;
            }

            return false;
        }

        public List<K> ObtenerClaves()
        {
            List<K> listaClaves = new List<K>();

            foreach (K clave in claves)
            {
                if (clave != null)
                {
                    listaClaves.Add(clave);
                }
            }

            return listaClaves;
        }

        public void InsertarValores(K clave, V valor)
        {
            if (ContieneClave(clave))
            {
                Console.WriteLine($"Clave ya existente: {clave}");
                return;
            }

            int indice = HashFunction(clave);

            while (claves[indice] != null && !claves[indice].Equals(clave))
            {
                indice = (indice + 1) % tamanio;
            }

            claves[indice] = clave;
            valores[indice] = valor;

            Console.WriteLine($"Valor insertado: Clave={clave}, Valor={valor}");
        }

        public V BuscarValores(K clave)
        {
            int indice = HashFunction(clave);

            while (claves[indice] != null)
            {
                if (claves[indice].Equals(clave))
                {
                    Console.WriteLine($"Valor encontrado para clave {clave}: {valores[indice]}");
                    return valores[indice];
                }
                indice = (indice + 1) % tamanio;
            }

            Console.WriteLine($"Clave {clave} no encontrada.");
            return default;
        }

        public void EliminarValores(K clave)
        {
            int indice = HashFunction(clave);

            while (claves[indice] != null)
            {
                if (claves[indice].Equals(clave))
                {
                    claves[indice] = default;
                    valores[indice] = default;
                    Console.WriteLine($"Clave eliminada: {clave}");
                    return;
                }
                indice = (indice + 1) % tamanio;
            }

            Console.WriteLine($"Clave {clave} no encontrada.");
        }

        public void MostrarValores()
        {
            Console.WriteLine("Contenido de la tabla hash:");
            for (int ii = 0; ii < tamanio; ii++)
            {
                if (claves[ii] != null)
                {
                    Console.WriteLine($"Índice {ii}: Clave={claves[ii]}, Valor={valores[ii]}");
                }
            }
        }

        public bool Modificar(K clave, V nuevoValor)
        {
            int indice = HashFunction(clave);

            while (claves[indice] != null)
            {
                if (claves[indice].Equals(clave))
                {
                    valores[indice] = nuevoValor;
                    Console.WriteLine($"Valor modificado: Clave={clave}, Nuevo Valor={nuevoValor}");
                    return true;
                }
                indice = (indice + 1) % tamanio;
            }

            Console.WriteLine($"Clave {clave} no encontrada para modificar.");
            return false;
        }

        public List<V> GetAllValues()
        {
            List<V> listaValores = new List<V>();

            // Iterar a través del arreglo interno de valores
            for (int ii = 0; ii < tamanio; ii++) // 'tamanio' es el tamaño del arreglo
            {
                // Verificar si hay un elemento válido en este índice
                // Tanto la clave como el valor deben ser no nulos si usas borrado perezoso o si la posición nunca se usó
                if (claves[ii] != null && valores[ii] != null)
                {
                    listaValores.Add(valores[ii]); // Añadir el valor a la lista
                }
            }
            return listaValores; // Devolver la lista de todos los valores encontrados
        }

        public K GetKeyByValue(V value)
        {
            // Considerar cómo manejar valores nulos si es posible
            if (value == null)
            {
                Console.WriteLine("DEBUG GetKeyByValue: Intento de buscar con valor nulo.");
                return default(K); // El valor por defecto para K
            }

            // Iterar a través del arreglo interno de valores
            for (int ii = 0; ii < tamanio; ii++)
            {
                // Verificar si la posición está ocupada (clave no nula)
                // Y si el valor almacenado en esa posición coincide con el valor buscado.
                // Usar Equals para comparar valores.
                if (claves[ii] != null && valores[ii] != null && valores[ii].Equals(value))
                {
                    Console.WriteLine($"DEBUG GetKeyByValue: Valor encontrado en índice {ii}. Devolviendo clave: {claves[ii]}");
                    return claves[ii]; // Devolver la clave en este índice
                }
                // Si el valor en la posición es null, pero el valor buscado es null, también podría coincidir.
                // if (claves[i] != null && valores[i] == null && value == null) { return claves[i]; } // Si necesitas manejar valores nulos
            }

            // Si el valor no fue encontrado después de recorrer todo el arreglo
            Console.WriteLine($"DEBUG GetKeyByValue: Valor no encontrado en la tabla hash: {value}");
            return default(K); // Devolver el valor por defecto para K si el valor no se encuentra
        }
    }
}
