using Data;
using Entity.DTO.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class PAPCAP010Business
    {
        #region METODOS GET
        public async Task<Result> ObtenerMaquina(TokenData datosToken, string idMaquina)
        {
            try
            {
                return await new PAPCAP010Data().ObtenerMaquina(datosToken, idMaquina);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<Result> EstadoPrograma(TokenData datosToken, string idMaquina, string idPrograma)
        {
            try
            {
                return await new PAPCAP010Data().EstadoPrograma(datosToken, idMaquina, idPrograma);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        #endregion

        #region METODOS UPDATE
        public async Task<Result> UpdateEstado(TokenData datosToken, string idMaquina, string idPrograma, string estado)
        {
            try
            {
                return await new PAPCAP010Data().UpdateEstado(datosToken, idMaquina, idPrograma, estado);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        #endregion
    }
}
