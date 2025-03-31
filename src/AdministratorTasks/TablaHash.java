package AdministratorTasks;

public class TablaHash <T> {

    private int tamanio;
    private String[] claves;
    private String[] valores;

    public TablaHash(int tamanio) {
        this.tamanio = tamanio;
        claves = new String[tamanio];
        valores = new String[tamanio];
    }

    private int hashFunction(String clave) {
        int hashCode = clave.hashCode();
        return Math.abs(hashCode % tamanio);
    }

    public void insertarValores(String clave, String valor) {
        int indice = hashFunction(clave);
        while (claves[indice] != null && !claves[indice].equals(clave)) {
            indice = (indice + 1) % tamanio;
        }
        claves[indice] = clave;
        valores[indice] = valor;
    }

    public T buscarValores(String clave) {
        int indice = hashFunction(clave);

        while (claves[indice] != null) {
            if (claves[indice].equals(clave)) {
                System.out.println("Valores encontrados: " + valores[indice]);
                return (T) valores[indice];
            }
            indice = (indice + 1) % tamanio;
        }

        System.out.println("Valores no encontrados");
        return null;
    }

    public void eliminarValores(String clave) {
        int indice = hashFunction(clave);
        while (claves[indice] != null) {
            if (claves[indice].equals(clave)) {
                claves[indice] = null;
                valores[indice] = null;
                System.out.println("Eliminado " + clave + " del índice " + indice);
                return;
            }
            indice = (indice + 1) % tamanio;
        }
        System.out.println("Valores no encontrados");
    }

    public void mostrarValores() {
        for (int i = 0; i < tamanio; i++) {
            if (claves[i] != null) {
                System.out.println("Índice " + i + ": " + claves[i] + ", " + valores[i]);
            }
        }
    }
    
}
