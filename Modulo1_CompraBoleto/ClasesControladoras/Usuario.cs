using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEstructuras.Modulo1_CompraBoleto.ClasesControladoras
{
    public class Usuario
    {
        private string correo;
        private string contrasenia;
        private string rol;

        public string Correo { get => correo; set => correo = value; }
        public string Contrasenia { get => contrasenia; set => contrasenia = value; }
        public string Rol { get => rol; set => rol = value; }

        public Usuario(string correo, string contrasenia, string rol)
        {
            this.Correo = correo;
            this.Contrasenia = contrasenia;
            this.rol = rol;
        }
    }
}
