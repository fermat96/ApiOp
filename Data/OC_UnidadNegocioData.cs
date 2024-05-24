using Dapper;
using Entity;
using Entity.DTO;
using Entity.DTO.Common;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Data
{
    public class OC_UnidadNegocioData
    {
        public async Task<Result> GetOC_UnidadNegocio(string strConexion, int startRow, int endRow, string Filtro, string FiltroUN)
        {
            Result objResult = new Result();
            try
            {
                using (var con = new SqlConnection(strConexion))
                {
                    var result = await con.QueryMultipleAsync(
                        new SPNombre().Nombre,
                        new
                        {
                            Opcion = 2,
                            startRow,
                            endRow,
                            Filtro,
                            FiltroUN
                        },
                    commandType: CommandType.StoredProcedure);
                    objResult.data = await result.ReadAsync<OC_UnidadNegocio>();
                    objResult.totalRecords = await result.ReadFirstAsync<int>();
                }
                return objResult;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<bool> GetDuplicado(string strConexion, string OC)
        {
            using (var con = new SqlConnection(strConexion))
            {
                var Existe = await con.ExecuteScalarAsync(new SPNombre().Nombre, new { Opcion = 1, OC },
                    commandType: System.Data.CommandType.StoredProcedure);
                if (Convert.ToInt32(Existe) > 0)
                {
                    return true;
                }
                return false;
            }
        }

        public async Task<Result> Agregar(TokenData datosToken, OC_UnidadNegocio NuevaOC)
        {
            Result objResult = new Result();
            try
            {
                using (var con = new SqlConnection(datosToken.Conexion))
                {
                    SPNombre nombre = new SPNombre(Enums.SpTipo.Actualiza);
                    await con.QueryFirstOrDefaultAsync(
                        nombre.Nombre,
                        new
                        {
                            Opcion = 1,
                            NuevaOC.OC,
                            NuevaOC.UnidadNegocio,
                            datosToken.Usuario
                        },
                        commandType: CommandType.StoredProcedure);
                    objResult.Correcto = true;
                    return objResult;
                }
            }
            catch (Exception ex)
            {
                objResult.Correcto = false;
                objResult.Mensaje = ex.Message;
                return objResult;
            }
        }

        public async Task<Result> Eliminar(TokenData datosToken, OC_UnidadNegocio OC_Seleccionada)
        {
            Result objResult = new Result();
            try
            {
                using (var con = new SqlConnection(datosToken.Conexion))
                {
                    SPNombre nombre = new SPNombre(Enums.SpTipo.Actualiza);
                    await con.QueryFirstOrDefaultAsync(
                        nombre.Nombre,
                        new
                        {
                            Opcion = 2,
                            OC_Seleccionada.OC,
                            datosToken.Usuario
                        },
                        commandType: CommandType.StoredProcedure);
                    objResult.Correcto = true;
                    return objResult;
                }
            }
            catch (Exception ex)
            {
                objResult.Correcto = false;
                objResult.Mensaje = ex.Message;
                return objResult;
            }
        }
    }
}
