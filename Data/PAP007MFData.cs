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
    public class PAP007MFData
    {
        #region METODOS GET
        public async Task<Result> ObtenerProgramas(TokenData datosToken, string IdProduccion)
        {
            Result objResult = new Result();
            try
            {
                using (var con = new SqlConnection(datosToken.Conexion))
                {
                    var result = await con.QueryMultipleAsync(
                        "PAP007MFSPC1_PENDIENTE",
                        new
                        {
                            accion = 0,
                            idProduccion = Convert.ToInt32(IdProduccion)
                        },
                    commandType: CommandType.StoredProcedure);
                    objResult.data = await result.ReadAsync<PAP007MF_PRODUCCION>();
                }

                return objResult;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<Result> ObtenerBobinas(TokenData datosToken, string IdProduccion, string idPrograma, string idMaquina, string op, string tipoHB)
        {
            Result objResult = new Result();
            try
            {
                using (var con = new SqlConnection(datosToken.Conexion))
                {
                    var result = await con.QueryMultipleAsync(
                        "PAP007MFSPC1_PENDIENTE",
                        new
                        {
                            accion = 1,
                            idProduccion = Convert.ToInt32(IdProduccion),
                            idPrograma = Convert.ToInt32(idPrograma),
                            idMaquina = Convert.ToInt32(idMaquina),
                            op = op,
                            tipoHB = tipoHB
                        },
                    commandType: CommandType.StoredProcedure);
                    objResult.data = await result.ReadAsync<PAP007MF_BOBINAS>();
                }

                return objResult;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<Result> ObtenerTarimas(TokenData datosToken, string IdProduccion, string idPrograma, string idMaquina, string op, string tipoHB, string idPartida, string alma)
        {
            Result objResult = new Result();
            try
            {
                using (var con = new SqlConnection(datosToken.Conexion))
                {
                    var result = await con.QueryMultipleAsync(
                        "PAP007MFSPC1_PENDIENTE",
                        new
                        {
                            accion = 2,
                            idProduccion = Convert.ToInt32(IdProduccion),
                            idPrograma = Convert.ToInt32(idPrograma),
                            idMaquina = Convert.ToInt32(idMaquina),
                            idPartida = Convert.ToInt32(idPartida),
                            op = op,
                            tipoHB = tipoHB,
                            alma = alma
                        },
                    commandType: CommandType.StoredProcedure);
                    objResult.data = await result.ReadAsync<PAP007MF_TARIMAS>();
                }

                return objResult;
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
            Result objResult = new Result();
            try
            {
                TranformaDataTable Ds = new TranformaDataTable();
                using (var con = new SqlConnection(datosToken.Conexion))
                {
                    var result = await con.QueryMultipleAsync(
                        "PAP007MFSPA2_PENDIENTE",
                        new
                        {
                            accion = 0,
                            tblSolicitudes = Ds.CreateDataTable(listDocumento).AsTableValuedParameter("PAP007MFTB_001")
                        },
                    commandType: CommandType.StoredProcedure);
                    objResult.data = await result.ReadAsync<PAP007MF_TRAN_INFO>();
                }

                return objResult;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<Result> CancelarTarimas(TokenData datosToken, List<PAP007MF_CANCELAR_BOBINAS> listDocumento)
        {
            Result objResult = new Result();
            try
            {
                TranformaDataTable Ds = new TranformaDataTable();
                using (var con = new SqlConnection(datosToken.Conexion))
                {
                    var result = await con.QueryMultipleAsync(
                        "PAP007MFSPA2_PENDIENTE",
                        new
                        {
                            accion = 1,
                            tblSolicitudes = Ds.CreateDataTable(listDocumento).AsTableValuedParameter("PAP007MFTB_001")
                        },
                    commandType: CommandType.StoredProcedure);
                    objResult.data = await result.ReadAsync<PAP007MF_TRAN_INFO>();
                }

                return objResult;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<Result> CancelarFolio(TokenData datosToken, string idProduccion)
        {
            Result objResult = new Result();
            try
            {
                using (var con = new SqlConnection(datosToken.Conexion))
                {
                    var result = await con.QueryMultipleAsync(
                        "PAP007MFSPA2_PENDIENTE",
                        new
                        {
                            accion = 2,
                            idProduccion = idProduccion
                        },
                    commandType: CommandType.StoredProcedure);
                    objResult.data = await result.ReadAsync<PAP007MF_TRAN_INFO>();
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
