﻿namespace WebApiDemo.Model
{
}
public class StateModel
{
    public int StateID { get; set; }
    public int CountryID { get; set; }
    public string StateName { get; set; }
    public string StateCode { get; set; }
    public string CountryName { get; set; }
    public int CityCount { get; set; }
}
public class StateInsertUpdateModel
{
    public int StateID { get; set; }
    public string StateName { get; set; }
    public string StateCode { get; set; }
    public int CountryID { get; set; }

    public class StateDropDownModel
    {
        public int StateID { get; set; }
        public string StateName { get; set; }
    }
}
