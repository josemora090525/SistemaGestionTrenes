package Service;

import EmployeeTasks.PilaArreglo;

public class TrenArnold extends Tren{

    private PilaArreglo<Vagon> pilaVagones;

    public TrenArnold(String id, int capacidadCarga, int kilometraje, int maximoVagones, PilaArreglo<Vagon> pilaVagones) {
        super(id, capacidadCarga, kilometraje, 32, pilaVagones); 
        pilaVagones = new PilaArreglo(id, 32);
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
