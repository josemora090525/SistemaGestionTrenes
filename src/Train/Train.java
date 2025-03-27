package Train;

public abstract class Train {
    protected String id;
    protected int capacidad;
    protected boolean enMovimiento;
    
    public Train(String id, int capacidad) {
        this.id = id;
        this.capacidad = capacidad;
        this.enMovimiento = false;
    }
    
    public String getId() {
        return id;
    }
    
    public int getCapacidad() {
        return capacidad;
    }
    
    public boolean isEnMovimiento() {
        return enMovimiento;
    }
    
    public void iniciarViaje() {
        this.enMovimiento = true;
        System.out.println("El tren " + id + " ha iniciado su viaje.");
    }
    
    public void detenerViaje() {
        this.enMovimiento = false;
        System.out.println("El tren " + id + " se ha detenido.");
    }
    

    public abstract void mostrarInfoTren();
}
