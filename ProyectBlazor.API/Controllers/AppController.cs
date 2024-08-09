using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProyectBlazor.API.Models;
using ProyectBlazor.Library;
using System.Data;
using System.Data.SqlTypes;

namespace ProyectBlazor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppController : ControllerBase
    {
        public readonly SeguridadContext _BD;
        public AppController(SeguridadContext bd) { _BD = bd; }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(CargaApp());
        }

        private List<AplicacionCLS> ListarApp()
        {
            //se puede usar Where para filtrar o colocar una condicion
            var ListadoApp = _BD.SegAplicacions.Select(p => new AplicacionCLS
            {
                Cod_aplicacion = p.CodAplicacion,
                Des_aplicacion = p.DesAplicacion,
                Des_aplicacion_Eng = p.DesAplicacionEng
            }).ToList();
            return ListadoApp;
        }

        [HttpGet("{NomApp}")]
        public IActionResult Get(string NomApp)
        {
            List<AplicacionCLS> lista = ListarApp();
            if (NomApp == null || NomApp == "")
            {
                return Ok(ListarApp());
            }
            else
            {
                lista = lista.Where(p => p.Des_aplicacion.ToUpper().Contains(NomApp.ToUpper())).ToList();
                return Ok(lista);
            }
        }

        private List<AplicacionCLS> CargaApp()
        {
            List<AplicacionCLS> aplicaciones = new List<AplicacionCLS>();
            string connectionString = _BD.Database.GetDbConnection().ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SM_MUESTRA_APLICACIONES_PERFIL_EMPRESA", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Cod_Perfil", "0751");
                    cmd.Parameters.AddWithValue("@Cod_Empresa", "01");

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AplicacionCLS aplicacion = new AplicacionCLS
                            {
                                Cod_aplicacion = reader["Cod_Aplicacion"].ToString(),
                                Des_aplicacion = reader["Des_Aplicacion"].ToString(),
                                Des_aplicacion_Eng = reader["Des_Aplicacion_Eng"].ToString()
                            };
                            aplicaciones.Add(aplicacion);
                        }
                    }
                }
            }

            return aplicaciones;
        }


    }
}
