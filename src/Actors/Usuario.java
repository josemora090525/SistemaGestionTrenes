package Actors;

public class Usuario {

    private String nombre;
    private String apellidos;
    private String telefono;
    private String identificacion;
    private String correo;
    private String contrasenia;
    private String rol;

    public Usuario(String nombre, String apellidos, String telefono, String identificacion, String correo, String contrasenia, String rol) {
        this.nombre = nombre;
        this.apellidos = apellidos;
        this.telefono = telefono;
        this.identificacion = identificacion;
        this.correo = correo;
        this.contrasenia = contrasenia;
        this.rol = rol;
    }

    public String getNombre() {
        return nombre;
    }

    public String getApellidos() {
        return apellidos;
    }

    public String getTelefono() {
        return telefono;
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

    @Override
    public String toString() {
        return "Usuario{" + "nombre=" + nombre + ", apellidos=" + apellidos + ", telefono=" + telefono + ", identificacion=" + identificacion + ", correo=" + correo + ", contrasenia=" + contrasenia + ", rol=" + rol + '}';
    }
    
}
