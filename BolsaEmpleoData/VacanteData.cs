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
using BolsaEmpleoModel.DTO;
using BolsaEmpleoModel.Response;

namespace BolsaEmpleoData
{
    public class VacanteData : IVacanteData
    {
        private readonly ILogger<VacanteData> _logger;
        private readonly IConfiguration _config;

        public VacanteData(ILogger<VacanteData> logger, IConfiguration configuration)
        {
            _logger = logger;
            _config = configuration;
        }

        private const string VacantesGet = "sp_vacantes_get";
        private const string VacantesEdit = "sp_vacantes_edit";

        public async Task<RspVacante> VacantesGetAsync()
        {
            RspVacante vObjRspVacante = new RspVacante();
            Response vObjRsp = new Response();

            SqlConnection conn = new SqlConnection(_config["ConnectionStrings:SqlServer"]);
            try
            {
                SqlCommand StoreProc_enc = new SqlCommand(VacantesGet, conn);
                StoreProc_enc.CommandType = CommandType.StoredProcedure;

                conn.Open();
                using (SqlDataReader reader = await StoreProc_enc.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        if (Convert.ToInt32(reader["HasErrors"]) == 0)
                        {
                            VacantesOfertadas vObjVacante = new();
                            vObjVacante.IdVacante = reader["IdVacante"] != DBNull.Value ? Convert.ToInt32(reader["IdVacante"].ToString()) : 0;
                            vObjVacante.Codigo = reader["Codigo"] != DBNull.Value ? reader["Codigo"].ToString() : string.Empty;
                            vObjVacante.Cargo = reader["Cargo"] != DBNull.Value ? reader["Cargo"].ToString() : string.Empty;
                            vObjVacante.Descripcion = reader["Descripcion"] != DBNull.Value ? reader["Descripcion"].ToString() : string.Empty;
                            vObjVacante.Empresa = reader["Empresa"] != DBNull.Value ? reader["Empresa"].ToString() : string.Empty;
                            vObjVacante.Salario = reader["Salario"] != DBNull.Value ? Convert.ToDecimal(reader["Salario"].ToString()) : 0;
                            vObjVacante.State = reader["Estado"] != DBNull.Value ? Convert.ToInt32(reader["Estado"].ToString()) : 0;
                            vObjVacante.IdCiudadano = reader["IdCiudadano"] != DBNull.Value ? Convert.ToInt32(reader["IdCiudadano"].ToString()) : 0;

                            vObjRsp.Status = true;
                            vObjRsp.Message = "Registros encontrados";

                            vObjRspVacante.VacantesOfertadas.Add(vObjVacante);
                            vObjRspVacante.Response = vObjRsp;

                        }
                        else
                        {
                            vObjRspVacante.Response.Status = false;
                            vObjRspVacante.Response.Message = "No se encontraron registros";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                vObjRspVacante.Response.Status = false;
                vObjRspVacante.Response.Message = "Problemas al buscar el registro " + ex.Message;
                return vObjRspVacante;
            }

            finally
            {
                conn.Close();
            }

            return vObjRspVacante;
        }

        public async Task<RspVacante> VacanteEditAsync(VacantesOfertadas vVacantes)
        {
            RspVacante vObjRspVacante = new RspVacante();

            SqlConnection conn = new SqlConnection(_config["ConnectionStrings:SqlServer"]);
            try
            {
                SqlCommand StoreProc_enc = new SqlCommand(VacantesEdit, conn);
                StoreProc_enc.CommandType = CommandType.StoredProcedure;

                StoreProc_enc.Parameters.Add("@IdVacante", SqlDbType.Int).Value = vVacantes.IdVacante;
                StoreProc_enc.Parameters.Add("@state", SqlDbType.Int).Value = vVacantes.State;
                StoreProc_enc.Parameters.Add("@id_ciudadano", SqlDbType.Int).Value = vVacantes.IdCiudadano;                


                conn.Open();
                using (SqlDataReader reader = await StoreProc_enc.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        if (Convert.ToInt32(reader["HasErrors"]) == 0)
                        {
                            vObjRspVacante.Response.Status = true;
                            vObjRspVacante.Response.Message = "Registro editado con exito";
                        }
                        else
                        {
                            vObjRspVacante.Response.Status = false;
                            vObjRspVacante.Response.Message = "El registro no se logro editar";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                vObjRspVacante.Response.Status = false;
                vObjRspVacante.Response.Message = "Problemas al editar el registro " + ex.Message;
                return vObjRspVacante;
            }

            finally
            {
                conn.Close();
            }

            return vObjRspVacante;
        }
    }
}
