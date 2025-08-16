using BolsaEmpleoModel.DTO;
using BolsaEmpleoModel.Response;

namespace BolsaEmpleoData.Interfaces
{
    public interface IVacanteData
    {
        public Task<RspVacante> VacantesGetAsync();
        public Task<RspVacante> VacanteEditAsync(VacantesOfertadas vVacantes);
    }
}