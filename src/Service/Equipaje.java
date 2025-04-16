package Service;

import EmployeeTasks.InterfazID;

public class Equipaje implements InterfazID {

    private String idEquipaje;       
    private String idPasajero;     
    private double peso;          
    private String idVagonCarga;   
    private static final double MAXIMO_PESO = 80.0;    

    public Equipaje(String idEquipaje, String idPasajero, double peso, String idVagonCarga) {
        this.idEquipaje = idEquipaje;
        this.idPasajero= idPasajero;
        this.peso = validarPeso(peso); 
        this.idVagonCarga = idVagonCarga;
    }

    private static double validarPeso(double peso) { 
        if (peso > MAXIMO_PESO) {
            System.out.println("El peso excede el máximo permitido (" + MAXIMO_PESO + " kg). Ajustando al máximo permitido.");
            return MAXIMO_PESO;
        }
        return peso; 
    }

    @Override
    public String getId() {
        return idEquipaje;
    }

    public String getIdPasajero() {
        return idPasajero;
    }

    public double getPeso() {
        return peso;
    }

    public String getIdVagonCarga() {
        return idVagonCarga;
    }
}