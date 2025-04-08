package Service;
import EmployeeTasks.PilaArreglo;

public abstract class Tren {

    private String id;
    private int capacidadCarga;
    private int kilometraje;
    private PilaArreglo<Vagon> pilaVagones;

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

    public PilaArreglo<Vagon> getVagones() {
        return pilaVagones;
    }

    public void setId(String id) {
        this.id = id;
    }

    public void setCapacidadCarga(int capacidadCarga) {
        this.capacidadCarga = capacidadCarga;
    }

    public void setKilometraje(int kilometraje) {
        this.kilometraje = kilometraje;
    }

    public void setPilaVagones(PilaArreglo<Vagon> pilaVagones) {
        this.pilaVagones = pilaVagones;
    }

    public void agregarVagon(Vagon vagon) {
        if (pilaVagones.totalElementos() >= pilaVagones.getCapacidad()) {
            System.out.println("La pila de vagones está llena.");
        } else {
            pilaVagones.push(vagon);
            System.out.println("Vagón " + vagon.getIdVagon() + " agregado al tren " + id);
        }
    }

    public void eliminarVagon() {
        Vagon vagonEliminado = pilaVagones.pop();
        if (vagonEliminado != null) {
            System.out.println("Vagón " + vagonEliminado.getIdVagon() + " eliminado del tren " + id);
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
