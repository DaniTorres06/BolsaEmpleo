using BolsaEmpleoModel;

namespace BolsaEmpleoData.Interfaces
{
    public interface ITipoDoctoData
    {
        public Task<RspTipoDocto> TipoDoctoGetAsync();
    }
}