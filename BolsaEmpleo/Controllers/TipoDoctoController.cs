using BolsaEmpleoBusiness.Interfaces;
using BolsaEmpleoModel.Response;
using Microsoft.AspNetCore.Mvc;

namespace BolsaEmpleo.Controllers
{
    public class TipoDoctoController : Controller
    {
        private readonly ILogger<TipoDoctoController> _logger;
        private readonly ITipoDoctoBusiness _service;

        public TipoDoctoController(ILogger<TipoDoctoController> logger, ITipoDoctoBusiness TipoDoctoBusiness)
        {
            _logger = logger;
            _service = TipoDoctoBusiness;
        }


        [HttpGet("TipoDoctoGetAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RspTipoDocto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RspTipoDocto>> TipoDoctoGetAsync()
        {
            try
            {
                var response = await _service.TipoDoctoGetAsync();
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
