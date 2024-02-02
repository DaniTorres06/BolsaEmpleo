using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaEmpleoModel.ModelView
{
    public class Response
    {
        public string Message { get; set; }
        public string Code { get; set; }
        public bool Status { get; set; }

        public Response()
        {
            Message = string.Empty;
            Code = string.Empty;
            Status = false;
        }
    }
}
