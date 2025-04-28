using ProyectoEstructuras.Códigos.Actores;
using ProyectoEstructuras.Códigos.Servicio;
using ProyectoEstructuras.Códigos.TareasAdministrador;
using ProyectoEstructuras.Códigos.TareasEmpleado;
using ProyectoEstructuras.Modulo1_CompraBoleto.ClasesControladoras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuario = ProyectoEstructuras.Códigos.Actores.Usuario;

namespace ProyectoEstructuras
{
    public static class Datos
    {
        public static ListaCircular<Tren> listaTrenes;
        public static TablaHash<string, Usuario> tablaUsuarios;
        public static TablaHash<string, Ruta> tablaRutas;
        public static Grafos<Estacion> grafoEstaciones;

        public static Pasajero pasajeroPredeterminado = new Pasajero("Ana", "García Pérez", "3001234567", "Cedula Ciudadania", "1000123456", "pasajero@ejemplo.com", "passpasajero", "Pasajero");

        static Datos()
        {
            Console.WriteLine("--- Inicializando clase Datos ---");

            listaTrenes = new ListaCircular<Tren>();
            tablaUsuarios = new TablaHash<string, Usuario>(101);
            tablaRutas = new TablaHash<string, Ruta>(10);
            grafoEstaciones = new Grafos<Estacion>(11);

            Console.WriteLine("Estructuras de datos principales inicializadas.");

            if (pasajeroPredeterminado != null)
            {
                Datos.tablaUsuarios.InsertarValores(pasajeroPredeterminado.Correo, pasajeroPredeterminado);
                Console.WriteLine($"Pasajero predeterminado agregado a la TablaHash: Correo = '{pasajeroPredeterminado.Correo}'");
            }
            else
            {
                Console.WriteLine("ADVERTENCIA: pasajeroPredeterminado es null durante la inicialización de Datos.");
            }

            Console.WriteLine("--- Inicialización de clase Datos completada ---");
        }
    }


}
