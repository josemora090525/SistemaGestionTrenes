package Service;
import EmployeeTasks.PilaArreglo;

public abstract class Tren {

    private String id;
    private int capacidadCarga;
    private int kilometraje;
    private PilaArreglo<Vagon> pilaVagones;
    private Tren siguiente;

    public Tren(String id, int capacidadCarga, int kilometraje, int maximoVagones, PilaArreglo<Vagon> pilaVagones) {
        this.id = id;
        this.capacidadCarga = capacidadCarga;
        this.kilometraje = kilometraje;
        pilaVagones = new PilaArreglo(id, maximoVagones);
    }

    public String getId() {
        return id;
    }

    public int getCapacidadCarga() {
        return capacidadCarga;
    }

    public int getKilometraje() {
        return kilometraje;
    }

    public Tren getSiguiente() {
        return siguiente;
    }

    public void setSiguiente(Tren siguiente) {
        this.siguiente = siguiente;
    }
    
    public abstract void verificarNumeroVagones();

}
