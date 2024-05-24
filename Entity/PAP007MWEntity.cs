using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class PAP007MW_DATOS_CLIENTE
    {
        public string Cliente { get; set; }
        public string Op_Larga { get; set; }
        public string Op { get; set; }
        public string FechaGen { get; set; }
        public string Embarcado { get; set; }
        public string Gramaje { get; set; }
        public string Solicitado { get; set; }
        public int IdCliente { get; set; }
        public string Cons { get; set; }
        public string Ancho { get; set; }
        public int IdMaquina { get; set; }
        public string OrdenCompra { get; set; }
        public string SolMenosEmb { get; set; }
        public string EmbMasSec { get; set; }
        public int IdUnidad1 { get; set; }
        public string ClasePapel { get; set; }
        public int idClasePapel { get; set; }
        public string Diametro { get; set; }
        public int IdUdDiametro { get; set; }
        public string CantSolicitada { get; set; }
        public string Programado { get; set; }
    }

    public class PAP007MW_GRAMAJE
    {
        public int IdTipoPapel { get; set; }
        public string Gramaje { get; set; }
    }

    public class PAP007MW_ROLLOS
    {
        public string OPPartida { get; set; }
        public string Cantidad { get; set; } //DECIMAL EN BD
        public int IdUnidad1 { get; set; }
        public string Unidad {  get; set; }
        public int IdTipoPapel1 { get; set; }
        public string Ancho1 { get; set; } //DECIMAL EN BD
        public string Clase {  get; set; }
        public string Tipo {  get; set; }
        public string ClasePapel { get; set; }
        public string Cons {  get; set; }
        public int IdClasePapel { get; set; }
    }

    public class PAP007MWTB_01
    {
        public int IdSecuencia { get; set; }
        public int IdCliente { get; set; }
        public string OP { get; set; }
        public decimal Ancho { get; set; }
        public decimal Tons { get; set; }
        public string IdTipoPapel { get; set; }
        public string Rango_Gramaje { get; set; }
        public int IdMaquina { get; set; }
        public int UdMedida { get; set; }
        public string OPPartida { get; set; }
        public int IdClasePapel { get; set; }
        public decimal Diametro { get; set; }
        public int IdUdDiametro { get; set; }
        public int IdCorte { get; set; }
        public string Corte { get; set; }
        public decimal CantSolicitada { get; set; }
        public string Cons { get; set;}
        public int IdPartida { get; set; }
        public int PartidaIndividual { get; set; }
    }

    public class PAP007MW_DATA_INSERT
    {
        public string fechaEntrega { get; set; }
        public string Comentarios { get; set; }
        public List<PAP007MWTB_01> PAP007MWTB { get; set; }
    }

    public class PAP007MW_CLIENTES
    {
        public int IdCliente { get; set; }
        public string Cliente { get; set;}
    }

    public class PAP007MW_SECUENCIAS
    {
        public int IdSecuencia { get; set; }
        public string Secuencia { get; set; }
    }

    public class PAP007MW_SECUENCIAS_MODIFICACION
    {
        public int Id { get; set; }
        public int IdSecuencia { get; set; }
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string OP { get; set; }
        public string Ancho { get; set; } //ES DECIMAL
        public string Tons { get; set; } //ES DECIMAL
        public string IdTipoPapel { get; set; }
        public string Rango_Gramaje { get; set; }
        public int IdMaquina { get; set; }
        public int UdMedida { get; set; }
        public string Unidad { get; set; }
        public string OPPartida { get; set; }
        public int IdClasePapel { get; set; }
        public string Diametro { get; set; } //ES DECIMAL
        public int IdUnidadDiametro { get; set; }
        public int IdCorte { get; set; }
        public string Corte {  get; set; }
        public string CantSolicitada { get; set; }
        public string Cons {  get; set; }
        public int IdPartida { get; set; }
        public string PartidaIndividual {  get; set; }
        public string FechaProbableEntrega { get; set; }
        public string ClasePapel { get; set; }
        public string TipoPapel { get; set; }
        public string OC {  get; set; }
    }

    public class PAP007MW_INSERT_UPDATE
    {
        public int IdSecuencia { get; set; }
        public List<PAP007MWTB_02> paramTablePapDat046 { get; set; }
    }

    public class PAP007MWTB_02
    {
        public int Id { get; set; }
        public int IdSecuencia { get; set; }
        public int IdCliente { get; set; }
        public string OP { get; set; }
        public decimal Ancho { get; set; }
        public decimal Tons { get; set; }
        public string IdTipoPapel { get; set; }
        public string Rango_Gramaje { get; set; }
        public int IdMaquina { get; set; }
        public int UdMedida { get; set; }
        public string OPPartida{ get; set; }
        public int IdClasePapel { get; set; }
        public decimal Diametro { get; set; }
        public int IdUdDiametro { get; set; }
        public int IdCorte { get; set; }
        public string Corte { get; set; }
        public decimal CantSolicitada { get; set; }
        public string Cons { get; set; }
        public int IdPartida { get; set; }
        public int PartidaIndividual { get; set; }
    }

    public class PAP007MW_PROGRAMA
    {
        public int IdPrograma { get; set; }
        public string Estado { get; set; }
    }
}
