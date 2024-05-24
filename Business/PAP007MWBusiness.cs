using Data;
using Entity;
using Entity.DTO.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class PAP007MWBusiness
    {
        #region METODOS GET
        public async Task<Result> ObtenerClientes(TokenData datosToken, string fechaIni, string fechaFin)
        {
            try
            {
                return await new PAP007MWData().ObtenerClientes(datosToken, fechaIni, fechaFin);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<Result> ObtenerGramaje(TokenData datosToken, string IdMaquina, string RangoMenor, string RangoMayor)
        {
            try
            {
                return await new PAP007MWData().ObtenerGramaje(datosToken, IdMaquina, RangoMenor, RangoMayor);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<Result> ObtenerRolloInfo(TokenData datosToken, string OrdenCompra)
        {
            try
            {
                return await new PAP007MWData().ObtenerRolloInfo(datosToken, OrdenCompra);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<Result> ObtenerSecuenciasClientes(TokenData datosToken)
        {
            try
            {
                return await new PAP007MWData().ObtenerSecuenciasClientes(datosToken);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<Result> ObtenerSecuenciasModificar(TokenData datosToken, string secuencia)
        {
            try
            {
                return await new PAP007MWData().ObtenerSecuenciasModificar(datosToken, secuencia);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<Result> ObtenerPartidasOP(TokenData datosToken, string op)
        {
            try
            {
                return await new PAP007MWData().ObtenerPartidasOP(datosToken, op);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<Result> ObtenerEstatusPrograma(TokenData datosToken, string secuencia)
        {
            try
            {
                return await new PAP007MWData().ObtenerEstatusPrograma(datosToken, secuencia);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        #endregion

        #region METODOS INSERT
        public async Task<Result> InsertarRollos(TokenData datosToken, PAP007MW_DATA_INSERT dt)
        {
            try
            {
                return await new PAP007MWData().InsertarRollos(datosToken, dt);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        #endregion

        #region METODOS UPDATE
        public async Task<Result> InsertarUpdatePartida(TokenData datosToken, PAP007MW_INSERT_UPDATE dt)
        {
            try
            {
                return await new PAP007MWData().InsertarUpdatePartida(datosToken, dt);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        #endregion

        #region METODOS DELETE
        public async Task<Result> EliminarSecuencia(TokenData datosToken, string secuencia)
        {
            try
            {
                return await new PAP007MWData().EliminarSecuencia(datosToken, secuencia);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        #endregion
    }
}
