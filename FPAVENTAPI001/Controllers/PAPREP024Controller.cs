using Business;
using Entity.DTO.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Authorization;

namespace FPAVENTAPI001.Controllers
{
    [Authorize]
    [Route("/[controller]")]
    [ApiController]
    public class PAPREP024Controller : ControllerBase
    {
        private readonly TokenData datosToken = new TokenData();
        public PAPREP024Controller(IOptions<AppSettings> AppSettings, IHttpContextAccessor httpContext)
        {
            datosToken.Conexion = httpContext.HttpContext.Items["Conexion"].ToString();
            datosToken.Conexion2 = httpContext.HttpContext.Items["Conexion2"].ToString();
            datosToken.Usuario = httpContext.HttpContext.Items["UsuarioERP"].ToString();
            datosToken.Zona = httpContext.HttpContext.Items["Zona"].ToString();
        }

        #region METODOS GET
        [HttpGet("ObtenerClientes")]
        public async Task<IActionResult> ObtenerClientes(string nombre)
        {
            try
            {
                return Ok(await new PAPREP024Business().ObtenerClientes(datosToken, nombre));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error,{ex.Message}");

            }
        }

        [HttpGet("ObtenerClientesID")]
        public async Task<IActionResult> ObtenerClientesID(string id)
        {
            try
            {
                return Ok(await new PAPREP024Business().ObtenerClientesID(datosToken, id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error,{ex.Message}");

            }
        }

        [HttpGet("ObtenerDatosReporte")]
        public async Task<IActionResult> ObtenerDatosReporte(string material, string idCliente, string fechaInicio, string fechaFin, string op, string rolloEmbarque)
        {
            try
            {
                return Ok(await new PAPREP024Business().ObtenerDatosReporte(datosToken, material, idCliente, fechaInicio, fechaFin, op, rolloEmbarque));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error,{ex.Message}");

            }
        }
        #endregion


    }
}
