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
    public class PAPCAP010Data
    {
        #region METODOS GET
        public async Task<Result> ObtenerMaquina(TokenData datosToken, string idMaquina)
        {
            Result objResult = new Result();
            try
            {
                using (var con = new SqlConnection(datosToken.Conexion))
                {
                    var result = await con.QueryMultipleAsync(
                        "PAPCAP010SPC1_TEMPORAL",
                        new
                        {
                            accion = 0,
                            IdMaquina = Convert.ToInt32(idMaquina)
                        },
                    commandType: CommandType.StoredProcedure);
                    objResult.data = await result.ReadAsync<string>();
                }

                return objResult;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<Result> EstadoPrograma(TokenData datosToken, string idMaquina, string idPrograma)
        {
            Result objResult = new Result();
            try
            {
                using (var con = new SqlConnection(datosToken.Conexion))
                {
                    var result = await con.QueryMultipleAsync(
                        "PAPCAP010SPC1_TEMPORAL",
                        new
                        {
                            accion = 1,
                            IdMaquina = Convert.ToInt32(idMaquina),
                            IdPrograma = Convert.ToInt32(idPrograma)
                        },
                    commandType: CommandType.StoredProcedure);
                    objResult.data = await result.ReadAsync<string>();
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
        public async Task<Result> UpdateEstado(TokenData datosToken, string idMaquina, string idPrograma, string estado)
        {
            Result objResult = new Result();
            try
            {
                using (var con = new SqlConnection(datosToken.Conexion))
                {
                    var result = await con.QueryMultipleAsync(
                        "PAPCAP010SPA2_TEMPORAL",
                        new
                        {
                            accion = 0,
                            IdMaquina = Convert.ToInt32(idMaquina),
                            IdPrograma = Convert.ToInt32(idPrograma),
                            Estado = estado
                        },
                    commandType: CommandType.StoredProcedure);
                    objResult.Mensaje = "Acción Completada con Exito.";
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
