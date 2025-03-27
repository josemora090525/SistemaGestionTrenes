package Train;

import java.util.ArrayList;
import java.util.List;

public class TrainCarriage extends Train {
    private int numeroVagones;
    private List<String> tiposVagones;
    
    public TrainCarriage(String id, int capacidad, int numeroVagones) {
        super(id, capacidad);
        this.numeroVagones = numeroVagones;
        this.tiposVagones = new ArrayList<>();
    }
    
    public int getNumeroVagones() {
        return numeroVagones;
    }
    
    public List<String> getTiposVagones() {
        return tiposVagones;
    }
    
    public void agregarTipoVagon(String tipo) {
        if (tiposVagones.size() < numeroVagones) {
            tiposVagones.add(tipo);
            System.out.println("Vagón tipo '" + tipo + "' agregado al tren " + id);
        } else {
            System.out.println("No se pueden agregar más vagones. Capacidad máxima alcanzada.");
        }
    }
    
    @Override
    public void mostrarInfoTren() {
        System.out.println("Tren Vagón - ID: " + id);
        System.out.println("Capacidad total: " + capacidad + " pasajeros");
        System.out.println("Número de vagones: " + numeroVagones);
        System.out.println("Tipos de vagones: " + tiposVagones);
    }
} 