using BolsaEmpleoModel.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaEmpleoModel
{
    public class RspTipoDocto
    {
        public List<TipoDocto> TipoDocto { get; set; }
        public Response? Response { get; set; }

        public RspTipoDocto()
        {
            TipoDocto = new();
            Response = new();
        }

    }
}
