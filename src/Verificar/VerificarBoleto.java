package Verificar;
import Service.Boleto;
import Actors.Pasajero;
import EmployeeTasks.ListaDoblementeEnlazada;

public class VerificarBoleto {

    private ListaDoblementeEnlazada<Boleto> boletosValidados;

    public VerificarBoleto() {
        this.boletosValidados = new ListaDoblementeEnlazada<>();
    }

    public boolean verificarIdentidad(Pasajero pasajero, Boleto boleto) {
        if (boleto.getIdPasajero().equals(pasajero.getIdentificacion())) {
            System.out.println("Identidad verificada: " + pasajero.getNombre() + " " + pasajero.getApellidos());
            return true;
        }
        System.out.println("Identidad no coincide con el boleto.");
        return false;
    }

    public boolean revisarEquipaje(Boleto boleto) {
        if (boleto.getPesoEquipaje() <= 160) { 
            System.out.println("Equipaje dentro del límite permitido.");
            return true;
        }
        System.out.println("Equipaje excede el límite permitido.");
        return false;
    }

    public void validarBoletoEnTrayecto(Boleto boleto) {
        if (boletosValidados.buscar(boleto.getId()) == null) {
            boletosValidados.agregarAlFinal(boleto);
            System.out.println("Boleto validado durante el trayecto: " + boleto.getId());
        } 
        else {
            System.out.println("El boleto ya fue validado anteriormente.");
        }
    }

    public void mostrarBoletosValidados() {
        System.out.println("\nLista de boletos validados:");
        boletosValidados.mostrarElementos();
    }

    public void eliminarBoletoValidado(String idBoleto) {
        boolean eliminado = boletosValidados.eliminar(idBoleto);
        if (eliminado) {
            System.out.println("Boleto con ID " + idBoleto + " eliminado de la lista de boletos validados.");
        } 
        else {
            System.out.println("No se encontró el boleto con ID " + idBoleto + " en la lista.");
        }
    }

}
