using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Data;
using WebApiDemo.Model;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly StateRepository _stateRepository;

        public StateController(StateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }


        [HttpGet]
        public IActionResult GetAllStates()
        {
            var stateList = _stateRepository.GetAllStates();
            return Ok(stateList);
        }


        [HttpGet("{StateID}")]
        public IActionResult GetAllStateByID(int StateID)
        {
            var stateList = _stateRepository.GetStateByID(StateID);
            return Ok(stateList);
        }
        [HttpGet("{CountryID}")]
        public IActionResult StatesDropDownByCountryID(int CountryID)
        {
            var stateList = _stateRepository.StatesDropDownByCountryID(CountryID);
            return Ok(stateList);
        }


        [HttpDelete("{StateID}")]
        public IActionResult DeleteStateByID(int StateID)
        {
            var isDeleted = _stateRepository.DeleteStateByID(StateID);
            if (isDeleted)
                return Ok(new { Message = "State deleted successfully." });
            else
                return NotFound(new { Message = "State not found or could not be deleted." });
        }

        [HttpPost]
        public IActionResult InsertState([FromBody] StateInsertUpdateModel state)
        {
            if (state == null)
                return BadRequest(new { Message = "State data is required." });

            var isInserted = _stateRepository.InsertState(state);
            if (isInserted)
                return Ok(new { Message = "State inserted successfully." });
            else
                return StatusCode(500, new { Message = "State could not be inserted." });
        }

        [HttpPut("{StateID}")]
        public IActionResult UpdateState(int StateID, [FromBody] StateInsertUpdateModel state)
        {
            if (state == null || StateID != state.StateID)
                return BadRequest(new { Message = "Invalid state data or ID mismatch." });

            var isUpdated = _stateRepository.UpdateState(state);
            if (isUpdated)
                return Ok(new { Message = "State updated successfully." });
            else
                return NotFound(new { Message = "State not found or could not be updated." });
        }

    }
}
