package Service;

public class Wagon {

    private String IdVagon;
    private String Tipo;

    public Wagon(String idVagon, String tipo) {
        IdVagon = idVagon;
        Tipo = tipo;
    }

    public String getIdVagon() {
        return IdVagon;
    }

    public String getTipo() {
        return Tipo;
    }
}
