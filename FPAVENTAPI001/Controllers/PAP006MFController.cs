using Data;
using Entity.DTO.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using System;
using Entity;
using System.Collections.Generic;
using Business;

namespace FPAVENTAPI001.Controllers
{
    [Authorize]
    [Route("/[controller]")]
    [ApiController]
    public class PAP006MFController : ControllerBase
    {
        private readonly TokenData datosToken = new TokenData();

        public PAP006MFController(IOptions<AppSettings> AppSettings, IHttpContextAccessor httpContext)
        {
            datosToken.Conexion = httpContext.HttpContext.Items["Conexion"].ToString();
            datosToken.Usuario = httpContext.HttpContext.Items["UsuarioERP"].ToString();
            datosToken.Zona = httpContext.HttpContext.Items["Zona"].ToString();
        }

        #region METODOS GET
        [HttpGet("ObtenerTarimas")]
        public async Task<IActionResult> ObtenerTarimas(string fechaInicial, string fechaFin, string tipoMaterial)
        {
            try
            {
                return Ok(await new PAP006MFBusiness().ObtenerTarimas(datosToken, fechaInicial, fechaFin, tipoMaterial));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error,{ex.Message}");

            }
        }

        [HttpGet("ValidarExistencia")]
        public async Task<IActionResult> ValidarExistencia(string codigo2)
        {
            try
            {
                return Ok(await new PAP006MFBusiness().ValidarExistencia(datosToken, codigo2));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error,{ex.Message}");

            }
        }

        [HttpGet("RegresaFolioE_S")]
        public async Task<IActionResult> RegresaFolioE_S(string tipoMovimiento, string folioE_S, string TipoHB, string IdProduccion, string AlmSalidas)
        {
            try
            {
                return Ok(await new PAP006MFBusiness().RegresaFolioE_S(datosToken,tipoMovimiento, folioE_S, TipoHB, IdProduccion, AlmSalidas));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error,{ex.Message}");

            }
        }

        [HttpGet("BusRollosSalAlm")]
        public async Task<IActionResult> BusRollosSalAlm(string programa, string partida, string maquinaHR, string tipoHB, string idProduccion)
        {
            try
            {
                return Ok(await new PAP006MFBusiness().BusRollosSalAlm(datosToken, programa, partida, maquinaHR, tipoHB, idProduccion));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error,{ex.Message}");

            }
        }
        #endregion

        #region METODOS UPDATE
        [HttpPost("ActualizarInsertarTarima")]
        public async Task<IActionResult> ActualizarInsertarTarima(PAP006MF_OBJETO tarimas)
        {
            try
            {
                return Ok(await new PAP006MFBusiness().ActualizarInsertarTarima(datosToken, tarimas));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error,{ex.Message}");

            }
        }

        [HttpPost("GenEntradasAuth")]
        public async Task<IActionResult> GenEntradasAuth(PAP006MF_ARTICULOS articulos)
        {
            try
            {
                return Ok(await new PAP006MFBusiness().GenEntradasAuth(datosToken, articulos));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error,{ex.Message}");

            }
        }

        [HttpGet("IncrementarFolio")]
        public async Task<IActionResult> IncrementarFolio(string tipoMovimiento, string folioE_S, string TipoHB, string IdProduccion, string AlmSalidas)
        {
            try
            {
                return Ok(await new PAP006MFBusiness().IncrementarFolio(datosToken, tipoMovimiento, folioE_S, TipoHB, IdProduccion, AlmSalidas));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error,{ex.Message}");

            }
        }
        #endregion

        #region METODOS DELETE
        [HttpGet("EliminarInsumosAlmacenes")]
        public async Task<IActionResult> EliminarInsumosAlmacenes(string atributos)
        {
            try
            {
                return Ok(await new PAP006MFBusiness().EliminarInsumosAlmacenes(datosToken, atributos));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error,{ex.Message}");

            }
        }

        [HttpGet("ActRollosSalida")]
        public async Task<IActionResult> ActRollosSalida(string iPrograma, string iMaquina, string tipoHB)
        {
            try
            {
                return Ok(await new PAP006MFBusiness().ActRollosSalida(datosToken, iPrograma, iMaquina, tipoHB));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error,{ex.Message}");

            }
        }
        #endregion

        #region METODOS INSERT
        [HttpGet("GenCentroCosto")]
        public async Task<IActionResult> GenCentroCosto(string folioE_S, string tipoHB)
        {
            try
            {
                return Ok(await new PAP006MFBusiness().GenCentroCosto(datosToken, folioE_S, tipoHB));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error,{ex.Message}");

            }
        }
        #endregion
    }
}
