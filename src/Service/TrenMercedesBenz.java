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
        } 
        
        else {
            System.out.println("Cantidad de vagones correcta.");
        }
    }
    
}
