using BolsaEmpleoModel.DTO;
using BolsaEmpleoModel.Response;

namespace BolsaEmpleoData.Interfaces
{
    public interface ICiudadanosData
    {
        public Task<RspCiudadano> CiudadanosGetAsync();
        public Task<RspCiudadano> CiudadanosAddAsync(Ciudadanos vCiudadanos);
        public Task<RspCiudadano> CiudadanosEditAsync(Ciudadanos vCiudadanos);
        public Task<RspCiudadano> CiudadanosGetIdAsync(int vIdCiudadano);
        public Task<RspCiudadano> CiudadanosDeleteAsync(int vIdCiudadano);
    }
}