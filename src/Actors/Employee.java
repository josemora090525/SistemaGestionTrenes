public class Employee extends AbstractSession{

    private String name;
    private String id;
    private String mail;
    private String password;
    private boolean login;

    public Employee(String name, String id, String mail, String password) {
        this.name = name;
        this.id = id;
        this.mail = mail;
        this.password = password;
        login = false;
    }

    public String getName() {
        return name;
    }

    public String getId() {
        return id;
    }

    public String getMail() {
        return mail;
    }

    public String getPassword() {
        return password;
    }

    @Override
    public boolean logIn(String mail, String password) {
        if(!this.mail.equals(mail) || this.password.equals(password)) {
            System.out.println("Correo o contraseña incorrectos");
            return false;
        }

        else if(this.mail.equals(mail) && this.password.equals(password)){
            login = true;
            System.out.println("Sesion iniciada");
            return true;
        }
        return false;
    }

    @Override
    public boolean logOut() {
        if(login){
            login = false;
            System.out.println("Sesion cerrada");
            return true;
        }

        else{
            System.out.println("No hay ninguna sesion activa");
            return false;
        }
    }
}
