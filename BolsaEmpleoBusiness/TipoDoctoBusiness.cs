using BolsaEmpleoBusiness.Interfaces;
using BolsaEmpleoData;
using BolsaEmpleoData.Interfaces;
using BolsaEmpleoModel;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaEmpleoBusiness
{
    public class TipoDoctoBusiness : ITipoDoctoBusiness
    {
        private readonly ILogger<TipoDoctoBusiness> _logger;
        private readonly ITipoDoctoData _tipoDoctoData;

        public TipoDoctoBusiness(ILogger<TipoDoctoBusiness> logger, ITipoDoctoData tipoDoctoData)
        {
            _logger = logger;
            _tipoDoctoData = tipoDoctoData;
        }

        public async Task<RspTipoDocto> TipoDoctoGetAsync()
        {
            RspTipoDocto vObjRespTipoDocto = new();

            try
            {
                return await _tipoDoctoData.TipoDoctoGetAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                vObjRespTipoDocto.Response.Status = false;
                vObjRespTipoDocto.Response.Message = "Problemas en capa de negocio";
                return vObjRespTipoDocto;
            }
        }


    }
}
