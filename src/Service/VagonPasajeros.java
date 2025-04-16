package Service;
import Actors.Pasajero;
import EmployeeTasks.ColaPrioridad;

public class VagonPasajeros extends Vagon{

    private int premium;
    private int ejecutivo;
    private int estandar;
    private int pilotos;
    private int personal;
    private ColaPrioridad<Pasajero> colaAbordaje = new ColaPrioridad<>(40);
    private int asientos;

    public VagonPasajeros(String idVagon, int capacidad) {
        super(idVagon, capacidad);
        this.premium = 4;
        this.ejecutivo = 8;
        this.estandar = 22;
        this.pilotos = 2;
        this.personal = 4;
    }

    public int getPremium() {
        return premium;
    }

    public int getEjecutivo() {
        return ejecutivo;
    }

    public int getEstandar() {
        return estandar;
    }

    public int getPilotos() {
        return pilotos;
    }

    public int getPersonal() {
        return personal;
    }

    public ColaPrioridad<Pasajero> getColaAbordaje() {
        return colaAbordaje;
    }

    public int getAsientos() {
        return asientos;
    }

    public void setAsientos(int asientos) {
        this.asientos = asientos;
    }

    public void abordarPasajeros(Pasajero pasajero) {
        if (colaAbordaje.getCantidadElementos() >= getCapacidad()) {
            System.out.println("El vagón está lleno. No se puede agregar más pasajeros.");
            return;
        }
        colaAbordaje.encolar(pasajero);
    }

    public void asignarAsientos() {
    int asientoActual = 1; 
    Pasajero pasajero;

    while ((pasajero = colaAbordaje.desencolar()) != null) {
        pasajero.setNumeroAsiento(asientoActual++);
        System.out.println("Pasajero " + pasajero.getNombre() + " asignado al asiento " + pasajero.getNumeroAsiento());
    }
}

    public void desencolarPasajero() {
        Pasajero pasajero = colaAbordaje.desencolar();
        if (pasajero != null) {
            System.out.println("Pasajero desencolado: " + pasajero.getNombre());
        }
    }

    public void mostrarPasajeros() {
        System.out.println("Lista de pasajeros en la cola de abordaje:");
        colaAbordaje.mostrarCola();
    }

    public void mostrarOrdenAbordaje() {
        System.out.println("Orden de abordaje para el vagón:");
        while (colaAbordaje.getCantidadElementos() > 0) {
            Pasajero pasajero = colaAbordaje.desencolar();
            System.out.println("    " + pasajero.getNombre() + " - Prioridad: " + pasajero.getPrioridad());
        }
    }

}