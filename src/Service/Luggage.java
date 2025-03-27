package Service;

public class Luggage {

    private String IdEquipaje;
    private String IdPasajero;
    private double Peso;
    private String IdVagonCarga;

    
    public Luggage(String idEquipaje, String idPasajero, double peso, String idVagonCarga) {
        IdEquipaje = idEquipaje;
        IdPasajero = idPasajero;
        Peso = peso;
        IdVagonCarga = idVagonCarga;
    }


    public String getIdEquipaje() {
        return IdEquipaje;
    }


    public String getIdPasajero() {
        return IdPasajero;
    }


    public double getPeso() {
        return Peso;
    }


    public String getIdVagonCarga() {
        return IdVagonCarga;
    }
}

