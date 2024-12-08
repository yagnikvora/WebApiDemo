using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Data;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
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
    }
}
