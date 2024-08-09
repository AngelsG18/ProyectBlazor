using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProyectBlazor.API.Models;
using ProyectBlazor.Library;
using System.Data;

namespace ProyectBlazor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpcionController : ControllerBase
    {
      private readonly SeguridadContext _BD;
        public OpcionController(SeguridadContext bd) {
            _BD = bd;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(CargaOpcion());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        private List<OpcionesCLS> CargaOpcion()
        {
            List<OpcionesCLS> opciones = new List<OpcionesCLS>();
            string connectionString = _BD.Database.GetDbConnection().ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SM_MUESTRA_OPCIONES_PERFIL_EMPRESA", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Cod_Perfil", "0751");
                    cmd.Parameters.AddWithValue("@Cod_Empresa", "01");

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            OpcionesCLS sOpcion = new OpcionesCLS
                            {
                                Cod_Opcion = reader["Cod_Opcion"].ToString().Trim(),
                                Cod_Aplicacion = reader["Cod_Aplicacion"].ToString(),
                                Des_Opcion = reader["Des_Opcion"].ToString(),
                                Des_Opcion_Eng = reader["Des_Opcion_Eng"].ToString(),
                                Nivel = reader["Nivel"] != DBNull.Value && !string.IsNullOrEmpty(reader["Nivel"].ToString())
                                ? Convert.ToInt16(reader["Nivel"].ToString())
                                : (short)0,
                                Cod_Padre = reader["Cod_Padre"] != DBNull.Value ? reader["Cod_Padre"].ToString().Trim() : string.Empty,
                                tipo = reader["tipo"].ToString()
                            };
                            opciones.Add(sOpcion);
                        }
                    }
                }
            }

            return opciones;
        }

    }
}
