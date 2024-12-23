using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using WebApiDemo.Model;

namespace WebApiDemo.Data
{
    public class CityRepository
    {
        private IConfiguration _configuration;
        public CityRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #region GetAllCities
        public List<CityModel> GetAllCitis(int StateID)
        {
            var cities = new List<CityModel>();
            string connectionString = _configuration.GetConnectionString("myConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_LOC_City_SelectAll_Condition";
            command.Parameters.AddWithValue("StateID", StateID);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                cities.Add(new CityModel
                {
                    CityID = Convert.ToInt32(reader["CityID"]),
                    CityName = reader["CityName"].ToString(),
                    StateID = Convert.ToInt32(reader["StateID"]),
                    StateName = reader["StateName"].ToString(),
                    CountryID = Convert.ToInt32(reader["CountryID"]),
                    CountryName = reader["CountryName"].ToString(),
                    CityCode = reader["CityCode"].ToString()
                });
            }
            connection.Close();
            return cities;
        }
        #endregion

        #region GetCityByID
        public List<CityModel> GetCityByID(int CityID)
        {
            var city = new List<CityModel>();
            string connectionString = _configuration.GetConnectionString("myConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_LOC_City_SelectById";
            command.Parameters.AddWithValue("CityID", CityID);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                city.Add(new CityModel
                {
                    CityID = Convert.ToInt32(reader["CityID"]),
                    CityName = reader["CityName"].ToString(),
                    StateID = Convert.ToInt32(reader["StateID"]),
                    StateName = reader["StateName"].ToString(),
                    CountryID = Convert.ToInt32(reader["CountryID"]),
                    CountryName = reader["CountryName"].ToString(),
                    CityCode = reader["CityCode"].ToString()
                });
            }
            connection.Close();
            return city;
        }
        #endregion

        #region DeleteByID
        public bool DeleteCityByID(int CityID)
        {
            bool isDeleted = false;
            string connectionString = _configuration.GetConnectionString("myConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_LOC_City_DeleteById";
            command.Parameters.AddWithValue("CityID", CityID);
            int rowsAffected = command.ExecuteNonQuery();
            isDeleted = rowsAffected > 0;
            return isDeleted;
        }
        #endregion

        #region InsertCity
        public bool InsertCity(CityInsertUpdateModel city)
        {
            bool isInserted = false;
            string connectionString = _configuration.GetConnectionString("myConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_LOC_City_Insert";
            command.Parameters.AddWithValue("CityName", city.CityName);
            command.Parameters.AddWithValue("CityCode", city.CityCode);
            command.Parameters.AddWithValue("StateID", city.StateID);
            command.Parameters.AddWithValue("CountryID", city.CountryID);
            int rowsAffected = command.ExecuteNonQuery();
            isInserted = rowsAffected > 0;
            return isInserted;
        }

        #endregion

        #region UpdateCity
        public bool UpdateCity(CityInsertUpdateModel city)
        {
            bool isUpdate = false;
            string connectionString = _configuration.GetConnectionString("myConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_LOC_City_UpdateById";
            command.Parameters.AddWithValue("CityID", city.CityID);
            command.Parameters.AddWithValue("CityName", city.CityName);
            command.Parameters.AddWithValue("CityCode", city.CityCode);
            command.Parameters.AddWithValue("StateID", city.StateID);
            command.Parameters.AddWithValue("CountryID", city.CountryID);
            int rowsAffected = command.ExecuteNonQuery();
            isUpdate = rowsAffected > 0;
            return isUpdate;
        }
        #endregion
    }
}
