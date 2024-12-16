using Microsoft.Data.SqlClient;
using System.Data;
using WebApiDemo.Model;

namespace WebApiDemo.Data
{
    public class StateRepository
    {
        private IConfiguration _configuration;
        public StateRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #region GetAllStates
        public List<StateModel> GetAllStates()
        {
            var states = new List<StateModel>();
            string connectionString = _configuration.GetConnectionString("myConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_LOC_State_SelectAll";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                states.Add(new StateModel
                {
                    StateID = Convert.ToInt32(reader["StateID"]),
                    StateName = reader["StateName"].ToString(),
                    CountryID = Convert.ToInt32(reader["CountryID"]),
                    CountryName = reader["CountryName"].ToString(),

                });
            }
            connection.Close();
            return states;
        }
        #endregion

        #region GetStateByID
        public List<StateModel> GetStateByID(int StateID)
        {
            var state = new List<StateModel>();
            string connectionString = _configuration.GetConnectionString("myConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_LOC_State_SelectById";
            command.Parameters.AddWithValue("StateID", StateID);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                state.Add(new StateModel
                {
                    StateID = Convert.ToInt32(reader["StateID"]),
                    StateName = reader["StateName"].ToString(),
                    CountryID = Convert.ToInt32(reader["CountryID"]),
                    CountryName = reader["CountryName"].ToString(),
                });
            }
            connection.Close();
            return state;
        }
        #endregion

        #region DeleteByID
        public bool DeleteStateByID(int StateID)
        {
            bool isDeleted = false;
            string connectionString = _configuration.GetConnectionString("myConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_LOC_State_DeleteById";
            command.Parameters.AddWithValue("StateID", StateID);
            int rowsAffected = command.ExecuteNonQuery();
            isDeleted = rowsAffected > 0;
            return isDeleted;
        }
        #endregion

        #region InsertState
        public bool InsertState(StateInsertUpdate state)
        {
            bool isInserted = false;
            string connectionString = _configuration.GetConnectionString("myConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_LOC_State_Insert";
            command.Parameters.AddWithValue("StateName", state.StateName);
            command.Parameters.AddWithValue("CountryID", state.CountryID);
            int rowsAffected = command.ExecuteNonQuery();
            isInserted = rowsAffected > 0;
            return isInserted;
        }

        #endregion

        #region UpdateState
        public bool UpdateState(StateInsertUpdate state)
        {
            bool isUpdate = false;
            string connectionString = _configuration.GetConnectionString("myConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_LOC_State_UpdateById";
            command.Parameters.AddWithValue("StateID", state.StateID);
            command.Parameters.AddWithValue("StateName", state.StateName);
            command.Parameters.AddWithValue("CountryID", state.CountryID);
            int rowsAffected = command.ExecuteNonQuery();
            isUpdate = rowsAffected > 0;
            return isUpdate;
        }
        #endregion

        #region StatesDropDownByCountryID
        public List<StatesDropDownByCountryIDModel> StatesDropDownByCountryID(int CountryID)
        {
            var states = new List<StatesDropDownByCountryIDModel>();
            string connectionString = _configuration.GetConnectionString("myConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_LOC_State_DropDownByCountryID";
            command.Parameters.AddWithValue("CountryID", CountryID);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                states.Add(new StatesDropDownByCountryIDModel
                {
                    StateID = Convert.ToInt32(reader["StateID"]),
                    StateName = reader["StateName"].ToString()
                });
            }
            connection.Close();
            return states;
        }
        #endregion
    }
}
