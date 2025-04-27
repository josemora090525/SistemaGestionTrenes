using System;
using System.Collections.Generic;
using ProyectoEstructuras.Códigos.Servicio;
using ProyectoEstructuras.Códigos.TareasAdministrador;
using ProyectoEstructuras.Códigos.TareasEmpleado.ProyectoEstructuras.Códigos.TareasEmpleado;

namespace ProyectoEstructuras.Códigos.TareasEmpleado
{
    public class Grafos
    {
        private TablaHash<Estacion, int> estaciones;
        private List<List<Arista>> listaAdyacencia;

        public TablaHash<Estacion, int> Estaciones { get => estaciones; set => estaciones = value; }
        public List<List<Arista>> ListaAdyacencia { get => listaAdyacencia; set => listaAdyacencia = value; }

        public Grafos(int numeroEstaciones)
        {
            this.Estaciones = new TablaHash<Estacion, int>(numeroEstaciones);
            this.ListaAdyacencia = new List<List<Arista>>();

            for (int ii = 0; ii < numeroEstaciones; ii++)
            {
                ListaAdyacencia.Add(new List<Arista>());
            }
        }

        public void AgregarEstacion(Estacion estacion)
        {
            if (estacion == null)
            {
                return;
            }

            if (!Estaciones.ContieneClave(estacion))
            {
                Estaciones.InsertarValores(estacion, ListaAdyacencia.Count);
                ListaAdyacencia.Add(new List<Arista>());
            }
        }

        public Estacion BuscarEstacion(string id)
        {
            foreach (Estacion estacion in Estaciones.ObtenerClaves())
            {
                if (estacion.NombreEstacion.Equals(id))
                {
                    return estacion;
                }
            }
            return null;
        }

        public void AgregarRutaDirigida(Estacion origen, Estacion destino, int distancia)
        {
            if (!Estaciones.ContieneClave(origen) || !Estaciones.ContieneClave(destino))
            {
                return;
            }

            int indiceOrigen = Estaciones.BuscarValores(origen);
            int indiceDestino = Estaciones.BuscarValores(destino);

            if (indiceOrigen >= 0 && indiceOrigen < ListaAdyacencia.Count)
            {
                ListaAdyacencia[indiceOrigen].Add(new Arista(indiceDestino, distancia, 1));
            }
        }

        public void AgregarRutaNoDirigida(Estacion origen, Estacion destino, int distancia)
        {
            if (!Estaciones.ContieneClave(origen) || !Estaciones.ContieneClave(destino))
            {
                return;
            }

            int indiceOrigen = Estaciones.BuscarValores(origen);
            int indiceDestino = Estaciones.BuscarValores(destino);

            if (indiceOrigen >= 0 && indiceOrigen < ListaAdyacencia.Count && indiceDestino >= 0 && indiceDestino < ListaAdyacencia.Count)
            {
                ListaAdyacencia[indiceOrigen].Add(new Arista(indiceDestino, distancia, 1));
                ListaAdyacencia[indiceDestino].Add(new Arista(indiceOrigen, distancia, 1));
            }
        }

        public List<int> AplicarDijkstra(Estacion estacionOrigen)
        {
            if (!Estaciones.ContieneClave(estacionOrigen))
            {
                return null;
            }

            int indiceOrigen = Estaciones.BuscarValores(estacionOrigen);

            List<int> distanciasMinimas = new List<int>(new int[ListaAdyacencia.Count]);
            List<bool> estacionesVisitadas = new List<bool>(new bool[ListaAdyacencia.Count]);

            for (int i = 0; i < ListaAdyacencia.Count; i++)
            {
                distanciasMinimas[i] = int.MaxValue;
            }

            PriorityQueue<Arista> colaPrioridad = new PriorityQueue<Arista>();
            colaPrioridad.Enqueue(new Arista(indiceOrigen, 0, 0), 0);
            distanciasMinimas[indiceOrigen] = 0;

            while (colaPrioridad.Count > 0)
            {
                Arista rutaActual = colaPrioridad.Dequeue();
                int estacionActual = rutaActual.Destino;

                if (estacionesVisitadas[estacionActual]) continue;

                estacionesVisitadas[estacionActual] = true;

                foreach (Arista rutaVecina in ListaAdyacencia[estacionActual])
                {
                    int estacionVecina = rutaVecina.Destino;
                    int distanciaRuta = rutaVecina.Distancia;

                    if (!estacionesVisitadas[estacionVecina] &&
                        distanciasMinimas[estacionActual] + distanciaRuta < distanciasMinimas[estacionVecina])
                    {
                        distanciasMinimas[estacionVecina] = distanciasMinimas[estacionActual] + distanciaRuta;
                        colaPrioridad.Enqueue(new Arista(estacionVecina, distanciasMinimas[estacionVecina], 0), distanciasMinimas[estacionVecina]);
                    }
                }
            }

            Console.WriteLine($"Distancias más cortas desde {estacionOrigen.NombreEstacion}:");
            foreach (var estacion in estaciones.ObtenerClaves())
            {
                int indice = estaciones.BuscarValores(estacion);
                if (indice >= 0 && indice < distanciasMinimas.Count)
                {
                    Console.WriteLine($"- {estacion.NombreEstacion}: {distanciasMinimas[indice]} km");
                }
                else
                {
                    Console.WriteLine($"- {estacion.NombreEstacion}: No se pudo calcular la distancia.");
                }
            }

            return distanciasMinimas;
        }

        public int CalcularDistanciaEntre(Estacion origen, Estacion destino)
        {
            if (!Estaciones.ContieneClave(origen) || !Estaciones.ContieneClave(destino))
            {
                return -1;
            }

            List<int> distancias = AplicarDijkstra(origen);
            int indiceDestino = Estaciones.BuscarValores(destino);

            if (indiceDestino >= 0 && indiceDestino < distancias.Count)
            {
                return distancias[indiceDestino];
            }
            return -1;
        }
    }
}