using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaEmpleoModel
{
    public class VacantesOfertadas
    {
        public int IdVacante {  get; set; }
        public string? Codigo {  get; set; }
        public string? Cargo {  get; set; }
        public string? Descripcion {  get; set; }
        public string? Empresa {  get; set; }
        public decimal Salario {  get; set; }
        public int State {  get; set; }
        public int IdCiudadano {  get; set; }

    }
}
