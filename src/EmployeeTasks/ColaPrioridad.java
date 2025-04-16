package EmployeeTasks;

public class ColaPrioridad<T extends Comparable<T> & InterfazID> {
    private T[] elementos;
    private int capacidadMaxima;
    private int cantidadElementos;

    public ColaPrioridad(int capacidadMaxima) {
        this.capacidadMaxima = capacidadMaxima;
        this.elementos = (T[]) new Object[capacidadMaxima]; 
        this.cantidadElementos = 0;
    }

    public void encolar(T elemento) {
    if (cantidadElementos >= capacidadMaxima) {
        System.out.println("La cola está llena. No se puede agregar más elementos.");
        return;
    }

    int index = cantidadElementos;
    while (index > 0 && elementos[index - 1] != null && elemento.compareTo(elementos[index - 1]) > 0) {
        elementos[index] = elementos[index - 1];
        index--;
    }
    elementos[index] = elemento;
    cantidadElementos++;
}

    public T desencolar() {
    if (cantidadElementos == 0) {
        System.out.println("La cola está vacía.");
        return null;
    }

    T elemento = elementos[0];

    for (int ii = 0; ii < cantidadElementos - 1; ii++) {
        elementos[ii] = elementos[ii + 1];
    }

    elementos[cantidadElementos - 1] = null; 
    cantidadElementos--;
    return elemento;
}

    public T buscarPorId(String id) {
        for (int ii = 0; ii < cantidadElementos; ii++) {
            if (elementos[ii].getId().equals(id)) {
                return elementos[ii];
            }
        }
        System.out.println("Elemento con ID " + id + " no encontrado.");
        return null;
    }

    public boolean eliminarPorId(String id) {
        for (int ii = 0; ii < cantidadElementos; ii++) {
            if (elementos[ii].getId().equals(id)) {
                for (int jj = ii; jj < cantidadElementos - 1; jj++) {
                    elementos[jj] = elementos[jj + 1];
                }
                cantidadElementos--;
                System.out.println("Elemento con ID " + id + " eliminado.");
                return true;
            }
        }
        System.out.println("Elemento con ID " + id + " no encontrado.");
        return false;
    }

    public void mostrarCola() {
        for (int ii = 0; ii < cantidadElementos; ii++) {
            System.out.println(elementos[ii]);
        }
    }

    public int getCantidadElementos() {
        return cantidadElementos;
    }
}