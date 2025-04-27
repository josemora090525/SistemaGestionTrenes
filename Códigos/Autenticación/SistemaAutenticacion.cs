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
        private TablaHash<K, V> tabla;
        private bool sesionActiva; // Indica si hay una sesión activa.

        public SistemaAutenticacion(TablaHash<K, V> tabla)
        {
            this.tabla = tabla;
            sesionActiva = false;
        }

        // Intenta iniciar sesión buscando el elemento asociado a la clave y validándolo.
        // Retorna el elemento si la validación es exitosa; de lo contrario, retorna null.
        public V IniciarSesion(K clave, Func<V, bool> validar)
        {
            V elemento = tabla.BuscarValores(clave);

            if (elemento == null)
            {
                Console.WriteLine("Clave no encontrada.");
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

        // Cierra la sesión si hay una activa.
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
