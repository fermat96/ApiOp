using Data;
using Entity.DTO.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using System;
using Business;
using Entity;
using System.Collections.Generic;

namespace FPAVENTAPI001.Controllers
{
    [Authorize]
    [Route("/[controller]")]
    [ApiController]
    public class PAP007MFController : ControllerBase
    {
        private readonly TokenData datosToken = new TokenData();

        public PAP007MFController(IOptions<AppSettings> AppSettings, IHttpContextAccessor httpContext)
        {
            datosToken.Conexion = httpContext.HttpContext.Items["Conexion"].ToString();
            datosToken.Usuario = httpContext.HttpContext.Items["UsuarioERP"].ToString();
            datosToken.Zona = httpContext.HttpContext.Items["Zona"].ToString();
        }

        #region METODOS GET
        [HttpGet("ObtenerProgramas")]
        public async Task<IActionResult> ObtenerProgramas(string IdProduccion)
        {
            try
            {
                return Ok(await new PAP007MFBusiness().ObtenerProgramas(datosToken, IdProduccion));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error,{ex.Message}");

            }
        }

        [HttpGet("ObtenerBobinas")]
        public async Task<IActionResult> ObtenerBobinas(string IdProduccion, string idPrograma, string idMaquina, string op, string tipoHB)
        {
            try
            {
                return Ok(await new PAP007MFBusiness().ObtenerBobinas(datosToken, IdProduccion, idPrograma, idMaquina, op, tipoHB));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error,{ex.Message}");

            }
        }

        [HttpGet("ObtenerTarimas")]
        public async Task<IActionResult> ObtenerTarimas(string IdProduccion, string idPrograma, string idMaquina, string op, string tipoHB, string idPartida, string alma)
        {
            try
            {
                return Ok(await new PAP007MFBusiness().ObtenerTarimas(datosToken, IdProduccion, idPrograma, idMaquina, op, tipoHB, idPartida, alma));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error,{ex.Message}");

            }
        }
        #endregion

        #region METODOS UPDATE
        [HttpPost("CancelarBobinas")]
        public async Task<IActionResult> CancelarBobinas(List<PAP007MF_CANCELAR_BOBINAS> listDocumento)
        {
            try
            {
                return Ok(await new PAP007MFBusiness().CancelarBobinas(datosToken, listDocumento));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error,{ex.Message}");

            }
        }

        [HttpPost("CancelarTarimas")]
        public async Task<IActionResult> CancelarTarimas(List<PAP007MF_CANCELAR_BOBINAS> listDocumento)
        {
            try
            {
                return Ok(await new PAP007MFBusiness().CancelarTarimas(datosToken, listDocumento));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error,{ex.Message}");

            }
        }

        [HttpGet("CancelarFolio")]
        public async Task<IActionResult> CancelarFolio(string idProduccion)
        {
            try
            {
                return Ok(await new PAP007MFBusiness().CancelarFolio(datosToken, idProduccion));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error,{ex.Message}");

            }
        }
        #endregion
    }
}
