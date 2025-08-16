using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaEmpleoModel.DTO
{
    public class TipoDocto
    {
        public int IdTipoDocto { get; set; }
        public string? TipoDocumneto { get; set; }

        public TipoDocto()
        {
            IdTipoDocto = 0;
            TipoDocumneto = string.Empty;
        }
    }
}
