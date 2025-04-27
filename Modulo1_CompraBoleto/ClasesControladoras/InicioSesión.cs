using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEstructuras.Modulo1_CompraBoleto.ClasesControladoras
{
    public class InicioSesion
    {
        private Usuario usuarioActual;
        private List<Usuario> usuariosPredefinidos;

        public InicioSesion()
        {
            usuariosPredefinidos = new List<Usuario>
            {
                new Usuario("admin@example.com", "admin123", "Administrador"),
                new Usuario("empleado@example.com", "empleado123", "Empleado"),
                new Usuario("pasajero@example.com", "pasajero123", "Pasajero")
            };
        }

        public bool IniciarSesion(string correo, string contrasenia)
        {
            foreach (var usuario in usuariosPredefinidos)
            {
                if (usuario.Correo == correo && usuario.Contrasenia == contrasenia)
                {
                    usuarioActual = usuario;
                    Console.WriteLine($"Sesión iniciada correctamente como {usuario.Rol}.");
                    return true;
                }
            }

            Console.WriteLine("Correo o contraseña incorrectos.");
            return false;
        }

        public Usuario ObtenerUsuarioActual()
        {
            return usuarioActual;
        }

    }
}

