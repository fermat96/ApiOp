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
    public class PAP007MWData
    {
        #region METODOS GET
        public async Task<Result> ObtenerClientes(TokenData datosToken, string fechaIni, string fechaFin)
        {
            Result objResult = new Result();
            try
            {
                using (var con = new SqlConnection(datosToken.Conexion))
                {
                    var result = await con.QueryMultipleAsync(
                        "FPAPROG003MWSPC2",
                        new
                        {
                            accion = 0,
                            FechaIni = fechaIni,
                            FechaFin = fechaFin,
                            BanRegresaInfo = 1
                        },
                    commandType: CommandType.StoredProcedure);
                    objResult.data = await result.ReadAsync<PAP007MW_DATOS_CLIENTE>();
                }
                return objResult;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<Result> ObtenerGramaje(TokenData datosToken, string IdMaquina, string RangoMenor, string RangoMayor)
        {
            Result objResult = new Result();
            try
            {
                using (var con = new SqlConnection(datosToken.Conexion))
                {
                    var result = await con.QueryMultipleAsync(
                        "FPAPROG003MWSPC2",
                        new
                        {
                            accion = 2,
                            IdMaquina = Convert.ToInt32(IdMaquina),
                            RangoMenor = RangoMenor,
                            RangoMayor = RangoMayor
                        },
                    commandType: CommandType.StoredProcedure);
                    objResult.data = await result.ReadAsync<PAP007MW_GRAMAJE>();
                }
                return objResult;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<Result> ObtenerRolloInfo(TokenData datosToken, string OrdenCompra)
        {
            Result objResult = new Result();
            try
            {
                using (var con = new SqlConnection(datosToken.Conexion))
                {
                    var result = await con.QueryMultipleAsync(
                        "FPAPROG003MWSPC2",
                        new
                        {
                            accion = 3,
                            OrdenCompra = OrdenCompra
                        },
                    commandType: CommandType.StoredProcedure);
                    objResult.data = await result.ReadAsync<PAP007MW_ROLLOS>();
                }
                 return objResult;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<Result> ObtenerSecuenciasClientes(TokenData datosToken)
        {
            Result objResult = new Result();
            try
            {
                using (var con = new SqlConnection(datosToken.Conexion))
                {
                    var result = await con.QueryMultipleAsync(
                        "FPAPROG003MWSPC2",
                        new
                        {
                            accion = 4
                        },
                    commandType: CommandType.StoredProcedure);
                    objResult.data = await result.ReadAsync<PAP007MW_SECUENCIAS>();
                    objResult.data2 = await result.ReadAsync<PAP007MW_CLIENTES>();
                }
                return objResult;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<Result> ObtenerSecuenciasModificar(TokenData datosToken, string secuencia)
        {
            Result objResult = new Result();
            try
            {
                using (var con = new SqlConnection(datosToken.Conexion))
                {
                    var result = await con.QueryMultipleAsync(
                        "FPAPROG003MWSPC2",
                        new
                        {
                            accion = 9,
                            IdSecuencia = Convert.ToInt32(secuencia)
                        },
                    commandType: CommandType.StoredProcedure);
                    objResult.data = await result.ReadAsync<PAP007MW_SECUENCIAS_MODIFICACION>();
                    objResult.data2 = await result.ReadAsync<string>();
                }
                return objResult;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<Result> ObtenerPartidasOP(TokenData datosToken, string op)
        {
            Result objResult = new Result();
            try
            {
                using (var con = new SqlConnection(datosToken.Conexion))
                {
                    var result = await con.QueryMultipleAsync(
                        "FPAPROG003MWSPC2",
                        new
                        {
                            accion = 10,
                            OP = op
                        },
                    commandType: CommandType.StoredProcedure);
                    objResult.data = await result.ReadAsync<PAP007MW_SECUENCIAS_MODIFICACION>();
                }
                return objResult;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<Result> ObtenerEstatusPrograma(TokenData datosToken, string secuencia)
        {
            Result objResult = new Result();
            try
            {
                using (var con = new SqlConnection(datosToken.Conexion))
                {
                    var result = await con.QueryMultipleAsync(
                        "FPAPROG003MWSPC2",
                        new
                        {
                            accion = 11,
                            IdSecuencia = Convert.ToInt32(secuencia)
                        },
                    commandType: CommandType.StoredProcedure);
                    objResult.data = await result.ReadAsync<PAP007MW_PROGRAMA>();
                }
                return objResult;
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
            Result objResult = new Result();
            try
            {
                int xIdSec = 0;
                using (var con = new SqlConnection(datosToken.Conexion))
                {
                    var result = await con.QuerySingleAsync<int>(
                        "FPAPROG003MWSPA1",
                        new
                        {
                            accion = 0,
                            UsuarioERP = datosToken.Usuario,
                            FechaProbableEntrega = dt.fechaEntrega,
                            Comentario = dt.Comentarios
                        },
                    commandType: CommandType.StoredProcedure);
                    xIdSec = result;
                    objResult.Mensaje = "SECUENCIA [<strong>" + xIdSec + "</strong>] GENERADA CORRECTAMENTE!";
                }

                foreach (PAP007MWTB_01 item in dt.PAP007MWTB)
                {
                    item.IdSecuencia = xIdSec;
                }

                using (var con = new SqlConnection(datosToken.Conexion))
                {
                    TranformaDataTable Ds = new TranformaDataTable();
                    var result = await con.QueryMultipleAsync(
                        "FPAPROG003MWSPA1",
                        new
                        {
                            accion = 1,
                            PAP007MWTB = Ds.CreateDataTable(dt.PAP007MWTB).AsTableValuedParameter("PAP007MWTB_TEMPORAL_01")
                        },
                    commandType: CommandType.StoredProcedure);
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
        public async Task<Result> InsertarUpdatePartida(TokenData datosToken, PAP007MW_INSERT_UPDATE dt)
        {
            Result objResult = new Result();
            try
            {
                using (var con = new SqlConnection(datosToken.Conexion))
                {
                    TranformaDataTable Ds = new TranformaDataTable();
                    var result = await con.QueryMultipleAsync(
                        "FPAPROG003MWSPA1",
                        new
                        {
                            accion = 2,
                            IdSecuencia = dt.IdSecuencia,
                            paramTablePapDat046 = Ds.CreateDataTable(dt.paramTablePapDat046).AsTableValuedParameter("PAP007MWTB_TEMPORAL_02")
                        },
                    commandType: CommandType.StoredProcedure);
                    objResult.Mensaje = "Secuencia [" + dt.IdSecuencia + "] Actualizada Correctamente".ToUpper();
                }
                return objResult;
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
            Result objResult = new Result();
            try
            {
                using (var con = new SqlConnection(datosToken.Conexion))
                {
                    var result = await con.QueryMultipleAsync(
                        "FPAPROG003MWSPA1",
                        new
                        {
                            accion = 3,
                            IdSecuencia = Convert.ToInt32(secuencia),
                            UsuarioERP = datosToken.Usuario
                        },
                    commandType: CommandType.StoredProcedure);
                    objResult.Mensaje = "Secuencia [<strong>"+secuencia+"</strong>] Eliminada Correctamente";
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
