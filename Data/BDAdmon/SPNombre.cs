using Data.BDAdmon;
using Data.Enums;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Data
{
    public class SPNombre
    {
        private static SpTipo Tipo;

        public static string SubPro = ProcesosCecso.FpaPapel + SubProcesos.FpaProgramacion;

        private static string TipoAccionNombre = Tipo == SpTipo.Actualiza ? "SPA" : "SPC";

        public string Nombre = SubPro + TablaTipo.Datos + "001" + TipoAccionNombre;
        public SPNombre(SpTipo TipoAccion = SpTipo.Consulta, string SP = "001")
        {
            Tipo = TipoAccion;
            SubPro = ProcesosCecso.FpaPapel + SubProcesos.FpaProgramacion;
            TipoAccionNombre = Tipo == SpTipo.Actualiza ? "SPA" : "SPC";
            Nombre = SubPro + TablaTipo.Datos + SP + TipoAccionNombre;
        }
    }

}

