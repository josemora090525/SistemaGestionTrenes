package Service;

public class MaquinaVenta {

    private Grafos grafos;
    private ListaDoblementeEnlazada<Boleto> listaBoletos;
    private TablaHash<Ruta, String> rutas;

    public MaquinaVenta(Grafos grafos, int capacidadRutas) {
        this.grafos = grafos;
        this.listaBoletos = new ListaDoblementeEnlazada<>();
        this.rutas = new TablaHash<>(capacidadRutas);
    }

    public void registrarRuta(Ruta ruta) {
        if (!rutas.contieneClave(ruta)) {
            rutas.insertarValores(ruta, ruta.getOrigen() + " → " + ruta.getDestino());
            System.out.println("Ruta registrada: " + ruta.getOrigen() + " → " + ruta.getDestino());
        }
        else {
            System.out.println("La ruta ya existe: " + ruta.getOrigen() + " → " + ruta.getDestino());
        }
    }

    public void iniciarCompraBoleto(Pasajero pasajero) {
        Scanner scanner = new Scanner(System.in);

        System.out.println("\n?Bienvenido, " + pasajero.getNombre() + "! Comencemos con la compra de tu boleto.");
        System.out.println("Seleccione una ruta para su viaje:");

        Ruta rutaSeleccionada = seleccionarRuta(scanner);
        if (rutaSeleccionada == null) {
            System.out.println("Error: No seleccionó una ruta válida.");
            return;
        }

        System.out.println("\nCalculando la ruta óptima...");
        Estacion estacionOrigen = grafos.buscarEstacion(rutaSeleccionada.getOrigen());
        Estacion estacionDestino = grafos.buscarEstacion(rutaSeleccionada.getDestino());
        int distanciaOptima = grafos.calcularDistanciaEntre(estacionOrigen, estacionDestino);

        System.out.println("\nSeleccione el tipo de boleto:");
        System.out.println("1. Premium\n2. Ejecutivo\n3. Estándar");
        int opcionBoleto = scanner.nextInt();
        String tipoBoleto = obtenerTipoBoleto(opcionBoleto);
        double precio = calcularPrecio(tipoBoleto, distanciaOptima);

        Boleto nuevoBoleto = new Boleto(generarIdRegistro(), generarIdRegistro(), LocalDateTime.now(), LocalDateTime.now().plusHours(2),
                LocalDateTime.now().plusHours(2 + (distanciaOptima / 50)), pasajero.getIdentificacion(),  pasajero.getNombre(),
                pasajero.getApellidos(), "DNI", "Sin dirección", pasajero.getTelefono(), "TrenAsignado",
                rutaSeleccionada.getOrigen() + " - " + rutaSeleccionada.getDestino(), tipoBoleto, precio,
                "", "", "", "", 0, ""
        );

        listaBoletos.agregarAlFinal(nuevoBoleto);
        System.out.println("\n¡Boleto comprado con éxito!");
        mostrarDetallesBoleto(nuevoBoleto);
    }

    private Ruta seleccionarRuta(Scanner scanner) {
        System.out.println("\nRutas disponibles:");
        rutas.mostrarValores();

        System.out.println("Ingrese el nombre de la ruta:");
        scanner.nextLine();
        String seleccion = scanner.nextLine();

        for (Ruta ruta : rutas.obtenerClaves()) {
            if ((ruta.getOrigen() + " → " + ruta.getDestino()).equals(seleccion)) {
                return ruta;
            }
        }

        System.out.println("Ruta no encontrada.");
        return null;
    }

    public void recomendarRutaMasCorta(Estacion origen, Estacion destino) {
        System.out.println("Calculando la ruta más corta desde " + origen.getNombreEstacion() + " hacia " + destino.getNombreEstacion() + "...");

        ArrayList<Integer> distancias = grafos.aplicarDijkstra(origen);
        int indiceDestino = grafos.getEstaciones().buscarValores(destino);

        if (distancias != null && indiceDestino >= 0 && indiceDestino < distancias.size()) {
            int distanciaOptima = distancias.get(indiceDestino);
            System.out.println("Ruta más corta: " + distanciaOptima + " km.");
            System.out.println("Costo estimado: " + calcularPrecio("Estandar", distanciaOptima));
        }
        else {
            System.out.println("No se pudo calcular la ruta más corta.");
        }
    }

    private String obtenerTipoBoleto(int opcion) {
        return switch (opcion) {
            case 1 -> "Premium";
            case 2 -> "Ejecutivo";
            default -> "Estandar";
        };
    }

    private double calcularPrecio(String tipoBoleto, int distancia) {
        double baseTarifaPorKm = 0.5;

        double precioBase = distancia * baseTarifaPorKm;

        return switch (tipoBoleto) {
            case "Premium" -> precioBase * 1.5;
            case "Ejecutivo" -> precioBase * 1.2;
            default -> precioBase;
        };
    }

    private String generarIdRegistro() {
        return "B-" + System.currentTimeMillis();
    }

    private void mostrarDetallesBoleto(Boleto boleto) {
        System.out.println("Detalles del boleto:");
        System.out.println("ID Registro: " + boleto.getId());
        System.out.println("Fecha y hora de compra: " + boleto.getFechaHoraCompra());
        System.out.println("Fecha y hora de salida: " + boleto.getFechaHoraSalida());
        System.out.println("Fecha y hora de llegada estimada: " + boleto.getFechaHorallegada());
        System.out.println("Pasajero: " + boleto.getNombres() + " " + boleto.getApelllidos());
        System.out.println("Tipo de identificación: " + boleto.getTipoIdentificacion());
        System.out.println("Identificación: " + boleto.getIdPasajero());
        System.out.println("Dirección: " + boleto.getDireccion());
        System.out.println("Teléfono: " + boleto.getTelefono());
        System.out.println("ID del tren: " + boleto.getIdTren());
        System.out.println("Ruta: " + boleto.getLugar());
        System.out.println("Categoría del pasajero: " + boleto.getCategoriaPasajero());
        System.out.println("Precio: $" + boleto.getValorPasaje());
        System.out.println("Contacto de emergencia: " + boleto.getContactoNombres() + " " + boleto.getContactoApellidos() +
                " | Teléfono: " + boleto.getContactoTelefono());
        System.out.println("ID del equipaje: " + boleto.getIdEquipaje());
        System.out.println("Peso del equipaje: " + boleto.getPesoEquipaje() + " kg");
        System.out.println("Vagón de carga asignado: " + boleto.getIdVagonCarga());
        System.out.println();
    }

    public void mostrarBoletosVendidos() {
        System.out.println("\nLista de boletos vendidos:");
        listaBoletos.mostrarElementos();
    }

    public void buscarBoleto(String id) {
        Boleto boleto = listaBoletos.buscar(id);
        if (boleto != null) {
            System.out.println("\nBoleto encontrado:");
            mostrarDetallesBoleto(boleto);
        }

        else {
            System.out.println("\nNo se encontró ningún boleto con el ID: " + id);
        }
    }

    public void cancelarBoleto(String id) {
        boolean eliminado = listaBoletos.eliminar(id);
        if (eliminado) {
            System.out.println("\nBoleto con ID " + id + " ha sido cancelado.");
        }

        else {
            System.out.println("\nNo se pudo cancelar el boleto, ID no encontrado.");
        }
    }

    public void mostrarRutasRegistradas() {
        System.out.println("\nRutas registradas:");
        rutas.mostrarValores();
    }

    public void mostrarRutasDisponibles() {
        System.out.println("\nRutas disponibles:");
        for (Ruta ruta : rutas.obtenerClaves()) {
            System.out.println("" + ruta.getOrigen() + " → " + ruta.getDestino());
        }
    }

    public void mostrarHorariosPorRuta(String idRuta) {
        System.out.println("Horarios disponibles para la ruta " + idRuta + ":");

        ListaDoblementeEnlazada<Boleto> boletos = obtenerBoletosPorRuta(idRuta);
        if (boletos.getTamanio() == 0) {
            System.out.println("No hay horarios disponibles para esta ruta.");
            return;
        }
        for (Boleto boleto : boletos) {
            System.out.println("Salida: " + boleto.getFechaHoraSalida() + " | Llegada: " + boleto.getFechaHorallegada());
        }
    }

    public ListaDoblementeEnlazada<Boleto> obtenerBoletosPorRuta(String idRuta) {
        ListaDoblementeEnlazada<Boleto> boletosPorRuta = new ListaDoblementeEnlazada<>();

        for (Boleto boleto : listaBoletos) {
            if (boleto.getIdTren().equals(idRuta)) {
                boletosPorRuta.agregarAlFinal(boleto);
            }
        }

        return boletosPorRuta;
    }

}
