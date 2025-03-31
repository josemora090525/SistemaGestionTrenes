package Actors;

public class Usuario {

    private String nombre;
    private String identificacion;
    private String correo;
    private String contraseña;
    private String rol;

    public Usuario(String nombre, String identificacion, String correo, String contraseña, String rol) {
        this.nombre = nombre;
        this.identificacion = identificacion;
        this.correo = correo;
        this.contraseña = contraseña;
        this.rol = rol;
    }

    public String getNombre() {
        return nombre;
    }

    public String getIdentificacion() {
        return identificacion;
    }

    public String getCorreo() {
        return correo;
    }

    public String getContraseña() {
        return contraseña;
    }

    public String getRol() {
        return rol;
    }
    
}
