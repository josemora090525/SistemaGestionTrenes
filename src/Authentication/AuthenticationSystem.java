import AdministratorTasks.HashTableUsers;
import Actors.User; 

public class AuthenticationSystem {

    private HashTableUsers tableUsers;
    private User authenticatedUser;

    public AuthenticationSystem(HashTableUsers tableUsers) {
        this.tableUsers = tableUsers;
    }
    
    public boolean logIn(String mail, String password){
        User user = tableUsers.search(mail);
        
        if(user == null){
            System.out.println("Usuario no encontrado");
            return false;
        }
        
        else if(!user.getPassword().equals(password)){
            System.out.println("Contraseña incorrecta");
            return false;
        }
        
        else{
            authenticatedUser = user;
            System.out.println("Sesion iniciada" + user.getMail());
            return true;
        }
    }
    
    public boolean logOut(){
        if(authenticatedUser != null){
            System.out.println("Sesion cerrada");
            authenticatedUser = null;
            return true;
        }
        
        else{
            System.out.println("No hay sesion activa");
            return false;
        }
    }
    
    public User getAuthenticatedUser(){
        return authenticatedUser;
    }

}
