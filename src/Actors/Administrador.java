package Actors;

public class Administrador extends Usuario{

    public Administrador(String nombre, String apellidos, String telefono, String identificacion, String correo, String contrasenia, String rol) {
        super(nombre, apellidos, telefono, identificacion, correo, contrasenia, "Administrador");
    }

}