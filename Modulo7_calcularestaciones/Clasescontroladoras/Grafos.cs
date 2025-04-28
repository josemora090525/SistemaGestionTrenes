using System;
using System.Collections.Generic;
using ProyectoEstructuras.Códigos.Servicio; 
using ProyectoEstructuras.Códigos.TareasAdministrador;
using ProyectoEstructuras.Códigos.TareasEmpleado.ProyectoEstructuras.Códigos.TareasEmpleado;
namespace ProyectoEstructuras.Códigos.TareasEmpleado 
{
    public class Grafos<T> 
    {
        
        private TablaHash<T, int> nodos; // Cambiado de 'estaciones' a 'nodos' para generalidad
        private List<List<Arista>> listaAdyacencia; // La lista de adyacencia almacena Aristas (aristas/bordes) usando índices
        // Propiedades públicas para acceder a la estructura del grafo
        public TablaHash<T, int> Nodos { get => nodos; set => nodos = value; } // Acceso público al mapeo nodo -> índice
        public List<List<Arista>> ListaAdyacencia { get => listaAdyacencia; set => listaAdyacencia = value; } // Acceso público a la lista de adyacencia
        // Constructor
        // La capacidad inicial es principalmente para la TablaHash. La lista de adyacencia crece dinámicamente.
        public Grafos(int capacidadInicial) // Cambiado el nombre del parámetro
        {
            this.Nodos = new TablaHash<T, int>(capacidadInicial); // Inicializa la tabla hash para los nodos
            this.ListaAdyacencia = new List<List<Arista>>(); // Inicializa la estructura de la lista de adyacencia (vacía inicialmente)
            // Las listas de adyacencia para cada nodo se añadirán en el método AgregarNodo.
        }

        // Método para agregar un nodo al grafo
        public void AgregarNodo(T nodo) // Ahora acepta un nodo de tipo TNode
        {
            if (nodo == null)
            {
                // No se pueden agregar nodos nulos
                Console.WriteLine("Intento de agregar nodo nulo."); // Depuración
                return;
            }
            // Usa la tabla hash para verificar si el nodo (clave) ya existe.
            if (!Nodos.ContieneClave(nodo))
            {
                // Si el nodo es nuevo, agrégalo a la tabla hash.
                // El valor asociado es el siguiente índice disponible en la lista de adyacencia.
                int nuevoIndice = ListaAdyacencia.Count;
                Nodos.InsertarValores(nodo, nuevoIndice);

                // Añade una lista vacía a la lista de adyacencia para este nuevo nodo.
                ListaAdyacencia.Add(new List<Arista>());

                Console.WriteLine($"Nodo agregado. Total nodos ahora: {ListaAdyacencia.Count}"); 
            }
            else
            {
                Console.WriteLine($"El nodo ya existe, no se agrega de nuevo."); 
            }
        }
        // Método auxiliar para obtener el índice entero asociado a un nodo
        // Útil para interactuar con la lista de adyacencia.
        public int GetIndiceNodo(T nodo)
        {
            // Usa la tabla hash para encontrar el índice asociado al nodo.
            if (Nodos.ContieneClave(nodo))
            {
                return Nodos.BuscarValores(nodo); // BuscarValores devuelve el índice si lo encuentra.
            }
            Console.WriteLine($"Nodo '{nodo}' no encontrado."); 
            return -1;
        }

        public void AgregarAristaDirigida(T origen, T destino, int peso) 
        {

            if (!Nodos.ContieneClave(origen) || !Nodos.ContieneClave(destino))
            {
                Console.WriteLine($"DEBUG Grafos<TNode>.AgregarAristaDirigida: Origen o destino no encontrados al intentar agregar arista."); // Depuración
                return;
            }
            // Obtiene los índices de los nodos origen y destino
            int indiceOrigen = GetIndiceNodo(origen);
            int indiceDestino = GetIndiceNodo(destino);

            if (indiceOrigen >= 0 && indiceOrigen < ListaAdyacencia.Count && indiceDestino >= 0 && indiceDestino < ListaAdyacencia.Count)
            {
                // Añade la arista a la lista de adyacencia del índice del nodo origen.
                ListaAdyacencia[indiceOrigen].Add(new Arista(indiceDestino, peso, 1));
                Console.WriteLine($"DEBUG Grafos<TNode>.AgregarAristaDirigida: Arista agregada de índice {indiceOrigen} a {indiceDestino} con peso {peso}."); // Depuración
            }
            else
            {
                Console.WriteLine($"DEBUG Grafos<TNode>.AgregarAristaDirigida: Índices de origen o destino inválidos ({indiceOrigen}, {indiceDestino}) después de ContieneClave."); // Depuración
            }
        }

        public void AgregarAristaNoDirigida(T origen, T destino, int peso) // Cambiado 'distancia' a 'peso'
        {
            // Verifica si ambos nodos existen
            if (!Nodos.ContieneClave(origen) || !Nodos.ContieneClave(destino))
            {
                Console.WriteLine($"DEBUG Grafos<TNode>.AgregarAristaNoDirigida: Origen o destino no encontrados al intentar agregar arista."); // Depuración
                return;
            }

            int indiceOrigen = GetIndiceNodo(origen);
            int indiceDestino = GetIndiceNodo(destino);

            if (indiceOrigen >= 0 && indiceOrigen < ListaAdyacencia.Count && indiceDestino >= 0 && indiceDestino < ListaAdyacencia.Count)
            {
                // Añade aristas en ambas direcciones para un grafo no dirigido.
                ListaAdyacencia[indiceOrigen].Add(new Arista(indiceDestino, peso, 1)); // Arista de origen a destino
                ListaAdyacencia[indiceDestino].Add(new Arista(indiceOrigen, peso, 1)); // Arista de destino a origen
                Console.WriteLine($"DEBUG Grafos<TNode>.AgregarAristaNoDirigida: Arista(s) agregada(s) entre índices {indiceOrigen} y {indiceDestino} con peso {peso}."); // Depuración
            }
            else
            {
                Console.WriteLine($"DEBUG Grafos<TNode>.AgregarAristaNoDirigida: Índices de origen o destino inválidos ({indiceOrigen}, {indiceDestino}) después de ContieneClave."); // Depuración
            }
        }

        // Algoritmo de Dijkstra - opera en índices, devuelve distancias indexadas por índice
        public List<int> AplicarDijkstra(T nodoOrigen)
        {
            // Verifica si el nodo origen está en el grafo
            if (!Nodos.ContieneClave(nodoOrigen))
            {
                // Nodo origen no encontrado, no se puede ejecutar Dijkstra
                Console.WriteLine($"DEBUG Grafos<TNode>.AplicarDijkstra: Nodo origen '{nodoOrigen}' no encontrado en el grafo."); // Depuración
                return null; // O lanzar una excepción
            }

            // Obtiene el índice del nodo origen
            int indiceOrigen = GetIndiceNodo(nodoOrigen);

            // Inicializa los arreglos de distancias y visitados basándose en el número total de nodos
            List<int> distanciasMinimas = new List<int>(new int[ListaAdyacencia.Count]);
            List<bool> nodosVisitados = new List<bool>(new bool[ListaAdyacencia.Count]); // Cambiado 'estaciones' a 'nodos'

            // Inicializa todas las distancias a infinito y el estado de visitado a falso
            for (int i = 0; i < ListaAdyacencia.Count; i++)
            {
                distanciasMinimas[i] = int.MaxValue; // Usa el valor máximo de int para representar infinito
                nodosVisitados[i] = false;
            }

            // Inicializa la cola de prioridad
            PriorityQueue<Arista, int> colaPrioridad = new PriorityQueue<Arista, int>();

            // Añade el nodo origen a la cola de prioridad con distancia 0
            // Creamos una Arista conceptual que representa llegar al origen con distancia 0.
            // Asumimos constructor de Arista es Arista(indiceDestino, distancia, costo). La prioridad es la distancia.
            colaPrioridad.Enqueue(new Arista(indiceOrigen, 0, 0), 0); // Arista a sí mismo, distancia 0, costo 0, prioridad 0
            distanciasMinimas[indiceOrigen] = 0; // La distancia mínima al origen es 0


            // Bucle principal de Dijkstra
            while (colaPrioridad.Count > 0)
            {
                // Extrae de la cola el camino con la menor distancia total encontrada hasta ahora
                Arista rutaActual = colaPrioridad.Dequeue(); // Asumiendo que Dequeue devuelve el elemento Arista
                int nodoActual = rutaActual.Destino; // El índice del nodo al que hemos llegado con este camino

                // Si ya hemos encontrado un camino más corto a este nodo y lo hemos procesado, saltar
                if (nodosVisitados[nodoActual]) continue;

                // Marca el nodo actual como visitado
                nodosVisitados[nodoActual] = true;

                // Explora los vecinos del nodo actual
                // ListaAdyacencia[nodoActual] da la lista de aristas que SALEN de nodoActual.
                foreach (Arista aristaVecina in ListaAdyacencia[nodoActual]) // Itera sobre las aristas salientes de nodoActual
                {
                    int nodoVecino = aristaVecina.Destino; // El índice del nodo vecino (destino de la arista)
                    int pesoArista = aristaVecina.Distancia; // El peso (distancia/costo) de la arista al vecino

                    // Paso de relajación: si encontramos un camino más corto al nodoVecino
                    if (!nodosVisitados[nodoVecino] && // Si el vecino no ha sido visitado definitivamente
                        distanciasMinimas[nodoActual] != int.MaxValue && // Si hemos podido llegar al nodo actual
                        distanciasMinimas[nodoActual] + pesoArista < distanciasMinimas[nodoVecino]) // Si el nuevo camino es más corto
                    {
                        // Actualiza la distancia mínima al vecino
                        distanciasMinimas[nodoVecino] = distanciasMinimas[nodoActual] + pesoArista;
                        // Añade el vecino a la cola de prioridad con la nueva distancia mínima como prioridad
                        // Creamos una Arista que representa el camino al vecino. Destino es el índice del vecino.
                        colaPrioridad.Enqueue(new Arista(nodoVecino, distanciasMinimas[nodoVecino], 0), distanciasMinimas[nodoVecino]); // Prioridad es la distancia mínima actualizada
                    }
                }
            }
            
            Console.WriteLine($"Distancias más cortas desde {nodoOrigen}:");
            foreach (var nodo in Nodos.ObtenerClaves())
            {
                 int indice = Nodos.BuscarValores(nodo);
                 if (indice >= 0 && indice < distanciasMinimas.Count)
                 {
                     Console.WriteLine($"- {nodo}: {distanciasMinimas[indice]} km");
                 }
                 
            }
            return distanciasMinimas; 
        }
      
        public int CalcularDistanciaEntre(T origen, T destino)
        {
            // Verifica si ambos nodos origen y destino existen en el grafo
            if (!Nodos.ContieneClave(origen) || !Nodos.ContieneClave(destino))
            {
                Console.WriteLine($"Origen o destino no encontrados en el grafo."); 
                return -1; // Indica que uno o ambos nodos no están en el grafo
            }

            // Aplica el algoritmo de Dijkstra partiendo del nodo origen
            // El resultado es una lista de distancias mínimas a todos los nodos, indexada por su índice.
            List<int> distancias = AplicarDijkstra(origen);

            // Obtiene el índice del nodo destino
            int indiceDestino = GetIndiceNodo(destino); // Usa el método auxiliar

            // Verifica si Dijkstra devolvió distancias válidas y si el índice destino es válido
            // distancias no debería ser null aquí si el origen existe (lo verificamos antes).
            // Verificamos si la distancia al índice destino es int.MaxValue (inaccesible).
            if (distancias != null && indiceDestino >= 0 && indiceDestino < distancias.Count)
            {
                // Devuelve la distancia mínima calculada al nodo destino
                if (distancias[indiceDestino] == int.MaxValue)
                {
                    Console.WriteLine($"Destino no alcanzable desde origen."); // Depuración
                    return -1; // Indica que el destino es inalcanzable desde el origen
                }
                Console.WriteLine($"Distancia calculada entre origen (índice {GetIndiceNodo(origen)}) y destino (índice {indiceDestino}) es {distancias[indiceDestino]}."); // Depuración
                return distancias[indiceDestino]; // Devuelve la distancia mínima
            }

            // No debería llegarse aquí si las verificaciones iniciales de ContieneClave pasaron, pero como resguardo.
            Console.WriteLine($"Error interno o índice de destino inválido."); 
            return -1; // Indica un error
        }

        public T GetNodeByIndex(int index)
        {
             if (index >= 0 && index < ListaAdyacencia.Count)
             {
                 return Nodos.GetKeyByValue(index); // Usa el método auxiliar en TablaHash
             }
             Console.WriteLine($"Indice inválido {index}."); 
             return default; // Devuelve el valor por defecto para TNode si el índice es inválido
        }

    }
}