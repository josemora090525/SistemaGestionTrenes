package Service;
import AdministratorTasks.TablaHash;
import EmployeeTasks.ListaCircular;

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
        if (idEstacion == null || idEstacion.isEmpty()) {
            throw new IllegalArgumentException("El ID de la estación no puede estar vacío.");
        }
        this.idEstacion = idEstacion;
    }

    public String getNombreEstacion() {
        return nombreEstacion;
    }

    public void setNombreEstacion(String nombreEstacion) {
        if (nombreEstacion == null || nombreEstacion.isEmpty()) {
            throw new IllegalArgumentException("El nombre de la estación no puede estar vacío.");
        }
        this.nombreEstacion = nombreEstacion;
    }

    public ListaCircular<Tren> getListaTrenes() {
        return listaTrenes;
    }

    public TablaHash<String, Ruta> getRutas() {
        return rutas;
    }

    public void agregarTren(Tren tren) {
        if (tren == null) {
            throw new IllegalArgumentException("El tren no puede ser nulo.");
        }
        listaTrenes.agregar(tren);
        System.out.println("Tren " + tren.getId() + " agregado a la estación " + nombreEstacion + ".");
    }

    public void eliminarTren(String id) {
        if (id == null) {
            throw new IllegalArgumentException("El tren no puede ser nulo.");
        }
        boolean eliminado = listaTrenes.eliminar(id);
        if (eliminado) {
            System.out.println("Tren " + id.getId() + " eliminado de la estación " + nombreEstacion + ".");
        } else {
            System.out.println("El tren " + id.getId() + " no se encuentra en la estación " + nombreEstacion + ".");
        }
    }

    public void agregarRuta(String idRuta, Ruta ruta) {
        if (idRuta == null || ruta == null) {
            throw new IllegalArgumentException("El ID de la ruta y la ruta no pueden ser nulos.");
        }
        rutas.insertarValores(idRuta, ruta);
        System.out.println("Ruta " + idRuta + " agregada a la estación " + nombreEstacion + ".");
    }

    public void eliminarRuta(String idRuta) {
        if (idRuta == null || idRuta.isEmpty()) {
            throw new IllegalArgumentException("El ID de la ruta no puede estar vacío.");
        }
        rutas.eliminarValores(idRuta);
        System.out.println("Ruta " + idRuta + " eliminada de la estación " + nombreEstacion + ".");
    }

    public void publicarOrdenAbordaje() {
        if (listaTrenes.getTamanio() == 0) {
            System.out.println("No hay trenes en la estación " + nombreEstacion + ".");
            return;
        }

        System.out.println("Orden de abordaje en la estación " + nombreEstacion + ":");

        for (Tren tren : listaTrenes) {
            System.out.println("Tren " + tren.getId() + ":");
            tren.mostrarVagones();
        }
    }

    public void mostrarRutas() {
        System.out.println("Rutas en la estación " + nombreEstacion + ":");
        rutas.mostrarValores();
    }
}