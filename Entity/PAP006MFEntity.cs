using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class PAP006MF_TARIMAS
    {
        public int IdProduccion {  get; set; }
        public string OP {  get; set; }
        public string Tarima { get; set; }
        public string Tons {  get; set; }
        public string TipoPapel { get; set; }
        public string Corte { get; set; }
        public string Codigo2 { get; set; }
        public bool Activar { get; set; }
        public int Programa { get; set; }
        public int IdMaquinaHR { get; set; }
        public int Partida {  get; set; }
        public string TipoHB { get; set; }
        public string AnchoTarimas { get; set; }
        public string AlmacenTarimas { get; set; }
        public int IdUnidad {  get; set; }
        public string Uancho {  get; set; }
        public string Nombre { get; set; }
        public string Comentarios { get; set; }
        public string FechaFabricacion { get; set; }
        public string Gramaje { get; set; }
        public int IdCliente { get; set; }
        public string cliente { get; set; }
        public string Largo { get; set; }
        public int PiezasTarima { get; set; }
    }

    public class PAP006MF_PUSH_TARIMAS
    {
        public string Codigo2 { get; set; }
        public string OP { get; set; }
        public string Cons { get; set; }
        public string Corte { get; set; }
        public string TipoHB { get; set; }
        public string Tarima { get; set; }
        public decimal Peso { get; set; }
        public int PiezasTarima { get; set; }
    }

    public class PAP006MF_OBJETO
    {
        public List<PAP006MF_PUSH_TARIMAS> tarimas { get; set; }
    }

    public class PAP006MF_DATA_ARTICULOS
    {
        public int IdMaquina { get; set; }
        public string Articulo { get; set; }
        public string Peso { get; set; }
        public string Codigo2 { get; set; }
        public string TipoHB { get; set; }
        public string FolioE_S {  get; set; }
        public string Partida { get; set; }
        public string OP { get; set; }
        public string Cons { get; set; }
        public string Fecha { get; set; }
    }

    public class PAP006MF_ARTICULOS
    {
        public string TipoMovimiento { get; set; }
        public string Cantidad { get; set; }
        public string PrecioU { get; set; }
        public string idTurno { get; set; }
        public string TipoHB { get; set; }
        public List<PAP006MF_DATA_ARTICULOS> tblArticulos { get; set; }
    }

    public class PAP006MF_ROLLOS_SALIDA
    {
        public string articulo { get; set; }
        public int Exi_Uni { get; set; }
        public int IdMaquinaHR { get; set; }
        public int Programa { get; set; }
        public int Partida { get; set; }
        public string TipoHB { get; set; }
        public string Rollo { get; set; }
        public int IdProduccion { get; set; }
        public string AlmacenRollo { get; set; }
    }
}
