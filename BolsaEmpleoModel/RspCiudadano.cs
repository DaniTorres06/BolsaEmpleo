using BolsaEmpleoModel.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaEmpleoModel
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
