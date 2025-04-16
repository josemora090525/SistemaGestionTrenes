package EmployeeTasks;

public class Arista<T> {
    
    private Nodo<T> origen;
    private Nodo<T> destino;
    private int distancia;
    private boolean bidireccional; 

    public Arista(Nodo<T> origen, Nodo<T> destino, int distancia, boolean bidireccional) {
        this.origen = origen;
        this.destino = destino;
        this.distancia = distancia;
        this.bidireccional = bidireccional;
    }

    public Nodo<T> getOrigen() {
        return origen;
    }

    public Nodo<T> getDestino() {
        return destino;
    }

    public int getDistancia() {
        return distancia;
    }

    public boolean esBidireccional() {
        return bidireccional;
    }

    @Override
    public String toString() {
        return "Arista [Origen: " + origen.getElemento() + ", Destino: " + destino.getElemento() +
               ", Distancia: " + distancia + " Km, Bidireccional: " + bidireccional + "]";
    }
    
}
