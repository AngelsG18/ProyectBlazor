using Microsoft.Data.SqlClient;
using System.Data.SqlClient;

namespace ProyectBlazor.API.Controllers
{
    public class Cod_Metodo
    {
        public string strSQL { get; set; }
        public Cod_Metodo() { }

        public string DevuelveCampo(string strSQL, SqlParameter[] metros)
        {
            string sResult = "";
            try
            {
                return sResult;
            }catch(SqlException px)
            {
                
            }
            catch(Exception ex)
            {

            }
            return sResult;
        }



    }
}
