using Entity.DTO.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Entity;
using System.Globalization;
using Entity.DTO;

namespace Data
{
    public class PAP006MFData
    {
        #region METODOS GET
        public async Task<Result> ObtenerTarimas(TokenData datosToken, string fechaInicial, string fechaFin, string tipoMaterial)
        {
            Result objResult = new Result();
            try
            {
                using (var con = new SqlConnection(datosToken.Conexion))
                {
                    var result = await con.QueryMultipleAsync(
                        "PAP006MFC1_TEMPORAL",
                        new
                        {
                            accion = 0,
                            fechaInicial = fechaInicial,
                            fechaFin = fechaFin,
                            TipoHB = tipoMaterial
                        },
                    commandType: CommandType.StoredProcedure);
                    objResult.data = await result.ReadAsync<PAP006MF_TARIMAS>();
                }

                return objResult;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<Result> ValidarExistencia(TokenData datosToken, string codigo2)
        {
            Result objResult = new Result();
            try
            {
                using (var con = new SqlConnection(datosToken.Conexion))
                {
                    var result = await con.QuerySingleAsync<int>(
                        "PAP006MFC1_TEMPORAL",
                        new
                        {
                            accion = 1,
                            codigo2 = codigo2
                        }, 
                    commandType: CommandType.StoredProcedure);
                    objResult.data = result;
                }

                return objResult;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<Result> RegresaFolioE_S(TokenData datosToken, string tipoMovimiento, string folioE_S, string TipoHB, string IdProduccion, string AlmSalidas)
        {
            Result objResult = new Result();
            try
            {
                using (var con = new SqlConnection(datosToken.Conexion))
                {
                    var result = await con.QuerySingleAsync<string>(
                        "PAP006MFC1_TEMPORAL",
                        new
                        {
                            accion = 2,
                            FolioE_S = folioE_S,
                            TipoHB = TipoHB,
                            TipoMovimiento = tipoMovimiento,
                            IdProduccion = IdProduccion,
                            AlmSalidas = AlmSalidas
                        },
                    commandType: CommandType.StoredProcedure);
                    objResult.data = result;
                }

                return objResult;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<Result> BusRollosSalAlm(TokenData datosToken, string programa, string partida, string maquinaHR, string tipoHB, string idProduccion)
        {
            Result objResult = new Result();
            try
                {
                using (var con = new SqlConnection(datosToken.Conexion))
                {
                    var result = await con.QueryMultipleAsync(
                        "PAP006MFC1_TEMPORAL",
                        new
                        {
                            accion = 3,
                            IdProduccion = Convert.ToInt32(idProduccion),
                            Programa = Convert.ToInt32(programa),
                            Partida = Convert.ToInt32(partida),
                            MaquinaHR = Convert.ToInt32(maquinaHR),
                            TipoHB = tipoHB
                        },
                    commandType: CommandType.StoredProcedure);
                    objResult.data = await result.ReadAsync<PAP006MF_ROLLOS_SALIDA>();
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
        public async Task<Result> ActualizarInsertarTarima(TokenData datosToken, PAP006MF_OBJETO tarimas)
        {
            Result objResult = new Result();
            try
            {
                TranformaDataTable Ds = new TranformaDataTable();
                using (var con = new SqlConnection(datosToken.Conexion))
                {
                    var result = await con.QuerySingleAsync<string>(
                        "PAP006MFSPA2",
                        new
                        {
                            accion = 0,
                            tblTarima = Ds.CreateDataTable(tarimas.tarimas).AsTableValuedParameter("PAP006MFTD_001")
                        },
                    commandType: CommandType.StoredProcedure);
                    objResult.Mensaje = result;
                }

                return objResult;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<Result> IncrementarFolio(TokenData datosToken, string tipoMovimiento, string folioE_S, string TipoHB, string IdProduccion, string AlmSalidas)
        {
            Result objResult = new Result();
            try
            {
                using (var con = new SqlConnection(datosToken.Conexion))
                {
                    var result = await con.ExecuteAsync(
                        "PAP006MFSPA2",
                        new
                        {
                            accion = 1,
                            FolioE_S = folioE_S,
                            TipoHB = TipoHB,
                            TipoMovimiento = tipoMovimiento,
                            IdProduccion = IdProduccion,
                            AlmSalidas = AlmSalidas
                        },
                    commandType: CommandType.StoredProcedure);
                    objResult.Correcto = true;
                }
                return objResult;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<Result> GenEntradasAuth(TokenData datosToken, PAP006MF_ARTICULOS articulos)
        {
            Result objResult = new Result();
            try
            {
                TranformaDataTable Ds = new TranformaDataTable();
                using (var con = new SqlConnection(datosToken.Conexion))
                {
                    var result = await con.QuerySingleAsync<string>(
                        "PAP006MFSPA2",
                        new
                        {
                            accion = 2,
                            TipoMovimiento = articulos.TipoMovimiento,
                            Cantidad = articulos.Cantidad,
                            PrecioU = articulos.PrecioU,
                            idTurno = articulos.idTurno,
                            UsuarioERP = datosToken.Usuario,
                            TipoHB = articulos.TipoHB,
                            tblArticulos = Ds.CreateDataTable(articulos.tblArticulos).AsTableValuedParameter("PAP006MFTD_002")
                        },
                    commandType: CommandType.StoredProcedure);
                    objResult.data = result;
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
        public async Task<Result> EliminarInsumosAlmacenes(TokenData datosToken, string articulos)
        {
            Result objResult = new Result();
            try
            {
                TranformaDataTable Ds = new TranformaDataTable();
                using (var con = new SqlConnection(datosToken.Conexion))
                {
                    var result = await con.QuerySingleAsync<string>(
                        "PAP006MFSPA2",
                        new
                        {
                            accion = 3,
                            Articulo = articulos
                        },
                    commandType: CommandType.StoredProcedure);
                    objResult.data = result;
                }

                return objResult;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<Result> ActRollosSalida(TokenData datosToken, string iPrograma, string iMaquina, string tipoHB)
        {
            Result objResult = new Result();
            try
            {
                using (var con = new SqlConnection(datosToken.Conexion))
                {
                    var result = await con.ExecuteAsync(
                        "PAP006MFSPA2",
                        new
                        {
                            accion = 3,
                            Programa = iPrograma,
                            Maquina = iMaquina,
                            TipoHB = tipoHB
                        },
                    commandType: CommandType.StoredProcedure);
                    objResult.data = result;
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
        public async Task<Result> GenCentroCosto(TokenData datosToken, string folioE_S, string tipoHB)
        {
            Result objResult = new Result();
            try
            {
                TranformaDataTable Ds = new TranformaDataTable();
                using (var con = new SqlConnection(datosToken.Conexion))
                {
                    var result = await con.ExecuteAsync(
                        "PAP006MFSPA2",
                        new
                        {
                            accion = 4,
                            FolioE_S = folioE_S,
                            TipoHB = tipoHB,
                            TipoMovimiento = 'S'
                        },
                    commandType: CommandType.StoredProcedure);
                    objResult.Correcto = true;
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
