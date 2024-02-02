using BolsaEmpleoModel.ModelView;
using BolsaEmpleoModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BolsaEmpleoData.Interfaces;

namespace BolsaEmpleoData
{
    public class TipoDoctoData : ITipoDoctoData
    {
        private readonly ILogger<TipoDoctoData> _logger;
        private readonly IConfiguration _config;

        private const string TipoDoctoGet = "sp_TipoDocto_get";

        public TipoDoctoData(ILogger<TipoDoctoData> logger, IConfiguration configuration)
        {
            _logger = logger;
            _config = configuration;
        }

        public async Task<RspTipoDocto> TipoDoctoGetAsync()
        {
            RspTipoDocto vObjRspTipoDocto = new RspTipoDocto();
            Response vObjRsp = new Response();

            SqlConnection conn = new SqlConnection(_config["ConnectionStrings:SqlServer"]);
            try
            {
                SqlCommand StoreProc_enc = new SqlCommand(TipoDoctoGet, conn);
                StoreProc_enc.CommandType = CommandType.StoredProcedure;

                conn.Open();
                using (SqlDataReader reader = await StoreProc_enc.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        if (Convert.ToInt32(reader["HasErrors"]) == 0)
                        {
                            TipoDocto vObjTipoDocto = new();
                            vObjTipoDocto.IdTipoDocto = reader["Id"] != DBNull.Value ? Convert.ToInt32(reader["Id"].ToString()) : 0;
                            vObjTipoDocto.TipoDocumneto = reader["TipoDocumento"] != DBNull.Value ? (reader["TipoDocumento"].ToString()) : string.Empty;

                            vObjRsp.Status = true;
                            vObjRsp.Message = "Registros encontrados";

                            vObjRspTipoDocto.TipoDocto.Add(vObjTipoDocto);
                            vObjRspTipoDocto.Response = vObjRsp;
                        }
                        else
                        {
                            vObjRspTipoDocto.Response.Status = false;
                            vObjRspTipoDocto.Response.Message = "No se encontraron registros";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                vObjRspTipoDocto.Response.Status = false;
                vObjRspTipoDocto.Response.Message = "Problemas al buscar el registro " + ex.Message;
                return vObjRspTipoDocto;
            }

            finally
            {
                conn.Close();
            }

            return vObjRspTipoDocto;
        }
    }
}
