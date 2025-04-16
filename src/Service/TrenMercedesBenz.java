package Service;

public class TrenMercedesBenz extends Tren {

    public TrenMercedesBenz(String id, int capacidadCarga, int kilometraje, int maximoVagones) {
        super(id, capacidadCarga, kilometraje, maximoVagones);
    }

    @Override
    public void verificarNumeroVagones() {
        if (getVagones().getTamanio() > 28) { 
            System.out.println("La cantidad de vagones no es permitida para TrenMercedesBenz.");
        } 

        else {
            System.out.println("Cantidad de vagones correcta para TrenMercedesBenz.");
        }
    }
    
}
