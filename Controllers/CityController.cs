using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Data;
using System.Text.Json.Serialization;
using WebApiDemo.Data;
using WebApiDemo.Model;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly CityRepository _cityRepository;

        public CityController(CityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }


        [HttpGet]
        public IActionResult GetAllCitis() 
        {
            var cityList = _cityRepository.GetAllCitis();
            return Ok(cityList);
        }


        [HttpGet("{CityID}")]
        public IActionResult GetAllCityByID(int CityID)
        {
            var cityList = _cityRepository.GetCityByID(CityID);
            return Ok(cityList);
        }


        [HttpDelete("{CityID}")]
        public IActionResult DeleteCityByID(int CityID)
        {
            var isDeleted = _cityRepository.DeleteCityByID(CityID);
            if (isDeleted)
                return Ok(new { Message = "City deleted successfully." });
            else
                return NotFound(new { Message = "City not found or could not be deleted." });
        }

        [HttpPost]
        public IActionResult InsertCity([FromBody][Bind()] CityInsertUpdate city)
        {
            if (city == null)
                return BadRequest(new { Message = "City data is required." });

            var isInserted = _cityRepository.InsertCity(city);
            if (isInserted)
                return Ok(new { Message = "City inserted successfully." });
            else
                return StatusCode(500, new { Message = "City could not be inserted." });
        }

        [HttpPut("{CityID}")]
        public IActionResult UpdateCity(int CityID, [FromBody] CityInsertUpdate city)
        {
            if (city == null || CityID != city.CityID)
                return BadRequest(new { Message = "Invalid city data or ID mismatch." });

            var isUpdated = _cityRepository.UpdateCity(city);
            if (isUpdated)
                return Ok(new { Message = "City updated successfully." });
            else
                return NotFound(new { Message = "City not found or could not be updated." });
        }

    }
}
