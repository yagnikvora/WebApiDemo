namespace WebApiDemo.Model
{
    public class DistrictModel
    {
        public int DistrictID { get; set; }
        public string DistrictName { get; set; }
        public int StateID { get; set; }
        public string StateName { get; set; }
        public int CountryID { get; set; }
        public string CountryName { get; set; }
        public int UserID { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
