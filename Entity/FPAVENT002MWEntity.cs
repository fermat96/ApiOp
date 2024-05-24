using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
    }

    public class Pedidos
    {
        public string TipoPedido { get; set; }
        public string op { get; set; }
        public string FechaGen {  get; set; }
        public string Estado { get; set; }
        public int IdCliente { get; set; }
        public bool AutorizadoCC { get; set; }
        public bool AutorizadoGP { get; set; }
        public bool AutorizadoCO { get; set; }
        public bool CancelaRemision {  get; set; }
        public string NotasAutCC { get; set; }
        public string NotasAutGP { get; set; }
        public string NotasAutCO { get; set; }
        public string OrdenCompra {  get; set; }
        public string AuthCC { get; set; }
        public string AuthGP { get; set; }
        public string AuthCO { get; set; }
        public string Nombre { get; set; }
        public string UsuarioERP { get; set; }
        public string Material { get; set; }
        public string Cantidad { get; set; }
        public bool EstatusNotificacion { get; set; }
    }

    public class EstadoPedidos
    {
        public bool generadas { get; set; }
        public bool completamenteAutorizadas { get; set; }
        public bool parcialmenteAutorizadas { get; set; }
        public bool canceladas { get; set; }
    }

    public class Filtros
    {
        public string fechaInicio { get; set; }
        public string fechaFin {  get; set; }
        public int consultadoPor {  get; set; }
        public int idCliente { get; set; }
        public string nombreCliente { get; set; }
        public EstadoPedidos estadosP {  get; set; }
        public string numPedidoOP { get; set; }
        public string tipoOP { get; set; }
}

    public class Autorizacion 
    { 
        public int Total {  get; set; }
    }

    public class Password
    {
        public string Contraseña { get; set; }
    }

    public class TerminacionOP
    {
        public string Terminacion { get; set; }
    }

    public class  DatosOP
    {
        public string op {  get; set; }
        public string Nombre { get; set; }
        public bool CancelaRemision { get; set;}
        public string Estado {  get; set; }
        public bool AutorizadoCC { get; set;}
        public bool AutorizadoCO { get; set; }
        public bool AutorizadoGP { get; set; }
        public string FechaHoraAutCC { get; set;}
        public string FechaHoraAutGP { get; set;}
        public string FechaHoraAutCO { get; set; }
        public bool AutorizacionAutomatica { get; set;}
        public string NotasAutCC { get; set;}
        public string NombreDocumento { get; set; }
    }

    public class VerificacionOP
    {
        public string op { get; set; }
        public string NombreMaquina { get; set; }
        public int IdPrograma { get; set; }
        public int IdPartida { get; set; }
        public int IdCorte { get; set; }
        public string Estado { get; set; }
    }

    public class CORREO
    {
        public string Correo { get; set; }
    }

    public class NOMBRE_CORREO
    {
        public string Nombre { get; set; }
    }

    public class DataFTP
    {
        public string Servidor {  get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string Path { get; set; }
        public string Puerto { get; set; }
    }
}
