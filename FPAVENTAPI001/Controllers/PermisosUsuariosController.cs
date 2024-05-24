using System;
using System.Threading.Tasks;
using Business;
using Entity;
using Entity.DTO.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FPAVENTAPI001.Controllers
{
    [Authorize]
    [Route("/[controller]")]
    [ApiController]
    public class PermisosUsuariosController : ControllerBase
    {
        private readonly TokenData datosToken = new TokenData();
        public PermisosUsuariosController(IOptions<AppSettings> AppSettings, IHttpContextAccessor httpContext)
        {
            datosToken.Conexion = httpContext.HttpContext.Items["Conexion"].ToString();
            datosToken.Usuario = httpContext.HttpContext.Items["UsuarioERP"].ToString();
        }

        [HttpGet("getListar")]
        public async Task<IActionResult> ListarPermisosUsuarios(int startRow, int endRow, string Filtro, int IdArea)
        {
            try
            {
                return Ok(await new PermisosUsuariosBusiness().ListarPermisosUsuarios(datosToken.Conexion, startRow, endRow, Filtro, IdArea));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error, {ex.Message}");
            }
        }

        [HttpGet("getMostrar")]
        public async Task<IActionResult> Mostrar(int IdUsuario, int IdArea)
        {
            try
            {
                return Ok(await new PermisosUsuariosBusiness().MostrarPermiso(datosToken.Conexion, IdUsuario, IdArea));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error, {ex.Message}");
            }
        }

        [HttpPost("postAgregar")]
        public async Task<IActionResult> Agregar(PermisosUsuarios Permiso)
        {
            try
            {
                return Ok(await new PermisosUsuariosBusiness().Agregar(datosToken, Permiso));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error, {ex.Message}");
            }
        }

        [HttpPost("postEditar")]
        public async Task<IActionResult> Editar(PermisosUsuarios Permiso)
        {
            try
            {
                return Ok(await new PermisosUsuariosBusiness().Editar(datosToken, Permiso));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error, {ex.Message}");
            }
        }
    }
}
