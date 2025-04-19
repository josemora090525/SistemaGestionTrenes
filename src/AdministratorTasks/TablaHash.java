package AdministratorTasks;

import java.util.ArrayList;
import java.util.List;

public class TablaHash <K, V> {

    private int tamanio;
    private K[] claves;
    private V[] valores;

    public TablaHash(int tamanio) {
        this.tamanio = tamanio;
        claves = (K[]) new Object[tamanio];
        valores = (V[]) new Object[tamanio];
    }

    private int hashFunction(K clave) {
        int hashCode = clave.hashCode();
        return Math.abs(hashCode % tamanio);
    }

    public boolean contieneClave(K clave) {
        int indice = hashFunction(clave);

        while (claves[indice] != null) {
            if (claves[indice].equals(clave)) {
                return true;
            }
            indice = (indice + 1) % tamanio;
        }
        return false;
    }

    public List<K> obtenerClaves() {
        List<K> listaClaves = new ArrayList<>();
        for (K clave : claves) {
            if (clave != null) {
                listaClaves.add(clave);
            }
        }
        return listaClaves;
    }

    public void insertarValores(K clave, V valor) {
        if (contieneClave(clave)) {
            System.out.println("Clave ya existente: " + clave);
            return;
        }

        int indice = hashFunction(clave);

        while (claves[indice] != null && !claves[indice].equals(clave)) {
            indice = (indice + 1) % tamanio;
        }

        claves[indice] = clave;
        valores[indice] = valor;

        System.out.println("Valor insertado: Clave=" + clave + ", Valor=" + valor);
    }

    public V buscarValores(K clave) {
        int indice = hashFunction(clave);

        while (claves[indice] != null) {
            if (claves[indice].equals(clave)) {
                System.out.println("Valor encontrado para clave " + clave + ": " + valores[indice]);
                return valores[indice];
            }
            indice = (indice + 1) % tamanio;
        }

        System.out.println("Clave " + clave + " no encontrada.");
        return null;
    }

    public void eliminarValores(K clave) {
        int indice = hashFunction(clave);

        while (claves[indice] != null) {
            if (claves[indice].equals(clave)) {
                claves[indice] = null;
                valores[indice] = null;
                System.out.println("Clave eliminada: " + clave);
                return;
            }
            indice = (indice + 1) % tamanio;
        }
        System.out.println("Clave " + clave + " no encontrada.");
    }

    public void mostrarValores() {
        System.out.println("Contenido de la tabla hash:");
        for (int ii = 0; ii < tamanio; ii++) {
            if (claves[ii] != null) {
                System.out.println("Índice " + ii + ": Clave=" + claves[ii] + ", Valor=" + valores[ii]);
            }
        }
    }
    
}
