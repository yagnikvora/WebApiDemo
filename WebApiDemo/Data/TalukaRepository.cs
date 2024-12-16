using Microsoft.AspNetCore.Mvc;
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
                   
                });
            }
            connection.Close();
            return talukas;
        }
        #endregion

        #region GetTalukaByID
        public List<TalukaModel> GetTalukaByID(int TalukaID)
        {
            var taluka = new List<TalukaModel>();
            string connectionString = _configuration.GetConnectionString("myConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_LOC_Taluka_SelectById";
            command.Parameters.AddWithValue("TalukaID", TalukaID);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                taluka.Add(new TalukaModel
                {
                    TalukaID = Convert.ToInt32(reader["TalukaID"]),
                    TalukaName = reader["TalukaName"].ToString(),
                    DistrictID = Convert.ToInt32(reader["DistrictID"]),
                    DistrictName = reader["DistrictName"].ToString(),
                    StateID = Convert.ToInt32(reader["StateID"]),
                    StateName = reader["StateName"].ToString(),
                    CountryID = Convert.ToInt32(reader["CountryID"]),
                    CountryName = reader["CountryName"].ToString(),
                });
            }
            connection.Close();
            return taluka;
        }
        #endregion

        #region DeleteByID
        public bool DeleteTalukaByID(int TalukaID)
        {
            bool isDeleted = false;
            string connectionString = _configuration.GetConnectionString("myConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_LOC_Taluka_DeleteById";
            command.Parameters.AddWithValue("TalukaID", TalukaID);
            int rowsAffected = command.ExecuteNonQuery();
            isDeleted = rowsAffected > 0;
            return isDeleted;
        }
        #endregion

        #region InsertTaluka
        public bool InsertTaluka(TalukaInsertUpdate taluka)
        {
            bool isInserted = false;
            string connectionString = _configuration.GetConnectionString("myConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_LOC_Taluka_Insert";
            command.Parameters.AddWithValue("TalukaName", taluka.TalukaName);
            command.Parameters.AddWithValue("DistrictID", taluka.DistrictID);
            int rowsAffected = command.ExecuteNonQuery();
            isInserted = rowsAffected > 0;
            return isInserted;
        }

        #endregion

        #region UpdateTaluka
        public bool UpdateTaluka(TalukaInsertUpdate taluka)
        {
            bool isUpdate = false;
            string connectionString = _configuration.GetConnectionString("myConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_LOC_Taluka_UpdateById";
            command.Parameters.AddWithValue("TalukaID", taluka.TalukaID);
            command.Parameters.AddWithValue("TalukaName", taluka.TalukaName);
            command.Parameters.AddWithValue("TalukaID", taluka.TalukaID);
            int rowsAffected = command.ExecuteNonQuery();
            isUpdate = rowsAffected > 0;
            return isUpdate;
        }
        #endregion

        #region TalukasDropDownByDistrictID
        public List<TalukasDropDownByDistrictIDModel> TalukasDropDownByDistrictID(int DistrictID)
        {
            var talukas = new List<TalukasDropDownByDistrictIDModel>();
            string connectionString = _configuration.GetConnectionString("myConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_LOC_Taluka_DropDownByDistrictID";
            command.Parameters.AddWithValue("DistrictID", DistrictID);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                talukas.Add(new TalukasDropDownByDistrictIDModel
                {
                    TalukaID = Convert.ToInt32(reader["TalukaID"]),
                    TalukaName = reader["TalukaName"].ToString()
                });
            }
            connection.Close();
            return talukas;
        }
        #endregion
    }
}
