using BolsaEmpleoModel.Response;

namespace BolsaEmpleoBusiness.Interfaces
{
    public interface ITipoDoctoBusiness
    {
        Task<RspTipoDocto> TipoDoctoGetAsync();
    }
}