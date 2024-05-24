using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class PAP007MFEntity
    {

    }

    public class PAP007MF_PRODUCCION
    {
        public int IdProduccion { get; set; }
        public int IdPrograma { get; set; }
        public int IdPartida { get; set; }
        public string OP { get; set; }
        public int Maquina { get; set; }
        public string TipoHB { get; set; }
        public string Cantidad { get; set; }
    }

    public class PAP007MF_BOBINAS
    {
        public string Articulo { get; set; }
        public string Bobinas { get; set; }
        public string Salida { get; set; }
        public int Maquina { get; set; }
        public string Kilos { get; set; }
    }

    public class PAP007MF_TARIMAS
    {
        public string Articulo { get; set; }
        public string Tarimas { get; set; }
        public string Entrada { get; set; }
        public int Maquina { get; set; }
        public string Kilos { get; set;}
        public string Exi_Uni { get; set; }
        public string Kilos2 { get; set; }
        public string Diferencia { get; set; }
    }

    public class PAP007MF_CANCELAR_BOBINAS
    {
        public string TipoE_S { get; set; }
        public string Documento { get; set; }
        public string Articulo { get; set;}
        public decimal KgsCan { get; set; }
    }

    public class PAP007MF_TRAN_INFO
    {
        public string Mensaje { get; set; }
        public bool Correcto { get; set; }
        public string Info {  get; set; }
    }
}
