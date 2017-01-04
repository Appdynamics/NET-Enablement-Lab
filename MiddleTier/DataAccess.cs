using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MiddleTier
{
    class DataAccess
    {
        private string cs;

        public DataAccess()
        {
            cs = System.Configuration.ConfigurationManager.AppSettings["database"];
        }

        public object ExecuteQuery(string sp, IDictionary<string, object> parameters)
        {
            SqlConnection cn = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(sp, cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            
            if(parameters != null)
            {
                foreach(KeyValuePair<string, object> p in parameters)
                {
                    cmd.Parameters.AddWithValue(p.Key, p.Value);
                }
            }

            try
            {
                cn.Open();
                return cmd.ExecuteScalar();
            }
            finally { cn.Close(); }
        }

        public async Task<object> ExecuteQueryAsync(string sp, IDictionary<string, object> parameters)
        {
            SqlConnection cn = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(sp, cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            if (parameters != null)
            {
                foreach (KeyValuePair<string, object> p in parameters)
                {
                    cmd.Parameters.AddWithValue(p.Key, p.Value);
                }
            }

            try
            {
                await cn.OpenAsync();
                return await cmd.ExecuteScalarAsync();
            }
            finally { cn.Close(); }
        }
    }
}
