package Actors;

public class Usuario {

    private String nombre;
    private String identificacion;
    private String correo;
    private String contrasenia;
    private String rol;

    public Usuario(String nombre, String identificacion, String correo, String contrasenia, String rol) {
        this.nombre = nombre;
        this.identificacion = identificacion;
        this.correo = correo;
        this.contrasenia = contrasenia;
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

    public String getContrasenia() {
        return contrasenia;
    }

    public String getRol() {
        return rol;
    }
    
}
