package Service;

import Actors.Pasajero;
import EmployeeTasks.ColaPrioridad;

public class VagonPasajeros extends Vagon{

    private int premium;
    private int ejecutivo;
    private int estandar;
    private int pilotos;
    private int personal;
    private ColaPrioridad<Pasajero> colaPasajeros = new ColaPrioridad<>(100);

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

    public void abordarPasajeros(Pasajero pasajero){
        colaPasajeros.encolar(pasajero);
    }

}
