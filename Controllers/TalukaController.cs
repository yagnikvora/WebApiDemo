using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Data;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
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
    }
}
