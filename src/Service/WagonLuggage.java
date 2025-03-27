package Service;

public class WagonLuggage extends Wagon{ 
    
    private static final int MAXMALETA = 2;
    private static final double MAXPESO = 80.0;
    private int MaletasActuales;
    private double PesoActual;

    public WagonLuggage(String idVagon, String tipo, int maletasActuales, double pesoActual) {
        super(idVagon, tipo);
        MaletasActuales = maletasActuales;
        PesoActual = pesoActual;
    }

    public static int getMaxmaleta() {
        return MAXMALETA;
    }

    public static double getMaxpeso() {
        return MAXPESO;
    }

    public int getMaletasActuales() {
        return MaletasActuales;
    }

    public double getPesoActual() {
        return PesoActual;
    }
}
