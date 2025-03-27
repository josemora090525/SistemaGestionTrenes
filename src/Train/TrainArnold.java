package Train;

public class TrainArnold extends Train {
    private int velocidadMaxima;
    private boolean servicioLujo;
    
    public TrainArnold(String id, int capacidad, int velocidadMaxima, boolean servicioLujo) {    
        super(id, capacidad);
        this.velocidadMaxima = velocidadMaxima;
        this.servicioLujo = servicioLujo;
    }
    
    public int getVelocidadMaxima() {
        return velocidadMaxima;
    }
    
    public boolean isServicioLujo() {
        return servicioLujo;
    }
    
    public void activarServicioLujo() {
        if (this.servicioLujo) {
            System.out.println("Servicio de lujo activado en el Tren Arnold " + id);
        } else {
            System.out.println("Este Tren Arnold no dispone de servicio de lujo");
        }
    }
    
    @Override
    public void mostrarInfoTren() {
        System.out.println("Tren Arnold - ID: " + id);
        System.out.println("Capacidad: " + capacidad + " pasajeros");
        System.out.println("Velocidad máxima: " + velocidadMaxima + " km/h");
        System.out.println("Servicio de lujo: " + (servicioLujo ? "Sí" : "No"));
    }
} 