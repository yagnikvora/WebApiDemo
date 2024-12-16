using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Data;
using WebApiDemo.Model;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TalukaController : ControllerBase
    {
        private readonly TalukaRepository _talukaRepository;

        public TalukaController(TalukaRepository talukaRepository)
        {
            _talukaRepository = talukaRepository;
        }


        [HttpGet]
        public IActionResult GetAllTalukas()
        {
            var talukaList = _talukaRepository.GetAllTalukas();
            return Ok(talukaList);
        }

        
        [HttpGet("{TalukaID}")]
        public IActionResult GetAllTalukaByID(int TalukaID)
        {
            var talukaList = _talukaRepository.GetTalukaByID(TalukaID);
            return Ok(talukaList);
        } 
        [HttpGet("{DistrictID}")]
        public IActionResult TalukasDropDownByDistrictID(int DistrictID)
        {
            var talukaList = _talukaRepository.TalukasDropDownByDistrictID(DistrictID);
            return Ok(talukaList);
        }


        [HttpDelete("{TalukaID}")]
        public IActionResult DeleteTalukaByID(int TalukaID)
        {
            var isDeleted = _talukaRepository.DeleteTalukaByID(TalukaID);
            if (isDeleted)
                return Ok(new { Message = "Taluka deleted successfully." });
            else
                return NotFound(new { Message = "Taluka not found or could not be deleted." });
        }

        [HttpPost]
        public IActionResult InsertTaluka([FromBody][Bind()] TalukaInsertUpdate taluka)
        {
            if (taluka == null)
                return BadRequest(new { Message = "Taluka data is required." });

            var isInserted = _talukaRepository.InsertTaluka(taluka);
            if (isInserted)
                return Ok(new { Message = "Taluka inserted successfully." });
            else
                return StatusCode(500, new { Message = "Taluka could not be inserted." });
        }

        [HttpPut("{TalukaID}")]
        public IActionResult UpdateTaluka(int TalukaID, [FromBody] TalukaInsertUpdate taluka)
        {
            if (taluka == null || TalukaID != taluka.TalukaID)
                return BadRequest(new { Message = "Invalid taluka data or ID mismatch." });

            var isUpdated = _talukaRepository.UpdateTaluka(taluka);
            if (isUpdated)
                return Ok(new { Message = "Taluka updated successfully." });
            else
                return NotFound(new { Message = "Taluka not found or could not be updated." });
        }

    
    }
}
