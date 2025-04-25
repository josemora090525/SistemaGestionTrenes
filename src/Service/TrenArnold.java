package Service;

public class TrenArnold extends Tren {

    public TrenArnold(String id, int capacidadCarga, int kilometraje) {
        super(id, capacidadCarga, kilometraje, 32); 
    }

    @Override
    public void verificarNumeroVagones() {
        if (getVagones().getTamanio() > 32) { 
            System.out.println("La cantidad de vagones no es permitida para TrenArnold.");
        }   
        else {
            System.out.println("Cantidad de vagones correcta para TrenArnold.");
        }
    }

}