using Data;
using System;
using Entity.DTO.Common;
using System.Threading.Tasks;
using Entity;
using System.Collections.Generic;

namespace Business
{
    public class PermisosUsuariosBusiness
    {
        public async Task<Result> ListarPermisosUsuarios(string strConexion, int startRow, int endRow, string Filtro, int IdArea)
        {
            try
            {
                return await new PermisosUsuariosData().ListarPermisosUsuarios(strConexion, startRow, endRow, Filtro, IdArea);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<Result> MostrarPermiso(string strConexion, int IdUsuario, int IdArea)
        {
            try
            {
                return await new PermisosUsuariosData().MostrarPermiso(strConexion, IdUsuario, IdArea);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<Result> Agregar(TokenData datosToken, PermisosUsuarios Permiso)
        {
            try
            {
                return await new PermisosUsuariosData().Agregar(datosToken, Permiso);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<Result> Editar(TokenData datosToken, PermisosUsuarios Permiso)
        {
            try
            {
                return await new PermisosUsuariosData().Editar(datosToken, Permiso);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
