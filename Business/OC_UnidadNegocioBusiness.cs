using Data;
using System;
using Entity.DTO.Common;
using System.Threading.Tasks;
using Entity;
using System.Collections.Generic;

namespace Business
{
    public class OC_UnidadNegocioBusiness
    {
        public async Task<bool> GetDuplicado(string strConexion, string OC)
        {
            try
            {
                return await new OC_UnidadNegocioData().GetDuplicado(strConexion, OC);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<Result> GetOC_UnidadNegocio(string strConexion, int startRow, int endRow, string Filtro, string FiltroUN)
        {
            try
            {
                return await new OC_UnidadNegocioData().GetOC_UnidadNegocio(strConexion, startRow, endRow, Filtro, FiltroUN);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<Result> Agregar(TokenData datosToken, OC_UnidadNegocio NuevaOC)
        {
            try
            {
                return await new OC_UnidadNegocioData().Agregar(datosToken, NuevaOC);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<Result> Eliminar(TokenData datosToken, OC_UnidadNegocio OC_Seleccionada)
        {
            try
            {
                return await new OC_UnidadNegocioData().Eliminar(datosToken, OC_Seleccionada);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
