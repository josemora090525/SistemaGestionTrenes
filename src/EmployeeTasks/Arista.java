package EmployeeTasks;

public class Arista<T> {
    
    private int destino;
    private int distancia;
    private int peso;

	public Arista(int destino, int distancia, int peso) {
        this.destino = destino;
        this.distancia = distancia;
        this.peso = peso;
    }

    public int getDestino() {
        return destino;
    }

    public int getDistancia() {
        return distancia;
    }
    
    public int getPeso() {
		return peso;
	}

    @Override
    public String toString() {
        return "Arista [Destino: " + destino + ", Distancia: " + distancia + " km]";
    }
    
}
