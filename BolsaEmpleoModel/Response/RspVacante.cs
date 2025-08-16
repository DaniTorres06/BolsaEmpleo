using BolsaEmpleoModel.DTO;

namespace BolsaEmpleoModel.Response
{
    public class RspVacante
    {
        public List<VacantesOfertadas> VacantesOfertadas { get; set; }
        public Response? Response { get; set; }

        public RspVacante()
        {
            VacantesOfertadas = new();
            Response = new();
        }
    }
}
