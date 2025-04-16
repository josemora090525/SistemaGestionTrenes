package EmployeeTasks;

import AdministratorTasks.TablaHash;
import Service.Estacion;
import Service.Ruta;
import java.util.ArrayList;

public class Grafos {

    private TablaHash<Estacion, ArrayList<Arista>> estaciones;

    public Grafos(int tamanio) {
        this.estaciones = new TablaHash<>(tamanio);
    }

    public void agregarEstacion(Estacion estacion) {
        if (estacion == null) {
            System.out.println("Estación no puede ser nula.");
            return;
        }
        if (!estaciones.contieneClave(estacion)) {
            estaciones.insertarValores(estacion, new ArrayList<>());
            System.out.println("Estación agregada: " + estacion.getNombreEstacion());
        } else {
            System.out.println("La estación ya existe: " + estacion.getNombreEstacion());
        }
    }

    public void agregarRuta(Estacion origen, Estacion destino, double distancia) {
        if (origen == null || destino == null) {
            System.out.println("Las estaciones de origen y destino no pueden ser nulas.");
            return;
        }
        if (!estaciones.contieneClave(origen) || !estaciones.contieneClave(destino)) {
            System.out.println("Una de las estaciones no existe.");
            return;
        }

        Arista nuevaArista = new Arista(origen, destino, distancia);
        estaciones.buscarValores(origen).add(nuevaArista);
        estaciones.buscarValores(destino).add(new Arista(destino, origen, distancia));

        System.out.println("✅ Ruta agregada: " + origen.getNombreEstacion() + " -> " + destino.getNombreEstacion() + " | Distancia: " + distancia + " km");
    }

    public void mostrarEstaciones() {
        System.out.println("Lista de estaciones:");
        estaciones.mostrarValores();
    }

    public void mostrarRutasDesde(Estacion origen) {
        if (!estaciones.contieneClave(origen)) {
            System.out.println("La estación no existe.");
            return;
        }
        System.out.println("Rutas desde la estación " + origen.getNombreEstacion() + ":");
        for (Arista arista : estaciones.buscarValores(origen)) {
            System.out.println("- " + arista);
        }
    }
}