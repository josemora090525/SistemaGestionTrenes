package Service;

import java.time.LocalDateTime;

public class Ticket {

    private String IdRegistro;
    private LocalDateTime fechaHoraCompra;
    private LocalDateTime fechaHoraSalida;
    private LocalDateTime fechaHorallegada;
    private String IdPasajero;
    private String Nombres;
    private String Apelllidos;
    private String TipoIdentificacion;
    private String Direccion;
    private String Telefono;
    private String IdTren;
    private String Lugar;
    private String CategoriaPasajero;
    private double ValorPasaje;
    private String ContactoNombres;
    private String ContactoApellidos;
    private String ContactoTelefono;
    private String IdEquipaje;
    private double pesoEquipaje;
    private String IdVagonCarga;

    
    public Ticket(String idRegistro, LocalDateTime fechaHoraCompra, LocalDateTime fechaHoraSalida,
            LocalDateTime fechaHorallegada, String idPasajero, String nombres, String apelllidos,
            String tipoIdentificacion, String direccion, String telefono, String idTren, String lugar,
            String categoriaPasajero, double valorPasaje, String contactoNombres, String contactoApellidos,
            String contactoTelefono, String idEquipaje, double pesoEquipaje, String idVagonCarga) {

        this. IdRegistro = idRegistro;
        this.fechaHoraCompra = fechaHoraCompra;
        this.fechaHoraSalida = fechaHoraSalida;
        this.fechaHorallegada = fechaHorallegada;
        this.IdPasajero = idPasajero;
        this. Nombres = nombres;
        this.Apelllidos = apelllidos;
        this.TipoIdentificacion = tipoIdentificacion;
        this. Direccion = direccion;
        this.Telefono = telefono;
        this. IdTren = idTren;
        this.Lugar = lugar;
        this.CategoriaPasajero = categoriaPasajero;
        this.ValorPasaje = valorPasaje;
        this.ContactoNombres = contactoNombres;
        this.ContactoApellidos = contactoApellidos;
        this.ContactoTelefono = contactoTelefono;
        this.IdEquipaje = idEquipaje;
        this.pesoEquipaje = pesoEquipaje;
        this.IdVagonCarga = idVagonCarga;
    }

    public String getIdRegistro() {
        return IdRegistro;
    }

    public LocalDateTime getFechaHoraCompra() {
        return fechaHoraCompra;
    }

    public LocalDateTime getFechaHoraSalida() {
        return fechaHoraSalida;
    }

    public LocalDateTime getFechaHorallegada() {
        return fechaHorallegada;
    }

    public String getIdPasajero() {
        return IdPasajero;
    }

    public String getNombres() {
        return Nombres;
    }

    public String getApelllidos() {
        return Apelllidos;
    }

    public String getTipoIdentificacion() {
        return TipoIdentificacion;
    }

    public String getDireccion() {
        return Direccion;
    }

    public String getTelefono() {
        return Telefono;
    }

    public String getIdTren() {
        return IdTren;
    }

    public String getLugar() {
        return Lugar;
    }

    public String getCategoriaPasajero() {
        return CategoriaPasajero;
    }

    public double getValorPasaje() {
        return ValorPasaje;
    }

    public String getContactoNombres() {
        return ContactoNombres;
    }

    public String getContactoApellidos() {
        return ContactoApellidos;
    }

    public String getContactoTelefono() {
        return ContactoTelefono;
    }

    public String getIdEquipaje() {
        return IdEquipaje;
    }

    public double getPesoEquipaje() {
        return pesoEquipaje;
    }

    public String getIdVagonCarga() {
        return IdVagonCarga;
    }

}
