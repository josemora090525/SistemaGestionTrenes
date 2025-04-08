package EmployeeTasks;

public class ColaPrioridad <T extends InterfazColaPrioridad>{

    private T[] elementos;
    private int capacidadMaxima;
    private int cantidadElementos;

    public ColaPrioridad(int capacidadMaxima) {
        this.capacidadMaxima = capacidadMaxima;
        elementos = (T[]) new Object[capacidadMaxima];
        cantidadElementos = 0;
    }

    public void encolar(T elemento) {
        if (cantidadElementos >= capacidadMaxima) {
            System.out.println("La cola está llena");
            return;
        }

        for (int ii = cantidadElementos - 1; ii >= 0; ii--) {
            if (elemento.getPrioridad() < elementos[ii].getPrioridad()) {
                elementos[ii + 1] = elementos[ii];
            }

            else {
                elementos[ii + 1] = elemento;
                cantidadElementos++;
                break;
            }
        }
    }

    public T desencolar() {
        if (cantidadElementos == 0) {
            System.out.println("La cola está vacía");
            return null;
        }

        T elemento = elementos[0];
        for (int i = 0; i < cantidadElementos - 1; i++) {
            elementos[i] = elementos[i + 1];
        }
        cantidadElementos--;
        return elemento;
    }

    public void mostrarCola() {
        for (int i = 0; i < cantidadElementos; i++) {
            System.out.println(elementos[i]);
        }
    }

    public int getCantidadElementos() {
        return cantidadElementos;
    }
}
