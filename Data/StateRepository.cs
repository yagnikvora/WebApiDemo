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
                    UserID = Convert.ToInt32(reader["UserID"]),
                    Created = Convert.ToDateTime(reader["CreatedAt"]),
                    Modified = Convert.ToDateTime(reader["ModifiedAt"])
                });
            }
            connection.Close();
            return states;
        }
        #endregion
    }
}
