using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProyectBlazor.API.Models;
using System.Data;

namespace ProyectBlazor.API.Controllers
{
    public class Cod_Metodos
    {
        public string strSQL;
        private readonly SeguridadContext _BD;


        public Cod_Metodos(SeguridadContext bd)
        {
            _BD = bd;
        }

        public string DevuelveCampo(string strSQL, SqlParameter[] parametros)
        {
            string sResult = "";
            try
            {
                using (var connection = _BD.Database.GetDbConnection())
                {
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = strSQL;
                        command.Parameters.AddRange(parametros);

                        var result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            sResult = result.ToString();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al ejecutar la consulta SQL", e);
            }

            return sResult;
        }

        //public List<t> CargaDataList()
        //{

        //}


    }
}
