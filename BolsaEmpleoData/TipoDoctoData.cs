using BolsaEmpleoData.Interfaces;
using BolsaEmpleoModel.DTO;
using BolsaEmpleoModel.Response;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BolsaEmpleoData
{
    public class TipoDoctoData : ITipoDoctoData
    {
        private readonly IConfiguration _config;
        private const string TipoDoctoGet = "sp_TipoDocto_get";

        public TipoDoctoData(IConfiguration configuration)
        {
            _config = configuration;
        }

        public async Task<RspTipoDocto> TipoDoctoGetAsync()
        {
            var rspTypeDocto = new RspTipoDocto();            

            try
            {
                await using var conn = new SqlConnection(_config["ConnectionStrings:SqlServer"]);
                await conn.OpenAsync();

                await using var cmd = new SqlCommand(TipoDoctoGet, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                using var reader = await cmd.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    if (reader["HasErrors"] != DBNull.Value && Convert.ToInt32(reader["HasErrors"]) == 0)
                    {
                        var tipoDocto = new TipoDocto
                        {
                            IdTipoDocto = reader["Id"] != DBNull.Value ? Convert.ToInt32(reader["Id"]) : 0,
                            TipoDocumneto = reader["TipoDocumento"]?.ToString() ?? string.Empty
                        };

                        rspTypeDocto.TipoDocto.Add(tipoDocto);
                    }
                }

                // Si encontró registros
                if (rspTypeDocto.TipoDocto.Any())
                {
                    rspTypeDocto.Response.Status = true;
                    rspTypeDocto.Response.Message = "Tipo de documentos encontrados";
                }
                else
                {
                    rspTypeDocto.Response.Status = false;
                    rspTypeDocto.Response.Message = "No se encontraron registros";
                }
            }
            catch (Exception ex)
            {
                rspTypeDocto.Response.Status = false;
                rspTypeDocto.Response.Message = $"Error al buscar registros: {ex.Message}";
            }

            return rspTypeDocto;
        }

    }
}
