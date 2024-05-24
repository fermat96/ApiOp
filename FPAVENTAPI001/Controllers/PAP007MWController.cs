using Business;
using Entity.DTO.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using System;
using Entity;

namespace FPAVENTAPI001.Controllers
{
    [Authorize]
    [Route("/[controller]")]
    [ApiController]
    public class PAP007MWController : ControllerBase
    {
        private readonly TokenData datosToken = new TokenData();
        public PAP007MWController(IOptions<AppSettings> AppSettings, IHttpContextAccessor httpContext)
        {
            datosToken.Conexion = httpContext.HttpContext.Items["Conexion"].ToString();
            datosToken.Conexion2 = httpContext.HttpContext.Items["Conexion2"].ToString();
            datosToken.Usuario = httpContext.HttpContext.Items["UsuarioERP"].ToString();
            datosToken.Zona = httpContext.HttpContext.Items["Zona"].ToString();
        }

        #region METODOS GET
        [HttpGet("ObtenerClientes")]
        public async Task<IActionResult> ObtenerClientes(string fechaIni, string fechaFin)
        {
            try
            {
                return Ok(await new PAP007MWBusiness().ObtenerClientes(datosToken, fechaIni, fechaFin));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error,{ex.Message}");

            }
        }

        [HttpGet("ObtenerGramaje")]
        public async Task<IActionResult> ObtenerGramaje(string IdMaquina, string RangoMenor, string RangoMayor)
        {
            try
            {                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     
                return Ok(await new PAP007MWBusiness().ObtenerGramaje(datosToken, IdMaquina, RangoMenor, RangoMayor));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error,{ex.Message}");

            }
        }

        [HttpGet("ObtenerRolloInfo")]
        public async Task<IActionResult> ObtenerRolloInfo(string OrdenCompra)
        {
            try
            {
                return Ok(await new PAP007MWBusiness().ObtenerRolloInfo(datosToken, OrdenCompra));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error,{ex.Message}");

            }
        }

        [HttpGet("ObtenerSecuenciasClientes")]
        public async Task<IActionResult> ObtenerSecuenciasClientes()
        {
            try  
            {
                return Ok(await new PAP007MWBusiness().ObtenerSecuenciasClientes(datosToken));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error,{ex.Message}");

            }
        }

        [HttpGet("ObtenerSecuenciasModificar")]
        public async Task<IActionResult> ObtenerSecuenciasModificar(string secuencia)
        {
            try
            {
                return Ok(await new PAP007MWBusiness().ObtenerSecuenciasModificar(datosToken, secuencia));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error,{ex.Message}");

            }
        }

        [HttpGet("ObtenerPartidasOP")]
        public async Task<IActionResult> ObtenerPartidasOP(string op)
        {
            try
            {                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                
                return Ok(await new PAP007MWBusiness().ObtenerPartidasOP(datosToken, op));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error,{ex.Message}");

            }
        }

        [HttpGet("ObtenerEstatusPrograma")]
        public async Task<IActionResult> ObtenerEstatusPrograma(string secuencia)
        {
            try
            {
                return Ok(await new PAP007MWBusiness().ObtenerEstatusPrograma(datosToken, secuencia));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error,{ex.Message}");

            }
        }
        #endregion

        #region METODOS INSERT
        [HttpPost("InsertarRollos")]
        public async Task<IActionResult> InsertarRollos(PAP007MW_DATA_INSERT dt)
        {
            try
            {
                return Ok(await new PAP007MWBusiness().InsertarRollos(datosToken, dt));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error,{ex.Message}");

            }
        }
        #endregion

        #region METODOS UPDATE
        [HttpPost("InsertarUpdatePartida")]
        public async Task<IActionResult> InsertarUpdatePartida(PAP007MW_INSERT_UPDATE dt)
        {
            try
            {
                return Ok(await new PAP007MWBusiness().InsertarUpdatePartida(datosToken, dt));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error,{ex.Message}");

            }
        }
        #endregion

        #region METODOS DELETE
        [HttpGet("EliminarSecuencia")]
        public async Task<IActionResult> EliminarSecuencia(string secuencia)
        {
            try
            {
                return Ok(await new PAP007MWBusiness().EliminarSecuencia(datosToken, secuencia));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error,{ex.Message}");

            }
        }
        #endregion


    }
}
