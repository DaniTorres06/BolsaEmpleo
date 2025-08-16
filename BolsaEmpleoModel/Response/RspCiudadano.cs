using BolsaEmpleoModel.DTO;
using System.Collections.Generic;

namespace BolsaEmpleoModel.Response
{
    public class RspCiudadano
    {
        public List<Ciudadanos> Ciudadanos { get; set; }
        public Response? Response { get; set; }

        public RspCiudadano()
        {
            Ciudadanos = new();
            Response = new();
        }
    }
}
