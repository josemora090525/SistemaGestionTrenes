package Service;

public class Ruta {

    private String IdRuta;
    private String Origen;
    private String Destino;


    
    public Ruta(String idRuta, String origen, String destino) {
        IdRuta = idRuta;
        Origen = origen;
        Destino = destino;
    }

    public String getIdRuta() {
        return IdRuta;
    }



    public String getOrigen() {
        return Origen;
    }



    public String getDestino() {
        return Destino;
    }
}
