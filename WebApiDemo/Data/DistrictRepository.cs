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
            var districts = new List<DistrictModel>();
            string connectionString = _configuration.GetConnectionString("myConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_LOC_District_SelectAll";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                districts.Add(new DistrictModel
                {
                    DistrictID = Convert.ToInt32(reader["DistrictID"]),
                    DistrictName = reader["DistrictName"].ToString(),
                    StateID = Convert.ToInt32(reader["StateID"]),
                    StateName = reader["StateName"].ToString(),
                    CountryID = Convert.ToInt32(reader["CountryID"]),
                    CountryName = reader["CountryName"].ToString(),

                });
            }
            connection.Close();
            return districts;
        }
        #endregion

        #region GetDistrictByID
        public List<DistrictModel> GetDistrictByID(int DistrictID)
        {
            var district = new List<DistrictModel>();
            string connectionString = _configuration.GetConnectionString("myConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_LOC_District_SelectById";
            command.Parameters.AddWithValue("DistrictID", DistrictID);
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
                });
            }
            connection.Close();
            return district;
        }
        #endregion

        #region DeleteByID
        public bool DeleteDistrictByID(int DistrictID)
        {
            bool isDeleted = false;
            string connectionString = _configuration.GetConnectionString("myConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_LOC_District_DeleteById";
            command.Parameters.AddWithValue("DistrictID", DistrictID);
            int rowsAffected = command.ExecuteNonQuery();
            isDeleted = rowsAffected > 0;
            return isDeleted;
        }
        #endregion

        #region InsertDistrict
        public bool InsertDistrict(DistrictInsertUpdate district)
        {
            bool isInserted = false;
            string connectionString = _configuration.GetConnectionString("myConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_LOC_District_Insert";
            command.Parameters.AddWithValue("DistrictName", district.DistrictName);
            command.Parameters.AddWithValue("StateID", district.StateID);
            int rowsAffected = command.ExecuteNonQuery();
            isInserted = rowsAffected > 0;
            return isInserted;
        }

        #endregion

        #region UpdateDistrict
        public bool UpdateDistrict(DistrictInsertUpdate district)
        {
            bool isUpdate = false;
            string connectionString = _configuration.GetConnectionString("myConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_LOC_District_UpdateById";
            command.Parameters.AddWithValue("DistrictID", district.DistrictID);
            command.Parameters.AddWithValue("DistrictName", district.DistrictName);
            command.Parameters.AddWithValue("StateID", district.StateID);
            int rowsAffected = command.ExecuteNonQuery();
            isUpdate = rowsAffected > 0;
            return isUpdate;
        }
        #endregion

        #region DistrictsDropDownByStateID
        public List<DistrictsDropDownByStateIDModel> DistrictsDropDownByStateID(int StateID)
        {
            var districts = new List<DistrictsDropDownByStateIDModel>();
            string connectionString = _configuration.GetConnectionString("myConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_LOC_District_DropDownByStateID";
            command.Parameters.AddWithValue("StateID", StateID);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                districts.Add(new DistrictsDropDownByStateIDModel
                {
                    DistrictID = Convert.ToInt32(reader["DistrictID"]),
                    DistrictName = reader["DistrictName"].ToString()
                });
            }
            connection.Close();
            return districts;
        }
        #endregion
    }
}
