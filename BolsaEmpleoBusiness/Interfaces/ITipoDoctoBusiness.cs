using BolsaEmpleoModel;

namespace BolsaEmpleoBusiness.Interfaces
{
    public interface ITipoDoctoBusiness
    {
        Task<RspTipoDocto> TipoDoctoGetAsync();
    }
}