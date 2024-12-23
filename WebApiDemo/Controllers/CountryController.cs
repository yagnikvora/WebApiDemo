using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Data;
using WebApiDemo.Model;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]/[action]")]
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
        [HttpGet]
        public IActionResult CountryDropDown()
        {
            var countryList = _countryRepository.CountryDropDown();
            return Ok(countryList);
        }


        [HttpGet("{CountryID}")]
        public IActionResult GetAllCountryByID(int CountryID)
        {
            var countryList = _countryRepository.GetCountryByID(CountryID);
            return Ok(countryList);
        }


        [HttpDelete("{CountryID}")]
        public IActionResult DeleteCountryByID(int CountryID)
        {
            var isDeleted = _countryRepository.DeleteCountryByID(CountryID);
            if (isDeleted)
                return Ok(new { Message = "Country deleted successfully." });
            else
                return NotFound(new { Message = "Country not found or could not be deleted." });
        }

        [HttpPost]
        public IActionResult InsertCountry([FromBody] CountryModel country)
        {
            if (country == null)
                return BadRequest(new { Message = "Country data is required." });

            var isInserted = _countryRepository.InsertCountry(country);
            if (isInserted)
                return Ok(new { Message = "Country inserted successfully." });
            else
                return StatusCode(500, new { Message = "Country could not be inserted." });
        }

        [HttpPut("{CountryID}")]
        public IActionResult UpdateCountry(int CountryID, [FromBody] CountryModel country)
        {
            if (country == null || CountryID != country.CountryID)
                return BadRequest(new { Message = "Invalid country data or ID mismatch." });

            var isUpdated = _countryRepository.UpdateCountry(country);
            if (isUpdated)
                return Ok(new { Message = "Country updated successfully." });
            else
                return NotFound(new { Message = "Country not found or could not be updated." });
        }
    }
}
