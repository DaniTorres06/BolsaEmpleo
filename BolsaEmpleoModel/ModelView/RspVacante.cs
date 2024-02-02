using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaEmpleoModel.ModelView
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
