package EmployeeTasks;
import java.util.Iterator;
import java.util.NoSuchElementException;

public class ListaCircular<T extends InterfazID> implements Iterable<T> {
    private Nodo<T> cabeza;
    private Nodo<T> cola;
    private int tamanio;

    public ListaCircular() {
        this.cabeza = null;
        this.cola = null;
        this.tamanio = 0;
    }

    public Nodo<T> getCabeza() {
        return cabeza;
    }

    public void agregar(T nuevo) {
        Nodo<T> nuevoNodo = new Nodo<>(nuevo);

        if (cabeza == null) {
            cabeza = nuevoNodo;
            cola = nuevoNodo;
            nuevoNodo.setSiguiente(cabeza);
        }

        else {
            cola.setSiguiente(nuevoNodo);
            nuevoNodo.setSiguiente(cabeza);
            cola = nuevoNodo;
        }
        tamanio++;
    }

    public T buscar(String id) {
        if (cabeza == null) {
            return null;
        }

        Nodo<T> actual = cabeza;

        do {
            if (actual.getElemento().getId().equals(id)) {
                return actual.getElemento();
            }
            actual = actual.getSiguiente();
        } while (actual != cabeza);

        return null;
    }

    public boolean eliminar(String id) {
        if (cabeza == null) {
            return false;
        }

        Nodo<T> actual = cabeza;
        Nodo<T> anterior = cola;

        do {
            if (actual.getElemento().getId().equals(id)) {
                if (actual == cabeza) {
                    cabeza = cabeza.getSiguiente();
                    cola.setSiguiente(cabeza);
                }

                else if (actual == cola) {
                    cola = anterior;
                    cola.setSiguiente(cabeza);
                }

                else {
                    anterior.setSiguiente(actual.getSiguiente());
                }
                tamanio--;
                return true;
            }
            anterior = actual;
            actual = actual.getSiguiente();
        } while (actual != cabeza);

        return false;
    }

    public int getTamanio() {
        return tamanio;
    }

    @Override
    public Iterator<T> iterator() {
        return new Iterator<T>() {
            private Nodo<T> actual = cabeza;
            private Nodo<T> previo = null;
            private int elementosVisitados = 0;

            @Override
            public boolean hasNext() {
                return elementosVisitados < tamanio;
            }

            @Override
            public T next() {
                if (!hasNext()) {
                    throw new NoSuchElementException();
                }
                T elemento = actual.getElemento();
                previo = actual;
                actual = actual.getSiguiente();
                elementosVisitados++;
                return elemento;
            }

            @Override
            public void remove() {
                if (previo == null || elementosVisitados == 0) {
                    throw new IllegalStateException("Debe llamarse a next() antes de eliminar.");
                }

                ListaCircular.this.eliminar(previo.getElemento().getId());
                elementosVisitados--;
                previo = null;
            }
        };
    }
}