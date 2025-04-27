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

        }
    }
