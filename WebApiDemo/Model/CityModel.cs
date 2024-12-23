using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApiDemo.Model
{
    public class CityModel
    {
        public int CityID { get; set; }
        public int StateID { get; set; }
        public int CountryID { get; set; }
        public string CityName { get; set; }
        public string StateName { get; set; }
        public string CountryName { get; set; }
        public string CityCode { get; set; }
    }
    public class CityInsertUpdateModel
    {
        public int CityID { get; set; }
        public string CityName { get; set; }
        public int StateID { get; set; }
        public int CountryID { get; set; }
        public string CityCode { get; set; }
    }
}
