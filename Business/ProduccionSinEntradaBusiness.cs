using Data;
using System;
using Entity.DTO.Common;
using Entity.DTO;
using System.Threading.Tasks;
using Entity;
using System.Collections.Generic;


namespace Business
{
    public class ProduccionSinEntradaBusiness
    {
        public async Task<Result> Get_ListarMaquinas(string strConexion)
        {
            try
            {
                return await new ProduccionSinEntradaData().Get_ListarMaquinas(strConexion);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<Result> Get_ListarProduccionSinEntrada(string strConexion, int startRow, int endRow, ProduccionSinEntradaFiltro Filtro)
        {
            try
            {
                return await new ProduccionSinEntradaData().Get_ListarProduccionSinEntrada(strConexion, startRow, endRow, Filtro);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<Result> Get_ListarProduccion(string strConexion, int startRow, int endRow, ProduccionSinEntradaFiltro Filtro)
        {
            try
            {
                return await new ProduccionSinEntradaData().Get_ListarProduccion(strConexion, startRow, endRow, Filtro);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<Result> post_Actualizar(TokenData datosToken, int Mes, int Anio, int idMaquina, ProduccionSinEntrada[] Tabla)
        {
            try
            {
                return await new ProduccionSinEntradaData().post_Actualizar(datosToken, Mes, Anio, idMaquina, Tabla);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
