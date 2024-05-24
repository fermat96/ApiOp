using Data;
using Entity;
using Entity.DTO.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class PAP007MFBusiness
    {
        #region METODOS GET
        public async Task<Result> ObtenerProgramas(TokenData datosToken, string IdProduccion)
        {
            try
            {
                return await new PAP007MFData().ObtenerProgramas(datosToken, IdProduccion);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<Result> ObtenerBobinas(TokenData datosToken, string IdProduccion, string idPrograma, string idMaquina, string op, string tipoHB)
        {
            try
            {
                return await new PAP007MFData().ObtenerBobinas(datosToken, IdProduccion, idPrograma, idMaquina, op, tipoHB);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<Result> ObtenerTarimas(TokenData datosToken, string IdProduccion, string idPrograma, string idMaquina, string op, string tipoHB, string idPartida, string alma)
        {
            try
            {
                return await new PAP007MFData().ObtenerTarimas(datosToken, IdProduccion, idPrograma, idMaquina, op, tipoHB, idPartida, alma);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        #endregion

        #region METODOS UPDATE 
        public async Task<Result> CancelarBobinas(TokenData datosToken, List<PAP007MF_CANCELAR_BOBINAS> listDocumento)
        {
            try
            {
                return await new PAP007MFData().CancelarBobinas(datosToken, listDocumento);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<Result> CancelarTarimas(TokenData datosToken, List<PAP007MF_CANCELAR_BOBINAS> listDocumento)
        {
            try
            {
                return await new PAP007MFData().CancelarTarimas(datosToken, listDocumento);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<Result> CancelarFolio(TokenData datosToken, string idProduccion)
        {
            try
            {
                return await new PAP007MFData().CancelarFolio(datosToken, idProduccion);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        #endregion
    }
}
