using ProyectoEstructuras.Códigos.TareasAdministrador;
using ProyectoEstructuras.Códigos.TareasEmpleado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEstructuras.Códigos.Servicio
{
    public class Estacion : InterfazID
    {
        private string idEstacion;
        private string nombreEstacion;
        private ListaCircular<Tren> listaTrenes;
        //private TablaHash<string, Ruta> rutas;

        public string IdEstacion { get => idEstacion; set => idEstacion = value; }
        public string NombreEstacion { get => nombreEstacion; set => nombreEstacion = value; }
        public ListaCircular<Tren> ListaTrenes { get => listaTrenes; set => listaTrenes = value; }
        //public TablaHash<string, Ruta> Rutas { get => rutas; set => rutas = value; }

        public Estacion(string idEstacion, string nombreEstacion)
        {
            this.IdEstacion = idEstacion;
            this.NombreEstacion = nombreEstacion;
            this.listaTrenes = new ListaCircular<Tren>();
            //this.rutas = new TablaHash<string, Ruta>(33);
        }

        public string GetId()
        {
            return IdEstacion;
        }

        public override bool Equals(object obj)
        {
            // Si el objeto a comparar es nulo o no es una Estacion, no son iguales.
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            // Convierte el objeto a comparar a tipo Estacion.
            Estacion otraEstacion = (Estacion)obj;

            // *** La comparación se basa ÚNICAMENTE en la Identificación (IdEstacion) ***
            // Maneja el caso de que IdEstacion sea null (aunque idealmente no debería ser null para ser clave).
            bool sonIguales = (this.IdEstacion != null && this.IdEstacion.Equals(otraEstacion.IdEstacion));

            return sonIguales; // Devuelve true si los IDs son iguales, false en caso contrario.
        }

        public override string ToString()
        {
            return $"Estacion [ID: {IdEstacion}, Nombre: {NombreEstacion}]";
        }

        public override int GetHashCode()
        {
            int hashCode = (IdEstacion != null) ? IdEstacion.GetHashCode() : 0;
            return hashCode; // Devuelve el código hash basado en el ID.
        }

        public void AgregarTren(Tren tren)
        {
            if (tren == null)
            {
                throw new ArgumentException("El tren no puede ser nulo.");
            }

            ListaTrenes.Agregar(tren);
            Console.WriteLine($"Tren {tren.GetId()} agregado a la estación {NombreEstacion}.");
        }

        public void EliminarTren(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("El ID del tren no puede estar vacío.");
            }

            Tren trenEliminado = ListaTrenes.Buscar(id);
            if (trenEliminado != null)
            {
                ListaTrenes.Eliminar(id);
                Console.WriteLine($"Tren {id} eliminado de la estación {NombreEstacion}.");
            }
            else
            {
                Console.WriteLine($"El tren {id} no se encuentra en la estación {NombreEstacion}.");
            }
        }

        /*public void AgregarRuta(string idRuta, Ruta ruta)
        {
            if (string.IsNullOrEmpty(idRuta) || ruta == null)
            {
                throw new ArgumentException("El ID de la ruta y la ruta no pueden ser nulos.");
            }

            if (Rutas.ContieneClave(idRuta))
            {
                Console.WriteLine($"La ruta con ID {idRuta} ya existe.");
            }
            else
            {
                Rutas.InsertarValores(idRuta, ruta);
                Console.WriteLine($"Ruta {idRuta} agregada a la estación {NombreEstacion}.");
            }
        }*/

        /*public void EliminarRuta(string idRuta)
        {
            if (string.IsNullOrEmpty(idRuta))
            {
                throw new ArgumentException("El ID de la ruta no puede estar vacío.");
            }

            if (Rutas.ContieneClave(idRuta))
            {
                Rutas.EliminarValores(idRuta);
                Console.WriteLine($"Ruta {idRuta} eliminada de la estación {NombreEstacion}.");
            }
            else
            {
                Console.WriteLine($"La ruta con ID {idRuta} no existe en la estación {NombreEstacion}.");
            }
        }*/
    }

}
