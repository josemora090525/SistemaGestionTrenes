package Service;

import EmployeeTasks.InterfazID;
import EmployeeTasks.Pila;

public abstract class Tren implements InterfazID{

    private String id;
    private int capacidadCarga;
    private int kilometraje;
    private Pila<Vagon> pilaVagones;

    public Tren(String id, int capacidadCarga, int kilometraje, int maximoVagones) {
        this.id = id;
        this.capacidadCarga = capacidadCarga;
        this.kilometraje = kilometraje;
        this.pilaVagones = new Pila<Vagon>(); 
    }

    @Override
    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public int getCapacidadCarga() {
        return capacidadCarga;
    }

    public void setCapacidadCarga(int capacidadCarga) {
        this.capacidadCarga = capacidadCarga;
    }

    public int getKilometraje() {
        return kilometraje;
    }

    public void setKilometraje(int kilometraje) {
        this.kilometraje = kilometraje;
    }

    public Pila<Vagon> getVagones() {
        return pilaVagones;
    }

    public void setPilaVagones(Pila<Vagon> pilaVagones) {
        this.pilaVagones = pilaVagones;
    }

    public void agregarVagon(Vagon vagon) {
        if (pilaVagones.getTamanio() >= pilaVagones.getCapacidad()) {
            System.out.println("La pila de vagones está llena.");
        } else {
            pilaVagones.push(vagon);
            System.out.println("Vagón " + vagon.getId() + " agregado al tren " + id + ".");
        }
    }

    public void eliminarVagon() {
        Vagon vagonEliminado = pilaVagones.pop();
        if (vagonEliminado != null) {
            System.out.println("Vagón " + vagonEliminado.getId() + " eliminado del tren " + id + ".");
        } else {
            System.out.println("No hay vagones para eliminar en el tren " + id + ".");
        }
    }

    public Vagon obtenerPrimerVagon() {
        return pilaVagones.peek();
    }

    public void mostrarVagones() {
        System.out.println("Vagones del tren " + id + ":");
        pilaVagones.mostrarElementos();
    }

    public abstract void verificarNumeroVagones();
}