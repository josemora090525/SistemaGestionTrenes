package Actors;

import EmployeeTasks.InterfazID;
import EmployeeTasks.InterfazPrioridad;
import java.util.Arrays;
import java.util.List;

public class Pasajero extends Usuario implements Comparable<Pasajero>, InterfazPrioridad, InterfazID{
    
    private String prioridad;
    private int numeroAsiento;
    
    public Pasajero(String nombre, String apellidos, String telefono, String identificacion, String correo, String contraseña, String rol, String prioridad, int numeroAsiento) {
        super(nombre, apellidos, telefono, identificacion, correo, contraseña, rol);
        this.numeroAsiento = numeroAsiento;
        this.prioridad = prioridad;
    }

    @Override
    public String getPrioridad() {
        return prioridad;
    }

    public void setPrioridad(String prioridad) {
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
        List<String> ordenPrioridades = Arrays.asList("premium", "ejecutivo", "estándar");

        int thisIndex = ordenPrioridades.indexOf(this.prioridad.toLowerCase());
        int otroIndex = ordenPrioridades.indexOf(otro.prioridad.toLowerCase());

        return Integer.compare(thisIndex, otroIndex);
    }

    @Override
    public String toString() {
        return "Pasajero{" + "prioridad=" + prioridad + ", numeroAsiento=" + numeroAsiento + '}';
    }
