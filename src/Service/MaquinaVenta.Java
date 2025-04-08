package Service;

public class MaquinaVenta {

    private ListaDoblementeEnlazada<Boleto> listaBoletos;

    public MaquinaVenta() {
        listaBoletos = new ListaDoblementeEnlazada<>();
    }

    // Agregar un boleto a la lista
    public void agregarBoleto(Boleto boleto) {
        listaBoletos.agregarAlFinal(boleto);
        System.out.println("Boleto agregado: " + boleto.getIdRegistro());
    }

    // Eliminar un boleto por su ID de registro
    public void eliminarBoleto(String idRegistro) {
        Boleto boletoAEliminar = buscarBoletoPorId(idRegistro);
        if (boletoAEliminar != null) {
            listaBoletos.eliminar(boletoAEliminar);
            System.out.println("Boleto eliminado: " + idRegistro);
        } else {
            System.out.println("Boleto no encontrado: " + idRegistro);
        }
    }

    public Boleto buscarBoletoPorId(String idRegistro) {
        Nodo<Boleto> nodoActual = listaBoletos.buscar(new BoletoDummy(idRegistro));
        if (nodoActual != null) {
            System.out.println("Boleto encontrado: " + nodoActual.getElemento().getIdRegistro());
            return nodoActual.getElemento();
        } else {
            System.out.println("Boleto no encontrado: " + idRegistro);
            return null;
        }
    }

    // Mostrar todos los boletos en la lista
    public void mostrarBoletos() {
        listaBoletos.mostrarElementos();
    }

    // Generar un boleto de manera dinámica
    public Boleto generarBoleto(String idRegistro, String idPasajero, String nombres, String apellidos,
                                LocalDateTime fechaHoraCompra, LocalDateTime fechaHoraSalida,
                                LocalDateTime fechaHoraLlegada, String idTren, String lugar,
                                String categoriaPasajero, double valorPasaje) {
        return new Boleto(
                idRegistro, fechaHoraCompra, fechaHoraSalida, fechaHoraLlegada, idPasajero, nombres, apellidos,
                "Cédula", "Dirección por defecto", "123456789", idTren, lugar, categoriaPasajero, valorPasaje,
                "Nombres de Contacto", "Apellidos de Contacto", "987654321", "ID-EQUIPAJE", 0.0, "ID-VAGON-CARGA"
        );
    }

    public Boleto venderBoleto(Boleto boleto) {
        // Buscar el tren y horario por ID
        Tren tren = buscarTrenPorId(boleto.getIdTren());
        if (tren == null) {
            System.out.println("Tren no encontrado: " + boleto.getIdTren());
            return null;
        }

        // Buscar un vagón de pasajeros con espacio
        VagonPasajeros vagonDisponible = null;
        for (Vagon vagon : tren.getVagones().totalElementos()) {
            if (vagon instanceof VagonPasajeros) {
                VagonPasajeros vagonPasajeros = (VagonPasajeros) vagon;
                if (vagonPasajeros.getColaAbordaje().getCantidadElementos() < vagonPasajeros.getCapacidad()) {
                    vagonDisponible = vagonPasajeros;
                    break;
                }
            }
        }

        if (vagonDisponible == null) {
            System.out.println("No hay asientos disponibles para el tren: " + boleto.getIdTren());
            return null;
        }

        Pasajero pasajero = new Pasajero(boleto.getIdPasajero(), boleto.getNombres(), boleto.getApelllidos(), boleto.getTipoIdentificacion(), boleto.getDireccion(), boleto.getTelefono(), boleto.getCategoriaPasajero());

        vagonDisponible.getColaAbordaje().encolar(pasajero);

        System.out.println("✅ Boleto vendido a " + pasajero.getNombre() +
                " - Tren: " + boleto.getIdTren() +
                " - Salida: " + boleto.getFechaHoraSalida());

        return boleto;
    }

}
