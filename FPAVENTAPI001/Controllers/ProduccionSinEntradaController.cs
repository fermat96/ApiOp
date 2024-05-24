using System;
using System.Threading.Tasks;
using Business;
using Entity;
using Entity.DTO.Common;
using Entity.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FPAVENTAPI001.Controllers
{
    [Authorize]
    [Route("/[controller]")]
    [ApiController]
    public class ProduccionSinEntradaController : Controller
    {

        private readonly TokenData datosToken = new TokenData();
        public ProduccionSinEntradaController(IOptions<AppSettings> AppSettings, IHttpContextAccessor httpContext)
        {
            datosToken.Conexion = httpContext.HttpContext.Items["Conexion"].ToString();
            datosToken.Usuario = httpContext.HttpContext.Items["UsuarioERP"].ToString();
        }

        [HttpGet("getMaquinas")]
        public async Task<IActionResult> ListarMaquinas()
        {
            try
            {
                return Ok(await new ProduccionSinEntradaBusiness().Get_ListarMaquinas(datosToken.Conexion));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error, {ex.Message}");
            }
        }

        [HttpGet("Get_ListarProduccionSinEntrada")]
        public async Task<IActionResult> Get_ListarProduccionSinEntrada(int startRow, int endRow, int idMaquina, int Mes, int Anio, string Papel, string Rollo, string Bobina)
        {
            try
            {
                ProduccionSinEntradaFiltro Filtro = new ProduccionSinEntradaFiltro();
                Filtro.idMaquina = idMaquina;
                Filtro.Mes = Mes;
                Filtro.Anio = Anio;
                Filtro.Papel = Papel;
                Filtro.Rollo = Rollo;
                Filtro.Bobina = Bobina;
                return Ok(await new ProduccionSinEntradaBusiness().Get_ListarProduccionSinEntrada(datosToken.Conexion, startRow, endRow, Filtro));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error, {ex.Message}");
            }
        }

        [HttpGet("Get_ListarProduccion")]
        public async Task<IActionResult> Get_ListarProduccion(int startRow, int endRow, int idMaquina, int Mes, int Anio)
        {
            try
            {
                ProduccionSinEntradaFiltro Filtro = new ProduccionSinEntradaFiltro();
                Filtro.idMaquina = idMaquina;
                Filtro.Mes = Mes;
                Filtro.Anio = Anio;
                return Ok(await new ProduccionSinEntradaBusiness().Get_ListarProduccion(datosToken.Conexion, startRow, endRow, Filtro));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error, {ex.Message}");
            }
        }

        [HttpPost("post_Actualizar")]
        public async Task<IActionResult> post_Actualizar(ProduccionSinEntradaActualizar Datos)
        {
            
            try
            {
                return Ok(await new ProduccionSinEntradaBusiness().post_Actualizar(datosToken, Datos.Mes, Datos.Anio, Convert.ToInt32(Datos.idMaquina), Datos.Tabla));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error, {ex.Message}");
            }
        }
    }
}