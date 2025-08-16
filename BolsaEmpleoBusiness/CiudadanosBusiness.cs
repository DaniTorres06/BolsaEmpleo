using BolsaEmpleoBusiness.Interfaces;
using BolsaEmpleoData.Interfaces;
using BolsaEmpleoModel.DTO;
using BolsaEmpleoModel.Response;
using Microsoft.Extensions.Logging;

namespace BolsaEmpleoBusiness
{
    public class CiudadanosBusiness : ICiudadanosBusiness
    {
        private readonly ILogger<CiudadanosBusiness> _logger;
        private readonly ICiudadanosData _ciudadanosData;

        public CiudadanosBusiness(ILogger<CiudadanosBusiness> logger, ICiudadanosData ciudadanosData)
        {
            _logger = logger;
            _ciudadanosData = ciudadanosData;
        }

        public async Task<RspCiudadano> CiudadanosGetAsync()
        {
            RspCiudadano vObjRespCiudadano = new();

            try
            {
                return await _ciudadanosData.CiudadanosGetAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                vObjRespCiudadano.Response.Status = false;
                vObjRespCiudadano.Response.Message = "Problemas en capa de negocio";
                return vObjRespCiudadano;
            }
        }

        public async Task<RspCiudadano> CiudadanosAddAsync(Ciudadanos vCiudadanos)
        {
            RspCiudadano vObjRespCiudadano = new();

            try
            {
                return await _ciudadanosData.CiudadanosAddAsync(vCiudadanos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                vObjRespCiudadano.Response.Status = false;
                vObjRespCiudadano.Response.Message = "Problemas en capa de negocio";
                return vObjRespCiudadano;
            }
        }

        public async Task<RspCiudadano> CiudadanosEditAsync(Ciudadanos vCiudadanos)
        {
            RspCiudadano vObjRespCiudadano = new();

            try
            {
                return await _ciudadanosData.CiudadanosEditAsync(vCiudadanos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                vObjRespCiudadano.Response.Status = false;
                vObjRespCiudadano.Response.Message = "Problemas en capa de negocio";
                return vObjRespCiudadano;
            }
        }

        public async Task<RspCiudadano> CiudadanosGetIdAsync(int vIdCiudadano)
        {
            RspCiudadano vObjRespCiudadano = new();

            try
            {
                return await _ciudadanosData.CiudadanosGetIdAsync(vIdCiudadano);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                vObjRespCiudadano.Response.Status = false;
                vObjRespCiudadano.Response.Message = "Problemas en capa de negocio";
                return vObjRespCiudadano;
            }
        }

        public async Task<RspCiudadano> CiudadanosDeleteAsync(int vIdCiudadano)
        {
            RspCiudadano vObjRespCiudadano = new();

            try
            {
                return await _ciudadanosData.CiudadanosDeleteAsync(vIdCiudadano);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                vObjRespCiudadano.Response.Status = false;
                vObjRespCiudadano.Response.Message = "Problemas en capa de negocio";
                return vObjRespCiudadano;
            }
        }
    }
}
