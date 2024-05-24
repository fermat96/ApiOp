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
    public class PermisosUsuariosData
    {
        private static string SPNombre = "PapSp138";
        public async Task<Result> ListarPermisosUsuarios(string strConexion, int startRow, int endRow, string Filtro, int IdArea)
        {
            Result objResult = new Result();
            try
            {
                using (var con = new SqlConnection(strConexion))
                {
                    var result = await con.QueryMultipleAsync(
                        SPNombre,
                        new
                        {
                            Opcion = 1,
                            startRow,
                            endRow,
                            Filtro,
                            IdArea
                        },
                    commandType: CommandType.StoredProcedure);
                    objResult.data = await result.ReadAsync<PermisosUsuarios>();
                    objResult.totalRecords = await result.ReadFirstAsync<int>();
                }
                return objResult;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<Result> MostrarPermiso(string strConexion, int IdUsuario, int IdArea)
        {
            Result objResult = new Result();
            try
            {
                using (var con = new SqlConnection(strConexion))
                {
                    var result = await con.QueryMultipleAsync(
                        SPNombre,
                        new
                        {
                            Opcion = 2,
                            IdUsuario,
                            IdArea
                        },
                    commandType: CommandType.StoredProcedure);
                    objResult.data = await result.ReadAsync<PermisosUsuarios>();
                    objResult.totalRecords = await result.ReadFirstAsync<int>();
                }
                return objResult;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<Result> Editar(TokenData datosToken, PermisosUsuarios Permiso)
        {
            Result objResult = new Result();
            try
            {
                using (var con = new SqlConnection(datosToken.Conexion))
                {

                    await con.QueryFirstOrDefaultAsync(
                        SPNombre,
                        new
                        {
                            Opcion = 4,
                            Permiso.IdUsuario,
                            Permiso.IdArea,
                            Permiso.EsAdmin,
                            Permiso.EsActivo,
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

        public async Task<Result> Agregar(TokenData datosToken, PermisosUsuarios Permiso)
        {
            Result objResult = new Result();
            try
            {
                using (var con = new SqlConnection(datosToken.Conexion))
                {
                    
                    await con.QueryFirstOrDefaultAsync(
                        SPNombre,
                        new
                        {
                            Opcion = 3,
                            Permiso.IdUsuario,
                            Permiso.IdArea,
                            Permiso.EsAdmin,
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
