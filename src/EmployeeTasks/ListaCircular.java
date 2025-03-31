package EmployeeTasks;

public class ListaCircular <T extends InterfazLista> {

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

    public void eliminar(String id) {
        if (cabeza == null) { 
            System.out.println("La lista está vacía, no hay elementos que eliminar.");
            return;
        }

        Nodo<T> actual = cabeza;
        Nodo<T> puntero = cola;

        do {
            if (actual.getElemento().getId().equals(id)) { 
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
                System.out.println("Elemento eliminado: " + id);
                return;
            }
            
            puntero = actual;
            actual = actual.getSiguiente(); 
        } while (actual != cabeza);

        System.out.println("No se encontró el elemento con ID: " + id);
    }

    public T buscar(String id) {
        if (cabeza == null) {
            System.out.println("La lista está vacía.");
            return null;
        }

        Nodo<T> actual = cabeza;

        do {
            if (actual.getElemento().getId().equals(id)) { 
                System.out.println("Elemento encontrado: " + actual.getElemento().getId());
                return actual.getElemento();
            }
            actual = actual.getSiguiente(); 
        } while (actual != cabeza);

        System.out.println("No se encontró el elemento con ID: " + id);
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
