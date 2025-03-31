package EmployeeTasks;

public class ListaDoblementeEnlazada <T>  {

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

    public void eliminar(T elemento) {
        if (cabeza == null) { 
            System.out.println("La lista esta vacia");
            return;
        }

        Nodo<T> actual = cabeza;

        while (actual != null) {
            if (actual.getElemento().equals(elemento)) { 
                if (actual == cabeza) { 
                    cabeza = cabeza.getSiguiente();
                    if (cabeza != null) {
                        cabeza.setAnterior(null);
                    } 
                    
                    else { 
                        cola = null;
                    }
                } 
                
                else if (actual == cola) { 
                    cola = cola.getAnterior();
                    cola.setSiguiente(null);
                } 
                
                else { 
                    actual.getAnterior().setSiguiente(actual.getSiguiente());
                    actual.getSiguiente().setAnterior(actual.getAnterior());
                }
                tamanio--;
                return;
            }
            actual = actual.getSiguiente();
        }
    }

    public Nodo<T> buscar(T elemento) {
        Nodo<T> actual = cabeza;

        while (actual != null) {
            if (actual.getElemento().equals(elemento)) {
                return actual; 
            }
            actual = actual.getSiguiente();
        }
        return null; 
    }

    public void mostrarElementos() {
        Nodo <T> actual = cabeza;

        System.out.println("Elementos en la lista doblemente enlazada:");
        while (actual != null) {
            System.out.println(actual.getElemento()); 
            actual = actual.getSiguiente();
        }
    }

    public int getTamanio() {
        return tamanio;
    }

}
