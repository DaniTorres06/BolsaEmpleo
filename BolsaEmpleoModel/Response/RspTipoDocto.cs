using BolsaEmpleoModel.DTO;

namespace BolsaEmpleoModel.Response
{
    public class RspTipoDocto
    {
        public List<TipoDocto> TipoDocto { get; set; }
        public Response Response { get; set; }

        public RspTipoDocto()
        {
            TipoDocto = new List<TipoDocto>();
            Response = new Response();
        }

    }
}
