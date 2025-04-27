using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEstructuras.Códigos.Actores
{
    public class Administrador: Usuario
    {
        public Administrador(string nombre, string apellidos, string telefono, string identificacion, string correo, string contrasenia)
            : base(nombre, apellidos, telefono, identificacion, correo, contrasenia, "Administrador")
        {
        }
    }
}
