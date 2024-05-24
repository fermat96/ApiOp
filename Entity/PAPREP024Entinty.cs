using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class DATOS_CLIENTE
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
    }

    public class DATOS_REPORTE_EMBARQUE
    {
        public string OrdenCompra { get; set; }
        public string HojaClase { get; set; }
        public string Clase { get; set; }
        public string Partida { get; set; }
        public string ancho { get; set; }
        public decimal Solicitado { get; set; }
        public decimal fabricado { get; set; }
        public int IdCliente { get; set; }
        public string Cliente { get; set; }
        public string Op { get; set; }
        public string FechaGen { get; set; }
        public string Destino { get; set; } 
        public decimal Embarcado { get; set; }
        public decimal EmbarcadoOP { get; set; }
        public decimal EmbarcadoOtras { get; set; }
        public string Gramaje { get; set; }
        public string FechaEmb {  get; set; }
        public decimal EnPiso { get; set; }
        public decimal PenFab { get; set; }
        public decimal PenEmb { get; set; }
        public string Estado { get; set; }
        public bool CancelaRemision { get; set; }
        public string Tipo { get; set; }
        public string FechaFab { get; set; }
        public string Cons {  get; set; }

    }
}
