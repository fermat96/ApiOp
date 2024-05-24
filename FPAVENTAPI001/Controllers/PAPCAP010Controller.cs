using Business;
using Entity.DTO.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using System;
using Data;

namespace FPAVENTAPI001.Controllers
{
    [Authorize]
    [Route("/[controller]")]
    [ApiController]
    public class PAPCAP010Controller : ControllerBase
    {
        private readonly TokenData datosToken = new TokenData();

        public PAPCAP010Controller(IOptions<AppSettings> AppSettings, IHttpContextAccessor httpContext)
        {
            datosToken.Conexion = httpContext.HttpContext.Items["Conexion"].ToString();
            datosToken.Conexion2 = httpContext.HttpContext.Items["Conexion2"].ToString(); //poputepipikku
            datosToken.Usuario = httpContext.HttpContext.Items["UsuarioERP"].ToString();
            datosToken.Zona = httpContext.HttpContext.Items["Zona"].ToString();
        }

        [HttpGet("EstadoPrograma")]
        public async Task<IActionResult> EstadoPrograma(string idMaquina, string idPrograma)
        {
            try
            {
                return Ok(await new PAPCAP010Data().EstadoPrograma(datosToken, idMaquina, idPrograma));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error,{ex.Message}");

            }
        }

        [HttpGet("ObtenerMaquina")]
        public async Task<IActionResult> ObtenerMaquina(string idMaquina)
        {
            try
            {
                return Ok(await new PAPCAP010Data().ObtenerMaquina(datosToken, idMaquina));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error,{ex.Message}");

            }
        }

        [HttpGet("UpdateEstado")]
        public async Task<IActionResult> UpdateEstado(string idMaquina, string idPrograma, string estado)
        {
            try
            {
                return Ok(await new PAPCAP010Data().UpdateEstado(datosToken, idMaquina, idPrograma, estado));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error,{ex.Message}");

            }
        }
    }
}
