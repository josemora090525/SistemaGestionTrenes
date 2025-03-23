public class User {

    private String name;
    private String id;
    private String mail;
    private String password;
    private String rol;
    
    public User(String name, String id, String mail, String password, String rol) {
        this.name = name;
        this.id = id;
        this.mail = mail;
        this.password = password;
        this.rol = rol;
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
    
}
