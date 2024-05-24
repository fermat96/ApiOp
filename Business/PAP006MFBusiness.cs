using Data;
using Entity;
using Entity.DTO.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class PAP006MFBusiness
    {
        #region METODOS GET
        public async Task<Result> ObtenerTarimas(TokenData datosToken, string fechaInicial, string fechaFin, string tipoMaterial)
        {
            try
            {
                return await new PAP006MFData().ObtenerTarimas(datosToken, fechaInicial, fechaFin, tipoMaterial);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<Result> ValidarExistencia(TokenData datosToken, string codigo2)
        {
            try
            {
                return await new PAP006MFData().ValidarExistencia(datosToken, codigo2);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<Result> RegresaFolioE_S(TokenData datosToken, string tipoMovimiento, string folioE_S, string TipoHB, string IdProduccion, string AlmSalidas)
        {
            try
            {
                return await new PAP006MFData().RegresaFolioE_S(datosToken, tipoMovimiento, folioE_S, TipoHB, IdProduccion, AlmSalidas);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<Result> BusRollosSalAlm(TokenData datosToken, string programa, string partida, string maquinaHR, string tipoHB, string idProduccion)
        {
            try
            {
                return await new PAP006MFData().BusRollosSalAlm(datosToken, programa, partida, maquinaHR, tipoHB, idProduccion);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        #endregion

        #region METODOS UPDATE
        public async Task<Result> ActualizarInsertarTarima(TokenData datosToken, PAP006MF_OBJETO tarimas)
        {
            try
            {
                return await new PAP006MFData().ActualizarInsertarTarima(datosToken, tarimas);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<Result> IncrementarFolio(TokenData datosToken, string tipoMovimiento, string folioE_S, string TipoHB, string IdProduccion, string AlmSalidas)
        {
            try
            {
                return await new PAP006MFData().IncrementarFolio(datosToken, tipoMovimiento, folioE_S, TipoHB, IdProduccion, AlmSalidas);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<Result> GenEntradasAuth(TokenData datosToken, PAP006MF_ARTICULOS articulos)
        {
            try
            {
                return await new PAP006MFData().GenEntradasAuth(datosToken, articulos);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        #endregion

        #region METODOS DELETE
        public async Task<Result> EliminarInsumosAlmacenes(TokenData datosToken, string articulos)
        {
            try
            {
                return await new PAP006MFData().EliminarInsumosAlmacenes(datosToken, articulos);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<Result> ActRollosSalida(TokenData datosToken, string iPrograma, string iMaquina, string tipoHB)
        {
            try
            {
                return await new PAP006MFData().ActRollosSalida(datosToken, iPrograma, iMaquina, tipoHB);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        #endregion

        #region METODOS INSERT
        public async Task<Result> GenCentroCosto(TokenData datosToken, string folioE_S, string tipoHB)
        {
            try
            {
                return await new PAP006MFData().GenCentroCosto(datosToken, folioE_S, tipoHB);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        #endregion
    }
}
