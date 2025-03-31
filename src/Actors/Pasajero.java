package Actors;

public class Pasajero {

    private int prioridad;
    private int numeroAsiento;
    
    public Pasajero(String nombre, String identificacion, String correo, String contraseña, String rol) {
        super(nombre, identificacion, correo, contraseña, rol);
        this.numeroAsiento = numeroAsiento;
        this.prioridad = prioridad;
    }

}
