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
    public class OC_UnidadNegocioController : ControllerBase
    {
        private readonly TokenData datosToken = new TokenData();
        public OC_UnidadNegocioController(IOptions<AppSettings> AppSettings, IHttpContextAccessor httpContext)
        {
            datosToken.Conexion = httpContext.HttpContext.Items["Conexion"].ToString();
            datosToken.Usuario = httpContext.HttpContext.Items["UsuarioERP"].ToString();
        }

        [HttpGet("getListar")]
        public async Task<IActionResult> GetOC_UnidadNegocio(int startRow, int endRow, string Filtro, string FiltroUN)
        {
            try
            {
                return Ok(await new OC_UnidadNegocioBusiness().GetOC_UnidadNegocio(datosToken.Conexion, startRow, endRow, Filtro, FiltroUN));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error, {ex.Message}");
            }
        }

        [HttpGet("getDuplicados")]
        public async Task<IActionResult> GetDuplicados(string OC)
        {
            try
            {
                return Ok(await new OC_UnidadNegocioBusiness().GetDuplicado(datosToken.Conexion, OC));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error, {ex.Message}");
            }
        }

        [HttpPost("postAgregar")]
        public async Task<IActionResult> Agregar(OC_UnidadNegocio NuevaOC)
        {
            try
            {
                return Ok(await new OC_UnidadNegocioBusiness().Agregar(datosToken, NuevaOC));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error, {ex.Message}");
            }
        }

        [HttpPost("postEliminar")]
        public async Task<IActionResult> Eliminar(OC_UnidadNegocio OC_Seleccionada)
        {
            try
            {
                return Ok(await new OC_UnidadNegocioBusiness().Eliminar(datosToken, OC_Seleccionada));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error, {ex.Message}");
            }
        }

    }
}
