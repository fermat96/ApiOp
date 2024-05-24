using Entity.DTO.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using System;
using Data;
using Business;
using Entity;
using System.Net;

namespace FPAVENTAPI001.Controllers
{
    [Authorize]
    [Route("/[controller]")]
    [ApiController]
    public class FPAVENT002MWController : ControllerBase
    {
        private readonly TokenData datosToken = new TokenData();
        public FPAVENT002MWController(IOptions<AppSettings> AppSettings, IHttpContextAccessor httpContext)
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
                return Ok(await new FPAVENT002MWBusiness().ObtenerClientes(datosToken, nombre));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error,{ex.Message}");

            }
        }

        [HttpGet("ObtenerPedidoOP")]
        public async Task<IActionResult> ObtenerPedidoOP(string op, string tipo)
        {
            try
            {
                return Ok(await new FPAVENT002MWBusiness().ObtenerPedidoOP(datosToken, op, tipo));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error,{ex.Message}");

            }
        }

        [HttpPost("ObtenerPedidoFecha")]
        public async Task<IActionResult> ObtenerPedidoFecha(Filtros fl)
        {
            try
            {
                return Ok(await new FPAVENT002MWBusiness().ObtenerPedidoFecha(datosToken, fl));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error,{ex.Message}");

            }
        }

        [HttpPost("ObtenerPedidoCliente")]
        public async Task<IActionResult> ObtenerPedidoCliente(Filtros fl)
        {
            try
            {
                return Ok(await new FPAVENT002MWBusiness().ObtenerPedidoCliente(datosToken, fl));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error,{ex.Message}");

            }
        }

        [HttpGet("ObtenerClientesID")]
        public async Task<IActionResult> ObtenerClientesID(string idCliente)
        {
            try
            {
                return Ok(await new FPAVENT002MWBusiness().ObtenerClientesID(datosToken, idCliente));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error,{ex.Message}");

            }
        }

        [HttpGet("ValidarAutorizacionCC")]
        public async Task<IActionResult> ValidarAutorizacionCC(string usuario)
        {
            try
            {
                return Ok(await new FPAVENT002MWBusiness().ValidarAutorizacionCC(datosToken, usuario));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error,{ex.Message}");

            }
        }

        [HttpGet("ValidarAutorizacionGP")]
        public async Task<IActionResult> ValidarAutorizacionGP(string usuario)
        {
            try
            {
                return Ok(await new FPAVENT002MWBusiness().ValidarAutorizacionGP(datosToken, usuario));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error,{ex.Message}");

            }
        }

        [HttpGet("ValidarAutorizacionCO")]
        public async Task<IActionResult> ValidarAutorizacionCO(string usuario)
        {
            try
            {
                return Ok(await new FPAVENT002MWBusiness().ValidarAutorizacionCO(datosToken, usuario));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error,{ex.Message}");

            }
        }

        [HttpGet("BuscarValidarOP")]
        public async Task<IActionResult> BuscarValidarOP(string op)
        {
            try
            {
                return Ok(await new FPAVENT002MWBusiness().BuscarValidarOP(datosToken, op));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error,{ex.Message}");

            }
        }

        [HttpGet("ObtenerValidarContraseña")]
        public async Task<IActionResult> ObtenerValidarContraseña(string usuario)
        {
            try
            {
                return Ok(await new FPAVENT002MWBusiness().ObtenerValidarContraseña(datosToken, usuario));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error,{ex.Message}");

            }
        }

        [HttpGet("ValidarOP")]
        public async Task<IActionResult> ValidarOP(string op)
        {
            try
            {
                return Ok(await new FPAVENT002MWBusiness().ValidarOP(datosToken, op));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error,{ex.Message}");

            }
        }

        [HttpGet("ObtenerTerminacionOP")]
        public async Task<IActionResult> ObtenerTerminacionOP()
        {
            try
            {
                return Ok(await new FPAVENT002MWBusiness().ObtenerTerminacionOP(datosToken));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error,{ex.Message}");

            }
        }

        [HttpGet("ObtenerCorreo")]
        public async Task<IActionResult> ObtenerCorreo(string usuario)
        {
            try
            {
                return Ok(await new FPAVENT002MWBusiness().ObtenerCorreo(datosToken, usuario));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error,{ex.Message}");

            }
        }

        [HttpGet("ObtenerNombreCorreo")]
        public async Task<IActionResult> ObtenerNombreCorreo(string usuario)
        {
            try
            {
                return Ok(await new FPAVENT002MWBusiness().ObtenerNombreCorreo(datosToken, usuario));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error,{ex.Message}");

            }
        }
        #endregion

        #region METODOS UPDATE
        [HttpGet("UpdateAutorizar")]
        public async Task<IActionResult> UpdateAutorizar(string clave, string notasAuth, string op, string tipoMateria, string tipoAuth, string autorizacion)
        {
            try
            {
                return Ok(await new FPAVENT002MWBusiness().UpdateAutorizar(datosToken, clave, notasAuth, op, tipoMateria, tipoAuth, autorizacion));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error,{ex.Message}");

            }
        }

        [HttpGet("UpdateBloquear")]
        public async Task<IActionResult> UpdateBloquear(string op, string tipoMaterial, bool cancelaRemision)
        {
            try
            {
                return Ok(await new FPAVENT002MWBusiness().UpdateBloquear(datosToken, tipoMaterial, op, cancelaRemision));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error,{ex.Message}");

            }
        }

        [HttpGet("UpdateClaveEnvio")]
        public async Task<IActionResult> UpdateClaveEnvio(string destino, string mensaje, string remitente, string nombreRemitente, string subject, string claveEnvio)
        {
            try
            {
                return Ok(await new FPAVENT002MWBusiness().UpdateClaveEnvio(datosToken, destino, mensaje, remitente, nombreRemitente, subject, claveEnvio));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error,{ex.Message}");

            }
        }

        [HttpGet("EnviarCorreo")]
        public async Task<IActionResult> EnviarCorreo(string claveEnvio)
        {
            try
            {
                return Ok(await new FPAVENT002MWBusiness().EnviarCorreo(datosToken, claveEnvio));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error,{ex.Message}");

            }
        }

        [HttpGet("UpdateNotificacion")]
        public async Task<IActionResult> UpdateNotificacion(string op)
        {
            try
            {
                return Ok(await new FPAVENT002MWBusiness().UpdateNotificacion(datosToken, op));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error,{ex.Message}");

            }
        }

        [HttpGet("downloadFTP")]
        public async Task<IActionResult> downloadFTP(string url,string FileName)
        {
            try
            {
                return Ok(await new FPAVENT002MWBusiness().downloadFTP(datosToken, url, FileName));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error,{ex.Message}");

            }
        }
        #endregion
    }
}
