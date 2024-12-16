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

        #region GetAllCountrys
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

                });
            }
            connection.Close();
            return countries;
        }
        #endregion

        #region GetCountryByID
        public List<CountryModel> GetCountryByID(int CountryID)
        {
            var country = new List<CountryModel>();
            string connectionString = _configuration.GetConnectionString("myConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_LOC_Country_SelectById";
            command.Parameters.AddWithValue("CountryID", CountryID);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                country.Add(new CountryModel
                {
                    CountryID = Convert.ToInt32(reader["CountryID"]),
                    CountryName = reader["CountryName"].ToString(),
                });
            }
            connection.Close();
            return country;
        }
        #endregion

        #region DeleteByID
        public bool DeleteCountryByID(int CountryID)
        {
            bool isDeleted = false;
            string connectionString = _configuration.GetConnectionString("myConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_LOC_Country_DeleteById";
            command.Parameters.AddWithValue("CountryID", CountryID);
            int rowsAffected = command.ExecuteNonQuery();
            isDeleted = rowsAffected > 0;
            return isDeleted;
        }
        #endregion

        #region InsertCountry
        public bool InsertCountry(CountryModel country)
        {
            bool isInserted = false;
            string connectionString = _configuration.GetConnectionString("myConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_LOC_Country_Insert";
            command.Parameters.AddWithValue("CountryName", country.CountryName);
            int rowsAffected = command.ExecuteNonQuery();
            isInserted = rowsAffected > 0;
            return isInserted;
        }

        #endregion

        #region UpdateCountry
        public bool UpdateCountry(CountryModel country)
        {
            bool isUpdate = false;
            string connectionString = _configuration.GetConnectionString("myConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_LOC_Country_UpdateById";
            command.Parameters.AddWithValue("CountryID", country.CountryID);
            command.Parameters.AddWithValue("CountryName", country.CountryName);
            int rowsAffected = command.ExecuteNonQuery();
            isUpdate = rowsAffected > 0;
            return isUpdate;
        }
        #endregion

    }
}
