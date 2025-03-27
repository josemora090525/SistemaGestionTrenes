package Service;

public class Route {

    private String IdRuta;
    private String Origen;
    private String Destino;


    
    public Route(String idRuta, String origen, String destino) {
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
