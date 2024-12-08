using Microsoft.Data.SqlClient;
using System.Data;
using WebApiDemo.Model;

namespace WebApiDemo.Data
{
    public class CountryRepository
    {
        private IConfiguration _configuration;
        public CountryRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #region GetAllCountries
        public List<CountryModel> GetAllCountries()
        {
            var countries = new List<CountryModel>();
            string connectionString = _configuration.GetConnectionString("myConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_LOC_Country_SelectAll";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                countries.Add(new CountryModel
                {
                    CountryID = Convert.ToInt32(reader["CountryID"]),
                    CountryName = reader["CountryName"].ToString(),
                    UserID = Convert.ToInt32(reader["UserID"]),
                    Created = Convert.ToDateTime(reader["CreatedAt"]),
                    Modified = Convert.ToDateTime(reader["ModifiedAt"])
                });
            }
            connection.Close();
            return countries;
        }
        #endregion
    }
}
