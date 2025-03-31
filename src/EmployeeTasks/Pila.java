package EmployeeTasks;

public class Pila <T> {

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

    public int getTamanio() {
        return tamanio; 
    }

}
