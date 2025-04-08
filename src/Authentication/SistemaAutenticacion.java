package Authentication;
import Actors.Usuario;
import AdministratorTasks.TablaHash;

public class SistemaAutenticacion {

    private TablaHash<String, Usuario> tablaUsuarios;
    private Usuario usuarioAutenticar;

    public SistemaAutenticacion(TablaHash<String, Usuario> tablaUsuarios) {
        this.tablaUsuarios = tablaUsuarios;
    }

    public boolean iniciarSesion(String correo, String password) {
        Usuario usuario = tablaUsuarios.buscarValores(correo);

        if (usuario == null) {
            System.out.println("Usuario no encontrado.");
            return false;
        }

        else if (!usuario.getContrasenia().equals(password)) {
            System.out.println("Contraseña incorrecta.");
            return false;
        }

        else {
            usuarioAutenticar = usuario;
            System.out.println("Sesión iniciada: " + usuario.getCorreo());
            return true;
        }
    }

    public boolean cerrarSesion() {
        if (usuarioAutenticar != null) {
            System.out.println("Sesión cerrada.");
            usuarioAutenticar = null;
            return true;
        }

        else {
            System.out.println("No hay sesión activa.");
            return false;
        }
    }

    public void registrarUsuario(Usuario usuario) {
        if (tablaUsuarios.contieneClave(usuario.getCorreo())) {
            System.out.println("El correo ya está registrado: " + usuario.getCorreo());
        }

        else {
            tablaUsuarios.insertarValores(usuario.getCorreo(), usuario);
            System.out.println("Usuario registrado: " + usuario.getCorreo());
        }
    }

    public boolean recuperarContrasenia(String correo) {
        Usuario usuario = tablaUsuarios.buscarValores(correo);

        if (usuario != null) {
            System.out.println("Contraseña para " + correo + ": " + usuario.getContrasenia());
            return true;
        }

        else {
            System.out.println("Correo no encontrado.");
            return false;
        }
    }

    public Usuario getUsuarioAutenticar() {
        return usuarioAutenticar;
    }

}
