package Aunthentication;
import Actors.Usuario;
import AdministratorTasks.TablaHash;

public class SistemaAutenticacion {

    private TablaHash<Usuario> tablaUsuarios;
    private Usuario usuarioAutenticar;

    public SistemaAutenticacion(TablaHash<Usuario> tablaUsuarios) {
        this.tablaUsuarios = tablaUsuarios;
    }
    
    public boolean iniciarSesion(String mail, String password){
        Usuario usuario = tablaUsuarios.buscarValores(mail);
        
        if(usuario == null){
            System.out.println("Usuario no encontrado");
            return false;
        }
        
        else if(!usuario.getContraseña().equals(password)){
            System.out.println("Contraseña incorrecta");
            return false;
        }
        
        else{
            usuarioAutenticar = usuario;
            System.out.println("Sesion iniciada" + usuario.getCorreo());
            return true;
        }
    }
    
    public boolean cerrarSesion(){
        if(usuarioAutenticar != null){
            System.out.println("Sesion cerrada");
            usuarioAutenticar = null;
            return true;
        }
        
        else{
            System.out.println("No hay sesion activa");
            return false;
        }
    }

    public Usuario getUsuarioAutenticar() {
        return usuarioAutenticar;
    }

}
