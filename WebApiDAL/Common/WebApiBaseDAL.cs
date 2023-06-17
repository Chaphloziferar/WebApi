using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiDAL.Common
{
    public class WebApiBaseDAL
    {
        public string ConnectionString { get; set; }

        public WebApiBaseDAL(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(this.ConnectionString);
        }
    }
}
