using System;
using System.Collections.Generic;
using ProyectoEstructuras.Códigos.TareasEmpleado;
using ProyectoEstructuras.Códigos.TareasAdministrador;
using ProyectoEstructuras.Códigos.Servicio;
using ProyectoEstructuras.Códigos.Actores;

namespace ProyectoEstructuras.Códigos.Servicio
{
    public class MaquinaVenta
    {
        private Grafos grafos;
        private ListaDoblementeEnlazada<Boleto> listaBoletos;
        private TablaHash<Ruta, string> rutas;

        public MaquinaVenta(Grafos grafos, int capacidadRutas)
        {
            this.grafos = grafos;
            this.listaBoletos = new ListaDoblementeEnlazada<Boleto>();
            this.rutas = new TablaHash<Ruta, string>(capacidadRutas);
        }

        public void RegistrarRuta(Ruta ruta)
        {
            if (!rutas.ContieneClave(ruta))
            {
                rutas.InsertarValores(ruta, ruta.Origen + " → " + ruta.Destino);
                Console.WriteLine($"Ruta registrada: {ruta.Origen} → {ruta.Destino}");
            }
            else
            {
                Console.WriteLine($"La ruta ya existe: {ruta.Origen} → {ruta.Destino}");
            }
        }

        public void IniciarCompraBoleto(Pasajero pasajero)
        {
            Console.WriteLine($"\nBienvenido, {pasajero.Nombre}! Comencemos con la compra de tu boleto.");
            Console.WriteLine("Seleccione una ruta para su viaje:");

            Ruta rutaSeleccionada = SeleccionarRuta();
            if (rutaSeleccionada == null)
            {
                Console.WriteLine("Error: No seleccionó una ruta válida.");
                return;
            }

            Console.WriteLine("\nCalculando la ruta óptima...");
            Estacion estacionOrigen = grafos.BuscarEstacion(rutaSeleccionada.Origen);
            Estacion estacionDestino = grafos.BuscarEstacion(rutaSeleccionada.Destino);
            int distanciaOptima = grafos.CalcularDistanciaEntre(estacionOrigen, estacionDestino);

            Console.WriteLine("\nSeleccione el tipo de boleto:");
            Console.WriteLine("1. Premium\n2. Ejecutivo\n3. Estándar");
            int opcionBoleto = int.Parse(Console.ReadLine());
            string tipoBoleto = ObtenerTipoBoleto(opcionBoleto);
            double precio = CalcularPrecio(tipoBoleto, distanciaOptima);

            Boleto nuevoBoleto = new Boleto(
                GenerarIdRegistro(),
                DateTime.Now,
                DateTime.Now.AddHours(2),
                DateTime.Now.AddHours(2 + (distanciaOptima / 50)),
                pasajero.Identificacion,
                pasajero.Nombre,
                pasajero.Apellidos,
                "DNI",
                "Sin dirección",
                pasajero.Telefono,
                "TrenAsignado",
                rutaSeleccionada.Origen + " - " + rutaSeleccionada.Destino,
                tipoBoleto,
                precio,
                "",
                "",
                "",
                "",
                0,
                ""
            );

            listaBoletos.AgregarAlFinal(nuevoBoleto);
            Console.WriteLine("\n¡Boleto comprado con éxito!");
            MostrarDetallesBoleto(nuevoBoleto);
        }

        private Ruta SeleccionarRuta()
        {
            Console.WriteLine("\nRutas disponibles:");
            rutas.MostrarValores();

            Console.WriteLine("Ingrese el nombre de la ruta:");
            string seleccion = Console.ReadLine();

            foreach (Ruta ruta in rutas.ObtenerClaves())
            {
                if ((ruta.Origen + " → " + ruta.Destino) == seleccion)
                {
                    return ruta;
                }
            }

            Console.WriteLine("Ruta no encontrada.");
            return null;
        }

        public void RecomendarRutaMasCorta(Estacion origen, Estacion destino)
        {
            Console.WriteLine($"Calculando la ruta más corta desde {origen.NombreEstacion} hacia {destino.NombreEstacion}...");

            List<int> distancias = grafos.AplicarDijkstra(origen);
            int indiceDestino = grafos.Estaciones.BuscarValores(destino);

            if (distancias != null && indiceDestino >= 0 && indiceDestino < distancias.Count)
            {
                int distanciaOptima = distancias[indiceDestino];
                Console.WriteLine($"Ruta más corta: {distanciaOptima} km.");
                Console.WriteLine($"Costo estimado: {CalcularPrecio("Estandar", distanciaOptima)}");
            }
            else
            {
                Console.WriteLine("No se pudo calcular la ruta más corta.");
            }
        }

        private string ObtenerTipoBoleto(int opcion)
        {
            if (opcion == 1)
            {
                return "Premium";
            }
            else if (opcion == 2)
            {
                return "Ejecutivo";
            }
            else if (opcion == 3)
            {
                return "Estandar";
            }
            else
            {
                return "Estandar"; 
            }
        }

        private double CalcularPrecio(string tipoBoleto, int distancia)
        {
            double baseTarifaPorKm = 0.5;
            double precioBase = distancia * baseTarifaPorKm;

            if (tipoBoleto == "Premium")
            {
                return precioBase * 1.5;
            }
            else if (tipoBoleto == "Ejecutivo")
            {
                return precioBase * 1.2;
            }
            else
            {
                return precioBase; 
            }
        }

        private string GenerarIdRegistro()
        {
            return $"B-{DateTimeOffset.Now.ToUnixTimeMilliseconds()}";
        }

        private void MostrarDetallesBoleto(Boleto boleto)
        {
            Console.WriteLine("Detalles del boleto:");
            Console.WriteLine($"ID Registro: {boleto.GetId()}");
            Console.WriteLine($"Fecha y hora de compra: {boleto.FechaHoraCompra}");
            Console.WriteLine($"Fecha y hora de salida: {boleto.FechaHoraSalida}");
            Console.WriteLine($"Fecha y hora de llegada estimada: {boleto.FechaHoraLlegada}");
            Console.WriteLine($"Pasajero: {boleto.Nombres} {boleto.Apellidos}");
            Console.WriteLine($"Tipo de identificación: {boleto.TipoIdentificacion}");
            Console.WriteLine($"Identificación: {boleto.IdPasajero}");
            Console.WriteLine($"Dirección: {boleto.Direccion}");
            Console.WriteLine($"Teléfono: {boleto.Telefono}");
            Console.WriteLine($"ID del tren: {boleto.IdTren}");
            Console.WriteLine($"Ruta: {boleto.Lugar}");
            Console.WriteLine($"Categoría del pasajero: {boleto.CategoriaPasajero}");
            Console.WriteLine($"Precio: ${boleto.ValorPasaje}");
            Console.WriteLine($"Contacto de emergencia: {boleto.ContactoNombres} {boleto.ContactoApellidos} | Teléfono: {boleto.ContactoTelefono}");
            Console.WriteLine($"ID del equipaje: {boleto.IdEquipaje}");
            Console.WriteLine($"Peso del equipaje: {boleto.PesoEquipaje} kg");
            Console.WriteLine($"Vagón de carga asignado: {boleto.IdVagonCarga}");
            Console.WriteLine();
        }

        public void MostrarBoletosVendidos()
        {
            Console.WriteLine("\nLista de boletos vendidos:");
            listaBoletos.MostrarElementos();
        }

        public void BuscarBoleto(string id)
        {
            Boleto boleto = listaBoletos.Buscar(id);
            if (boleto != null)
            {
                Console.WriteLine("\nBoleto encontrado:");
                MostrarDetallesBoleto(boleto);
            }
            else
            {
                Console.WriteLine($"\nNo se encontró ningún boleto con el ID: {id}");
            }
        }

        public void CancelarBoleto(string id)
        {
            bool eliminado = listaBoletos.Eliminar(id);
            if (eliminado)
            {
                Console.WriteLine($"\nBoleto con ID {id} ha sido cancelado.");
            }
            else
            {
                Console.WriteLine($"\nNo se pudo cancelar el boleto, ID no encontrado.");
            }
        }

        public void MostrarRutasRegistradas()
        {
            Console.WriteLine("\nRutas registradas:");
            rutas.MostrarValores();
        }

        public void MostrarRutasDisponibles()
        {
            Console.WriteLine("\nRutas disponibles:");
            foreach (Ruta ruta in rutas.ObtenerClaves())
            {
                Console.WriteLine($"{ruta.Origen} → {ruta.Destino}");
            }
        }

        public void MostrarHorariosPorRuta(string idRuta)
        {
            Console.WriteLine($"Horarios disponibles para la ruta {idRuta}:");

            ListaDoblementeEnlazada<Boleto> boletos = ObtenerBoletosPorRuta(idRuta);
            if (boletos.Tamanio == 0)
            {
                Console.WriteLine("No hay horarios disponibles para esta ruta.");
                return;
            }
            foreach (Boleto boleto in boletos)
            {
                Console.WriteLine($"Salida: {boleto.FechaHoraSalida} | Llegada: {boleto.FechaHoraLlegada}");
            }
        }

        public ListaDoblementeEnlazada<Boleto> ObtenerBoletosPorRuta(string idRuta)
        {
            ListaDoblementeEnlazada<Boleto> boletosPorRuta = new ListaDoblementeEnlazada<Boleto>();

            foreach (Boleto boleto in listaBoletos)
            {
                if (boleto.IdTren.Equals(idRuta))
                {
                    boletosPorRuta.AgregarAlFinal(boleto);
                }
            }

            return boletosPorRuta;
        }
    }
}