using BolsaEmpleoModel;
using BolsaEmpleoModel.ModelView;

namespace BolsaEmpleoData.Interfaces
{
    public interface IVacanteData
    {
        public Task<RspVacante> VacantesGetAsync();
        public Task<RspVacante> VacanteEditAsync(VacantesOfertadas vVacantes);
    }
}