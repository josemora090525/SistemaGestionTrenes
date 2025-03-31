package Actors

public class Administrador extends Usuario{

    public Administrador(String nombre, String id, String correo, String contraseña) {
        super(nombre, id, correo, contraseña, "Administrador");
    }

}