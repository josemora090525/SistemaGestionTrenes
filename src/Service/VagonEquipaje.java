package Service;
import EmployeeTasks.Pila;

public class VagonEquipaje extends Vagon{ 
    
    private Pila<Equipaje> pilaEquipaje;  
    private double pesoActual;         
    private int capacidadMaximaEquipaje; 

    public VagonEquipaje(String idVagon, int capacidad) {
        super(idVagon, capacidad);
        this.pilaEquipaje = new Pila(); 
        this.pesoActual = 0.0;
        this.capacidadMaximaEquipaje = 2; 
    }
    
    public void agregarEquipaje(Equipaje equipaje) {
        if (pilaEquipaje.getTamanio() < capacidadMaximaEquipaje && (pesoActual + equipaje.getPeso() <= capacidadMaximaEquipaje * 80.0)) {
            pilaEquipaje.push(equipaje);
            pesoActual += equipaje.getPeso();
            System.out.println("Equipaje agregado al vagón: " + equipaje.getIdEquipaje());
        } else {
            System.out.println("No se puede agregar más equipaje. Capacidad o peso excedido.");
        }
    }

    public Equipaje retirarEquipaje() {
        Equipaje equipaje = pilaEquipaje.pop();
        if (equipaje != null) {
            pesoActual -= equipaje.getPeso();
            System.out.println("Equipaje retirado: " + equipaje.getIdEquipaje());
        }
        return equipaje;
    }

    public Equipaje obtenerEquipaje() {
        return pilaEquipaje.peek();
    }

    public Pila<Equipaje> getPilaEquipaje() {
        return pilaEquipaje;
    }

    public double getPesoActual() {
        return pesoActual;
    }

    public void setPesoActual(double pesoActual) {
        this.pesoActual = pesoActual;
    }

    public int getCapacidadMaximaEquipaje() {
        return capacidadMaximaEquipaje;
    }

    public void setCapacidadMaximaEquipaje(int capacidadMaximaEquipaje) {
        this.capacidadMaximaEquipaje = capacidadMaximaEquipaje;
    }

}
