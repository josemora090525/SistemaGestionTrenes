package EmployeeTasks;

public class ListaCircular <T> {

    private Nodo<T> cabeza; 
    private Nodo<T> cola;   
    private int tamanio;    

    public ListaCircular() {
        this.cabeza = null;
        this.cola = null;
        this.tamanio = 0;
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

    public void eliminar(T elemento) {
        if (cabeza == null) { 
            System.out.println("La lista está vacía, no hay elementos que eliminar.");
            return;
        }

        Nodo<T> actual = cabeza;
        Nodo<T> puntero = cola;

        do {
            if (actual.getElemento().equals(elemento)) { 
                if (actual == cabeza) { 
                    cabeza = cabeza.getSiguiente();
                    cola.setSiguiente(cabeza); 
                } 
                
                else if (actual == cola) { 
                    cola = puntero;
                    cola.setSiguiente(cabeza);
                } 
                
                else { 
                    puntero.setSiguiente(actual.getSiguiente());
                }
                tamanio--;
                System.out.println("Elemento eliminado: " + elemento);
                return;
            }
            
            puntero = actual;
            actual = actual.getSiguiente(); 
        } while (actual != cabeza);

        System.out.println("No se encontró el elemento: " + elemento);
    }

    public T buscar(T elemento) {
        if (cabeza == null) {
            System.out.println("La lista está vacía.");
            return null;
        }

        Nodo<T> actual = cabeza;

        do {
            if (actual.getElemento().equals(elemento)) { 
                System.out.println("Elemento encontrado: " + actual.getElemento());
                return actual.getElemento();
            }
            actual = actual.getSiguiente(); 
        } while (actual != cabeza);

        System.out.println("No se encontró el elemento: " + elemento);
        return null;
    }

    public void mostrar() {
        if (cabeza == null) {
            System.out.println("La lista está vacía.");
            return;
        }

        Nodo<T> actual = cabeza;

        System.out.println("Elementos en la lista circular:");
        do {
            System.out.println(actual.getElemento()); 
            actual = actual.getSiguiente(); 
        } while (actual != cabeza);
    }

    public int getTamanio() {
        return tamanio;
    }

}
