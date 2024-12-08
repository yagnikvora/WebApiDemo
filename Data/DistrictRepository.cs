using Microsoft.Data.SqlClient;
using System.Data;
using WebApiDemo.Model;

namespace WebApiDemo.Data
{
    public class DistrictRepository
    {
        private IConfiguration _configuration;
        public DistrictRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #region GetAllDistricts
        public List<DistrictModel> GetAllDistricts()
        {
            var district = new List<DistrictModel>();
            string connectionString = _configuration.GetConnectionString("myConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_LOC_District_SelectAll";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                district.Add(new DistrictModel
                {
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
            return district;
        }
        #endregion
    }
}
