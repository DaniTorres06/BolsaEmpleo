using BolsaEmpleoModel.DTO;
using BolsaEmpleoModel.Response;

namespace BolsaEmpleoBusiness.Interfaces
{
    public interface IVacanteBusiness
    {
        public Task<RspVacante> VacantesGetAsync();
        public Task<RspVacante> VacanteEditAsync(VacantesOfertadas vVacantes);
    }
}