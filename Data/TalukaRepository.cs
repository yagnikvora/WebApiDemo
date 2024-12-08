using Microsoft.Data.SqlClient;
using System.Data;
using WebApiDemo.Controllers;
using WebApiDemo.Model;

namespace WebApiDemo.Data
{
    public class TalukaRepository
    {
        private IConfiguration _configuration;
        public TalukaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #region GetAllTalukas
        public List<TalukaModel> GetAllTalukas()
        {
            var talukas = new List<TalukaModel>();
            string connectionString = _configuration.GetConnectionString("myConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_LOC_Taluka_SelectAll";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                talukas.Add(new TalukaModel
                {
                    TalukaID = Convert.ToInt32(reader["TalukaID"]),
                    TalukaName = reader["TalukaName"].ToString(),
                    DistrictID = Convert.ToInt32(reader["DistrictID"]),
                    DistrictName = reader["DistrictName"].ToString(),
                    StateID = Convert.ToInt32(reader["StateID"]),
                    StateName = reader["StateName"].ToString(),
                    CountryID = Convert.ToInt32(reader["CountryID"]),
                    CountryName = reader["CountryName"].ToString(),
                    UserID = Convert.ToInt32(reader["UserID"]),
                    Created = Convert.ToDateTime(reader["CreatedAt"]),
                    Modified = Convert.ToDateTime(reader["ModifiedAt"])
                });
            }
            connection.Close();
            return talukas;
        }
        #endregion
    }
}
