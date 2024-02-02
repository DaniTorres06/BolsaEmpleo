using BolsaEmpleoBusiness.Interfaces;
using BolsaEmpleoData;
using BolsaEmpleoData.Interfaces;
using BolsaEmpleoModel;
using BolsaEmpleoModel.ModelView;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaEmpleoBusiness
{
    public class VacanteBusiness : IVacanteBusiness
    {
        private readonly ILogger<VacanteBusiness> _logger;
        private readonly IVacanteData _vacanteData;

        public VacanteBusiness(ILogger<VacanteBusiness> logger, IVacanteData vacanteData)
        {
            _logger = logger;
            _vacanteData = vacanteData;
        }

        public async Task<RspVacante> VacantesGetAsync()
        {
            RspVacante vObjRespVacante = new();

            try
            {
                return await _vacanteData.VacantesGetAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                vObjRespVacante.Response.Status = false;
                vObjRespVacante.Response.Message = "Problemas en capa de negocio";
                return vObjRespVacante;
            }
        }

        public async Task<RspVacante> VacanteEditAsync(VacantesOfertadas vVacantes)
        {
            RspVacante vObjRespVacante = new();

            try
            {
                return await _vacanteData.VacanteEditAsync(vVacantes);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                vObjRespVacante.Response.Status = false;
                vObjRespVacante.Response.Message = "Problemas en capa de negocio";
                return vObjRespVacante;
            }
        }
    }
}
