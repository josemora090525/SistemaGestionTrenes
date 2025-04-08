package EmployeeTasks;

public class PilaArreglo <T> {

    private T[] elementos;
    private int tope;
    private int capacidad;

    public PilaArreglo(String id, int capacidad) {
        this.tope = -1;
        this.capacidad = capacidad;
        this.elementos = (T[]) new Object[capacidad];
    }
    
    public void push(T elemento){
        if(tope >= capacidad - 1){
            System.out.println("La pila de vagones se llenó");
        }
        
        else{
            tope++;
            elementos[tope] = elemento;
        }
    }
    
    public T pop(){
        if(tope < 0){
            System.out.println("La pila de vagones está vacia");
            return null;
        }
        
        else{
            T eliminado = elementos[tope];
            elementos[tope] = null; 
            tope--;
            System.out.println("Se ha desapilado: " + eliminado);
            return eliminado;
        }
    }
    
    public T peek(){
        if(tope < 0){
            System.out.println("La pila de vagones está vacía");
            return null;
        }
        
        else{
            return elementos[tope];
        }
    }

    public void mostrarElementos() {
        if (tope < 0) {
            System.out.println("La pila de vagones está vacía.");
            return;
        }

        System.out.println("Elementos en la pila:");
        for (int i = tope; i >= 0; i--) {
            System.out.println(elementos[i]);
        }

    }
    
    public int totalElementos(){
        return tope + 1;
    }
    
    public int getCapacidad() {
        return capacidad;
    }

}
