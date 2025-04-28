using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEstructuras.Códigos.Actores
{
    public class Empleado : Usuario
    {
        public Empleado(string nombre, string apellidos, string telefono, string identificacion, string numeroIdentificacion, string correo, string contrasenia, string rol)
            : base(nombre, apellidos, telefono, identificacion, numeroIdentificacion, correo, contrasenia, "Empleado")
        {
        }
    }
}
