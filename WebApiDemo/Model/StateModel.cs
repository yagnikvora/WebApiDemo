namespace WebApiDemo.Model
{
    public class StateModel
    {
        public int StateID { get; set; }
        public string StateName { get; set; }
        public int CountryID { get; set; }
        public string CountryName { get; set; }
    }

    public class StateInsertUpdate
    {
        public int StateID { get; set; }
        public string StateName { get; set; }
        public int CountryID { get; set; }
    }

    public class StatesDropDownByCountryIDModel
    {
        public int StateID { get; set; }
        public string StateName { get; set; }
    }
}
