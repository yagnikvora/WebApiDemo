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
    }

    public class DistrictInsertUpdate
    {
        public int DistrictID { get; set; }
        public string DistrictName { get; set; }
        public int StateID { get; set; }
    }

    public class DistrictsDropDownByStateIDModel
    {
        public int DistrictID { get; set; } 
        public string DistrictName { get; set; }
    }
}
