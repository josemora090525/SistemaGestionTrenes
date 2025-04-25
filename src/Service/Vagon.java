package Service;

import EmployeeTasks.InterfazID;

public class Vagon implements InterfazID{
    
    private String idVagon;        
    private int capacidad;            

    public Vagon(String idVagon, int capacidad) {
        this.idVagon = idVagon;
        this.capacidad = capacidad;
    }

    @Override
    public String getId(){
        return idVagon;
    }

    public int getCapacidad() {
        return capacidad;
    }

}