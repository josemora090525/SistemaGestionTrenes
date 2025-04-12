package EmployeeTasks;
import java.util.Iterator;
import java.util.NoSuchElementException;

public class Pila<T extends Interfaz> implements Iterable<T> {
    private Nodo<T> tope;
    private int tamanio;

    public Pila() {
        this.tope = null;
        this.tamanio = 0;
    }

    public void push(T elemento) {
        Nodo<T> nuevoNodo = new Nodo<>(elemento);
        nuevoNodo.setSiguiente(tope);
        tope = nuevoNodo;
        tamanio++;
    }

    public T pop() {
        if (tope == null) {
            System.out.println("La pila está vacía.");
            return null;
        }
        T eliminado = tope.getElemento();
        tope = tope.getSiguiente();
        tamanio--;
        return eliminado;
    }

    public T peek() {
        if (tope == null) {
            System.out.println("La pila está vacía.");
            return null;
        }
        return tope.getElemento();
    }

    public T buscarPorId(String id) {
        Nodo<T> actual = tope;

        while (actual != null) {
            if (actual.getElemento().getId().equals(id)) {
                return actual.getElemento();
            }
            actual = actual.getSiguiente();
        }
        return null;
    }

    public boolean eliminarPorId(String id) {
        if (tope == null) {
            System.out.println("La pila está vacía.");
            return false;
        }

        Nodo<T> actual = tope;
        Nodo<T> previo = null;

        while (actual != null) {
            if (actual.getElemento().getId().equals(id)) {
                if (previo == null) {
                    tope = actual.getSiguiente();
                }

                else {
                    previo.setSiguiente(actual.getSiguiente());
                }
                tamanio--;
                return true;
            }
            previo = actual;
            actual = actual.getSiguiente();
        }
        return false;
    }

    public int getTamanio() {
        return tamanio;
    }

    @Override
    public Iterator<T> iterator() {
        return new Iterator<T>() {
            private Nodo<T> actual = tope;

            @Override
            public boolean hasNext() {
                return actual != null;
            }

            @Override
            public T next() {
                if (!hasNext()) {
                    throw new NoSuchElementException();
                }
                T elemento = actual.getElemento();
                actual = actual.getSiguiente();
                return elemento;
            }
        };
    }
}