package Actors;

public class Empleado extends Usuario{
    
    public Empleado(String nombre, String apellidos, String telefono, String identificacion, String correo, String contrasenia, String rol) {
        super(nombre, apellidos, telefono, identificacion, correo, contrasenia, "Empleado");
    }

}
