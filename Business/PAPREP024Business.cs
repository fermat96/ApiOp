using Data;
using Entity.DTO.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class PAPREP024Business
    {
        #region METODOS GET
        public async Task<Result> ObtenerClientes(TokenData datosToken, string nombre)
        {
            try
            {
                return await new PAPREP024Data().ObtenerClientes(datosToken, nombre);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<Result> ObtenerClientesID(TokenData datosToken, string id)
        {
            try
            {
                return await new PAPREP024Data().ObtenerClientesID(datosToken, id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<Result> ObtenerDatosReporte(TokenData datosToken, string material, string idCliente, string fechaInicio, string fechaFin, string op, string rolloEmbarque)
        {
            try
            {
                return await new PAPREP024Data().ObtenerDatosReporte(datosToken, material, idCliente, fechaInicio, fechaFin, op, rolloEmbarque);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        #endregion
    }
}
