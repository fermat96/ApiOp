using Entity.DTO.Common;
using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Data
{
    public class PAPREP024Data
    {
        #region METODOS GET
        //OBTENER DATOS CLIENTE
        public async Task<Result> ObtenerClientes(TokenData datosToken, string nombre)
        {
            Result objResult = new Result();
            try
            {
                using (var con = new SqlConnection(datosToken.Conexion))
                {
                    var result = await con.QueryMultipleAsync(
                        "PAPREP024SPTEMPORAL",
                        new
                        {
                            accion = 0,
                            nombre = nombre,
                        },
                    commandType: CommandType.StoredProcedure);
                    objResult.data = await result.ReadAsync<DATOS_CLIENTE>();
                }
                return objResult;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        //OBTENER CLIENTES POR ID
        public async Task<Result> ObtenerClientesID(TokenData datosToken, string id)
        {
            Result objResult = new Result();
            try
            {
                using (var con = new SqlConnection(datosToken.Conexion))
                {
                    var result = await con.QueryMultipleAsync(
                        "PAPREP024SPTEMPORAL",
                        new
                        {
                            accion = 1,
                            idCliente = Convert.ToInt32(id),
                        },
                    commandType: CommandType.StoredProcedure);
                    objResult.data = await result.ReadAsync<DATOS_CLIENTE>();
                }
                return objResult;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        //OBTENER DATOS
        public async Task<Result> ObtenerDatosReporte(TokenData datosToken, string material, string idCliente, string fechaInicio, string fechaFin, string op, string rolloEmbarque)
        {
            Result objResult = new Result();
            try
            {
                using (var con = new SqlConnection(datosToken.Conexion))
                {
                    var result = await con.QueryMultipleAsync(
                        "PAPREP024SPTEMPORAL",
                        new
                        {
                            accion = 2,
                            material = material,
                            idCliente = idCliente,
                            fechaFin = fechaFin,
                            op = op,
                            fechaInicio = fechaInicio,
                            rolloEmbarcados = rolloEmbarque
                        },
                    commandType: CommandType.StoredProcedure);
                    objResult.data = await result.ReadAsync<DATOS_REPORTE_EMBARQUE>();
                }
                return objResult;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        #endregion
    }
}
