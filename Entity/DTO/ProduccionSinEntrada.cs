using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.DTO
{
    public class ProduccionSinEntrada
    {
        public int id { get; set; }
        public int ConsecutivoBobina { get; set; }
        public int ConsecutivoRollo { get; set; }
        public decimal Peso { get; set; }
        public int idMaquina { get; set; }
        public string FechaProd { get; set; }
        public string FechaProdSinEntrada { get; set; }
        public string Corte { get; set; }
        public string ClasePapel { get; set; }
        public string TipoPapel { get; set; }
        public string Tipo { get; set; }
        public string Condicion { get; set; }
        public string Nombre { get; set; }
        public string Articulo { get; set; }
    }

    public class ProduccionSinEntradaFiltro
    {
        public int idMaquina { get; set; }
        public int Mes { get; set; }
        public int Anio { get; set; }
        public string Papel { get; set; }
        public string Rollo { get; set; }
        public string Bobina { get; set; }
        public string Fecha { get; set; }
    }

    public class ProduccionSinEntradaActualizar
    {
        public int Mes { get; set; }
        public int Anio { get; set; }
        public string idMaquina { get; set; }
        public ProduccionSinEntrada[] Tabla { get; set; }
    }
}
