package Service;

import AdministratorTasks.TablaHash;
import EmployeeTasks.InterfazID;
import EmployeeTasks.ListaCircular;

public class Estacion implements InterfazID{
    
    private String idEstacion;
    private String nombreEstacion;
    private ListaCircular<Tren> listaTrenes;
    private TablaHash<String, Ruta> rutas;

    public Estacion(String idEstacion, String nombreEstacion) {
        if (idEstacion == null || idEstacion.isEmpty()) {
            throw new IllegalArgumentException("El ID de la estación no puede estar vacío.");
        }

        if (nombreEstacion == null || nombreEstacion.isEmpty()) {
            throw new IllegalArgumentException("El nombre de la estación no puede estar vacío.");
        }

        this.idEstacion = idEstacion;
        this.nombreEstacion = nombreEstacion;
        this.listaTrenes = new ListaCircular<>();
        this.rutas = new TablaHash<>(33);
    }

    @Override
    public String getId() {
        return idEstacion;
    }

    public String getNombreEstacion() {
        return nombreEstacion;
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
        if (id == null || id.isEmpty()) {
            throw new IllegalArgumentException("El ID del tren no puede estar vacío.");
        }

        Tren trenEliminado = listaTrenes.buscar(id);
        if (trenEliminado != null) {
            listaTrenes.eliminar(id);
            System.out.println("Tren " + id + " eliminado de la estación " + nombreEstacion + ".");
        } 
        
        else {
            System.out.println("El tren " + id + " no se encuentra en la estación " + nombreEstacion + ".");
        }
    }

    public void agregarRuta(String idRuta, Ruta ruta) {
        if (idRuta == null || ruta == null) {
            throw new IllegalArgumentException("El ID de la ruta y la ruta no pueden ser nulos.");
        }

        if (rutas.contieneClave(idRuta)) {
            System.out.println("La ruta con ID " + idRuta + " ya existe.");
        } 
        
        else {
            rutas.insertarValores(idRuta, ruta);
            System.out.println("Ruta " + idRuta + " agregada a la estación " + nombreEstacion + ".");
        }
    }

    public void eliminarRuta(String idRuta) {
        if (idRuta == null || idRuta.isEmpty()) {
            throw new IllegalArgumentException("El ID de la ruta no puede estar vacío.");
        }

        if (rutas.contieneClave(idRuta)) {
            rutas.eliminarValores(idRuta);
            System.out.println("Ruta " + idRuta + " eliminada de la estación " + nombreEstacion + ".");
        } 
        
        else {
            System.out.println("La ruta con ID " + idRuta + " no existe en la estación " + nombreEstacion + ".");
        }
    }
    
}
