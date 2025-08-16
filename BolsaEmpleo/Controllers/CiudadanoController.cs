using BolsaEmpleoBusiness.Interfaces;
using BolsaEmpleoModel.DTO;
using BolsaEmpleoModel.Response;
using Microsoft.AspNetCore.Mvc;

namespace BolsaEmpleo.Controllers
{
    public class CiudadanoController : Controller
    {
        private readonly ILogger<CiudadanoController> _logger;
        private readonly ICiudadanosBusiness _service;

        public CiudadanoController(ILogger<CiudadanoController> logger, ICiudadanosBusiness CiudadanoBusiness)
        {
            _logger = logger;
            _service = CiudadanoBusiness;
        }

        [HttpGet("CiudadanoGetAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RspCiudadano))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RspCiudadano>> RouteGetAsync()
        {
            try
            {
                var response = await _service.CiudadanosGetAsync();
                if (response is null)
                    return BadRequest();

                if (!response.Response.Status)
                    return BadRequest(response);
                else
                    return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest();
            }
        }

        [HttpPost("CiudadanoAddAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RspCiudadano))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RspCiudadano>> CiudadanoAddAsync([FromBody] Ciudadanos vCiudadanos)
        {
            try
            {
                var response = await _service.CiudadanosAddAsync(vCiudadanos);
                if (response is null)
                    return BadRequest();

                if (!response.Response.Status)
                    return BadRequest(response);
                else
                    return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest();
            }
        }

        [HttpPut("CiudadanoEditAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RspCiudadano))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RspCiudadano>> CiudadanoEditAsync([FromBody] Ciudadanos vCiudadanos)
        {
            try
            {
                var response = await _service.CiudadanosEditAsync(vCiudadanos);
                if (response is null)
                    return BadRequest();
                if (!response.Response.Status)
                    return BadRequest(response);
                else
                    return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest();
            }
        }

        [HttpPost("CiudadanosGetIdAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RspCiudadano))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RspCiudadano>> CiudadanosGetIdAsync(int vIdCiudadano)
        {
            try
            {
                var response = await _service.CiudadanosGetIdAsync(vIdCiudadano);
                if (response is null)
                    return BadRequest();
                if (!response.Response.Status)
                    return BadRequest(response);
                else
                    return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest();
            }
        }

        [HttpDelete("CiudadanosGetIdAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RspCiudadano))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RspCiudadano>> CiudadanosDeleteAsync(int vIdCiudadano)
        {
            try
            {
                var response = await _service.CiudadanosDeleteAsync(vIdCiudadano);
                if (response is null)
                    return BadRequest();
                if (!response.Response.Status)
                    return BadRequest(response);
                else
                    return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest();
            }
        }

    }
}
