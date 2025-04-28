using ProyectoEstructuras.Códigos.TareasEmpleado;
using System;

namespace ProyectoEstructuras.Códigos.Servicio
{
    public class Boleto : InterfazID
    {
        private string idRegistro;
        private string fechaHoraCompra;
        private string fechaHoraSalida;
        private string fechaHoraLlegada;
        private string idPasajero;
        private string nombres;
        private string apellidos;
        private string tipoIdentificacion;
        private string direccion;
        private string telefono;
        private string idTren;
        private string lugar;
        private string categoriaPasajero;
        private double valorPasaje;
        private string contactoNombres;
        private string contactoApellidos;
        private string contactoTelefono;
        private string idEquipaje;
        private double pesoEquipaje;
        private string idVagonCarga;

        public string GetId() { return idRegistro; }
        public string FechaHoraCompra { get => fechaHoraCompra; set => fechaHoraCompra = value; }
        public string FechaHoraSalida { get => fechaHoraSalida; set => fechaHoraSalida = value; }
        public string FechaHoraLlegada { get => fechaHoraLlegada; set => fechaHoraLlegada = value; }
        public string IdPasajero { get => idPasajero; set => idPasajero = value; }
        public string Nombres { get => nombres; set => nombres = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string TipoIdentificacion { get => tipoIdentificacion; set => tipoIdentificacion = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string IdTren { get => idTren; set => idTren = value; }
        public string Lugar { get => lugar; set => lugar = value; }
        public string CategoriaPasajero { get => categoriaPasajero; set => categoriaPasajero = value; }
        public double ValorPasaje { get => valorPasaje; set => valorPasaje = value; }
        public string ContactoNombres { get => contactoNombres; set => contactoNombres = value; }
        public string ContactoApellidos { get => contactoApellidos; set => contactoApellidos = value; }
        public string ContactoTelefono { get => contactoTelefono; set => contactoTelefono = value; }
        public string IdEquipaje { get => idEquipaje; set => idEquipaje = value; }
        public double PesoEquipaje { get => pesoEquipaje; set => pesoEquipaje = value; }
        public string IdVagonCarga { get => idVagonCarga; set => idVagonCarga = value; }

        public Boleto(
            string idRegistro,
            string fechaHoraCompra,
            string fechaHoraSalida,
            string fechaHoraLlegada,
            string idPasajero,
            string nombres,
            string apellidos,
            string tipoIdentificacion,
            string direccion,
            string telefono,
            string idTren,
            string lugar,
            string categoriaPasajero,
            double valorPasaje,
            string contactoNombres,
            string contactoApellidos,
            string contactoTelefono,
            string idEquipaje,
            double pesoEquipaje,
            string idVagonCarga)
        {
            this.idRegistro = idRegistro;
            this.fechaHoraCompra = fechaHoraCompra;
            this.fechaHoraSalida = fechaHoraSalida;
            this.fechaHoraLlegada = fechaHoraLlegada;
            this.idPasajero = idPasajero;
            this.nombres = nombres;
            this.apellidos = apellidos;
            this.tipoIdentificacion = tipoIdentificacion;
            this.direccion = direccion;
            this.telefono = telefono;
            this.idTren = idTren;
            this.lugar = lugar;
            this.categoriaPasajero = categoriaPasajero;
            this.valorPasaje = valorPasaje;
            this.contactoNombres = contactoNombres;
            this.contactoApellidos = contactoApellidos;
            this.contactoTelefono = contactoTelefono;
            this.idEquipaje = idEquipaje;
            this.pesoEquipaje = pesoEquipaje;
            this.idVagonCarga = idVagonCarga;
        }
    }
}