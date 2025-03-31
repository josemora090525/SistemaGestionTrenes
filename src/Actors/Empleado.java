package Actors

public class Empleado extends Usuario{
    
    public Empleado(String nombre, String id, String correo, String contraseña) {
        super(nombre, id, correo, contraseña, "Empleado");
    }

}
