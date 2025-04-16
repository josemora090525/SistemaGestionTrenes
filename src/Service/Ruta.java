package Service;

public class Ruta {

    private String idRuta; 
    private String origen;
    private String destino;

    public Ruta(String idRuta, String origen, String destino) {
        this.idRuta = idRuta;
        this.origen = origen;
        this.destino = destino;
    }

    public String getIdRuta() {
        return idRuta;
    }

    public String getOrigen() {
        return origen;
    }

    public String getDestino() {
        return destino;
    }
}