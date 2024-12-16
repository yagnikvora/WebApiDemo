using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Data;
using WebApiDemo.Model;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private readonly DistrictRepository _districtRepository;

        public DistrictController(DistrictRepository districtRepository)
        {
            _districtRepository = districtRepository;
        }


        [HttpGet]
        public IActionResult GetAllDistricts()
        {
            var districtList = _districtRepository.GetAllDistricts();
            return Ok(districtList);
        }


        [HttpGet("{DistrictID}")]
        public IActionResult GetAllDistrictByID(int DistrictID)
        {
            var districtList = _districtRepository.GetDistrictByID(DistrictID);
            return Ok(districtList);
        }
        
        [HttpGet("{StateID}")]
        public IActionResult DistrictsDropDownByStateID(int StateID)
        {
            var districtList = _districtRepository.DistrictsDropDownByStateID(StateID);
            return Ok(districtList);
        }


        [HttpDelete("{DistrictID}")]
        public IActionResult DeleteDistrictByID(int DistrictID)
        {
            var isDeleted = _districtRepository.DeleteDistrictByID(DistrictID);
            if (isDeleted)
                return Ok(new { Message = "District deleted successfully." });
            else
                return NotFound(new { Message = "District not found or could not be deleted." });
        }

        [HttpPost]
        public IActionResult InsertDistrict([FromBody] DistrictInsertUpdate district)
        {
            if (district == null)
                return BadRequest(new { Message = "District data is required." });

            var isInserted = _districtRepository.InsertDistrict(district);
            if (isInserted)
                return Ok(new { Message = "District inserted successfully." });
            else
                return StatusCode(500, new { Message = "District could not be inserted." });
        }

        [HttpPut("{DistrictID}")]
        public IActionResult UpdateDistrict(int DistrictID, [FromBody] DistrictInsertUpdate district)
        {
            if (district == null || DistrictID != district.DistrictID)
                return BadRequest(new { Message = "Invalid district data or ID mismatch." });

            var isUpdated = _districtRepository.UpdateDistrict(district);
            if (isUpdated)
                return Ok(new { Message = "District updated successfully." });
            else
                return NotFound(new { Message = "District not found or could not be updated." });
        }

    }
}
