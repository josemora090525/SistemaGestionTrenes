package Actors;

import EmployeeTasks.InterfazColaPrioridad;

public class Pasajero extends Usuario implements InterfazColaPrioridad{

    private int prioridad;
    private int numeroAsiento;
    
    public Pasajero(String nombre, String identificacion, String correo, String contrasenia, String rol) {
        super(nombre, identificacion, correo, contrasenia, rol);
        this.numeroAsiento = numeroAsiento;
        this.prioridad = prioridad;
    }

    public int getPrioridad() {
        return prioridad;
    }

    public void setPrioridad(int prioridad) {
        this.prioridad = prioridad;
    }

    public int getNumeroAsiento() {
        return numeroAsiento;
    }

    public void setNumeroAsiento(int numeroAsiento) {
        this.numeroAsiento = numeroAsiento;
    }

}
