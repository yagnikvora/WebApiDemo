﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Data;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly CountryRepository _countryRepository;
        public CountryController(CountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }


        [HttpGet]
        public IActionResult GetAllCountries()
        {
            var countryList = _countryRepository.GetAllCountries();
            return Ok(countryList);
        }
    }
}
