package EmployeeTasks;
import java.util.Iterator;
import java.util.NoSuchElementException;

public class ListaDoblementeEnlazada<T extends InterfazID> implements Iterable<T> {
    private Nodo<T> cabeza;
    private Nodo<T> cola;
    private int tamanio;

    public ListaDoblementeEnlazada() {
        this.cabeza = null;
        this.cola = null;
        this.tamanio = 0;
    }

    public void agregarAlFinal(T elemento) {
        Nodo<T> nuevoNodo = new Nodo<>(elemento);

        if (cabeza == null) {
            cabeza = nuevoNodo;
            cola = nuevoNodo;
        }

        else {
            cola.setSiguiente(nuevoNodo);
            nuevoNodo.setAnterior(cola);
            cola = nuevoNodo;
        }
        tamanio++;
    }

    public void agregarAlInicio(T elemento) {
        Nodo<T> nuevoNodo = new Nodo<>(elemento);

        if (cabeza == null) {
            cabeza = nuevoNodo;
            cola = nuevoNodo;
        }

        else {
            nuevoNodo.setSiguiente(cabeza);
            cabeza.setAnterior(nuevoNodo);
            cabeza = nuevoNodo;
        }
        tamanio++;
    }

    public boolean eliminar(String id) {
        if (cabeza == null) {
            return false;
        }

        Nodo<T> actual = cabeza;

        while (actual != null) {
            if (actual.getElemento().getId().equals(id)) {
                if (actual == cabeza) {
                    cabeza = cabeza.getSiguiente();
                    if (cabeza != null) {
                        cabeza.setAnterior(null);
                    } else {
                        cola = null;
                    }
                }

                else if (actual == cola) {
                    cola = cola.getAnterior();
                    if (cola != null) {
                        cola.setSiguiente(null);
                    }
                }

                else {
                    actual.getAnterior().setSiguiente(actual.getSiguiente());
                    actual.getSiguiente().setAnterior(actual.getAnterior());
                }
                tamanio--;
                return true;
            }
            actual = actual.getSiguiente();
        }
        return false;
    }

    public T buscar(String id) {
        Nodo<T> actual = cabeza;

        while (actual != null) {
            if (actual.getElemento().getId().equals(id)) {
                return actual.getElemento();
            }
            actual = actual.getSiguiente();
        }
        return null;
    }

    public void mostrarElementos() {
        for (T elemento : this) {
            System.out.println(elemento);
        }
    }

    public int getTamanio() {
        return tamanio;
    }

    @Override
    public Iterator<T> iterator() {
        return new Iterator<T>() {
            private Nodo<T> actual = cabeza;

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