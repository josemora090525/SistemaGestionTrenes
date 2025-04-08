package Service;
import EmployeeTasks.ListaCircular;
import EmployeeTasks.Nodo;
import AdministratorTasks.TablaHash;

public class Estacion {

    private String idEstacion;
    private String nombreEstacion;
    private ListaCircular<Tren> listaTrenes;
    private TablaHash<String, Ruta> rutas;

    public Estacion(String idEstacion, String nombreEstacion) {
        this.idEstacion = idEstacion;
        this.nombreEstacion = nombreEstacion;
        this.listaTrenes = new ListaCircular<>();
        this.rutas = new TablaHash<>(33);
    }

    public String getIdEstacion() {
        return idEstacion;
    }

    public void setIdEstacion(String idEstacion) {
        this.idEstacion = idEstacion;
    }

    public String getNombreEstacion() {
        return nombreEstacion;
    }

    public void setNombreEstacion(String nombreEstacion) {
        this.nombreEstacion = nombreEstacion;
    }

    public ListaCircular<Tren> getListaTrenes() {
        return listaTrenes;
    }

    public void setListaTrenes(ListaCircular<Tren> listaTrenes) {
        this.listaTrenes = listaTrenes;
    }

    public TablaHash<String, Ruta> getRutas() {
        return rutas;
    }

    public void setRutas(TablaHash<String, Ruta> rutas) {
        this.rutas = rutas;
    }

    public void agregarTren(Tren tren) {
        listaTrenes.agregar(tren);
        System.out.println("Tren " + tren.getId() + " agregado a la estación " + nombreEstacion + ".");
    }

    public void eliminarTren(Tren tren) {
        boolean eliminado = listaTrenes.eliminar(tren);
        if (eliminado) {
            System.out.println("Tren " + tren.getId() + " eliminado de la estación " + nombreEstacion + ".");
        } else {
            System.out.println("El tren " + tren.getId() + " no se encuentra en la estación " + nombreEstacion + ".");
        }
    }

    public void agregarRuta(String idRuta, Ruta ruta) {
        rutas.insertarValores(idRuta, ruta);
        System.out.println("Ruta " + idRuta + " agregada a la estación " + nombreEstacion + ".");
    }

    public void eliminarRuta(String idRuta) {
        rutas.eliminarValores(idRuta);
        System.out.println("Ruta " + idRuta + " eliminada de la estación " + nombreEstacion + ".");
    }

    public void publicarOrdenAbordaje() {
        if (listaTrenes.getTamanio() == 0) {
            System.out.println("No hay trenes en la estación " + nombreEstacion + ".");
            return;
        }

        System.out.println("Orden de abordaje en la estación " + nombreEstacion + ":");
        Nodo<Tren> actual = listaTrenes.getCabeza();

        do {
            Tren tren = actual.getElemento();
            System.out.println("Tren " + tren.getId() + ":");
            for (int ii = 0; ii < tren.getVagones().totalElementos(); ii++) {
                Vagon vagon = tren.getVagones().peek();

                if (vagon instanceof VagonPasajeros) {
                    VagonPasajeros vagonPasajeros = (VagonPasajeros) vagon;
                    System.out.println("Vagón " + vagonPasajeros.getIdVagon() + ":");

                    if (vagonPasajeros.getColaAbordaje().getCantidadElementos() == 0) {
                        System.out.println("Este vagón no tiene pasajeros en cola.");
                    } else {
                        vagonPasajeros.mostrarOrdenAbordaje();
                    }
                } else {
                    System.out.println("Vagón " + vagon.getIdVagon() + ": No es un vagón de pasajeros.");
                }
            }

            actual = actual.getSiguiente();
        } while (actual != listaTrenes.getCabeza());
    }
}