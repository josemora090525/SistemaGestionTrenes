package EmployeeTasks;
import java.util.Iterator;
import java.util.NoSuchElementException;

public class PilaArreglo<T extends Interfaz> implements Iterable<T> {

    private T[] elementos;
    private int tope;
    private int capacidad;

    public PilaArreglo(String id, int capacidad) {
        this.tope = -1;
        this.capacidad = capacidad;
        this.elementos = (T[]) new Object[capacidad];
    }

    public void push(T elemento) {
        if (tope >= capacidad - 1) {
            System.out.println("La pila de vagones se llenó");
        } else {
            elementos[++tope] = elemento;
        }
    }

    public T pop() {
        if (tope < 0) {
            System.out.println("La pila de vagones está vacía");
            return null;
        }

        else {
            T eliminado = elementos[tope];
            elementos[tope--] = null;
            System.out.println("Se ha desapilado: " + eliminado);
            return eliminado;
        }
    }

    public T peek() {
        if (tope < 0) {
            System.out.println("La pila de vagones está vacía");
            return null;
        }
        return elementos[tope];
    }

    public void mostrarElementos() {
        if (tope < 0) {
            System.out.println("La pila de vagones está vacía.");
            return;
        }

        System.out.println("Elementos en la pila:");
        for (int ii = tope; ii >= 0; ii--) {
            System.out.println(elementos[ii]);
        }
    }

    public T buscarPorId(String id) {
        for (int ii = tope; ii >= 0; ii--) {
            if (elementos[ii].getId().equals(id)) {
                return elementos[ii];
            }
        }
        return null;
    }

    public boolean eliminarPorId(String id) {
        for (int ii = tope; ii >= 0; ii--) {
            if (elementos[ii].getId().equals(id)) {
                for (int jj = ii; jj < tope; jj++) {
                    elementos[jj] = elementos[jj + 1];
                }
                elementos[tope--] = null;
                System.out.println("Se ha eliminado el elemento con ID: " + id);
                return true;
            }
        }
        System.out.println("Elemento con ID: " + id + " no encontrado.");
        return false;
    }

    public int totalElementos() {
        return tope + 1;
    }

    public int getCapacidad() {
        return capacidad;
    }

    @Override
    public Iterator<T> iterator() {
        return new Iterator<T>() {
            private int indiceActual = tope;

            @Override
            public boolean hasNext() {
                return indiceActual >= 0;
            }

            @Override
            public T next() {
                if (!hasNext()) {
                    throw new NoSuchElementException();
                }
                return elementos[indiceActual--];
            }

            @Override
            public void remove() {
                throw new UnsupportedOperationException("Eliminación no soportada en la pila.");
            }
        };
    }
}