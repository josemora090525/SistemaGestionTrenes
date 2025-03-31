package Service;

import EmployeeTasks.PilaArreglo;

public class TrenMercedesBenz extends Tren{

    private PilaArreglo<Vagon> pilaVagones;

    public TrenMercedesBenz(String id, int capacidadCarga, int kilometraje, int maximoVagones, PilaArreglo<Vagon> pilaVagones) {
        super(id, capacidadCarga, kilometraje, 28, pilaVagones); 
        pilaVagones = new PilaArreglo(id, 28);
    }

    @Override
    public void verificarNumeroVagones() {
        if (pilaVagones.totalElementos() > pilaVagones.getCapacidad()) {
            System.out.println("La cantidad de vagones no es permitida.");
        } else {
            System.out.println("Cantidad de vagones correcta.");
        }
    }

    public void agregarVagon(Vagon vagon) {
        pilaVagones.push(vagon);
        System.out.println("Vagón " + vagon.getIdVagon() + " agregado a la pila.");
    }

    public void eliminarVagon() {
        Vagon vagonEliminado = pilaVagones.pop(); 
        if (vagonEliminado != null) {
            System.out.println("Vagón " + vagonEliminado.getIdVagon() + " desapilado.");
        }
    }

    public Vagon obtenerPrimerVagon() {
        Vagon topeVagon = pilaVagones.peek(); 
        if (topeVagon != null) {
            System.out.println("El vagón en la cima es: " + topeVagon.getIdVagon());
        }
        return topeVagon;
    }
    
}
