using BolsaEmpleoBusiness.Interfaces;
using BolsaEmpleoModel;
using BolsaEmpleoModel.ModelView;
using Microsoft.AspNetCore.Mvc;

namespace BolsaEmpleo.Controllers
{
    public class VacanteController : Controller
    {
        private readonly ILogger<VacanteController> _logger;
        private readonly IVacanteBusiness _service;

        public VacanteController(ILogger<VacanteController> logger, IVacanteBusiness VacanteBusiness)
        {
            _logger = logger;
            _service = VacanteBusiness;
        }

        [HttpGet("VacantesGetAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RspVacante))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RspVacante>> VacantesGetAsync()
        {
            try
            {
                var response = await _service.VacantesGetAsync();
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

        
        [HttpPut("VacanteEditAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RspVacante))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RspVacante>> VacanteEditAsync([FromBody] VacantesOfertadas vVacantes)
        {
            try
            {
                var response = await _service.VacanteEditAsync(vVacantes);
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
