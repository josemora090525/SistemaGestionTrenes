package Service;

public class WagonPassengers extends Wagon{

    private int Premiun;
    private int Ejecutiva;
    private int Standar;
    private int Pilotos;
    private int Tripulacion;

    public WagonPassengers(String idVagon, String tipo, int premiun, int ejecutiva, int standar, int pilotos,
            int tripulacion) {
        super(idVagon, tipo);
        Premiun = 4;
        Ejecutiva = 8;
        Standar = 22;
        Pilotos = 2;
        Tripulacion = 4;
    }

    public int getPremiun() {
        return Premiun;
    }

    public int getEjecutiva() {
        return Ejecutiva;
    }

    public int getStandar() {
        return Standar;
    }

    public int getPilotos() {
        return Pilotos;
    }

    public int getTripulacion() {
        return Tripulacion;
    }

}
