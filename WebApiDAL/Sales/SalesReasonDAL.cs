using Entities.Sales;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WebApiDAL.Common;

namespace WebApiDAL.Sales
{
    public class SalesReasonDAL : WebApiBaseDAL
    {
        public SalesReasonDAL(string connectionString) : base(connectionString)
        {
        }

        public List<SalesReason> GetAllSalesReasons()
        {
            SqlConnection connection = GetConnection();
            connection.Open();
            SqlCommand command = new SqlCommand()
            {
                Connection = connection,
                CommandText = "GetAllSalesReason",
                CommandType = CommandType.StoredProcedure
            };

            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dt);

            var query = dt.AsEnumerable().Select(item => new SalesReason
            {
                SalesReasonId = Convert.ToInt32(item["SalesReasonID"]),
                Name = Convert.ToString(item["Name"]),
                ReasonType = Convert.ToString(item["ReasonType"]),
                ModifiedDate = Convert.ToDateTime(item["ModifiedDate"])
            });

            return query.ToList();
        }

        public async Task<SalesReason> GetSalesReasonById(int SalesReasonId)
        {
            SqlConnection connection = GetConnection();
            connection.Open();
            SqlCommand command = new SqlCommand()
            {
                Connection = connection,
                CommandText = "GetSalesReasonById",
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@pSalesReasonId", SalesReasonId);

            SqlDataReader reader = await command.ExecuteReaderAsync();
            SalesReason salesReason = new SalesReason();

            if (reader.Read())
            {
                salesReason.SalesReasonId = Convert.ToInt32(reader["SalesReasonID"]);
                salesReason.Name = Convert.ToString(reader["Name"]);
                salesReason.ReasonType = Convert.ToString(reader["ReasonType"]);
                salesReason.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
            }

            return salesReason;
        }

        public async Task<int> CreateSalesReason(string name, string reasonType, DateTime modifiedDate)
        {
            SqlConnection connection = GetConnection();
            connection.Open();
            SqlCommand command = new SqlCommand()
            {
                Connection = connection,
                CommandText = "CreateSalesReason",
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@pName", name);
            command.Parameters.AddWithValue("@pReasonType", reasonType);
            command.Parameters.AddWithValue("@pModifiedDate", modifiedDate);

            return await command.ExecuteNonQueryAsync();
        }

        public async Task<int> UpdateSalesReason(int salesReasonId, string name, string reasonType, DateTime modifiedDate)
        {
            SqlConnection connection = GetConnection();
            connection.Open();
            SqlCommand command = new SqlCommand()
            {
                Connection = connection,
                CommandText = "UpdateSalesReason",
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@pSalesReasonId", salesReasonId);
            command.Parameters.AddWithValue("@pName", name);
            command.Parameters.AddWithValue("@pReasonType", reasonType);
            command.Parameters.AddWithValue("@pModifiedDate", modifiedDate);

            return await command.ExecuteNonQueryAsync();
        }

        public async Task<int> DeleteSalesReason(int salesReasonId)
        {
            SqlConnection connection = GetConnection();
            connection.Open();
            SqlCommand command = new SqlCommand()
            {
                Connection = connection,
                CommandText = "DeleteSalesReason",
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@pSalesReasonId", salesReasonId);

            return await command.ExecuteNonQueryAsync();
        }
    }
}
