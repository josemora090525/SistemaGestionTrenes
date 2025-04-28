using ProyectoEstructuras.Códigos.Actores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEstructuras.Códigos.TareasAdministrador
{
    public class SistemaAutenticacion<K, V> where V : class
    {
        private TablaHash<K, V> tabla; // Referencia a la tabla hash
        private bool sesionActiva;     // Indica si hay una sesión activa

        public SistemaAutenticacion(TablaHash<K, V> tabla)
        {
            this.tabla = tabla;
            sesionActiva = false;
        }

        // Método para intentar iniciar sesión
        public V IniciarSesion(K clave, Func<V, bool> validar)
        {
            V elemento = tabla.BuscarValores(clave);

            if (elemento == null)
            {
                Console.WriteLine($"Clave '{clave}' no encontrada.");
                return null;
            }
            else if (!validar(elemento))
            {
                Console.WriteLine("Validación fallida para el elemento.");
                return null;
            }
            else
            {
                Console.WriteLine($"Sesión iniciada para la clave: {clave}");
                sesionActiva = true;
                return elemento;
            }
        }

        // Método para cerrar la sesión
        public void CerrarSesion()
        {
            if (!sesionActiva)
            {
                Console.WriteLine("No hay sesión activa.");
            }
            else
            {
                sesionActiva = false;
                Console.WriteLine("Sesión cerrada.");
            }
        }
    }

}
