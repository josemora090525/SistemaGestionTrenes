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

    public void desencolar() {
        if (cantidadElementos == 0) {
            System.out.println("La cola está vacía");
        }

        cantidadElementos--;

        for(int ii = 0; ii < cantidadElementos; ii++){
            System.out.println(elementos[ii]);
        }
    }
}
