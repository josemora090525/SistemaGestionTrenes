package EmployeeTasks;

import AdministratorTasks.TablaHash;
import Service.Estacion;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.PriorityQueue;

public class Grafos {

    private TablaHash<Estacion, Integer> estaciones;
    private ArrayList<ArrayList<Arista>> listaAdyacencia;

    public Grafos(int numeroEstaciones) {
        this.estaciones = new TablaHash<>(numeroEstaciones);
        this.listaAdyacencia = new ArrayList<>();
    }

    public TablaHash<Estacion, Integer> getEstaciones() {
        return estaciones;
    }

    public void agregarEstacion(Estacion estacion) {
        if (estacion == null) {
            System.out.println("La estación no puede ser nula.");
            return;
        }

        if (!estaciones.contieneClave(estacion)) {
            estaciones.insertarValores(estacion, listaAdyacencia.size());
            listaAdyacencia.add(new ArrayList<>());
            System.out.println("Estación agregada: " + estacion.getNombreEstacion());
        }
        else {
            System.out.println("La estación ya existe: " + estacion.getNombreEstacion());
        }
    }

    public Estacion buscarEstacion(String id) {
        for (Estacion estacion : estaciones.obtenerClaves()) {
            if (estacion.getNombreEstacion().equals(id)) {
                return estacion;
            }
        }
        System.out.println("No se encontró la estación con id: " + id);
        return null;
    }

    public void agregarRutaDirigida(Estacion origen, Estacion destino, int distancia) {
        if (!estaciones.contieneClave(origen) || !estaciones.contieneClave(destino)) {
            System.out.println("Las estaciones de origen o destino no existen.");
            return;
        }

        int indiceOrigen = estaciones.buscarValores(origen);
        int indiceDestino = estaciones.buscarValores(destino);

        if (indiceOrigen >= 0 && indiceOrigen < listaAdyacencia.size()) {
            listaAdyacencia.get(indiceOrigen).add(new Arista(indiceDestino, distancia, 1));
            System.out.println("Ruta dirigida agregada: " + origen.getNombreEstacion() + " -> " + destino.getNombreEstacion() + " | Distancia: " + distancia + " km");
        }
        else {
            System.out.println("Error: Índice de origen fuera de rango.");
        }
    }

    public void agregarRutaNoDirigida(Estacion origen, Estacion destino, int distancia) {
        if (!estaciones.contieneClave(origen) || !estaciones.contieneClave(destino)) {
            System.out.println("Las estaciones de origen o destino no existen.");
            return;
        }

        int indiceOrigen = estaciones.buscarValores(origen);
        int indiceDestino = estaciones.buscarValores(destino);

        if (indiceOrigen >= 0 && indiceOrigen < listaAdyacencia.size() && indiceDestino >= 0 && indiceDestino < listaAdyacencia.size()) {
            listaAdyacencia.get(indiceOrigen).add(new Arista(indiceDestino, distancia, 1));
            listaAdyacencia.get(indiceDestino).add(new Arista(indiceOrigen, distancia, 1));
            System.out.println("Ruta no dirigida agregada: " + origen.getNombreEstacion() + " <-> " + destino.getNombreEstacion() + " | Distancia: " + distancia + " km");
        }
        else {
            System.out.println("Error: Índices fuera de rango.");
        }
    }

    public ArrayList<Integer> aplicarDijkstra(Estacion estacionOrigen) {
        if (!estaciones.contieneClave(estacionOrigen)) {
            System.out.println("La estación de origen no existe.");
            return null;
        }

        int indiceOrigen = estaciones.buscarValores(estacionOrigen);

        ArrayList<Integer> distanciasMinimas = new ArrayList<>();
        ArrayList<Boolean> estacionesVisitadas = new ArrayList<>();

        for (int i = 0; i < listaAdyacencia.size(); i++) {
            distanciasMinimas.add(Integer.MAX_VALUE);
            estacionesVisitadas.add(false);
        }

        PriorityQueue<Arista> colaPrioridad = new PriorityQueue<>();
        colaPrioridad.add(new Arista(indiceOrigen, 0, 0));
        distanciasMinimas.set(indiceOrigen, 0);

        while (!colaPrioridad.isEmpty()) {
            Arista rutaActual = colaPrioridad.poll();
            int estacionActual = rutaActual.getDestino();

            if (estacionesVisitadas.get(estacionActual)) continue;
            estacionesVisitadas.set(estacionActual, true);

            Iterator<Arista> iterador = listaAdyacencia.get(estacionActual).iterator();
            while (iterador.hasNext()) {
                Arista rutaVecina = iterador.next();
                int estacionVecina = rutaVecina.getDestino();
                int distanciaRuta = rutaVecina.getDistancia();

                if (!estacionesVisitadas.get(estacionVecina) && distanciasMinimas.get(estacionActual) + distanciaRuta < distanciasMinimas.get(estacionVecina)) {
                    distanciasMinimas.set(estacionVecina, distanciasMinimas.get(estacionActual) + distanciaRuta);
                    colaPrioridad.add(new Arista(estacionVecina, distanciasMinimas.get(estacionVecina), 0));
                }
            }
        }

        System.out.println("Distancias más cortas desde " + estacionOrigen.getNombreEstacion() + ":");
        for (Estacion estacion : estaciones.obtenerClaves()) {
            int indice = estaciones.buscarValores(estacion);
            if (indice >= 0 && indice < distanciasMinimas.size()) {
                System.out.println("- " + estacion.getNombreEstacion() + ": " + distanciasMinimas.get(indice) + " km");
            }
            else {
                System.out.println("- " + estacion.getNombreEstacion() + ": No se pudo calcular la distancia.");
            }
        }

        return distanciasMinimas;
    }

    public int calcularDistanciaEntre(Estacion origen, Estacion destino) {
        if (!estaciones.contieneClave(origen) || !estaciones.contieneClave(destino)) {
            System.out.println("Error: Una de las estaciones no existe.");
            return -1;
        }

        ArrayList<Integer> distancias = aplicarDijkstra(origen);
        int indiceDestino = estaciones.buscarValores(destino);

        if (indiceDestino >= 0 && indiceDestino < distancias.size()) {
            return distancias.get(indiceDestino);
        }

        else {
            System.out.println("No se pudo calcular la distancia entre " + origen.getNombreEstacion() + " y " + destino.getNombreEstacion());
            return -1;
        }
    }
    
}