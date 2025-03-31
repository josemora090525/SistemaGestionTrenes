package Service;

public class Vagon {

    private String idVagon;        
    private int capacidad;            

    public Vagon(String idVagon, int capacidad) {
        this.idVagon = idVagon;
        this.capacidad = capacidad;
    }

    public String getIdVagon() {
        return idVagon;
    }

    public int getCapacidad() {
        return capacidad;
    }
    
}
