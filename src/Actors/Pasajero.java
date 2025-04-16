package Actors;

import EmployeeTasks.InterfazID;
import EmployeeTasks.InterfazPrioridad;

public class Pasajero extends Usuario implements Comparable<Pasajero>, InterfazPrioridad, InterfazID{
    
    private int prioridad;
    private int numeroAsiento;
    
    public Pasajero(String nombre, String identificacion, String correo, String contraseña, String rol, int prioridad, int numeroAsiento) {
        super(nombre, identificacion, correo, contraseña, rol);
        this.numeroAsiento = numeroAsiento;
        this.prioridad = prioridad;
    }

    @Override
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

    @Override
    public String getId() {
        return getIdentificacion();
    }

    @Override
    public int compareTo(Pasajero otro) {
        return Integer.compare(otro.prioridad, this.prioridad); 
    }
    
    
    
    @Override
    public String toString() {
        return "Pasajero{" +"nombre='" + getNombre() + '\'' +", identificacion='" + getIdentificacion() + '\'' +", correo='" + getCorreo() + '\'' +
                    ", contraseña='" + getContrasenia() + '\'' +
                    ", rol='" + getRol() + '\'' +
                    ", prioridad=" + prioridad +
                    ", numeroAsiento=" + numeroAsiento +
                    '}';
        }
}
