using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEstructuras.Códigos.Actores
{
    public class Usuario
    {
        private string nombre;
        private string apellidos;
        private string telefono;
        private string identificacion;
        private string correo;
        private string contrasenia;
        private string rol;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Identificacion { get => identificacion; set => identificacion = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Contrasenia { get => contrasenia; set => contrasenia = value; }
        public string Rol { get => rol; set => rol = value; }

        public Usuario(string nombre, string apellidos, string telefono, string identificacion, string correo, string contrasenia, string rol)
        {
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Telefono = telefono;
            this.Identificacion = identificacion;
            this.Correo = correo;
            this.Contrasenia = contrasenia;
            this.Rol = rol;
        }

        public override string ToString()
        {
            return $"Usuario{{nombre={Nombre}, apellidos={Apellidos}, telefono={Telefono}, identificacion={Identificacion}, correo={Correo}, contrasenia={Contrasenia}, rol={Rol}}}";
        }
    }
}
