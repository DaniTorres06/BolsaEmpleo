using BolsaEmpleoData.Interfaces;
using BolsaEmpleoModel;
using BolsaEmpleoModel.ModelView;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Data.SqlClient;

namespace BolsaEmpleoData
{
    public class CiudadanosData : ICiudadanosData
    {
        private readonly ILogger<CiudadanosData> _logger;        
        private readonly IConfiguration _config;

        private const string CiudadanosGet = "sp_Ciudadanos_get";
        private const string CiudadanosAdd = "sp_Ciudadanos_add";
        private const string CiudadanosEdit = "sp_Ciudadanos_edit";
        private const string CiudadanosGetId = "sp_Ciudadanos_getId";
        private const string CiudadanosDelete = "sp_Ciudadanos_del";


        public CiudadanosData(ILogger<CiudadanosData> logger, IConfiguration configuration)
        {
            _logger = logger;
            _config = configuration;
        }

        public async Task<RspCiudadano> CiudadanosGetAsync()
        {
            RspCiudadano vObjRspCiudadanos = new RspCiudadano();
            Response vObjRsp = new Response();

            SqlConnection conn = new SqlConnection(_config["ConnectionStrings:SqlServer"]);
            try
            {
                SqlCommand StoreProc_enc = new SqlCommand(CiudadanosGet, conn);
                StoreProc_enc.CommandType = CommandType.StoredProcedure;


                conn.Open();
                using (SqlDataReader reader = await StoreProc_enc.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        if (Convert.ToInt32(reader["HasErrors"]) == 0)
                        {
                            Ciudadanos vObjCiudadanos = new();
                            vObjCiudadanos.IdCiudadano = reader["Id"] != DBNull.Value ? Convert.ToInt32(reader["Id"].ToString()) : 0;
                            vObjCiudadanos.TipoDocumento = reader["TipoDocumento"] != DBNull.Value ? Convert.ToInt32(reader["TipoDocumento"].ToString()) : 0;
                            vObjCiudadanos.Cedula = reader["Cedula"] != DBNull.Value ? Convert.ToInt32(reader["Cedula"].ToString()) : 0;
                            vObjCiudadanos.Nombres = reader["Nombres"] != DBNull.Value ? (reader["Nombres"].ToString()) : string.Empty;
                            vObjCiudadanos.Apellidos = reader["Apellidos"] != DBNull.Value ? (reader["Apellidos"].ToString()) : string.Empty;
                            vObjCiudadanos.FechaNacimiento = reader["FechaNacimiento"] != DBNull.Value ? Convert.ToDateTime(reader["FechaNacimiento"].ToString()) : DateTime.Now;
                            vObjCiudadanos.Profesion = reader["Profesion"] != DBNull.Value ? (reader["Profesion"].ToString()) : string.Empty;
                            vObjCiudadanos.AspiracionSalarial = reader["AspiracionSalarial"] != DBNull.Value ? Convert.ToDecimal(reader["AspiracionSalarial"].ToString()) : 0;
                            vObjCiudadanos.CorreoElectronico = reader["CorreoElectronico"] != DBNull.Value ? (reader["CorreoElectronico"].ToString()) : string.Empty;

                            vObjRsp.Status = true;
                            vObjRsp.Message = "Registros encontrados";

                            vObjRspCiudadanos.Ciudadanos.Add(vObjCiudadanos);
                            vObjRspCiudadanos.Response = vObjRsp;

                        }
                        else
                        {
                            vObjRspCiudadanos.Response.Status = false;
                            vObjRspCiudadanos.Response.Message = "No se encontraron registros";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                vObjRspCiudadanos.Response.Status = false;
                vObjRspCiudadanos.Response.Message = "Problemas al buscar el registro " + ex.Message;
                return vObjRspCiudadanos;
            }

            finally
            {
                conn.Close();
            }

            return vObjRspCiudadanos;
        }

        public async Task<RspCiudadano> CiudadanosAddAsync(Ciudadanos vCiudadanos)
        {
            RspCiudadano vObjRspCiudadanos = new RspCiudadano();            

            SqlConnection conn = new SqlConnection(_config["ConnectionStrings:SqlServer"]);
            try
            {
                SqlCommand StoreProc_enc = new SqlCommand(CiudadanosAdd, conn);
                StoreProc_enc.CommandType = CommandType.StoredProcedure;

                StoreProc_enc.Parameters.Add("@TipoDocumento", SqlDbType.Int).Value = vCiudadanos.TipoDocumento;
                StoreProc_enc.Parameters.Add("@Cedula", SqlDbType.Int).Value = vCiudadanos.Cedula;
                StoreProc_enc.Parameters.Add("@Nombres", SqlDbType.VarChar, 100).Value = vCiudadanos.Nombres;
                StoreProc_enc.Parameters.Add("@Apellidos", SqlDbType.VarChar, 100).Value = vCiudadanos.Apellidos;
                StoreProc_enc.Parameters.Add("@FechaNacimiento", SqlDbType.Date).Value = vCiudadanos.FechaNacimiento;
                StoreProc_enc.Parameters.Add("@Profesion", SqlDbType.VarChar, 100).Value = vCiudadanos.Profesion;
                StoreProc_enc.Parameters.Add("@AspiracionSalarial", SqlDbType.Decimal).Value = vCiudadanos.AspiracionSalarial;
                StoreProc_enc.Parameters.Add("@CorreoElectronico", SqlDbType.VarChar, 100).Value = vCiudadanos.CorreoElectronico;


                conn.Open();
                using (SqlDataReader reader = await StoreProc_enc.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        if (Convert.ToInt32(reader["HasErrors"]) == 0)
                        {
                            vObjRspCiudadanos.Response.Status = true;
                            vObjRspCiudadanos.Response.Message = "Registro creado con exito";
                        }
                        else
                        {
                            vObjRspCiudadanos.Response.Status = false;
                            vObjRspCiudadanos.Response.Message = "El registro no se logro guardar!";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                vObjRspCiudadanos.Response.Status = false;
                vObjRspCiudadanos.Response.Message = "Problemas al guardar el registro " + ex.Message;
                return vObjRspCiudadanos;
            }

            finally
            {
                conn.Close();
            }

            return vObjRspCiudadanos;
        }

        public async Task<RspCiudadano> CiudadanosEditAsync(Ciudadanos vCiudadanos)
        {
            RspCiudadano vObjRspCiudadanos = new RspCiudadano();

            SqlConnection conn = new SqlConnection(_config["ConnectionStrings:SqlServer"]);
            try
            {
                SqlCommand StoreProc_enc = new SqlCommand(CiudadanosEdit, conn);
                StoreProc_enc.CommandType = CommandType.StoredProcedure;

                StoreProc_enc.Parameters.Add("@id", SqlDbType.Int).Value = vCiudadanos.IdCiudadano;
                StoreProc_enc.Parameters.Add("@TipoDocumento", SqlDbType.Int).Value = vCiudadanos.TipoDocumento;
                StoreProc_enc.Parameters.Add("@Cedula", SqlDbType.Int).Value = vCiudadanos.Cedula;
                StoreProc_enc.Parameters.Add("@Nombres", SqlDbType.VarChar, 100).Value = vCiudadanos.Nombres;
                StoreProc_enc.Parameters.Add("@Apellidos", SqlDbType.VarChar, 100).Value = vCiudadanos.Apellidos;
                StoreProc_enc.Parameters.Add("@FechaNacimiento", SqlDbType.Date).Value = vCiudadanos.FechaNacimiento;
                StoreProc_enc.Parameters.Add("@Profesion", SqlDbType.VarChar, 100).Value = vCiudadanos.Profesion;
                StoreProc_enc.Parameters.Add("@AspiracionSalarial", SqlDbType.Decimal).Value = vCiudadanos.AspiracionSalarial;
                StoreProc_enc.Parameters.Add("@CorreoElectronico", SqlDbType.VarChar, 100).Value = vCiudadanos.CorreoElectronico;


                conn.Open();
                using (SqlDataReader reader = await StoreProc_enc.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        if (Convert.ToInt32(reader["HasErrors"]) == 0)
                        {
                            vObjRspCiudadanos.Response.Status = true;
                            vObjRspCiudadanos.Response.Message = "Registro editado con exito";
                        }
                        else
                        {
                            vObjRspCiudadanos.Response.Status = false;
                            vObjRspCiudadanos.Response.Message = "El registro no se logro editar";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                vObjRspCiudadanos.Response.Status = false;
                vObjRspCiudadanos.Response.Message = "Problemas al editar el registro " + ex.Message;
                return vObjRspCiudadanos;
            }

            finally
            {
                conn.Close();
            }

            return vObjRspCiudadanos;
        }

        public async Task<RspCiudadano> CiudadanosGetIdAsync(int vIdCiudadano)
        {
            RspCiudadano vObjRspCiudadanos = new RspCiudadano();
            Response vObjRsp = new Response();

            SqlConnection conn = new SqlConnection(_config["ConnectionStrings:SqlServer"]);
            try
            {
                SqlCommand StoreProc_enc = new SqlCommand(CiudadanosGetId, conn);
                StoreProc_enc.CommandType = CommandType.StoredProcedure;

                StoreProc_enc.Parameters.Add("@id", SqlDbType.Int).Value = vIdCiudadano;

                conn.Open();
                using (SqlDataReader reader = await StoreProc_enc.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        if (Convert.ToInt32(reader["HasErrors"]) == 0)
                        {
                            Ciudadanos vObjCiudadanos = new();
                            vObjCiudadanos.IdCiudadano = reader["Id"] != DBNull.Value ? Convert.ToInt32(reader["Id"].ToString()) : 0;
                            vObjCiudadanos.TipoDocumento = reader["TipoDocumento"] != DBNull.Value ? Convert.ToInt32(reader["TipoDocumento"].ToString()) : 0;
                            vObjCiudadanos.Cedula = reader["Cedula"] != DBNull.Value ? Convert.ToInt32(reader["Cedula"].ToString()) : 0;
                            vObjCiudadanos.Nombres = reader["Nombres"] != DBNull.Value ? (reader["Nombres"].ToString()) : string.Empty;
                            vObjCiudadanos.Apellidos = reader["Apellidos"] != DBNull.Value ? (reader["Apellidos"].ToString()) : string.Empty;
                            vObjCiudadanos.FechaNacimiento = reader["FechaNacimiento"] != DBNull.Value ? Convert.ToDateTime(reader["FechaNacimiento"].ToString()) : DateTime.Now;
                            vObjCiudadanos.Profesion = reader["Profesion"] != DBNull.Value ? (reader["Profesion"].ToString()) : string.Empty;
                            vObjCiudadanos.AspiracionSalarial = reader["AspiracionSalarial"] != DBNull.Value ? Convert.ToDecimal(reader["AspiracionSalarial"].ToString()) : 0;
                            vObjCiudadanos.CorreoElectronico = reader["CorreoElectronico"] != DBNull.Value ? (reader["CorreoElectronico"].ToString()) : string.Empty;

                            vObjRsp.Status = true;
                            vObjRsp.Message = "Registro encontrado";

                            vObjRspCiudadanos.Ciudadanos.Add(vObjCiudadanos);
                            vObjRspCiudadanos.Response = vObjRsp;

                        }
                        else
                        {
                            vObjRspCiudadanos.Response.Status = false;
                            vObjRspCiudadanos.Response.Message = "No se encontro el registro";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                vObjRspCiudadanos.Response.Status = false;
                vObjRspCiudadanos.Response.Message = "Problemas al buscar el registro " + ex.Message;
                return vObjRspCiudadanos;
            }

            finally
            {
                conn.Close();
            }

            return vObjRspCiudadanos;
        }

        public async Task<RspCiudadano> CiudadanosDeleteAsync(int vIdCiudadano)
        {
            RspCiudadano vObjRspCiudadanos = new RspCiudadano();
            Response vObjRsp = new Response();

            SqlConnection conn = new SqlConnection(_config["ConnectionStrings:SqlServer"]);
            try
            {
                SqlCommand StoreProc_enc = new SqlCommand(CiudadanosDelete, conn);
                StoreProc_enc.CommandType = CommandType.StoredProcedure;

                StoreProc_enc.Parameters.Add("@id", SqlDbType.Int).Value = vIdCiudadano;

                conn.Open();
                using (SqlDataReader reader = await StoreProc_enc.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        if (Convert.ToInt32(reader["HasErrors"]) == 0)
                        {   
                            vObjRspCiudadanos.Response.Status = true;
                            vObjRspCiudadanos.Response.Message = "Registro eliminado";

                        }
                        else
                        {
                            vObjRspCiudadanos.Response.Status = false;
                            vObjRspCiudadanos.Response.Message = "No se encontro el registro";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                vObjRspCiudadanos.Response.Status = false;
                vObjRspCiudadanos.Response.Message = "Problemas al eliminar el registro " + ex.Message;
                return vObjRspCiudadanos;
            }

            finally
            {
                conn.Close();
            }

            return vObjRspCiudadanos;
        }
    }
}
